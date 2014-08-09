﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace TikiTankHardware
{
    public class TikiColor
    {
        public static TikiColor FromRgb(byte red, byte green, byte blue)
        {
            TikiColor clr = new TikiColor();
            clr.R = red;
            clr.G = green;
            clr.B = blue;

            return clr;
        }

        public static TikiColor FromRgb(int color)
        {
            TikiColor clr = new TikiColor();
            clr.R = (byte)(color >> 16);
            clr.G = (byte)(color >> 8);
            clr.B = (byte)color;

            return clr;
        }

        public int ToRgb()
        {
            int i = this.B;
            i <<= 8;
            i |= this.G;
            i <<= 8;
            i |= this.R;

            return i;
        }


        // Returns Color parsed from color string 
        public static TikiColor ColorStringToColor(string kobcol)
        {            
            return (TikiColor.FromRgb(int.Parse(kobcol, NumberStyles.AllowHexSpecifier)));
        }

        // Convert color to color string
        public static string ColorToColorString(TikiColor col)
        {            
            return col.ToRgb().ToString("X2");
        }

        public static int Wheel(int WheelPos)
        {
            int r = 0, g = 0, b = 0;
            switch (WheelPos / 128)
            {
                case 0:
                    r = 127 - WheelPos % 128; // red down
                    g = WheelPos % 128; // green up
                    b = 0; // blue off
                    break;
                case 1:
                    g = 127 - WheelPos % 128; // green down
                    b = WheelPos % 128; // blue up
                    r = 0; // red off
                    break;
                case 2:
                    b = 127 - WheelPos % 128; // blue down
                    r = WheelPos % 128; // red up
                    g = 0; // green off
                    break;
            }

            return TikiColor.FromRgb((byte)r, (byte)g, (byte)b).ToRgb();
        }

        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
    }
}