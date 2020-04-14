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

namespace PixelPlayer
{
    /// <summary>
    /// Form is the Primary paltform of 'PixelPlayer'. It creates a toolbar in the top of the form
    /// for the user to interact with, and dispalys the appropriate images in order, with attatched audio.
    /// </summary>
    public partial class Form1 : Form
    {
        int anim = 0;
        const int maxFrames = 8;
        Timer timer = new System.Windows.Forms.Timer();
        System.Media.SoundPlayer soundPlayer;
        Bitmap AnimationImageBase;
        Bitmap AnimationShow;
        public Form1()
        {
            InitializeComponent();
            this.timer.Start();
        }
        /// <summary>
        /// Crops a sub-rectangle of a given image
        /// </summary>
        /// <param name="source">The imagee file to draw a sub-image from</param>
        /// <param name="section">The specified size and position of the rectangle subimage</param>
        /// <returns></returns>
        private Bitmap CropImage(Bitmap source, Rectangle section)
        {
            var bitmap = new Bitmap(section.Width, section.Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
                return bitmap;
            }
        }
        /// <summary>
        /// SelectNewFile is an event listener for the toolbar to select a new image
        /// </summary>
        /// <param name="Sender">The object that called this handler</param>
        /// <param name="e">The arguments of the event occurence </param>
        private void SelectNewFile(object Sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();
            if (fd.FileName != String.Empty)
            {
                this.AnimationImageBase = new Bitmap(fd.FileName);
            }

        }
        /// <summary>
        /// SelectNewFile is an event listener for the toolbar to select a new sound
        /// </summary>
        /// <param name="Sender">The object that called this handler</param>
        /// <param name="e">The arguments of the event occurence </param>
        private void SelectNewFileSound(object Sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Wav Files | *.Wav;*.WAV";
            fd.ShowDialog();
            if (fd.FileName != String.Empty)
            {
                this.soundPlayer = new System.Media.SoundPlayer(fd.FileName);
            }

        }
        /// <summary>
        /// OnPaint is an override method to perform painting based on the animation 'step'
        /// </summary>
        /// <param name="e">The event arguments for this particular paint instance</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if(AnimationImageBase!= null)
            {
                Graphics g = this.CreateGraphics();
                int layer = 0;
                if (anim >=maxFrames/2)
                {
                    layer = 1;
                }
                Rectangle section = new Rectangle(new Point(400*(anim%4),400*layer), new Size(400, 400));
                g.DrawImage(CropImage(AnimationImageBase,section), 0,0,400,400);
            }
        }
        /// <summary>
        /// OnTick is the handler that calls changes to the form every 'tick' that occurs after a certain ammount of time.
        /// </summary>
        /// <param name="sender">The object that sent the tick event.</param>
        /// <param name="e">The argumebts of this particular 'tick' event</param>
        private void OnTick(object sender, EventArgs e)
        {
            this.anim++;
            if (anim == maxFrames)
            {
                if (this.soundPlayer != null)
                {

                    this.soundPlayer.Stop();
                    anim = 0;
                    this.soundPlayer.Play();
                }
                else
                {
                    anim = 0;
                }
            }
            this.Invalidate();
        }
    }

}
