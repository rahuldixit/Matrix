using System;

namespace MatrixConsoleApplication 
{
    public class Matrix
    {
        private int[,] matrix { get; set; }
        private int Rows { get;  }
        private int Columns { get;  }

        public Matrix(int[,] array)
        {

            Columns = array.GetLength(0);
            Rows = array.GetLength(1);
            matrix = new int[Rows, Columns];
            matrix = array;            
        }

        public int this[int i, int j]
        {
            get { return matrix[i,j]; }
            set { matrix[i,j] = value; }
        }

        public static Matrix operator + (Matrix a, Matrix b)
        {
            int x = a.Rows;
            int y = a.Columns;
            var result = new Matrix(new int[x,y]);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }


        public static Matrix operator - (Matrix a, Matrix b)
        {
            int x = a.Columns;
            int y = a.Rows;
            var result = new Matrix(new int[x, y]);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }
            return result;
        }


        public static Matrix operator * (Matrix a, Matrix b)
        {
            int aColumns = a.Columns;
            int aRows = a.Rows;
            int bColumns = b.Columns;
            int bRows = b.Rows;

            if (aRows != bColumns)
            {
                throw new InvalidOperationException("Matrices are not of valid dimensions");
            }

            var result = new Matrix(new int[aColumns, bRows]);
            
            //rename ints to rows and clomuns to make it clearer
            for (int i = 0; i < bRows; i++)
            {
                for (int q = 0; q < aColumns; q++)
                {
                    var value = 0;
                    for (int j = 0; j < aRows; j++)
                    {
                        value += a.matrix[q, j] * b.matrix[j, i];
                    }
                    result.matrix[q, i] = value;
                }
            }
            return result;
        }

        public static bool operator == (Matrix a, Matrix b)
        {
            int aColumns = a.Columns;
            int aRows = a.Rows;
            int bColumns = b.Columns;
            int bRows = b.Rows;

            if (aColumns != bColumns & aRows != bRows)
            {
                throw new InvalidOperationException("Matrices are not of valid dimensions");
            }
            for (int i = 0; i < aColumns; i++)
            {
                for (int j = 0; j < aRows; j++)
                {
                    if (a.matrix[i,j] != b.matrix[i,j])
                        return false;
                }
            }
            return true;
        }

        public static bool operator != (Matrix a, Matrix b)
        {
            int aColumns = a.Columns;
            int aRows = a.Rows;
            int bColumns = b.Columns;
            int bRows = b.Rows;

            if (aColumns != bColumns & aRows != bRows)
            {
                throw new InvalidOperationException("Matrices are not of valid dimensions");
            }

            for (int i = 0; i < aColumns; i++)
            {
                for (int j = 0; j < aRows; j++)
                {
                    if (a.matrix[i, j] != b.matrix[i, j])
                        return true;
                }
            }
            return false;
        }       
    }
}
