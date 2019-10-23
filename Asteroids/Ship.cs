using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
//using System.Diagnostics;

namespace Asteroids
{
	class Ship : GameObject
	{
		#region private members

		private Vector thrust;
		private Vector thrustPrime;
		private int maxSpeed;
		private sbyte turning;
		private bool thrusting;
		private static double turnAngle = Math.PI / 50;
		private static int projectileRadius = 3;

		#endregion

		#region public members

		public Vector Thrust
		{
			get { return thrust; }
		}

		public Vector ThrustPrime
		{
			get { return thrustPrime; }
			set { thrustPrime = value; }
		}

		public int MaxSpeed
		{
			get { return maxSpeed; }
		}

		public bool Thrusting
		{
			get { return thrusting; }
			set { thrusting = value; }
		}

		public sbyte Turning
		{
			get { return turning; }
			set
			{
				if (value > 0)
				{
					turning = 1;
				}
				else if (value < 0)
				{
					turning = -1;
				}
				else
				{
					turning = 0;
				}
			}

		}

		#endregion

		#region constructors
		public Ship(int x, int y, int r, Vector v) : base(x, y, r, v)
		{
			Thrusting = false;
			maxSpeed = 50;
			Angle = 0;
			thrust = new Vector(1, 0);
			ThrustPrime = new Vector(thrust);

			base.points = new Point[4];
			UpdatePoints();
		}
		#endregion

		#region public methods

		public override void UpdatePostion()
		{
			if (Turning != 0)
			{
				UpdateAngle();
			}

			if (Thrusting)
			{
				UpdateVelocity();
			}
			base.UpdatePostion();

			UpdatePoints();
		}

		public Projectile Fire()
		{
			Projectile p = new Projectile(this.XPos, this.YPos, projectileRadius, new Vector(), Angle);
			return p;
		}

		#endregion

		#region private methods

		private void UpdateVelocity()
		{
			Velocity += ThrustPrime;

			if (Velocity.GetMagnitude() > MaxSpeed)
			{
				Velocity = Velocity / (Velocity.GetMagnitude() / MaxSpeed);
			}

		}

		private void UpdatePoints()
		{
			points[0].X = this.XPos + (int)(this.HitBoxRadius * Math.Cos(Angle));
			points[0].Y = this.YPos + (int)(this.HitBoxRadius * Math.Sin(Angle));
			points[1].X = this.XPos + (int)(this.HitBoxRadius * Math.Cos(Angle + (3 * Math.PI) / 4));
			points[1].Y = this.YPos + (int)(this.HitBoxRadius * Math.Sin(Angle + (3 * Math.PI) / 4));
			points[2].X = this.XPos + (int)(this.HitBoxRadius * Math.Cos(Angle + (5 * Math.PI) / 4));
			points[2].Y = this.YPos + (int)(this.HitBoxRadius * Math.Sin(Angle + (5 * Math.PI) / 4));
			points[3] = points[0];
		}



		private void UpdateAngle()
		{
			if (turning == -1)
			{
				Angle += turnAngle;
			}
			else
			{
				Angle -= turnAngle;
			}

			if (Angle > 2 * Math.PI)
			{
				Angle -= 2 * Math.PI;
			}
			else if (Angle < 0)
			{
				Angle += 2 * Math.PI;
			}
			ThrustPrime.X = ((Thrust.X * Math.Cos(Angle)) - (Thrust.Y * Math.Sin(Angle)));
			ThrustPrime.Y = ((Thrust.X * Math.Sin(Angle)) + (Thrust.Y * Math.Cos(Angle)));
		}

		#endregion


	}
}
