namespace BlazorApp1
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
    }
}
