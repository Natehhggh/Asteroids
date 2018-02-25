using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
	class Projectile : GameObject
	{
		static private double speed = 15;

		static private int range = 2000;
		private int distanceTraveled;

		public double Speed
		{
			get { return speed; }
		}

		public int Range
		{
			get { return range; }
		}

		public int DistanceTraveled
		{
			get { return distanceTraveled; }
			set { distanceTraveled = value; }
		}

		public Projectile(int x, int y, int r, Vector v, double a) : base(x, y, r, v)
		{
			Velocity.X = Speed * Math.Cos(a);
			Velocity.Y = Speed * Math.Sin(a);
			distanceTraveled = 0;
		}

		public override void DrawObject(Graphics g)
		{
			g.FillEllipse(Brushes.White, this.XPos - HitBoxRadius, this.YPos - HitBoxRadius , this.HitBoxRadius * 2, this.HitBoxRadius * 2);
		}

		public override void UpdatePostion()
		{
			
			base.UpdatePostion();
			DistanceTraveled += (int)Velocity.GetMagnitude();
			
		}

		public bool OutOfRange()
		{
			return this.DistanceTraveled > this.Range;
		}
	}
}
