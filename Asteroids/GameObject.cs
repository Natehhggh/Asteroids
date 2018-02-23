using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Asteroids
{

	abstract class GameObject
	{
		private int xPos;	
		private int yPos;
		private int hitBoxRadius;
		private Vector velocity;

		public int XPos
		{
			get { return xPos; }
			set { xPos = value; }
		}

		public int YPos
		{
			get { return YPos; }
			set { YPos = value; }
		}

		public int HitBosRadius
		{
			get { return hitBoxRadius; }
			set { hitBoxRadius = value; }
		}

		public  Vector Velocity
		{
			get { return velocity; }
			set { velocity = value; }
		}

		public GameObject(int x, int y, int r, Vector v)
		{
			xPos = x;
			yPos = y;
			hitBoxRadius = r;
			velocity = v;
		}

		virtual public void UpdatePostion()
		{
			this.XPos += velocity.X;
			this.YPos += velocity.Y;
		}

	}
}
