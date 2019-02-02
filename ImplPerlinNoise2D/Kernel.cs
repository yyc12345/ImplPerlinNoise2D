using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Troschuetz.Random.Generators;
using Troschuetz.Random.Distributions.Continuous;
using Troschuetz.Random;

namespace ImplPerlinNoise2D {

    public static class Kernel {

        public static int MAP_SIZE = 512;

        public static Bitmap Generate(List<ImplPerlinNoise2D.Utility.Storage.NoiseData> data, bool useColorful) {
            var img = new ImplPerlinNoise2D.Utility.Image.BitmapOperator(512, 512);

            var count = data.Count;
            var perlinList = new List<PerlinNoise>();
            double max = 0;
            for (int i = 0; i < count; i++) {
                perlinList.Add(new PerlinNoise(data[i].Seed, data[i].Frequency, data[i].Interpolation));
                max += Math.Pow(data[i].Amplitude, data[i].Redistribution) * data[i].AttachPercentage;
            }

            //todo: find the proper relation of max. maybe is 1*sqrt(2) ?
            //max = 1.5;
            double calc = 0;
            double cache = 0;
            for (int y = 0; y < MAP_SIZE; y++) {
                for (int x = 0; x < MAP_SIZE; x++) {
                    calc = 0;
                    cache = 0;
                    for (int i = 0; i < count; i++) {
                        perlinList[i].GetNoise(x, y, ref cache);
                        calc += (cache < 0 ? -1 : 1) * Math.Pow(Math.Abs(cache * data[i].Amplitude), data[i].Redistribution) * data[i].AttachPercentage;
                    }
                    img.SetPixel(x, y, JudgeValue(calc, max, useColorful));
                }
            }

            return img.Close();
        }

        static ImplPerlinNoise2D.Utility.Image.ColorRGB JudgeValue(double value, double max, bool isColorful) {
            value += max;
            if (value < 0) return (isColorful ? new Utility.Image.ColorRGB(255, 255, 255) : new Utility.Image.ColorRGB(255, 0, 0));
            if (value > 2 * max) return (isColorful ? new Utility.Image.ColorRGB(255, 255, 255) : new Utility.Image.ColorRGB(255, 0, 0));

            var percent = value / (2 * max);
            if (isColorful) return HSBPureColorToRGB(300 * (1 - percent));
            return new Utility.Image.ColorRGB(255 * percent, 255 * percent, 255 * percent);
        }

        //rotate from 0 -> 360. Red -> Green -> Blue -> Red
        static ImplPerlinNoise2D.Utility.Image.ColorRGB HSBPureColorToRGB(double rotate) {
            double valuePerFragement = (double)360 / (double)6;
            int fragement = (int)(rotate / valuePerFragement);
            double remainPercent = (rotate - fragement * valuePerFragement) / valuePerFragement;
            var res = new ImplPerlinNoise2D.Utility.Image.ColorRGB();
            switch (fragement) {
                case 0:
                case 6:
                    res.R = 255;
                    res.G = 255 * remainPercent;
                    res.B = 0;
                    break;
                case 1:
                    res.R = 255 * (1 - remainPercent);
                    res.G = 255;
                    res.B = 0;
                    break;
                case 2:
                    res.R = 0;
                    res.G = 255;
                    res.B = 255 * remainPercent;
                    break;
                case 3:
                    res.R = 0;
                    res.G = 255 * (1 - remainPercent);
                    res.B = 255;
                    break;
                case 4:
                    res.R = 255 * remainPercent;
                    res.G = 0;
                    res.B = 255;
                    break;
                case 5:
                    res.R = 255;
                    res.G = 0;
                    res.B = 255 * (1 - remainPercent);
                    break;
                default:
                    res.R = 255;
                    res.G = 255;
                    res.B = 255;
                    break;
            }
            return res;
        }

    }

    public class PerlinNoise {
        public PerlinNoise(int seed, double frequency, InterpolationMethod interpol) {
            freq = frequency;
            this.seed = seed;
            interpolation = interpol;

            var intFreq = (int)freq;
            if (intFreq != freq) intFreq++;
            rndEngine = new TRandom(new Troschuetz.Random.Generators.StandardGenerator(seed));

            //generate row seed
            rowSeed = new uint[intFreq + 2];
            for (int i = 0; i < intFreq + 2; i++) {
                rowSeed[i] = rndEngine.NextUInt();
            }
        }

