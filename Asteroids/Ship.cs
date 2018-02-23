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
		private int maxSpeed;

		public Vector Thrust
		{
			get { return thrust; }
			set { thrust = value; }
		}

		public int MaxSpeed
		{
			get { return maxSpeed; }
			set { maxSpeed = value; }
		}

		private bool thrusting;

		public bool Thrusting
		{
			get { return thrusting; }
			set { thrusting = value; }
		}


		public Ship(int x, int y, int r, Vector v) : base(x, y , r ,v)
		{
			Thrusting = false;
		}


		public void UpdateVelocity()
		{
			Velocity += Thrust;
		}

		public override void UpdatePostion()
		{
			if (Thrusting)
			{
				UpdateVelocity();
			}
			base.UpdatePostion();
		}
	}
}
