using System;
using System.Collections.Generic;
using System.Text;

namespace GuitarLA
{
    class Analyse
    {
        public static double FindPeak(double[] magnitude)
        {
            bool growth = false;
            double mag = 0;
            double peak = 0;
            for (int i = 0; i < 900; i++)
            {
                if (magnitude[i] > 8 & mag != magnitude[i])
                {
                    if (mag < magnitude[i])
                        growth = true;
                    if (mag > magnitude[i] & growth)
                    {
                        peak = i - 1;
                        break;
                    }
                }
                mag = magnitude[i];
            }
            return peak;
        }
        public static double Octave(double peak, double Freq)
        {
            double note = Freq;
            for (double i = 1; i < 5; i++)
            {
                if (peak < Freq * (i + 0.5) & peak > Freq * (i - 0.5))
                    note = Freq * i;
            }
            return note;
        }
        private static List<int> FindPeaks(double[] magnitude)
        {
            bool growth = false;
            double mag = 0;
            List<int> peaks = new List<int>();
            for (int i = 0; i < 900; i++)
            {
                if (magnitude[i] > 6)
                {
                    if (mag < magnitude[i])
                        growth = true;
                    else if (mag > magnitude[i])
                    {
                        peaks.Add(i - 1);
                        if(growth)
                            peaks.Add(i - 1);
                        growth = false;
                    }
                }
                mag = magnitude[i];
            }
            return peaks;
        }
        public static bool IsEquals(double[] magnitude, sbyte[] accord, double[] freq)
        {
            List<int> peaks = FindPeaks(magnitude);
            double toMag = (double)32768 / 44100;
            double[] value = new double[6];
            for (int i = 0; i < 6; i++)
            {
                if (accord[i] >= 0)
                    value[i] = freq[i] * Math.Pow(2, (accord[i] - 48) / 12) * toMag;
            }
            int j = 0;
            foreach (int val in value)
            {
                if (val != 0)
                    for (int i = val - 5; i < val + 5; i++)
                    {
                        if (peaks.Contains(i))
                        {
                            j++;
                        }
                    }
                else
                    j++;
            }
            if (j < 6)
                return false;
            return true;
        }
    }
}
