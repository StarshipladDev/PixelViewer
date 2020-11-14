using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Configuration;

namespace PixelPlayer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip MS_toolbar;
        private System.Windows.Forms.ToolStripItem MI_animation;
        private System.Windows.Forms.ToolStripItem MI_sound;
        private System.Windows.Forms.ToolStripItem MI_config;
        private System.Windows.Forms.ToolStripItem MI_help;

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
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
            this.timer = new System.Windows.Forms.Timer();
            this.timer.Interval = 200;
            this.timer.Tick += this.OnTick;
            //Animation
            this.MI_animation = new System.Windows.Forms.ToolStripMenuItem();
            //this.MI_animation.Text = "Animation";
            this.MI_animation.Click += SelectNewFile;
            this.MI_animation.Image = new Bitmap("Animation.png");

            this.MI_animation.Size = new Size(100, 20);
            MI_animation.ImageAlign = ContentAlignment.MiddleLeft;
            MI_animation.ImageScaling = ToolStripItemImageScaling.None;
            //Sound

            this.MI_sound = new System.Windows.Forms.ToolStripMenuItem();

            //this.MI_sound.Text = "Sound";
            this.MI_sound.Click += SelectNewFileSound;
            this.MI_sound.Image = new Bitmap("Sound.png");

            this.MI_sound.Size = new Size(100, 20);
            MI_sound.ImageAlign = ContentAlignment.MiddleLeft;
            MI_sound.ImageScaling = ToolStripItemImageScaling.None;

            //Config

            this.MI_config = new System.Windows.Forms.ToolStripMenuItem();
            //this.MI_config.Text = "Config";
            this.MI_config.Click += OpenConfigForm;
            this.MI_config.Image = new Bitmap("Config.png");

            this.MI_config.Size = new Size(100, 20);
            MI_config.ImageAlign = ContentAlignment.MiddleLeft;
            MI_config.ImageScaling = ToolStripItemImageScaling.None;
            //HELP

            this.MI_help = new System.Windows.Forms.ToolStripMenuItem();
            //this.MI_help.Text = "Help";
            this.MI_help.Image = new Bitmap("Help.png");
            this.MI_help.Size = new Size(100, 20);
            MI_help.ImageAlign = ContentAlignment.MiddleLeft;
            MI_help.ImageScaling = ToolStripItemImageScaling.None;

            this.MI_help.Click += OpenHelpDialog;
            this.MS_toolbar = new System.Windows.Forms.MenuStrip();
            this.MS_toolbar.Items.Add(this.MI_animation);
            this.MS_toolbar.Items.Add(this.MI_sound);
            this.MS_toolbar.Items.Add(this.MI_config);

            this.MS_toolbar.Items.Add(this.MI_help);
            this.MS_toolbar.BackColor = Color.FromArgb(255,100,100,100 );
            this.components = new System.ComponentModel.Container();
            this.Controls.Add(MS_toolbar);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Icon = new System.Drawing.Icon("PixelPlayer.ico");
            this.Text = "Pixel Animation Tester";
            this.BackColor = Color.FromArgb(255, 100, 100, 100);
        }

        #endregion
    }
}

