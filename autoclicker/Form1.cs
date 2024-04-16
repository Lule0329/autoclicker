using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using System.Windows.Input;

namespace autoclicker
{
    public partial class Form1 : Form
    {
        InputSimulator input = new InputSimulator();
        int count;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out int X);
            int.TryParse(textBox2.Text, out int Y);

            int mouseX = (int)((65535.0 / Screen.PrimaryScreen.Bounds.Width) * X);
            int mouseY = (int)((65535.0 / Screen.PrimaryScreen.Bounds.Height) * Y);

            input.Mouse.MoveMouseTo(mouseX, mouseY);
            timer2.Interval = int.Parse(textBox3.Text) * 100;
            count = int.Parse(textBox3.Text);

            timer1.Start();
            timer2.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;

            textBox1.Text = X.ToString();
            textBox2.Text = Y.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            input.Mouse.LeftButtonClick();
            if (count == 0)
            {
                timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (count == 0)
            {
                timer2.Stop();
            }
            else
            {
                count -= 1;
            }
        }
    }
}
