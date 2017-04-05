using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Обратное_распространение
{
    class SettingWeights
    {
    public  static double[,] SetW(double[,] W, int FirstInd, int SecondInt, double norm, double[] x, double[] Sigma)
        {
            for (int j = 0; j < x.Count(); j++)
            {
                for (int m = 0; m < SecondInt; m++)
                {
                    W[j, m] += norm * x[j] * Sigma[m];
                }
            }
            return W;
        }
        public static double err(double[] t, double[] y, int M)
        {
            double Error = 0;
            for (int j = 0; j < M; j++)
            {
                Error += Math.Pow(Math.Round(t[j] - y[j+1],2),2);
            }
            return Math.Sqrt(Error);
        }
    }
}
