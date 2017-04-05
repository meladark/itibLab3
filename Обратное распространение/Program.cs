using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Обратное_распространение
{
    class Program
    {
       
        static void BackPropagation(double[] X1, double[] net1, double[] net2, double[] Out1, double[] Out2, double[] Sigma1, double[] Sigma2, double[,] W1, double[,] W2)
        {
          //  try
            {

                int N = 1, J = 1, M = 3;
                double[] t = new double[3];
                t[0] = 0.2;
                t[1] = -0.3;
                t[2] = 0.1;
                net1 = FirstStep.net(W1,X1,N,J);            
                Out1 = FirstStep.Out(Out1 ,net1,J);
                net2 = FirstStep.net(W2, Out1, J, M);
                Out2 = FirstStep.Out(Out2,net2,M);
                Sigma2 = SecondPhase.sigmaM(net2, M, t, Out2);
                Sigma1 = SecondPhase.sigmaJ(net1, J, M, W2, Sigma2);
                W1 = SettingWeights.SetW(W1, N, J, 1, X1, Sigma1);
                W2 = SettingWeights.SetW(W2, J, M, 1, Out1, Sigma2);
                double err = SettingWeights.err(t, Out2, M);
                if (err > 0)
                {
                    Console.Write("Веса W: ");
                    for(int i = 1;i<Out2.Count();i++)
                    {
                        Console.Write(Math.Round(Out2[i],2)+" ");
                    }
                    Console.WriteLine();
                    Console.Write("Средняя ошибка: ");
                    Console.WriteLine(Math.Round(err, 2));
                    BackPropagation(X1, net1, net2, Out1, Out2, Sigma1, Sigma2, W1, W2);
                }
                else
                {
                    Console.Write("Веса W: ");
                    for (int i = 1; i < Out2.Count(); i++)
                    {
                        Console.Write(Math.Round(Out2[i], 2) + " ");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Средняя ошибка: ");
                    Console.Write(Math.Round(err,2));
                    Console.ReadKey();
                }
            }
      //      catch
            {
                Console.Write("Колотить");
            }
        }
        static void Main(string[] args)
        {
            int N = 1, J = 1, M = 3;

            double[] X1 = new double[N+1];
            X1[0] = 1;
            X1[1] = -1;
            double[] net1 = new double[J+1];
            double[] net2 = new double[M+1];
            double[] Out1 = new double[J+1];
            double[] Out2 = new double[M+1];
            double[] Sigma1 = new double[J+1];
            double[] Sigma2 = new double[M+1];
            double[,] W1 = new double[N+1,J];
            double[,] W2 = new double[J+1,M];
            for (int i = 0; i < J + 1; i++)
            {
                W1[i, 0] = i+1;
            }
            BackPropagation(X1, net1, net2, Out1, Out2,Sigma1, Sigma2, W1, W2);
           
        }
    }
}
