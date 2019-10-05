using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
	abstract class GameObject
	{
		private int xPos;	
		private int yPos;
		private int hitBoxRadius;
		private Vector velocity;
		private double angle;
		protected Point[] points;

		public int XPos
		{
			get { return xPos; }
			set { xPos = value; }
		}

		public int YPos
		{
			get { return yPos; }
			set { yPos = value; }
		}

		public int HitBoxRadius
		{
			get { return hitBoxRadius; }
			set { hitBoxRadius = value; }
		}

		public  Vector Velocity
		{
			get { return velocity; }
			set { velocity = value; }
		}

		public double Angle
		{
			get { return angle; }
			set { angle = value; }
		}

		public GameObject(int x, int y, int r, Vector v)
		{
			xPos = x;
			yPos = y;
			hitBoxRadius = r;
			velocity = new Vector(v);
		}

		virtual public void UpdatePostion()
		{
			this.XPos += (int)velocity.X;
			this.YPos += (int)velocity.Y;

			if(XPos > 800)
			{
				this.XPos -= 800;
			}
			else if(XPos < 0)
			{
				this.XPos += 800;
			}

			if (YPos > 600)
			{
				this.YPos -= 600;
			}
			else if (YPos < 0)
			{
				this.YPos += 600;
			}

		}
		virtual public void DrawObject(PaintEventArgs e)
		{
			//g.DrawEllipse(Pens.Red, XPos - HitBoxRadius, YPos - HitBoxRadius, HitBoxRadius * 2, HitBoxRadius * 2);
			e.Graphics.DrawLines(Pens.White, points);
		}

	}
}
