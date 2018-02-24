using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Asteroids
{
	class Vector
	{

		private double x;
		private double y;

		public double X
		{
			get { return this.x; }
			set { this.x = value; }
		}
		public double Y
		{
			get { return this.y; }
			set { this.y = value; }
		}


		public Vector()
		{
			X = 0;
			Y = 0;
		}
		public Vector(double a, double b)
		{
			X = a;
			Y = b;
		}


		public static Vector operator +(Vector v1, Vector v2)
		{
			Vector v3 = new Vector(v1.X + v2.X, v1.Y + v2.Y);
			return v3;
		}

		public static Vector operator /(Vector v1, double scalar)
		{
			double a, b;
			a = v1.x;
			b = v1.y;
			Vector v3 = new Vector((int)(a / scalar), (int)(b / scalar));
			return v3;
		}

		public double GetMagnitude()
		{
			return Math.Sqrt(X * X + Y * Y);
		}

	}
}
