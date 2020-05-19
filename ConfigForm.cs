using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PixelPlayer
{
    class ConfigForm : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox TB_MaxFrames;
        private System.Windows.Forms.TextBox TB_cellSize;

        private System.Windows.Forms.TextBox TB_timerTimer;
        private System.Windows.Forms.TextBox TB_cellSizeText;
        private System.Windows.Forms.TextBox TB_maxFramesText;

        private System.Windows.Forms.TextBox TB_timerTimerText;
        private System.Windows.Forms.Button BT_accept;
        private Timer timer;
        public ConfigForm(Timer timer)
        {
            this.timer = timer;
            InitializeComponent();
        }
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
        private void Accept(object o, EventArgs e)
        {
            bool completed = true;
            int maxFramesInt = Int32.Parse(this.TB_MaxFrames.Text);
            int cellSizeInt = Int32.Parse(this.TB_cellSize.Text);
            int timerSpeedInt = Int32.Parse(this.TB_timerTimer.Text);
            if (maxFramesInt % 4 != 0)
            {
                MessageBox.Show("Error:MaxFrames must be a mutiple of 4");
                completed = false;
            }
            else if (cellSizeInt % 20 != 0)
            {
                MessageBox.Show("Error:Cell Size must be a mutiple of 20");
                completed = false;
            }
            if (completed)
                {

                    Globals.timer = timerSpeedInt;
                    timer.Interval = Globals.timer;
                    Globals.maxFrames = maxFramesInt;
                    Globals.cellSizePixels = cellSizeInt;
                    timer.Start();
                    this.Close();
                }
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);

            this.TB_cellSize = new TextBox();
            this.TB_MaxFrames = new TextBox();
            this.TB_maxFramesText = new TextBox();
            this.TB_cellSizeText = new TextBox();
            this.TB_timerTimer = new TextBox();
            this.TB_timerTimerText = new TextBox();
            this.BT_accept = new Button();
            this.components = new System.ComponentModel.Container();
            //CellSize
            this.TB_cellSize.Size = new System.Drawing.Size(100,50);
            this.TB_cellSize.Location = new System.Drawing.Point(150,50);

            this.TB_cellSize.Text = "400";
            //MaxFrames
            this.TB_MaxFrames.Size = new System.Drawing.Size(100, 50);
            this.TB_MaxFrames.Location = new System.Drawing.Point(150, 150);

            this.TB_MaxFrames.Text = "8";
            //TimerTime
            this.TB_timerTimer.Size = new System.Drawing.Size(100, 50);
            this.TB_timerTimer.Location = new System.Drawing.Point(150, 250);
            this.TB_timerTimer.Text = "200";
            //CellSizeLabel
            this.TB_cellSizeText.Size = new System.Drawing.Size(100, 50);
            this.TB_cellSizeText.Location = new System.Drawing.Point(0, 50);
            this.TB_cellSizeText.Enabled = false;
            this.TB_cellSizeText.Text = "CellSize(Pixels):";
            //Max Frames Label
            this.TB_maxFramesText.Size = new System.Drawing.Size(100, 50);
            this.TB_maxFramesText.Location = new System.Drawing.Point(0, 150);
            this.TB_maxFramesText.Enabled = false;
            this.TB_maxFramesText.Text = "Max Frames:";
            //TimerTime Label
            this.TB_timerTimerText.Size = new System.Drawing.Size(100, 50);
            this.TB_timerTimerText.Location = new System.Drawing.Point(0, 250);
            this.TB_timerTimerText.Enabled = false;
            this.TB_timerTimerText.Text = "Timer Speed(MS):";
            //Button
            this.BT_accept.Size = new System.Drawing.Size(100, 100);
            this.BT_accept.Location = new System.Drawing.Point(100,300);
            this.BT_accept.Text = "Accept";
            this.BT_accept.Click += Accept;
            //Add them all
            this.Controls.Add(TB_MaxFrames);
            this.Controls.Add(TB_cellSize);
            this.Controls.Add(TB_cellSizeText);
            this.Controls.Add(TB_maxFramesText);
            this.Controls.Add(TB_timerTimerText);
            this.Controls.Add(TB_timerTimer);
            this.Controls.Add(BT_accept);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200,400);
            this.Icon = new System.Drawing.Icon("Cog.ico");
            this.Text = "Pixel Animation Config";
        }
    }
}
