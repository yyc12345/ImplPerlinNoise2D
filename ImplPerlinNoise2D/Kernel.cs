using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImplPerlinNoise2D {

    public static class Kernel {

        public static int MAP_SIZE = 512;

        public static Bitmap Generate(List<ImplPerlinNoise2D.Utility.Storage.NoiseData> data) {
            var img = new ImplPerlinNoise2D.Utility.Image.BitmapOperator(512, 512);

            var count = data.Count;
            var perlinList = new List<PerlinNoise>();
            double max = 0;
            for (int i = 0; i < count; i++) {
                perlinList.Add(new PerlinNoise(data[i].Seed, data[i].Frequency));
                max += data[i].Amplitude * data[i].AttachPercentage;
            }

            //todo: find the proper relation of max. maybe is 1*sqrt(2) ?
            max = 1.5;
            double calc = 0;
            double cache = 0;
            for (int y = 0; y < MAP_SIZE; y++) {
                for (int x = 0; x < MAP_SIZE; x++) {
                    calc = 0;
                    cache = 0;
                    for (int i = 0; i < count; i++) {
                        perlinList[i].GetNoise(x, y, ref cache);
                        calc += cache * data[i].Amplitude * data[i].AttachPercentage;
                    }
                    img.SetPixel(x, y, JudgeValue(calc, max));
                }
            }

            return img.Close();
        }

        static ImplPerlinNoise2D.Utility.Image.ColorRGB JudgeValue(double value, double max) {
            value += max;
            if (value < 0) return new Utility.Image.ColorRGB(255, 0, 0);
            if (value > 2 * max) return new Utility.Image.ColorRGB(255, 0, 0);

            var realValue = 255 * (value / (2 * max));
            return new Utility.Image.ColorRGB(realValue, realValue, realValue);
        }

    }

    public class PerlinNoise {
        public PerlinNoise(int seed, int frequency) {
            rnd = new Random(seed);
            freq = frequency;

            preRow = new double[freq + 2];
            nowRow = new double[freq + 2];
            for (int i = 0; i < freq + 2; i++) {
                nowRow[i] = rnd.NextDouble();
            }
        }

        public void GetNoise(double x, double y, ref double res) {
            if (y == (nowRowIndex + 1) * wavelength) {
                //use 1D mode
                var basex = (int)(x / wavelength);
                var pos = new Utility.Vector(0, 0);
                pos.X = (x - basex * wavelength) / wavelength;
                var n0 = Influence(nowRow[basex], pos);
                pos.X = (x - (basex + 1) * wavelength) / wavelength;
                var n1 = Influence(nowRow[basex + 1], pos);

                var x_shortage = (x - basex * wavelength) / wavelength;
                res = n0 * (1 - Fade(x_shortage)) + n1 * Fade(x_shortage);
            } else {
                if (y > (nowRowIndex + 1) * wavelength) Step();
                //use 2D mode
                var basex = (int)(x / wavelength);
                var pos = new Utility.Vector(0, 0);

                pos.X = (x - basex * wavelength) / wavelength; pos.Y = (y - nowRowIndex * wavelength) / wavelength;
                var n00 = Influence(preRow[basex], pos);

                pos.X = (x - (basex + 1) * wavelength) / wavelength;
                var n10 = Influence(preRow[basex + 1], pos);

                pos.X = (x - basex * wavelength) / wavelength; pos.Y = (y - (nowRowIndex + 1) * wavelength) / wavelength;
                var n01 = Influence(nowRow[basex], pos);

                pos.X = (x - (basex + 1) * wavelength) / wavelength;
                var n11 = Influence(nowRow[basex + 1], pos);

                var x_shortage = (x - basex * wavelength) / wavelength;
                var y_shortage = (y - nowRowIndex * wavelength) / wavelength;
                var nx0 = n00 * (1 - Fade(x_shortage)) + n10 * Fade(x_shortage);
                var nx1 = n01 * (1 - Fade(x_shortage)) + n11 * Fade(x_shortage);
                res = nx0 * (1 - Fade(y_shortage)) + nx1 * Fade(y_shortage);
            }
        }

        Random rnd;
        int freq;
        double wavelength { get { return (double)(Kernel.MAP_SIZE) / (double)freq; } }

        int nowRowIndex = -1;
        double[] preRow;
        double[] nowRow;

        void Step() {
            nowRowIndex++;
            for (int i = 0; i < freq + 2; i++) {
                preRow[i] = nowRow[i];
                nowRow[i] = rnd.NextDouble();
            }
        }

        double Influence(double cornerRotate, Utility.Vector pos) {
            cornerRotate *= Math.PI * 2;
            var toward = new Utility.Vector(
                Math.Cos(cornerRotate),
                Math.Sin(cornerRotate));
            return toward * pos;
        }

        //todo: optimize this func
        double Fade(double pos) {
            return 6 * Math.Pow(pos, 5) - 15 * Math.Pow(pos, 4) + 10 * Math.Pow(pos, 3);
        }

    }

}
