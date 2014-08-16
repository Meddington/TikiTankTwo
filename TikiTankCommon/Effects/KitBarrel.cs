using System.Runtime.Serialization;
using System.Drawing;
using System;

namespace TikiTankCommon.Effects
{
    public class KitBarrel : IEffect
    {
        public KitBarrel()
        {
            Color = Color.White;
        }

        int kitLen = 11;

        public void Activate(System.Drawing.Color[] pixels)
        {
            pos = 0;
            right = true;

            for (int i = 0; i < pixels.Length; i++)
                pixels[i] = Color.Black;

            pixels[0] = Color.DarkRed;
            pixels[2] = Color.DarkRed;
            pixels[3] = Color.DarkRed;
            pixels[4] = Color.Red;
            pixels[5] = Color.Red;
            pixels[6] = Color.Red;
            pixels[7] = Color.Red;
            pixels[8] = Color.DarkRed;
            pixels[9] = Color.DarkRed;
            pixels[10] = Color.DarkRed;
        }

        public void Deactivate(System.Drawing.Color[] pixels) { }

        DateTime last = DateTime.Now;
        public bool WouldUpdate()
        {
            var span = DateTime.Now - last;
            if (span.TotalMilliseconds >= 70)
            {
                last = DateTime.Now;
                return true;
            }

            return false;
        }

        // move from 0 -> max len

        int pos = 0;
        bool right = true;

        public void FrameUpdate(Color[] pixels)
        {
            if (right)
            {
                StripHelper.ShiftRight(pixels);
                pos += 1;
                if (pos >= pixels.Length - kitLen)
                    right = false;
            }
            else
            {
                StripHelper.ShiftLeft(pixels);
                pos -= 1;
                if (pos < 0)
                    right = true;
            }
        }

        public void Tick() { }
        public bool IsSensorDriven { get; set; }
        public string Argument { get; set; }
        public System.Drawing.Color Color { get; set; }
    }
}