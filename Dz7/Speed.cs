using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz7
{
    class Speed : IFormattable
    {
        public double KmPerHour { get; set; }
        public Speed(double kmph)
        {
            if (kmph < 0)
            {
                KmPerHour = Math.Abs(kmph);
            }
            else
            {
                KmPerHour = kmph;
            }

        }
        public static Speed FromMilesPerHour(double milesPerHour)
        {
            return new Speed(milesPerHour * 1.609);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return KmPerHour.ToString("F2", formatProvider) + " км/ч";
        }
    }
}
