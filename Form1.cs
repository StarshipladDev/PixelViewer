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
        bool drawing = false;
        int anim = 0;

        Timer timer = new System.Windows.Forms.Timer();
        System.Media.SoundPlayer soundPlayer;
        Bitmap AnimationImageBase;
        Bitmap AnimationShow;

        int layer = 0;
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
        public String AddLine(string core, string newe)
        {
            return core+"\n"+newe;
        }
        /// <summary>
        /// OpenHelpDialog runs a simple help Dialog class with text explaining the basics of the program
        /// </summary>
        /// <param name="Sender">The object that called this method</param>
        /// <param name="e">The lst of arguments the instance of this method has</param>
        public void OpenHelpDialog(object sender, EventArgs e)
        {
            String helpString = String.Empty;
            helpString = AddLine(helpString,"Welcome to PixelPlayer!");
            helpString = AddLine(helpString, "To play an animation, select any valid image file by clicking 'Animation'");
            helpString = AddLine(helpString, "To play a sound over it, select any .WAV file by clicking 'Sound'");
            helpString = AddLine(helpString, "* Total Animation 'slides' must be a multiple of 4");
            helpString = AddLine(helpString, "* All animation 'slides' must have the same width&height");
            helpString = AddLine(helpString, "* Animations must be ordererd left to right, down, in groups of 4 across");
            helpString = AddLine(helpString, "* After opening 'config', 'accept' must be pressed to continue");
            helpString = AddLine(helpString, "* All Animation slides must have a box of ((width or height)/20) thickness");
            helpString = AddLine(helpString, "surrounding each 'slide'");
            helpString = AddLine(helpString, "E.G : A animation 'slide' 20x20 px must have a 1px square around it");
            MessageBox.Show(helpString);

        }
        /// <summary>
        /// This pauses the application and opens a <see cref="ConfigForm"/>
        /// After the ConfigForm is closed, values such as timer speed and animations are changed and the aniamtion continues
        /// </summary>
        /// <param name="Sender">The object that called this method</param>
        /// <param name="e">The lst of arguments the instance of this method has</param>
        public void OpenConfigForm(object Sender, EventArgs e)
        {
            this.timer.Stop();
            ConfigForm cf = new ConfigForm(timer);
            cf.Show();
        }
        /// <summary>
        /// OnPaint is an override method to perform painting based on the animation 'step'
        /// </summary>
        /// <param name="e">The event arguments for this particular paint instance</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if( !drawing)
            {
                int maxFrames = Globals.maxFrames;
                int cellSizePixels = Globals.cellSizePixels;
                drawing = true;
                base.OnPaint(e);

                if (AnimationImageBase != null)
                {
                    Graphics g = e.Graphics;
                    if ((anim) % 4==0 && anim>0)
                    {
                        layer++;
                    }
                    Rectangle section = new Rectangle(new Point((cellSizePixels) * (anim % 4)+ ((anim%4+1)*(cellSizePixels / 20)) , (cellSizePixels * layer) +( (cellSizePixels / 20)*(layer+1))), new Size(cellSizePixels, cellSizePixels));
                    g.DrawImage(CropImage(AnimationImageBase, section), 0, 0, 400, 400);
                }
                drawing = false; ;
            }
           
        }
        /// <summary>
        /// OnTick is the handler that calls changes to the form every 'tick' that occurs after a certain ammount of time.
        /// </summary>
        /// <param name="sender">The object that sent the tick event.</param>
        /// <param name="e">The argumebts of this particular 'tick' event</param>
        private void OnTick(object sender, EventArgs e)
        {

            int maxFrames = Globals.maxFrames;
            this.anim++;
            if (anim == maxFrames)
            {
                if (this.soundPlayer != null && AnimationImageBase!=null)
                {

                    this.soundPlayer.Stop();
                    layer = 0;
                    anim = 0;
                    this.soundPlayer.Play();
                }
                else
                {

                    layer = 0;
                    anim = 0;
                }
            }
            this.Invalidate();
        }
    }

}
