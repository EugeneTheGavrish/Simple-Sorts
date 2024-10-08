using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursovaMain
{
    public partial class ТренажерПСС : Form
    {
        private Form active;

        public ТренажерПСС()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.TransparencyKey = BackColor;
            panel2.BackColor = Color.FromArgb(68, 68, 68);
            panel1.BackColor = Color.FromArgb(51, 51, 51);

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
        }
        private void PanelForm(Form fm)
        {
            if ((active!=null))
            {
                active.Close();

            }
            active = fm;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            this.panel2.Controls.Add( fm );
            this.panel2.Tag = fm;
            fm.BringToFront();
            fm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PanelForm(new bulbash());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PanelForm(new vstavka());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PanelForm(new viborom());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox1.Location = new Point(0, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PanelForm(new ТренажерПСС());

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Gray;
            panel1.BackColor = Color.LightGray;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel1.BackColor= Color.FromArgb(51, 51, 51);
            panel2.BackColor = Color.FromArgb(68, 68, 68);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label8.Visible = true;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label8.Visible = false;
            label9.Visible = true;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = true;
            label11.Visible = false;
            label12.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = true;
            label12.Visible = true;
        }
    }
}
