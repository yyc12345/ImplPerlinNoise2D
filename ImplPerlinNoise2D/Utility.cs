using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Drawing;

namespace ImplPerlinNoise2D.Utility.Storage {

    public static class StorageManager {
        public static RootObject Read() {
            if (!File.Exists("config.cfg")) Init();
            var fs = new StreamReader("config.cfg", Encoding.UTF8);
            var cache = fs.ReadToEnd();
            fs.Close();
            fs.Dispose();
            return JsonConvert.DeserializeObject<RootObject>(cache);
        }

        static void Init() {
            var fs = new StreamWriter("config.cfg", false, Encoding.UTF8);
            var data = new RootObject();
            data.NoiseList = new List<NoiseData>();
            fs.Write(JsonConvert.SerializeObject(data));
            fs.Close();
            fs.Dispose();
        }

        public static void Write(RootObject data) {
            var fs = new StreamWriter("config.cfg", false, Encoding.UTF8);
            fs.Write(JsonConvert.SerializeObject(data));
            fs.Close();
            fs.Dispose();
        }
    }
    
    public class RootObject {
        public List<NoiseData> NoiseList { get; set; }
    }

    public class NoiseData {
        public string Name { get; set; }
        public int Seed { get; set; }
        public double Frequency { get; set; }
        public double Amplitude { get; set; }
        public double Redistribution { get; set; }
        public InterpolationMethod Interpolation { get; set; }
        public int Smooth { get; set; }
        public double AttachPercentage { get; set; }
    }
}

namespace ImplPerlinNoise2D.Utility.Image {

    public struct ColorRGB {
        public ColorRGB(double r, double g, double b) {
            R = r;
            G = g;
            B = b;
        }
        public double R;
        public double G;
        public double B;

        public static ColorRGB operator +(ColorRGB a, ColorRGB b) {
            return new ColorRGB(a.R + b.R, a.G + b.G, a.B + b.B);
        }
        public static ColorRGB operator -(ColorRGB a, ColorRGB b) {
            return new ColorRGB(a.R - b.R, a.G - b.G, a.B - b.B);
        }
        public static ColorRGB operator *(ColorRGB a, double num) {
            return new ColorRGB(a.R * num, a.G * num, a.B * num);
        }
        public static ColorRGB operator /(ColorRGB a, double num) {
            return new ColorRGB(a.R / num, a.G / num, a.B / num);
        }
    }

    public class BitmapOperator {

        public BitmapOperator(int width, int height) {
            image = new System.Drawing.Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            realImage = image.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),
                System.Drawing.Imaging.ImageLockMode.ReadWrite,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        }

        System.Drawing.Bitmap image;
        System.Drawing.Imaging.BitmapData realImage;
        const int PIXEL_SIZE = 3;
        public int Width { get { return image.Width; } }
        public int Height { get { return image.Height; } }

        public Bitmap Close() {
            //unlock
            image.UnlockBits(realImage);
            return image;
        }
        
        public ColorRGB GetPixel(int x, int y) {
            int offset = y * realImage.Stride + x * PIXEL_SIZE;
            //BGR -> RGB
            return new ColorRGB(
                System.Runtime.InteropServices.Marshal.ReadByte(realImage.Scan0, offset + 2),
                System.Runtime.InteropServices.Marshal.ReadByte(realImage.Scan0, offset + 1),
                System.Runtime.InteropServices.Marshal.ReadByte(realImage.Scan0, offset));
        }

        public void SetPixel(int x, int y, ColorRGB color) {
            int offset = y * realImage.Stride + x * PIXEL_SIZE;
            //RGB -> BGR
            System.Runtime.InteropServices.Marshal.WriteByte(realImage.Scan0, offset, (byte)color.B);
            System.Runtime.InteropServices.Marshal.WriteByte(realImage.Scan0, offset + 1, (byte)color.G);
            System.Runtime.InteropServices.Marshal.WriteByte(realImage.Scan0, offset + 2, (byte)color.R);
        }
    }

}

namespace ImplPerlinNoise2D.Utility {
    public struct Vector {
        public Vector(double x, double y) {
            X = x;
            Y = y;
        }
        public double X;
        public double Y;

        public static Vector operator +(Vector a, Vector b) {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }
        public static Vector operator -(Vector a, Vector b) {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }
        public static double operator *(Vector a, Vector b) {
            return (a.X * b.X) + (a.Y * b.Y);
        }
    }
}
