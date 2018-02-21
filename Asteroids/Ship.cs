using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
	class Ship : GameObject
	{

		private Vector thrust;

		public Vector Thrust
		{
			get { return thrust; }
			set { thrust = value; }
		}

		private bool thrusting;

		public bool Thrusting
		{
			get { return thrusting; }
			set { thrusting = value; }
		}


		public Ship(int x, int y, int r, Vector v) : base(x, y , r ,v)
		{
			


		}


		public void UpdateVelocity()
		{
			Velocity += Thrust;

		}
	}
}
