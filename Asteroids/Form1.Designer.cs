namespace Asteroids
{
	partial class FrmAsteroids
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAsteroids));
			this.TmrGameTimer = new System.Windows.Forms.Timer(this.components);
			this.PbxCanvas = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.PbxCanvas)).BeginInit();
			this.SuspendLayout();
			// 
			// TmrGameTimer
			// 
			this.TmrGameTimer.Interval = 10;
			this.TmrGameTimer.Tick += new System.EventHandler(this.TmrGameTimer_Tick);
			// 
			// PbxCanvas
			// 
			resources.ApplyResources(this.PbxCanvas, "PbxCanvas");
			this.PbxCanvas.Name = "PbxCanvas";
			this.PbxCanvas.TabStop = false;
			this.PbxCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.PbxCanvas_Paint);
			// 
			// FrmAsteroids
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.PbxCanvas);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FrmAsteroids";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
			((System.ComponentModel.ISupportInitialize)(this.PbxCanvas)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer TmrGameTimer;
		private System.Windows.Forms.PictureBox PbxCanvas;
	}
}

