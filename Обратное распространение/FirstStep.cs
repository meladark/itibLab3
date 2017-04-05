using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Обратное_распространение
{
    class FirstStep
    {
     public  static double[] net(double[,] W, double[] x, int N, int J)
        {
            double[] net = new double[J+1];
            for(int j = 0; j < J; j++)
            {
                for (int i = 1; i <= N; i++)
                {
                    net[j] += W[i, j] * x[i] + W[0, j];
                }
            }
            return net;
        }
    public  static double fnet(double net)
        {
            return ((1 - Math.Exp(-net)) / (1 + Math.Exp(-net)));
        }
    public  static double[] Out(double[] Out, double[] net, int J)
        {
           // double[] Out = new double[J+1];
            for (int j = 1; j <= J; j++)
            {
                Out[j] = fnet(net[j-1]);
            }
            return Out;
        } 
    }
}
