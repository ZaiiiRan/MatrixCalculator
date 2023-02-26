using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Matrix_Calculus
{
    internal class Englang
    {
        char[] nums = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };
        public int Num_input(ref bool error)
        {
            string[] Args = Console.ReadLine().Split();
            if (Args[0].Length == 0 || Args[0] == null || Args[0] == " ")
            {
                Console.WriteLine("\nNumber input error!");
                error = true;
                return -10;
            }

            else {
                int correct_length = 0;
                foreach (char c in Args[0])
                {
                    for (int i = 0; i < nums.Length - 1; i++)
                    {
                        if (c == nums[i]) correct_length++;
                    }
                }
                if (correct_length != (Args[0]).Length) { error = true; Console.WriteLine("\nNumber input error!"); return -10; }
                else return Convert.ToInt32(Args[0]);
            }
        }
        public double Double_input(ref bool error)
        {
            string[] Args = Console.ReadLine().Split();
            if (Args[0].Length == 0 || Args[0] == null || Args[0] == " ")
            {
                Console.WriteLine("\nNumber input error!");
                error = true;
                return 0;
            }

            else
            {
                int correct_length = 0;
                foreach (char c in Args[0])
                {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        if (c == nums[i]) correct_length++;
                    }
                }
                if (correct_length != (Args[0]).Length) { error = true; Console.WriteLine("\nNumber input error!"); return 0; }
                else return Double.Parse(Args[0], System.Globalization.CultureInfo.InvariantCulture);
            }
        }
        public void Matrix_input(ref double[,] matrix, ref int n, ref int m, ref bool error)
        {
            input Input = new input();
            Console.WriteLine("\nEnter elements line by line, separating them with a space:\n");
            string[] Args;
            for (int i=0;i<n;i++)
            {
                Args = Console.ReadLine().Split(' ');
                if (Input.Matrix_input_check(ref Args, ref m) == false)
                {
                    Console.WriteLine("Matrix input error\n");
                    error = true;
                    return;
                }
                else 
                {
                    bool err = false;
                    for (int l = 0; l < Args.Length; l++)
                    {
                        int correct_length = 0;
                        foreach (char c in Args[l])
                        {
                            for (int s = 0; s < nums.Length; s++)
                            {
                                if (nums[s] == c) correct_length++;
                            }
                        }
                        if (correct_length != Args[l].Length) { err = true; break; }
                    }
                    if (err == true)
                    {
                        Console.WriteLine("\nMatrix input error!");
                        error = true;
                        return;
                    }
                    else
                    {
                        for (int j = 0; j < m; j++)
                        {
                            matrix[i, j] = Double.Parse(Args[j], System.Globalization.CultureInfo.InvariantCulture);
                        }
                    }
                }
            }
        }
        public void Main()
        {
            Console.Clear();

            while (true)
            {
                Operations operations = new Operations();
                Console.WriteLine("Select the command:\n");
                Console.WriteLine("1 - Sum of two matrices");
                Console.WriteLine("2 - Multiplication of two matrices");
                Console.WriteLine("3 - Multiplying a Matrix by a Number");
                Console.WriteLine("4 - Matrix exponentiation");
                Console.WriteLine("5 - Element-wise multiplication of two matrices");
                Console.WriteLine("6 - Matrix determinant");
                Console.WriteLine("7 - Matrix rank");
                Console.WriteLine("8 - inverse matrix");
                Console.WriteLine();
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key==ConsoleKey.NumPad1 || key.Key == ConsoleKey.D1)                  /*Sum*/
                {
                    Console.WriteLine("\n------------------------------------------------------------------\n");
                    Console.WriteLine("**Sum of two matrices**\n");

                    bool error = false;
                    do
                    {
                        int n1, m1;
                        Console.WriteLine("\n-----\n");
                        Console.WriteLine("Enter the first matrix:\n");
                        Console.Write("Enter the number of first matrix rows: ");
                        n1 = Num_input(ref error);
                        if (error == true) break;
                        Console.Write("\nEnter the number of first matrix columns: ");
                        m1 = Num_input(ref error);
                        if (error == true) break;
                        double[,] matrix1 = new double[n1, m1];
                        Matrix_input(ref matrix1, ref n1, ref m1, ref error);
                        Console.WriteLine();
                        Console.WriteLine("\n-----\n");
                        if (error == true) break;

                        int n2, m2;
                        Console.WriteLine("\n-----\n");
                        Console.WriteLine("Enter the second matrix:\n");
                        Console.Write("Enter the number of second matrix rows: ");
                        n2 = Num_input(ref error);
                        if (error == true) break;
                        Console.Write("\nEnter the number of second matrix columns: ");
                        m2 = Num_input(ref error);
                        if (error == true) break;
                        double[,] matrix2 = new double[n2, m2];
                        Matrix_input(ref matrix2, ref n2, ref m2, ref error);
                        Console.WriteLine();
                        Console.WriteLine("\n-----\n");
                        if (error == true) break;

                        if (n1 != n2 || m1 != m2) { Console.WriteLine("Error! These matrices cannot be added."); }
                        else
                        {
                            double[,] matrix3 = new double[n1, m1];
                            operations.sum(ref matrix1, ref n1, ref m1, ref matrix2, ref matrix3);
                            Console.WriteLine("\nResult:\n");
                            operations.print(ref matrix3, ref n1, ref m1);
                        }
                    } while (false);
                    
                    Console.WriteLine("\n------------------------------------------------------------------\n");
                }


                if (key.Key == ConsoleKey.NumPad2 || key.Key == ConsoleKey.D2)             /*Multiplication*/
                {
                    Console.WriteLine("\n------------------------------------------------------------------\n");
                    Console.WriteLine("**Multiplication of two matrices**\n");

                    bool error = false;
                    do
                    {
                        int n1, m1;
                        Console.WriteLine("\n-----\n");
                        Console.WriteLine("Enter the first matrix:\n");
                        Console.Write("Enter the number of first matrix rows: ");
                        n1 = Num_input(ref error);
                        if (error == true) break;
                        Console.Write("\nEnter the number of first matrix columns: ");
                        m1 = Num_input(ref error);
                        if (error == true) break;
                        double[,] matrix1 = new double[n1, m1];
                        Matrix_input(ref matrix1, ref n1, ref m1, ref error);
                        Console.WriteLine();
                        Console.WriteLine("\n-----\n");
                        if (error == true) break;

                        int n2, m2;
                        Console.WriteLine("\n-----\n");
                        Console.WriteLine("Enter the second matrix:\n");
                        Console.Write("Enter the number of second matrix rows: ");
                        n2 = Num_input(ref error);
                        if (error == true) break;
                        Console.Write("\nEnter the number of second matrix columns: ");
                        m2 = Num_input(ref error);
                        if (error == true) break;
                        double[,] matrix2 = new double[n2, m2];
                        Matrix_input(ref matrix2, ref n2, ref m2, ref error);
                        Console.WriteLine();
                        Console.WriteLine("\n-----\n");
                        if (error == true) break;

                        if (m1 != n2) { Console.WriteLine("Error! These matrices cannot be multiplied."); }
                        else
                        {
                            double[,] matrix3 = new double[n1, m2];
                            operations.mult(ref matrix1, ref n1, ref m1, ref matrix2, ref n2, ref m2, ref matrix3);
                            Console.WriteLine("\nResult:\n");
                            operations.print(ref matrix3, ref n1, ref m2);
                        }
                    } while (false);
                    
                    Console.WriteLine("\n------------------------------------------------------------------\n");
                }


                if (key.Key == ConsoleKey.NumPad3 || key.Key == ConsoleKey.D3)                     /*Multiplying a Matrix by a Number*/
                {
                    Console.WriteLine("\n------------------------------------------------------------------\n");
                    Console.WriteLine("**Multiplying a Matrix by a Number**\n");

                    bool error = false;
                    do
                    {
                        int n1, m1;
                        Console.WriteLine("\n-----\n");
                        Console.WriteLine("Enter the matrix:\n");
                        Console.Write("Enter the number of matrix rows: ");
                        n1 = Num_input(ref error);
                        if (error == true) break;
                        Console.Write("\nEnter the number of matrix columns: ");
                        m1 = Num_input(ref error);
                        if (error == true) break;
                        double[,] matrix1 = new double[n1, m1];
                        Matrix_input(ref matrix1, ref n1, ref m1, ref error);
                        Console.WriteLine();
                        Console.WriteLine("\n-----\n");
                        if (error == true) break;

                        double C;
                        Console.WriteLine("\n-----\n");
                        Console.Write("Enter the number by which to multiply the matrix: ");
                        C = Double_input(ref error);
                        if (error == true) break;
                        Console.WriteLine("\n-----\n");


                        double[,] matrix3 = new double[n1, m1];
                        operations.multC(ref matrix1, ref n1, ref m1, ref C, ref matrix3);
                        Console.WriteLine("\nResult:\n");
                        operations.print(ref matrix3, ref n1, ref m1);
                    } while (false);
                    
                    Console.WriteLine("\n------------------------------------------------------------------\n");
                }


                if (key.Key == ConsoleKey.D4 || key.Key == ConsoleKey.NumPad4)                           /*Matrix exponentiation*/
                {
                    Console.WriteLine("\n------------------------------------------------------------------\n");
                    Console.WriteLine("**Matrix exponentiation**\n");

                    bool error = false;
                    do
                    {
                        int n1, m1;
                        Console.WriteLine("\n-----\n");
                        Console.WriteLine("Enter matrix:\n");
                        Console.Write("Enter matrix dimension: ");
                        n1 = Num_input(ref error);
                        if (error == true) break;
                        m1 = n1;
                        double[,] matrix1 = new double[n1, m1];
                        Matrix_input(ref matrix1, ref n1, ref m1, ref error);
                        Console.WriteLine();
                        Console.WriteLine("\n-----\n");
                        if (error == true) break;

                        int C;
                        Console.WriteLine("\n-----\n");
                        Console.Write("Enter degree: ");
                        C = Num_input(ref error);
                        if (error == true) break;
                        Console.WriteLine("\n-----\n");

                        if (C > 1)
                        {
                            int n2, m2;
                            n2 = n1; m2 = m1;
                            double[,] matrix2 = new double[n2, m2];
                            matrix2 = matrix1;
                            int itter = 2;
                            while (itter <= C)
                            {
                                double[,] matrix3 = new double[n1, m2];
                                operations.mult(ref matrix1, ref n1, ref m1, ref matrix2, ref n2, ref m2, ref matrix3);
                                matrix1 = matrix3;
                                itter++;
                            }
                            Console.WriteLine("\nResult:\n");
                            operations.print(ref matrix1, ref n1, ref m1);
                        }
                        else if (C == 1)
                        {
                            Console.WriteLine("\nResult:\n");
                            operations.print(ref matrix1, ref n1, ref m1);
                        }
                        else if (C == 0)
                        {
                            for (int i = 0; i < n1; i++)
                            {
                                for (int j = 0; j < m1; j++)
                                {
                                    if (i == j) matrix1[i, j] = 1;
                                    else matrix1[i, j] = 0;
                                }
                            }
                            Console.WriteLine("\nResult:\n");
                            operations.print(ref matrix1, ref n1, ref m1);
                        }
                        else Console.WriteLine("Error! The degree must be non-negative.");
                    } while (false);

                    Console.WriteLine("\n------------------------------------------------------------------\n");

                }


                if (key.Key == ConsoleKey.NumPad5 || key.Key == ConsoleKey.D5)                  /*Element - wise multiplication of two matrices*/
                {
                    Console.WriteLine("\n------------------------------------------------------------------\n");
                    Console.WriteLine("**Element-wise multiplication of two matrices**\n");

                    bool error = false;
                    do
                    {
                        int n1, m1;
                        Console.WriteLine("\n-----\n");
                        Console.WriteLine("Enter the first matrix:\n");
                        Console.Write("Enter the number of first matrix rows: ");
                        n1 = Num_input(ref error);
                        if (error == true) break;
                        Console.Write("\nEnter the number of first matrix columns: ");
                        m1 = Num_input(ref error);
                        if (error == true) break;
                        double[,] matrix1 = new double[n1, m1];
                        Matrix_input(ref matrix1, ref n1, ref m1, ref error);
                        Console.WriteLine();
                        Console.WriteLine("\n-----\n");
                        if (error == true) break;

                        int n2, m2;
                        Console.WriteLine("\n-----\n");
                        Console.WriteLine("Enter the second matrix:\n");
                        Console.Write("Enter the number of second matrix rows: ");
                        n2 = Num_input(ref error);
                        if (error == true) break;
                        Console.Write("\nEnter the number of second matrix columns: ");
                        m2 = Num_input(ref error);
                        if (error == true) break;
                        double[,] matrix2 = new double[n2, m2];
                        Matrix_input(ref matrix2, ref n2, ref m2, ref error);
                        Console.WriteLine();
                        Console.WriteLine("\n-----\n");
                        if (error == true) break;

                        if (n1 != n2 || m1 != m2) { Console.WriteLine("Error! These matrices cannot be multiplied."); }
                        else
                        {
                            double[,] matrix3 = new double[n1, n2];
                            operations.el_wise_mult(ref matrix1, ref n1, ref m1, ref matrix2, ref matrix3);
                            Console.WriteLine("\nResult:\n");
                            operations.print(ref matrix3, ref n1, ref n2);
                        }
                    } while (false);
                    
                    Console.WriteLine("\n------------------------------------------------------------------\n");
                }



                if (key.Key == ConsoleKey.NumPad6 || key.Key == ConsoleKey.D6)                   /*Matrix determinant*/
                {
                    Console.WriteLine("\n------------------------------------------------------------------\n");
                    Console.WriteLine("**Matrix determinant**\n");

                    bool error = false;
                    do
                    {
                        int n1, m1;
                        Console.WriteLine("\n-----\n");
                        Console.WriteLine("Enter the matrix:\n");
                        Console.Write("Enter the number of matrix rows: ");
                        n1 = Num_input(ref error);
                        if (error == true) break;
                        m1 = n1;
                        double[,] matrix1 = new double[n1, m1];
                        Matrix_input(ref matrix1, ref n1, ref m1, ref error);
                        Console.WriteLine();
                        Console.WriteLine("\n-----\n");
                        if (error == true) break;

                        Console.WriteLine("\nResult:\n");
                        Console.WriteLine("{0}", operations.det(ref matrix1, ref n1));
                    } while (false);
                    
                    Console.WriteLine("\n------------------------------------------------------------------\n");
                }
                if (key.Key == ConsoleKey.NumPad7 || key.Key == ConsoleKey.D7)                 /*Matrix rank*/
                {
                    Console.WriteLine("\n------------------------------------------------------------------\n");
                    Console.WriteLine("**Matrix rank**\n");

                    bool error = false;
                    do
                    {
                        int n1, m1;
                        Console.WriteLine("\n-----\n");
                        Console.WriteLine("Enter the matrix:\n");
                        Console.Write("Enter the number of matrix rows: ");
                        n1 = Num_input(ref error);
                        if (error == true) break;
                        Console.Write("\nEnter the number of matrix columns: ");
                        m1 = Num_input(ref error);
                        if (error == true) break;
                        double[,] matrix1 = new double[n1, m1];
                        Matrix_input(ref matrix1, ref n1, ref m1, ref error);
                        Console.WriteLine();
                        Console.WriteLine("\n-----\n");
                        if (error == true) break;

                        Console.WriteLine("\nResult:\n");
                        Console.WriteLine("{0}", operations.Rank(matrix1));
                    } while (false);
                    
                    Console.WriteLine("\n------------------------------------------------------------------\n");
                }


                if (key.Key == ConsoleKey.NumPad8 || key.Key == ConsoleKey.D8)                    /*inverse matrix*/
                {
                    Console.WriteLine("\n------------------------------------------------------------------\n");
                    Console.WriteLine("**Inverse matrix**\n");

                    bool error = false;
                    do
                    {
                        int n1, m1;
                        Console.WriteLine("\n-----\n");
                        Console.WriteLine("Enter matrix:\n");
                        Console.Write("Enter matrix dimension: ");
                        n1 = Num_input(ref error);
                        if (error == true) break;
                        m1 = n1;
                        double[,] matrix1 = new double[n1, m1];
                        Matrix_input(ref matrix1, ref n1, ref m1, ref error);
                        Console.WriteLine();
                        Console.WriteLine("\n-----\n");
                        if (error == true) break;

                        if (operations.det(ref matrix1, ref n1) != 0)
                        {
                            double[,] matrix2 = new double[n1, m1];
                            operations.obr(ref matrix1, ref n1, ref matrix2);
                            Console.WriteLine("\nResult:\n");
                            operations.print(ref matrix2, ref n1, ref m1);

                        }
                        else
                        {
                            Console.WriteLine("\nResult:\n");
                            Console.WriteLine("Inverse matrix does not exist");
                        }
                    } while (false);


                    Console.WriteLine("\n------------------------------------------------------------------\n");
                }
                }
                ConsoleKeyInfo key2 = Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}
