using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLib.Geometry
{
	public class Polygon
	{
		List<Point> _points;

		public Polygon(List<Point> points)
		{
			_points = points;
		}

		/// <summary>
		/// Calculates area of the polygon
		/// </summary>
		public double CalcArea()
		{
			double area = 0;
			int size = _points.Count;
			for(int i = 0; i < size; i++)
				area += 
					(_points[i].x + _points[(i + 1) % size].x) *
					(_points[i].y - _points[(i + 2) % size].y);
			return Math.Abs(area) / 2;
		}
	}	
}