        public void GetNoise(double x, double y, ref double res) {
            var basex = (int)(x / wavelength);
            var basey = (int)(y / wavelength);

            if (basex == x && basey == y) {
                res = 0;
                return;
            }

            //get gradient
            var g00 = GetGradient(basex, basey);
            var g10 = GetGradient(basex + 1, basey);
            var g01 = GetGradient(basex, basey + 1);
            var g11 = GetGradient(basex + 1, basey + 1);

            var pos = new Utility.Vector(0, 0);

            pos.X = (x - basex * wavelength) / wavelength; pos.Y = (y - basey * wavelength) / wavelength;
            var n00 = Influence(g00, pos);

            pos.X = (x - (basex + 1) * wavelength) / wavelength;
            var n10 = Influence(g10, pos);

            pos.X = (x - basex * wavelength) / wavelength; pos.Y = (y - (basey + 1) * wavelength) / wavelength;
            var n01 = Influence(g01, pos);

            pos.X = (x - (basex + 1) * wavelength) / wavelength;
            var n11 = Influence(g11, pos);

            var x_shortage = (x - basex * wavelength) / wavelength;
            var y_shortage = (y - basey * wavelength) / wavelength;
            var nx0 = n00 * (1 - Fade(x_shortage)) + n10 * Fade(x_shortage);
            var nx1 = n01 * (1 - Fade(x_shortage)) + n11 * Fade(x_shortage);
            res = nx0 * (1 - Fade(y_shortage)) + nx1 * Fade(y_shortage);

        }

        int seed;
        TRandom rndEngine;
        InterpolationMethod interpolation;
        uint[] rowSeed;
        double freq;
        double wavelength { get { return (double)(Kernel.MAP_SIZE) / freq; } }

        double GetGradient(int x, int y) {
            rndEngine.Reset(rowSeed[y]);
            for (int i = 0; i < x; i++)
                rndEngine.NextDouble();

            return rndEngine.NextDouble();
        }

        double Influence(double cornerRotate, Utility.Vector pos) {
            cornerRotate *= Math.PI * 2;
            //var toward = new Utility.Vector(
            //    Math.Cos(cornerRotate),
            //    Math.Sin(cornerRotate));
            var toward = new Utility.Vector();
            if (cornerRotate < Math.PI / 4 || cornerRotate > 7 * Math.PI / 4) {
                toward.X = 1;
                toward.Y = Math.Sin(cornerRotate);
            } else if (cornerRotate < 3 * Math.PI / 4) {
                toward.X = Math.Cos(cornerRotate);
                toward.Y = 1;
            } else if (cornerRotate < 5 * Math.PI / 4) {
                toward.X = -1;
                toward.Y = Math.Sin(cornerRotate);
            } else {
                toward.X = Math.Cos(cornerRotate);
                toward.Y = -1;
            }

            return toward * pos;
        }

        double Fade(double pos) {
            switch (this.interpolation) {
                case InterpolationMethod.NearestNeighborInterpolation:
                    return (pos > 0.5 ? 1 : 0);
                case InterpolationMethod.BilinearInterpolation:
                    return pos;
                case InterpolationMethod.BicubicInterpolation:
                    return pos;
                case InterpolationMethod.SineInterpolation:
                    return (1 - Math.Cos(Math.PI * pos)) / 2;
                case InterpolationMethod.KenPerlinInterpolation:
                    return 3 * Math.Pow(pos, 2) - 2 * Math.Pow(pos, 3);
                case InterpolationMethod.OptimizedKenPerlinInterpolation:
                    return 6 * Math.Pow(pos, 5) - 15 * Math.Pow(pos, 4) + 10 * Math.Pow(pos, 3);
                default:
                    return pos;
            }
        }

    }

    public enum InterpolationMethod : Int32 {
        NearestNeighborInterpolation,
        BilinearInterpolation,
        BicubicInterpolation,
        SineInterpolation,
        //Ken Perlin(3*t^2-2*t^3)
        KenPerlinInterpolation,
        //Optimized Ken Perlin(6*t^5-15*t^4+10*t^3)
        OptimizedKenPerlinInterpolation,
    }

}
