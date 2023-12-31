﻿namespace BlazorApp1
{
    public class SudokuProblem
    {

        private int N;

        private Random r = new Random();

        public SudokuProblem(int N = 3)
        {
            this.N = N;
        }

        public int[,] Initial()
        {
            int[,] result = new int[N * N, N * N];
            for (int i = 0; i < N * N; i++)
            {
                for (int j = 0; j < N * N; j++)
                {
                    result[i, j] = (i * N + i / N + j) % (N * N) + 1;
                }
            }
            return result;
        }

        public int[,] Transpose(int[,] a)
        {
            int[,] result = new int[N * N, N * N];
            for (int i = 0; i < N * N; i++)
            {
                for (int j = 0; j < N * N; j++)
                {
                    result[i, j] = a[j, i];
                }
            }
            return result;
        }

        public int[,] SwapColumns(int[,] a, int i, int j)
        {
            for (int k = 0; k < N * N; k++)
            {
                (a[k, i], a[k, j]) = (a[k, j], a[k, i]);
            }
            return a;
        }

        public int[,] SwapRows(int[,] a, int i, int j)
        {
            for (int k = 0; k < N * N; k++)
            {
                (a[i, k], a[j, k]) = (a[j, k], a[i, k]);
            }
            return a;
        }

        public int[,] SmallSwapColumns(int[,] a)
        {
            int u = r.Next(0, N);
            int v = r.Next(0, N);
            int w = r.Next(0, N);
            return SwapColumns(a, u * N + v, u * N + w);
        }

        public int[,] SmallSwapRows(int[,] a)
        {
            int u = r.Next(0, N);
            int v = r.Next(0, N);
            int w = r.Next(0, N);
            return SwapRows(a, u * N + v, u * N + w);
        }

        public int[,] SwapAreaColumns(int[,] a, int i, int j)
        {
            for (int k = 0; k < N * N; k++)
            {
                for (int l = 0; l < N; l++)
                {
                    (a[k, i * N + l], a[k, j * N + l]) = (a[k, j * N + l], a[k, i * N + l]);
                }
            }
            return a;
        }

        public int[,] SwapAreaRows(int[,] a, int i, int j)
        {
            for (int k = 0; k < N * N; k++)
            {
                for (int l = 0; l < N; l++)
                {
                    (a[i * N + l, k], a[j * N + l, k]) = (a[j * N + l, k], a[i * N + l, k]);
                }
            }
            return a;
        }

        public int[,] BigSwapColumns(int[,] a)
        {
            return SwapAreaColumns(a, r.Next(0, N), r.Next(0, N));
        }

        public int[,] BigSwapRows(int[,] a)
        {
            return SwapAreaRows(a, r.Next(0, N), r.Next(0, N));
        }

        public int[,] Mix(int[,] a, int iterations = 15)
        {
            List<Func<int[,], int[,]>> functions = new List<Func<int[,], int[,]>>
            {
                Transpose,
                SmallSwapColumns,
                SmallSwapRows,
                BigSwapColumns,
                BigSwapRows,
            };

            for (int i = 0; i < iterations; i++)
            {
                a = functions[r.Next(0, 5)](a);
            }
    
            return a;
        }

        public int[,] CreateSolution()
        {
            return Mix(Initial());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="difficult">
        /// 0 - very easy, 1 - easy, 2 - medium, 3 - difficukt, 4 - evil
        /// </param>
        /// <returns></returns>
        public int[,] CreateProblem(int[,] a, int difficult)
        {
            //return a;
            int left = difficult == 0 ? 47 : difficult == 1 ? 36 : difficult == 2 ? 32 : difficult == 3 ? 28 : 17;
            int right = difficult == 0 ? 52 : difficult == 1 ? 47 : difficult == 2 ? 36 : difficult == 3 ? 32 : 28;
            int fill = r.Next(left, right);
            return SimpleAlgorithm(a, fill);
            //return ImprovedAlgorithm(a);
        }

        
        /// <summary>
        /// Simple algorithm for creating sudoku problem. It just remains fill number of cells 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="difficult"></param>
        /// <returns></returns>
        public int[,] SimpleAlgorithm(int[,] a, int fill)
        {
            List<int> viewed = new List<int>();
            while (viewed.Count < N * N * N * N - fill)
            {
                int t = r.Next(0, N * N * N * N);
                if (!viewed.Any(x => x == t))
                {
                    a[t / (N * N), t % (N * N)] = 0;
                    viewed.Add(t);
                }
            }
            return a;
        }

        public int[,] ImprovedAlgorithm(int[,] a)
        {
            int[,] b = new int[N * N, N * N];

            int iter = 0;
            int difficult = N * N * N * N;

            while (iter < N * N * N * N)
            {
                int i = r.Next(0, N * N);
                int j = r.Next(0, N * N);

                if (b[i, j] == 0)
                {
                    iter++;
                    b[i, j] = 1;

                    int temp = a[i, j];
                    a[i, j] = 0;
                    difficult--;


                }
            }
            return a;
        }
    }
}
