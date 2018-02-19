using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Asteroids
{
	public partial class Form1 : Form
	{


		public Form1()
		{
			InitializeComponent();
		}

		private void PbxCanvas_Paint(object sender, PaintEventArgs e)
		{
			//Debug.WriteLine("drawing");
			e.Graphics.FillRectangle(Brushes.Black, 0, 0, 100, 100);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.DoubleBuffered = true;
			//Debug.WriteLine("loading");
			TmrGameTimer.Start();
			PbxCanvas.Paint += new PaintEventHandler(PbxCanvas_Paint);

		}

		private void TmrGameTimer_Tick(object sender, EventArgs e)
		{

			//this.Invalidate();
			PbxCanvas.Invalidate();
		}
	}
}
