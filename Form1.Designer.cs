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
            this.timer = new System.Windows.Forms.Timer();
            this.timer.Interval = 200;
            this.timer.Tick += this.OnTick;
            this.MI_animation = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_animation.Text = "Animation";
            this.MI_animation.Click += SelectNewFile;
            this.MI_sound = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_sound.Text = "Sound";
            this.MI_sound.Click += SelectNewFileSound;
            this.MS_toolbar = new System.Windows.Forms.MenuStrip();
            this.MS_toolbar.Items.Add(this.MI_animation);
            this.MS_toolbar.Items.Add(this.MI_sound);
            this.components = new System.ComponentModel.Container();
            this.Controls.Add(MS_toolbar);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Pixel Animation Tester";
        }

        #endregion
    }
}

