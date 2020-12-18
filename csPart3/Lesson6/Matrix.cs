using System;
using System.Threading.Tasks;

namespace Lesson6
{
    public class Matrix
    {

        private readonly int[,] _data;

        public Matrix(int rows, int cols)
        {
            _data = new int[rows, cols];
        }

        public void Randomize(int min, int max)
        {
            Random random = new Random();
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    _data[row, col] = random.Next(min, max);
                }
            }
        }

        public int Rows => _data.GetUpperBound(0) + 1;

        public int Cols => _data.GetUpperBound(1) + 1;

        /// <summary>
        /// Multiply in the same thread
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static Matrix operator *(Matrix m1, Matrix m2) => m1.Mul(m2);

        public int this[int row, int col]
        {
            get => _data[row, col];
            set => _data[row, col] = value;
        }

        /// <summary>
        /// Multiply in the same thread
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Matrix Mul(Matrix other)
        {
            if (this.Rows != other.Cols)
                throw new ArgumentException("this.Rows count is not equal to other.Cols");
            Matrix result = new Matrix(this.Rows, other.Cols);
            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Cols; col++)
                {
                    result[row, col] = MulRowCol(this, row, other, col);
                }
            }
            return result;
        }

        /// <summary>
        /// Multiply m1.Row * m2.Col in the same thread
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="row"></param>
        /// <param name="m2"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private static int MulRowCol(Matrix m1, int row, Matrix m2, int col)
        {
            //Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
            int result = 0;
            for (int i = 0; i < m1.Cols; i++)
            {
                result += m1[row, i] * m2[i, col];
            }
            return result;
        }

        /// <summary>
        /// Multiply with TPL | Parallel
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Matrix MulParallel(Matrix other)
        {
            if (this.Rows != other.Cols)
                throw new ArgumentException("this.Rows count is not equal to other.Cols");
            Matrix result = new Matrix(this.Rows, other.Cols);
            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Cols; col++)
                {
                    result[row, col] = MulParallelRowCol(this, row, other, col);
                }
            }
            return result;
        }

        /// <summary>
        /// Multiply m1.Row * m2.Col with TPL Parallel
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="row"></param>
        /// <param name="m2"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private static int MulParallelRowCol(Matrix m1, int row, Matrix m2, int col)
        {
            object lo = new object(); 
            int result = 0;
            ParallelLoopResult plr = Parallel.For(0, m1.Cols, (i) =>
            {
                lock (lo)
                {
                    result += m1[row, i] * m2[i, col];
                }
            });
            while (!plr.IsCompleted) ;
            return result;
        }

        /// <summary>
        /// Multiply with TPL | Task
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Matrix MulTask(Matrix other)
        {
            if (this.Rows != other.Cols)
                throw new ArgumentException("this.Rows count is not equal to other.Cols");
            Matrix result = new Matrix(this.Rows, other.Cols);
            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Cols; col++)
                {
                    Task<int> task = Task.Factory.StartNew(() => MulRowCol(this, row, other, col));
                    result[row, col] = task.Result;
                }
            }
            return result;
        }

        /// <summary>
        /// Multiply with TAP
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public async Task<Matrix> MulAsync(Matrix other)
        {
            if (this.Rows != other.Cols)
                throw new ArgumentException("this.Rows count is not equal to other.Cols");
            Matrix result = new Matrix(this.Rows, other.Cols);
            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Cols; col++)
                {
                    result[row, col] = await Task.Run(() => MulRowCol(this, row, other, col));
                }
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj is Matrix)
            {
                Matrix other = obj as Matrix;
                if ((this.Rows != other.Rows) || (this.Cols != other.Cols))
                    return false;

                for (int row = 0; row < Rows; row++)
                {
                    for (int col = 0; col < Cols; col++)
                    {
                        if (this[row, col] != other[row, col])
                            return false;
                    }
                }
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ 20;
        }
    }
}
