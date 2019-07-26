using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mailSenderandcolorfulboxes
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        int[] rastgelemayin = new int[5];
        int counter = 0;

        private void Form2_Load(object sender, EventArgs e)
        {

            int x = 50;
            int y = 50;

            for (int i = 0; i < 5; i++)
            {
                int rastgele = rnd.Next(1, 25);
                if (rastgelemayin.Contains(rastgele))
                {
                    i--;
                }
                else
                {

                    rastgelemayin[i] = rastgele;
                }
            }



            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button btn = new Button();
                    
                    btn.BackColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                    btn.Width = 50;
                    btn.Height = 50;
                    btn.Left = x;
                    btn.Top = y;
                    btn.Tag = counter;
                    btn.Click += Btn_Click; 

                    this.Controls.Add(btn);
                    x += 50;
                    counter++;

                }
                x = 50;
                y += 50;
            }
            timer1.Interval = 1;
            timer1.Start();
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Control item in Controls)
            {
                if (item is Button)
                {
                    item.BackColor= Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                }
            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int tagnumber = Convert.ToInt32(btn.Tag);
            if (rastgelemayin.Contains(tagnumber))
            {
                timer1.Stop();
                foreach (Control item in Controls)
                {
                    if (item is Button)
                    {
                        btn.Text = "BOOM";
                        btn.BackColor = Color.White;
                        item.BackColor = Color.Black;
                    }
                }
            }
        }
    }

}