using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Calculus
{
    internal class Operations
    {
        public void Minor_create(ref double[,] matrix, ref int n, ref double[,] minor, ref int col, ref int row)
        {

            for (int i=0;i<n;i++)
            {
                for (int j=0;j<n;j++)
                {
                    if (j!=col)
                    {
                        if (j<col && i<row) minor[i,j]=matrix[i,j];
                        if (j < col && i > row) minor[i - 1, j] = matrix[i, j];
                        if (j>col && i>row) minor[i-1,j-1]=matrix[i,j];
                        if (j > col && i < row) minor[i, j - 1] = matrix[i, j];
                    }
                }
            }
        }
        public int Rank(double[,] matrix)
        {
            int rang = 0;
            int q = 1;

            while (q <= MinValue(matrix.GetLength(0), matrix.GetLength(1)))
            {
                double[,] matbv = new double[q, q];
                for (int i = 0; i < (matrix.GetLength(0) - (q - 1)); i++)
                {
                    for (int j = 0; j < (matrix.GetLength(1) - (q - 1)); j++)
                    {
                        for (int k = 0; k < q; k++)
                        {
                            for (int c = 0; c < q; c++)
                            {
                                matbv[k, c] = matrix[i + k, j + c];
                            }
                        }

                        if (det(ref matbv,ref q) != 0)
                        {

                            rang = q;
                        }
                    }
                }
                q++;
            }

            return rang;
        }
        private int MinValue(int a, int b)
        {
            if (a >= b)
                return b;
            else
                return a;
        }
        private double MinValue(double a, double b)
        {
            if (a >= b)
                return b;
            else
                return a;
        }
        public double det(ref double[,] matrix, ref int n)
        {
            double res = 0;
            if (n>2)
            {
                for (int j=0;j<n;j++)
                {
                    int minor_n = n - 1;
                    double[,] minor = new double[n - 1, n - 1];
                    int row = 0;
                    Minor_create(ref matrix, ref n, ref minor, ref j, ref row);
                    res += ((j + 1) % 2 == 1 ? 1 : -1) * matrix[0, j] * det(ref minor, ref minor_n);
                }
            }
            if (n==2)
            {
                return (matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]);
            }
            if (n==1) return matrix[0, 0];
            return res;
        }
        public void allied(ref double[,] matrix1, ref int n, ref double[,] matrix3)
        {
            double[,] matrix2=new double[n,n];
            for (int i=0;i<n;i++)
            {
                for (int j=0;j<n;j++)
                {
                    matrix2[i, j] = matrix1[j, i];
                }
            }


            for (int i=0;i<n;i++)
            {
                for (int j=0;j<n;j++)
                {
                    int minor_n = n - 1;
                    double[,] minor = new double[n - 1, n - 1];
                    Minor_create(ref matrix2, ref n, ref minor, ref j, ref i);
                    matrix3[i, j] = ((j+1 + i+1) % 2 == 0 ? 1 : -1) * det(ref minor, ref minor_n);
                }
            }
        }
        public void obr(ref double[,] matrix1, ref int n, ref double[,] matrix2)
        {
            double Det = det(ref matrix1, ref n);
            allied(ref matrix1, ref n, ref matrix2);
            for (int i=0;i<n;i++)
            {
                for (int j=0;j<n;j++)
                {
                    matrix2[i, j] = (1/Det) * matrix2[i, j];
                }
            }
        }
        public void el_wise_mult(ref double[,] matrix1, ref int n1, ref int m1, ref double[,] matrix2, ref double[,] matrix3)
        {
            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < m1; j++)
                {
                    matrix3[i, j] = matrix1[i, j] * matrix2[i, j];
                }
            }
        }
        public void multC(ref double[,] matrix1,ref int n1, ref int m1, ref double C, ref double[,] matrix2)
        {
            for (int i=0;i<n1;i++)
            {
                for (int j=0;j<m1;j++)
                {
                    matrix2[i, j] = matrix1[i, j] * C;
                }
            }
        }
        public void mult(ref double[,] matrix1, ref int n1, ref int m1, ref double[,] matrix2, ref int n2, ref int m2, ref double[,] matrix3)
        {
            for (int i=0;i<n1;i++)
            {
                for (int j=0;j<m2;j++)
                {
                    for (int inner = 0; inner < n2; inner++)
                    {
                        matrix3[i, j] += matrix1[i,inner]* matrix2[inner, j];
                    }
                }
            }
        }
        public void print(ref double[,] matrix, ref int n, ref int m)
        {
            for (int i=0;i<n;i++)
            {
                for (int j=0;j<m;j++)
                {
                    Console.Write("{0}\t", matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
        public void sum(ref double[,] matrix1,ref int n1, ref int m1, ref double[,] matrix2, ref double[,] matrix3)
        {
            for (int i=0;i<n1;i++)
            {
                for (int j=0;j<m1;j++)
                {
                    matrix3[i, j] = matrix1[i, j] + matrix2[i,j];
                }
            }
        }
    }
}
