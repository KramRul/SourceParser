﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceParser.TestAlgoritms.Tests
{
    public static class DTTestListBased
    {
        public static void Test()
        {
            Console.WriteLine("\nBegin decision tree demo \n");

            double[][] dataX = new double[30][];
            dataX[0] = new double[] { 5.1, 3.5, 1.4, 0.2 };  // 0
            dataX[1] = new double[] { 4.9, 3.0, 1.4, 0.2 };
            dataX[2] = new double[] { 4.7, 3.2, 1.3, 0.2 };
            dataX[3] = new double[] { 4.6, 3.1, 1.5, 0.2 };
            dataX[4] = new double[] { 5.0, 3.6, 1.4, 0.2 };
            dataX[5] = new double[] { 5.4, 3.9, 1.7, 0.4 };
            dataX[6] = new double[] { 4.6, 3.4, 1.4, 0.3 };
            dataX[7] = new double[] { 5.0, 3.4, 1.5, 0.2 };
            dataX[8] = new double[] { 4.4, 2.9, 1.4, 0.2 };
            dataX[9] = new double[] { 4.9, 3.1, 1.5, 0.1 };

            dataX[10] = new double[] { 7.0, 3.2, 4.7, 1.4 };  // 1
            dataX[11] = new double[] { 6.4, 3.2, 4.5, 1.5 };
            dataX[12] = new double[] { 6.9, 3.1, 4.9, 1.5 };
            dataX[13] = new double[] { 5.5, 2.3, 4.0, 1.3 };
            dataX[14] = new double[] { 6.5, 2.8, 4.6, 1.5 };
            dataX[15] = new double[] { 5.7, 2.8, 4.5, 1.3 };
            dataX[16] = new double[] { 6.3, 3.3, 4.7, 1.6 };
            dataX[17] = new double[] { 4.9, 2.4, 3.3, 1.0 };
            dataX[18] = new double[] { 6.6, 2.9, 4.6, 1.3 };
            dataX[19] = new double[] { 5.2, 2.7, 3.9, 1.4 };

            dataX[20] = new double[] { 6.3, 3.3, 6.0, 2.5 };   // 2
            dataX[21] = new double[] { 5.8, 2.7, 5.1, 1.9 };
            dataX[22] = new double[] { 7.1, 3.0, 5.9, 2.1 };
            dataX[23] = new double[] { 6.3, 2.9, 5.6, 1.8 };
            dataX[24] = new double[] { 6.5, 3.0, 5.8, 2.2 };
            dataX[25] = new double[] { 7.6, 3.0, 6.6, 2.1 };
            dataX[26] = new double[] { 4.9, 2.5, 4.5, 1.7 };
            dataX[27] = new double[] { 7.3, 2.9, 6.3, 1.8 };
            dataX[28] = new double[] { 6.7, 2.5, 5.8, 1.8 };
            dataX[29] = new double[] { 7.2, 3.6, 6.1, 2.5 };

            int[] dataY =
              new int[30] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                      1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                      2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };

            Console.WriteLine("Iris 30-item subset looks like: ");
            Console.WriteLine("5.1, 3.5, 1.4, 0.2 -> 0");
            Console.WriteLine("7.0, 3.2, 4.7, 1.4 -> 1");
            Console.WriteLine("6.3, 3.3, 6.0, 2.5 -> 2");
            Console.WriteLine(" . . . ");

            Console.WriteLine("\nBuilding 7-node 3-class decision tree");
            BusinessLogicLevel.Helpers.DecisionTree.DecisionTreeListBased dt = new BusinessLogicLevel.Helpers.DecisionTree.DecisionTreeListBased(7, 3);
            dt.BuildTree(dataX, dataY);

            Console.WriteLine("\nTree is: ");
            dt.Show();  // show all nodes in tree

            Console.WriteLine("\nDone. Nodes 0 and 4 are:");
            dt.ShowNode(0);
            dt.ShowNode(4);

            Console.WriteLine("\nComputing prediction accuracy on reference data:");
            double acc = dt.Accuracy(dataX, dataY);
            Console.WriteLine("Classification accuracy = " + acc.ToString("F4"));

            double[] x = new double[] { 6.0, 2.0, 3.0, 4.0 };
            Console.WriteLine("\nPredicting class for (6.0, 2.0, 3.0, 4.0)");
            int predClass = dt.Predict(x, verbose: true);

            Console.WriteLine("\nEnd demo ");
            Console.ReadLine();
        }
    }
}
