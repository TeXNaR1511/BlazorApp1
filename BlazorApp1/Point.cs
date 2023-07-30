namespace BlazorApp1
{
	public class Point
	{
		public double X;
		public double Y;

		//Constructors
		public Point()
		{
			X = 0.0;
			Y = 0.0;
		}

		public Point(double x, double y)
		{
			X = x;
			Y = y;
		}

		public static double Norm(Point a)
		{
			return Math.Sqrt(a.X * a.X + a.Y * a.Y);
		}

		public static double Distance(Point a, Point b)
		{
			return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
		}

		public override string ToString()
		{
			return "(" + Math.Round(X, 3).ToString().Replace(',', '.') + "," + Math.Round(Y, 3).ToString().Replace(',', '.') + ")";
		}

		public static bool operator ==(Point a, Point b)
		{
			return a.X == b.X && a.Y == b.Y;
		}

		public static bool operator !=(Point a, Point b)
		{
			return a.X != b.X || a.Y != b.Y;
		}

		public static Point operator +(Point a, Point b)
		{
			return new Point(a.X + b.X, a.Y + b.Y);
		}

		public static Point operator -(Point a, Point b)
		{
			return new Point(a.X - b.X, a.Y - b.Y);
		}

		public static Point operator -(Point a)
		{
			return new Point(-a.X, -a.Y);
		}

		public static double operator *(Point a, Point b)
		{
			return a.X * b.X + a.Y * b.Y;
		}

		public static Point operator *(Point a, double b)
		{
			return new Point(a.X * b, a.Y * b);
		}

		public static Point operator *(double a, Point b)
		{
			return new Point(a * b.X, a * b.Y);
		}

		public static Point operator /(Point a, double b)
		{
			return new Point(a.X / b, a.Y / b);
		}

		/// <summary>
		/// Return index of Point inside list if Point in list, otherwise return -1
		/// </summary>
		/// <param name="a"></param>
		/// <param name="list"></param>
		/// <returns></returns>
		public static int ContainsInList(Point a, List<Point> list)
		{
			int result = -1;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] == a)
				{
					result = i;
				}
			}
			return result;
		}

		/// <summary>
		/// Return index of Point inside list if Point in list, otherwise return -1
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public int ContainsInList(List<Point> list)
		{
			int result = -1;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] == this)
				{
					result = i;
				}
			}
			return result;
		}

		public override bool Equals(object obj)
		{
			var item = obj as Point;

			return item == this;
		}

		public override int GetHashCode()
		{
			return this.X.GetHashCode() ^ this.Y.GetHashCode();	
		}
	}
}
