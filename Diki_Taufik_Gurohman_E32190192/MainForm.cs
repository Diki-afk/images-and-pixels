/*
 * Created by SharpDevelop.
 * User: lenovo
 * Date: 25/03/2021
 * Time: 10:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Diki_Taufik_Gurohman_E32190192
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private System.Drawing.Bitmap gambar;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.Filter = "Image Files(*.PNG;*.BMP;*.JPG;*.JPEG;*.GIF)|*.PNG;*.BMP;*.JPG;" +
				"*.JPEG;*.GIF|All files (*.*)|*.*";
			
			if (openFileDialog1.ShowDialog ()== DialogResult.OK){
				gambar = (Bitmap) Bitmap.FromFile(openFileDialog1.FileName);
				pictureBox1.Image = gambar;
			}
		}
		void PictureBox1MouseDown(object sender, MouseEventArgs e)
		{
			if (gambar==null) return;
			Point p = e.Location;
			Image b = pictureBox1.Image;
			int x = b.Width * p.X / pictureBox1.Width;
			int y = b.Height * p.Y / pictureBox1.Height;
			Color c = gambar.GetPixel(x,y);
			pictureBoxColor.BackColor = c;
			
			label1.Text = "X: " + x.ToString() + "  Y: " + y.ToString();
			label2.Text = "R: " + c.R.ToString();
			label3.Text = "G: " + c.G.ToString();
			label4.Text = "B: " + c.B.ToString();
			
			pictureBox2.BackColor = Color.FromArgb(c.R, 0, 0);
			pictureBox3.BackColor = Color.FromArgb(0, c.G, 0);
			pictureBox4.BackColor = Color.FromArgb(0, 0, c.B);
		}
	}
}
