﻿using System.Runtime.Serialization;
using System.Drawing;
using System;

namespace TikiTankCommon.Effects
{
    /// <summary>
    /// Multiple moving lines on barrel with random colors
    /// </summary>
    public class MultiLineBarrel : IEffect
    {
        public MultiLineBarrel()
        {
        }

        /// <summary>
        /// Track a moving line
        /// </summary>
        class Line
        {
            /// <summary>
            /// How many times have we changed line move direction
            /// </summary>
            int changeCount = 0;

             int lineLen = 4;
            int pos = 0;
            bool up = true;
            Color color = Color.White;

            public Line(bool up, Color color, int pos)
            {
                Console.WriteLine("up: " + up);
                this.up = up;
                this.color = color;
                this.pos = pos;
            }

            public void Update(Color[] pixels)
            {
                if (up)
                {
                    pos += 1;
                    if (pos >= pixels.Length)
                    {
                        pos = 0;
                        changeCount += 1;
                    }
                }
                else
                {
                    pos -= 1;
                    if (pos < 0)
                    {
                        pos = pixels.Length - 1;
                        changeCount += 1;
                    }
                }

                for (int i = pos, x = 0; i > -1 && x < lineLen; i--, x++)
                    pixels[i] = color.MakeDarker(0.05f * (float)x);
            }
        }

        Line[] lines;
        Random rnd = new Random();
        DateTime lastChangeup = DateTime.Now;

        public void Activate(System.Drawing.Color[] pixels)
        {
            lastChangeup = DateTime.Now;

            lines = new Line[rnd.Next(10)+1];

            Console.WriteLine("lines: " + lines.Length);

            for(int i = 0; i<lines.Length;i++)
                lines[i] = new Line(rnd.Next() % 2 == 0 ? true : false, Color.FromArgb(rnd.Next()), rnd.Next(pixels.Length-1));

            for (int i = 0; i < pixels.Length; i++)
                pixels[i] = Color.Black;
        }

        public void Deactivate(Color[] pixels) { }

        DateTime last = DateTime.Now;
        public bool WouldUpdate()
        {
            var span = DateTime.Now - last;
            if (span.TotalMilliseconds >= 50)
            {
                last = DateTime.Now;
                return true;
            }
            return false;
        }

       
        public void FrameUpdate(Color[] pixels)
        {
            // Change up every 60 seconds
            if ((DateTime.Now - lastChangeup).TotalSeconds > 60)
            {
                this.Activate(pixels);
                return;
            }

            for (int i = 0; i < pixels.Length; i++)
                pixels[i] = Color.Black;

            foreach (var l in lines)
                l.Update(pixels);
        }

        public void Tick() { }
        public bool IsSensorDriven { get; set; }
        public string Argument { get; set; }
        public System.Drawing.Color Color { get; set; }
    }
}