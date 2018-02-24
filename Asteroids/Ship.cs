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
		private int maxSpeed;
		private sbyte turning;
		private double turnAngle = Math.PI / 50;

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
			Thrust = t;
			MaxSpeed = max;
			Angle = -Math.PI / 2;
			base.points = new Point[4];
			UpdatePoints();
		}


		public void UpdateVelocity()
		{
			Velocity += Thrust;
			
			if ( Velocity.GetMagnitude() > MaxSpeed)
			{
				Velocity = Velocity / (Velocity.GetMagnitude() / MaxSpeed);
			}
			Debug.WriteLine("Player Speed: " + Velocity.GetMagnitude());
			Debug.WriteLine("Max Speed: " + MaxSpeed);
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
			double x = Thrust.X, y =  Thrust.Y;
			if (turning == -1)
			{
				Angle += turnAngle;
			}
			else
			{
				Angle -= turnAngle;
			}
			//TODO: fix, Keeps setting thrust to (0,0)
			Thrust.X = (int)(x * Math.Cos(Angle) - y * Math.Sin(Angle));
			Thrust.Y = (int)(y * Math.Cos(Angle) + x * Math.Sin(Angle));
		}
	}
}
