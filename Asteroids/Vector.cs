using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Asteroids
{
	class Vector
	{
		private double magnitude;
		private double direction;

		public double Magnitude
		{
			get { return this.magnitude; }
			set { this.magnitude = value; }
		}
		public double Direction
		{
			get { return this.direction; }
			set {
				while(value > 2 * Math.PI)
				{
					value -=  2 * Math.PI;
				}
				this.direction = value;
			}
		}

		public Vector()
		{
			Magnitude = 0;
			Direction = 0;
		}
		public Vector(double mag, double dir)
		{
			Magnitude = mag;
			Direction = dir;
		}


		public int getX()
		{
			return (int)(this.magnitude * Math.Cos(direction));
		}

		public int getY()
		{
			return (int)(this.magnitude * Math.Sin(direction));
		}


		//TODO Check Math, Probably shit
		public static Vector operator +(Vector v1, Vector v2)
		{
			int x, y;
			x = v1.getX() + v2.getX();
			y = v1.getY() + v2.getY();
			double a = 0;
			double m = Math.Sqrt(x * x + y * y);
			if(x == 0)
			{
				a = Math.PI / 2;
				if(y < 0)
				{
					a += Math.PI;
				}
			}
			else
			{
				a = Math.Atan(y / x);
			}
			

			if(x < 0)
			{
				a += Math.PI;
			}

			Vector v3 = new Vector(m,a);


			return v3;
		}

	}
}
