using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
	class Asteroid : GameObject
	{
		private int rotationDir;
		private double rotationSpeed;
		private int health;



		public int Health
		{
			get { return health; }
		}


		public Asteroid(int x, int y, int r, Vector v, int RotationDir, double RotationSpeed) : base(x, y, r, v)
		{
			Angle = 0;
			health = 1;
			rotationDir = RotationDir;
			rotationSpeed = RotationSpeed;

			base.points = new Point[8];
			UpdatePoints();
		}

		




		private void UpdatePoints()
		{


			for (int i = 0; i < points.Length; i++)
			{
				points[i].X = this.XPos + (int)(this.HitBoxRadius * Math.Cos(Angle + (i * Math.PI) / ((points.Length /2) - 1)));
				points[i].Y = this.YPos + (int)(this.HitBoxRadius * Math.Sin(Angle + (i * Math.PI) / ((points.Length /2) - 1)));
			}

		}


		public override void UpdatePostion()
		{
			base.UpdatePostion();
			Angle += rotationSpeed * rotationDir;
			UpdatePoints();
		}


		public void CheckProjectileCollision(List<Projectile> projectiles)
		{
			for (int i = 0; i < projectiles.Count; i++)
			{
				double dist =Math.Sqrt(Math.Pow(this.XPos - projectiles[i].XPos, 2) + Math.Pow(this.YPos - projectiles[i].YPos, 2));

				if (dist <= this.HitBoxRadius + projectiles[i].HitBoxRadius)
				{
					health -= projectiles[i].Damage;
					projectiles[i].collision();
				}

			}
		}
	}
}
