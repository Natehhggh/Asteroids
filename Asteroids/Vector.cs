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
		public Vector(float mag, float dir)
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


		//TODO
		public static Vector operator +(Vector v1, Vector v2)
		{
			Vector v3 = new Vector();




			return v3;
		}

	}
}
