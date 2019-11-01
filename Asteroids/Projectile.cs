using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
	class Projectile : GameObject
	{
		static private double speed = 15;

		static private int range = 2000;
		static private int damage = 1;
		private  bool collided;
		private int distanceTraveled;

		public bool Collided
		{
			get { return collided; }
		}

		public double Speed
		{
			get { return speed; }
		}

		public int Damage
		{
			get { return damage; }
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

		public override void DrawObject(PaintEventArgs e)
		{
			e.Graphics.FillEllipse(Brushes.White, this.XPos - HitBoxRadius, this.YPos - HitBoxRadius , this.HitBoxRadius * 2, this.HitBoxRadius * 2);
		}

		public override void UpdatePostion()
		{
			
			base.UpdatePostion();
			DistanceTraveled += (int)Velocity.GetMagnitude();
			
		}


		public void collision()
		{
			collided = true;
		}




		public bool OutOfRange()
		{
			return this.DistanceTraveled > this.Range;
		}
	}
}
