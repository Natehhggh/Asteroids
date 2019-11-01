using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Input;

//using System.Diagnostics;

namespace Asteroids
{
	

	public partial class FrmAsteroids : Form
	{
		#region Global Variables
		private Graphics g;
		private Ship player;
		private List<Projectile> projectiles;
		private List<Asteroid> asteroids;
		private Random random = new Random();
		private int NumAsteroids = 3;
		#endregion

		public FrmAsteroids()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			g = null;

			this.DoubleBuffered = true;

			projectiles = new List<Projectile>();
			asteroids = new List<Asteroid>();



			CreateGameObjects();

			PbxCanvas.Paint += new PaintEventHandler(PbxCanvas_Paint);
			TmrGameTimer.Start();
		}

		private void TmrGameTimer_Tick(object sender, EventArgs e)
		{

			//this.Invalidate();
			player.UpdatePostion();
			for (int i = 0; i < projectiles.Count; i++)
			{
				projectiles[i].UpdatePostion();
				if (projectiles[i].OutOfRange())
				{
					projectiles.RemoveAt(i);
					i--;
				}
			}

			for (int i = 0; i < asteroids.Count; i++)
			{
				asteroids[i].UpdatePostion();
			}


			//Hit Detection
			for (int i = 0; i < asteroids.Count; i++)
			{
				asteroids[i].CheckProjectileCollision(projectiles);
				if (asteroids[i].Health == 0)
				{
					asteroids.RemoveAt(i);
					i--;
				}
			}

			for (int i = 0; i < projectiles.Count; i++)
			{
				if (projectiles[i].Collided)
				{
					projectiles.RemoveAt(i);
					i--;
				}
			}


			PbxCanvas.Invalidate();
		}

		private void PbxCanvas_Paint(object sender, PaintEventArgs e)
		{


			e.Graphics.FillRectangle(Brushes.Black, 0, 0, 800, 600);

			DrawGameObjects(e);
		}

		private void DrawGameObjects(PaintEventArgs e)
		{
			player.DrawObject(e);
			foreach (GameObject item in projectiles)
			{
				item.DrawObject(e);
			}
			foreach (GameObject item in asteroids)
			{
				item.DrawObject(e);
			}
		}

		private void CreateGameObjects()
		{
			player = new Ship(400, 300, 10, new Vector(0, 0));

			for (int i = 0; i < NumAsteroids; i++)
			{
				//TODO make this less terrible
				asteroids.Add(new Asteroid(random.Next(0,800), random.Next(0,600), 50,
					new Vector( Math.Pow(-1, random.Next(0, 2)) * random.NextDouble() * random.Next(1,3), Math.Pow(-1, random.Next(0, 2)) * random.NextDouble() * random.Next(1, 3)),
					(int)Math.Pow(-1, random.Next(0,2)), random.Next(1,3) * (Math.PI / 50) ));
			}
			
		}

		#region Player Input

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Up:
					player.Thrusting = true;
					e.Handled = true;
					break;

				case Keys.Left:
					player.Turning = 1;
					e.Handled = true;
					break;

				case Keys.Right:
					player.Turning = -1;
					e.Handled = true;
					break;

				case Keys.Space:
					projectiles.Add(player.Fire());
					e.Handled = true;
					break;
			}
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Up:
					player.Thrusting = false;
					e.Handled = true;
					break;

				case Keys.Left:
				case Keys.Right:
					player.Turning  = 0;
					e.Handled = true;
					break;
			}
		}
		#endregion

	}
}
