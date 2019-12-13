using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;


namespace algo_Prima
{
     class Program
    {
        public static Stopwatch sw = new Stopwatch();

        static void algorithmByPrim(int numberV, List<Edge> E, List<Edge> MST)
        {
            //неиспользованные ребра
            List<Edge> notUsedE = new List<Edge>(E);
            //использованные вершины
            List<int> usedV = new List<int>();
            //неиспользованные вершины
            List<int> notUsedV = new List<int>();
            for (int i = 0; i < numberV; i++)
                notUsedV.Add(i);
            //выбираем случайную начальную вершину
            Random rand = new Random();
            usedV.Add(rand.Next(0, numberV));
            notUsedV.RemoveAt(usedV[0]);
            while (notUsedV.Count > 0)
            {
                int minE = -1; //номер наименьшего ребра
                               //поиск наименьшего ребра
                for (int i = 0; i < notUsedE.Count; i++)
                {
                    if ((usedV.IndexOf(notUsedE[i].v1) != -1) && (notUsedV.IndexOf(notUsedE[i].v2) != -1) ||
                        (usedV.IndexOf(notUsedE[i].v2) != -1) && (notUsedV.IndexOf(notUsedE[i].v1) != -1))
                    {
                        if (minE != -1)
                        {
                            if (notUsedE[i].weight < notUsedE[minE].weight)
                                minE = i;
                        }
                        else
                            minE = i;
                    }
                }
                //заносим новую вершину в список использованных и удаляем ее из списка неиспользованных
                if (usedV.IndexOf(notUsedE[minE].v1) != -1)
                {
                    usedV.Add(notUsedE[minE].v2);
                    notUsedV.Remove(notUsedE[minE].v2);
                }
                else
                {
                    usedV.Add(notUsedE[minE].v1);
                    notUsedV.Remove(notUsedE[minE].v1);
                }
                //заносим новое ребро в дерево и удаляем его из списка неиспользованных
                MST.Add(notUsedE[minE]);
                notUsedE.RemoveAt(minE);
            }
           // foreach(Edge e in MST)
           // {
                //Console.WriteLine(e);
           // }


            // Console.ReadKey();
        }


        [STAThread]
        static void Main(string[] args)
        {
            
           

            List<Edge> MST = new List<Edge>(); // минимальное остовное дерево

            int N;
            
            //string path = @"C:\Users\Аввесей\Desktop\pres\in2.txt";  // достать из папки на компе
            // достает из файла проекта
            
             string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Example\Test1.txt");
            
            
           
            string[] lines = File.ReadAllLines(path);
            N = Convert.ToInt32(lines[0]);
            List<Edge> E = new List<Edge>(N); //сам граф

            for (int i = 1; i < lines.Length; i++)
            {
                int v1 = Convert.ToInt32(lines[i]);
                int v2 = Convert.ToInt32(lines[i+1]);
                int weight = Convert.ToInt32(lines[i+2]);
                Edge Ed = new Edge(v1, v2, weight);
                E.Add(Ed);
                i += 2; 
            }

            
            sw.Start();
            algorithmByPrim( N , E, MST);
            sw.Stop();
            

            foreach (Edge e in MST)
            {
                //Console.WriteLine(e.ToString());
                Data.output.Add(e);
            }
           // Console.ReadKey();
            Form1.Runing();
        }
    }
}
