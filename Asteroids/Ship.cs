using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace Asteroids
{
	class Ship : GameObject
	{
		private Vector thrust;
		private Vector thrustPrime;
		private int maxSpeed;
		private sbyte turning;
		private bool thrusting;
		private static double turnAngle = Math.PI / 50;

		public Vector Thrust
		{
			get { return thrust; }
			set { thrust = value; }
		}

		public Vector ThrustPrime
		{
			get { return thrustPrime; }
			set { thrustPrime = value; }
		}

		public int MaxSpeed
		{	
			get { return maxSpeed; }
			set { maxSpeed = value; }
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

		public Ship(int x, int y, int r, Vector v, Vector t, int max) : base(x, y , r ,v)
		{
			Thrusting = false;
			Thrust = new Vector(t.X,t.Y);
			ThrustPrime = new Vector(t.X, t.Y);
			MaxSpeed = max;
			Angle = 0;
			base.points = new Point[4];
			UpdatePoints();
			
		}

		public void UpdateVelocity()
		{
			Velocity += ThrustPrime;
			
			if ( Velocity.GetMagnitude() > MaxSpeed)
			{
				Velocity = Velocity / (Velocity.GetMagnitude() / MaxSpeed);
			}
			//Debug.WriteLine("Player Speed: " + Velocity.GetMagnitude());
			//Debug.WriteLine("Max Speed: " + MaxSpeed);
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
		
		public void UpdateAngle()
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
			Debug.WriteLine("Thrust X: " + Thrust.X);
			Debug.WriteLine("Thrust Y: " + Thrust.Y);
			Debug.WriteLine("Thrust' X: " + ThrustPrime.X);
			Debug.WriteLine("Thrust' Y: " + ThrustPrime.Y);
		}
	}
}
