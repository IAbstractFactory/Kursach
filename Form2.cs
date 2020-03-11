using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач
{
    public partial class Form2 : Form
    {
        
        SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\Никита\source\repos\Курсач v2.0\Курсач\Курсач\bin\Debug\Sounds\01 Untitled (1).wav");

        public Form2()
        {
            InitializeComponent();
            Thread thread = new Thread(soundPlayer.PlayLooping);
            thread.Start();
            FontSize();
            //LabelMooving();
            
        }
        async private void FontSize()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    for (int i = 45; i < 48; i++)
                    {
                        Thread.Sleep(350);
                        this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", i, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    }

                }


            });
        }
        async private void LabelMooving()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    for (int i = label1.Location.X; i < this.Size.Width - label1.Width; i++)
                    {
                        label1.Location = new Point(label1.Location.X + 1, label1.Location.Y);
                        Thread.Sleep(10);
                    }
                    for (int i = label1.Location.X; i > 0; i--)
                    {
                        label1.Location = new Point(label1.Location.X - 1, label1.Location.Y);
                        Thread.Sleep(10);
                    }
                }

            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            soundPlayer.Stop();
            Form1 form1 = new Form1();
            form1.Show();





        }

        private void button2_Click(object sender, EventArgs e)
        {
            
   
        }
    }
}
