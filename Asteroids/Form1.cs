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
			PbxCanvas.Invalidate();
		}

		private void PbxCanvas_Paint(object sender, PaintEventArgs e)
		{
			g = PbxCanvas.CreateGraphics();


			e.Graphics.FillRectangle(Brushes.Black, 0, 0, 800, 600);

			DrawGameObjects();
		}

		private void DrawGameObjects()
		{
			player.DrawObject(g);
			foreach (GameObject item in projectiles)
			{
				item.DrawObject(g);
			}
		}

		private void CreateGameObjects()
		{
			player = new Ship(400, 300, 10, new Vector(0, 0));
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
