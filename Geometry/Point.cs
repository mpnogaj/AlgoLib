using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLib.Geometry
{
	public class Point
	{
		public readonly long x, y;
		public Point(long x, long y)
		{
			this.x = x;
			this.y = y;
		}

		/// <summary>
		/// Calculates distance from point x to line defined by p1 and p2
		/// </summary>
		public static double PointLineDist(Point p1, Point p2, Point x)
		{
			double A = p2.y - p1.y, B = p2.x - p1.x;
			double numerator = Math.Abs(A * (p1.x - x.x) + B * (x.y - p1.y));
			double denominator = Math.Sqrt(A * A + B * B);
			return numerator / denominator;
		}

		/// <summary>
		/// Calculates cross product for vectors a->b and a->c
		/// </summary>
		public static long CrossProduct(Point a, Point b, Point c)
			=> (b.x - a.x) * (c.y - a.y) - (b.y - a.y) * (c.x - a.x);

		#region Sort
		public static void SortByXY(ref List<Point> points)
			=> points.Sort(CompareByXY);

		public static void SortByYX(ref List<Point> points)
			=> points.Sort(CompareByYX);
		#endregion

		#region Comparators
		public static int CompareByXY(Point a, Point b)
			=> a.x == b.x 
				? a.y < b.y 
					? -1 
					: a.y == b.y 
						? 0
						: 1
				: a.x < b.x 
					? -1 
					: 1;

		public static int CompareByYX(Point a, Point b)
			=> a.y == b.y
				? a.x < b.x
					? -1
					: a.x == b.x
						? 0
						: 1
				: a.y < b.y
					? -1
					: 1;
		#endregion
		#region Operators
		public static bool operator ==(Point lhs, Point rhs)
			=> lhs.x == rhs.x && lhs.y == rhs.y;

		public static bool operator !=(Point lhs, Point rhs)
			=> lhs.x != rhs.x || lhs.y != rhs.y;
		#endregion
		#region Overrides
		public override string ToString()
			=> $"({x}, {y})";

		public override int GetHashCode()
			=> Tuple.Create(x, y).GetHashCode();

		public override bool Equals(object obj)
		{
			if (!(obj is Point)) return false;
			Point p = (Point)obj;
			return p == this;
		}
		#endregion
	}
}
