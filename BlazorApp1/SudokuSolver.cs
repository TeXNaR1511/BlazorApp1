namespace BlazorApp1
{
    public class SudokuSolver
    {
        public SudokuSolver()
        {

        }

        public int[,] SolveSudoku(int[,] grid, int D)
        {
            int R = D;
            int C = D;
            int N = D * D;

            List<Tuple<string, Tuple<int, int>>> X = new List<Tuple<string, Tuple<int, int>>>();

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    X.Add(new Tuple<string, Tuple<int, int>>("rc", new Tuple<int, int>(i, j)));
                    X.Add(new Tuple<string, Tuple<int, int>>("rn", new Tuple<int, int>(i, j + 1)));
                    X.Add(new Tuple<string, Tuple<int, int>>("cn", new Tuple<int, int>(i, j + 1)));
                    X.Add(new Tuple<string, Tuple<int, int>>("bn", new Tuple<int, int>(i, j + 1)));
                }
            }

            Dictionary<Tuple<int, int, int>, List<Tuple<string, Tuple<int, int>>>> Y = new Dictionary<Tuple<int, int, int>, List<Tuple<string, Tuple<int, int>>>>();

            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    for (int n = 1; n <= N; n++)
                    {
                        int b = (r / R) * R + (c / C) * C;
                        Y[new Tuple<int, int, int>(r, c, n)] = new List<Tuple<string, Tuple<int, int>>>
                        { 
                            new Tuple<string, Tuple<int, int>>("rc", new Tuple<int, int>(r, c)),
                            new Tuple<string, Tuple<int, int>>("rn", new Tuple<int, int>(r, n)),
                            new Tuple<string, Tuple<int, int>>("cn", new Tuple<int, int>(c, n)),
                            new Tuple<string, Tuple<int, int>>("bn", new Tuple<int, int>(b, n)),
                        };
                    }
                }
            }

            //(X, Y) = 

            return grid;
        }

        
    }
}
