using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Курсач
{
    partial class Form1
    {
        
        
        TimeSpan time;
        bool GameEnd = false;
        bool GameStart = false;
        bool FirstClick = true;
        private System.Drawing.Point point;
        SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\Никита\source\repos\Курсач v2.0\Курсач\Курсач\bin\Debug\Sounds\MOON - Dust [Hotline Miami 2 OST] (online-audio-converter.com).wav");

        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            // Музыка
            Thread thread = new Thread(soundPlayer.PlayLooping);
            thread.Start();
            //

            for (int i = 0; i < buttons.Length; i++)
                this.buttons[i] = new System.Windows.Forms.Button();
            this.SuspendLayout();
            int k = 0;
            var rnd = new Random();

            int pictureFile = rnd.Next(1, 6);

            for (int i = 0; i < Math.Sqrt(buttons.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(buttons.Length); j++)
                {
                    if (k != 15)
                    {
                        this.buttons[k].Cursor = System.Windows.Forms.Cursors.Hand;
                        this.buttons[k].Location = new System.Drawing.Point(300 + j * 76, 100 + i * 76);
                        this.points[k].X = this.buttons[k].Location.X;
                        this.points[k].Y = this.buttons[k].Location.Y;
                        this.buttons[k].Name = "button" + k.ToString();
                        this.buttons[k].Size = new System.Drawing.Size(75, 75);
                        this.buttons[k].TabIndex = 0;
                        this.buttons[k].UseVisualStyleBackColor = true;
                        this.buttons[k].BackColor = System.Drawing.Color.FromArgb(81, 81, 81);
                        this.buttons[k].FlatAppearance.BorderSize = 0;
                        this.buttons[k].FlatStyle = System.Windows.Forms.FlatStyle.Flat;

                        this.buttons[k].BackgroundImage = new Bitmap(@"C:\Users\Никита\source\repos\Курсач v2.0\Курсач\Курсач\bin\Debug\Pictures\" + pictureFile.ToString() + @"\" + k.ToString() + ".jpg");
                        this.buttons[k].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        this.buttons[k].Click += Button_Click;
                        this.buttons[k].Click += TimerStart;

                        k++;
                    }
                    else point = new System.Drawing.Point(300 + j * 76, 100 + i * 76);


                }
            }
            //label
            this.label.Location = point;
            this.label.Size = new System.Drawing.Size(75, 75);
            this.label.BackColor = Color.FromArgb(186, 178, 201);
            this.label.Name = "label";
            this.label.TabIndex = 0;
            this.label.Show();

            //labelTimer
            this.labelTimer.Location = new Point(300, 20);
            this.labelTimer.Size = new System.Drawing.Size(100, 55);
            this.labelTimer.BackColor = Color.FromArgb(186, 178, 201);
            this.labelTimer.Name = "label1";
            this.labelTimer.TabIndex = 0;
            //TODO: сделать текст
            this.labelTimer.Show();



            // Form1

            this.BackColor = Color.FromArgb(226, 218, 241);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            for (int i = 0; i < buttons.Length; i++)
                this.Controls.Add(this.buttons[i]);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Controls.Add(this.label);
            this.Controls.Add(this.labelTimer);
            this.ResumeLayout(false);
            this.FormClosed += Form1_FormClosed;

            Mix();
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            GameEnd = true;
            soundPlayer.Stop();



        }

        async private void Mix()
        {

            await Task.Run(() =>
            {
                Thread.Sleep(1000);
                for (int j = 0; j < 50 && !GameStart; j++)
                {
                    for (int i = 0; i < buttons.Length; i++)
                    {
                        Button_Click(buttons[i], new EventArgs());
                    }
                }

            });
            GameStart = true;
        }
        private bool Victory()
        {
            bool t = true;
            for (int i = 0; i < buttons.Length; i++)
            {
                if (!(buttons[i].Location.X == points[i].X && buttons[i].Location.Y == points[i].Y))
                {
                    t = false;
                }
            }
            return t && GameStart;
        }

        private void Button_Click(object sender, EventArgs e)
        {

            var but = (System.Windows.Forms.Button)sender;
            if (Math.Abs(point.X - but.Location.X) == 76 && point.Y == but.Location.Y)
            {
                System.Drawing.Point p = new System.Drawing.Point();
                p = but.Location;
                if (but.Location.X < point.X)
                    for (int i = but.Location.X; i <= point.X; i++)
                    {
                        but.Location = new Point(but.Location.X + 1, but.Location.Y);
                        //Thread.Sleep(1);
                    }
                if (but.Location.X > point.X)
                    for (int i = but.Location.X; i > point.X; i--)
                    {
                        but.Location = new Point(but.Location.X - 1, but.Location.Y);
                        // Thread.Sleep(1);
                    }

                point = p;


            }
            if (Math.Abs(point.Y - but.Location.Y) == 76 && point.X == but.Location.X)
            {
                System.Drawing.Point p = new System.Drawing.Point();
                p = but.Location;
                if (but.Location.Y < point.Y)
                    for (int i = but.Location.Y; i <= point.Y; i++)
                    {
                        but.Location = new Point(but.Location.X, but.Location.Y + 1);
                        // Thread.Sleep(1);
                    }
                if (but.Location.Y > point.Y)
                    for (int i = but.Location.Y; i > point.Y; i--)
                    {
                        but.Location = new Point(but.Location.X, but.Location.Y - 1);
                        // Thread.Sleep(1);
                    }

                point = p;
            }
            if (Victory())
            {
                GameEnd = true;
                Form3 form3 = new Form3(time);
                form3.Show();



            }
        }

        async private void TimerStart(object sender, EventArgs e)
        {


            if (GameStart && FirstClick)
            {
                DateTime dateTime = DateTime.Now;
                FirstClick = false;
                await Task.Run(() =>
                {
                    while (!GameEnd)
                    {
                        time = DateTime.Now - dateTime;
                        labelTimer.Text = time.ToString();//.Remove(11).Remove(0, 3);
                    }
                });




            }
        }






        #endregion
        private Point[] points = new Point[15];
        private System.Windows.Forms.Button[] buttons = new System.Windows.Forms.Button[15];
        private System.Windows.Forms.Label label = new System.Windows.Forms.Label();
        private Label labelTimer = new Label();
    }
}

