using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Matrix
{

	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid  _grid;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			const int  dim = 10;

			// can use any symple type.
			double[,]  array = new double[dim,dim];

			Random ran = new Random();
			for(int r = 0; r < dim; r++)
			{
				for(int c = 0; c < dim; c++)
				{
					array[r,c] = (ran.Next(dim));
				}
			}
			string[] colnames = new string[dim];
			for(int c = 0; c < dim; c++)
			{
				colnames[c] = string.Format("-{0}-",c);
			}
			//dataGrid1.DataSource = new Mommo.Data.ArrayDataView(array);
			_grid.DataSource = new Mommo.Data.ArrayDataView(array,colnames);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._grid = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
			this.SuspendLayout();
			// 
			// _grid
			// 
			this._grid.CaptionVisible = false;
			this._grid.DataMember = "";
			this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this._grid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this._grid.Location = new System.Drawing.Point(0, 0);
			this._grid.Name = "_grid";
			this._grid.Size = new System.Drawing.Size(292, 266);
			this._grid.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this._grid);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}
