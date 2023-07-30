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

		public static bool ContainsInList(Point a, List<Point> list)
		{
			bool result = false;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] == a)
				{
					result = true;
				}
			}
			return result;
		}

		public bool ContainsInList(List<Point> list)
		{
			bool result = false;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] == this)
				{
					result = true;
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
