// Copyright 2013 Travis Purdy. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ScreenCapture
{
    public partial class FormCapture : Form
    {
        Bitmap bmpScreenCapture;
        Graphics g;       

        public FormCapture()
        {
            InitializeComponent();
            label2.Text = pictureBox1.Size.ToString();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bmpScreenCapture != null)
            {
                bmpScreenCapture.Dispose();
                g.Dispose();
            }

            bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                                Screen.PrimaryScreen.Bounds.Height);

            g = Graphics.FromImage(bmpScreenCapture);

            g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                Screen.PrimaryScreen.Bounds.Y,
                                0, 0,
                                bmpScreenCapture.Size,
                                CopyPixelOperation.SourceCopy);

            pictureBox1.Image = bmpScreenCapture;
            pictureBox2.Parent = pictureBox1;

            // Save Jpeg
            //VaryQualityLevel();

            label1.Text = Cursor.Position.ToString();

            pictureBox2.Left = (Cursor.Position.X / 4) * 3;
            pictureBox2.Top = (Cursor.Position.Y / 4) * 3;

            label3.Text = ((int)Math.Floor((double)(Cursor.Position.X / 4) * 3)).ToString() + "," + ((int)Math.Floor((double)(Cursor.Position.Y / 4) * 3)).ToString();

        }

        private void VaryQualityLevel()
        {
            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);

            // Create an Encoder object based on the GUID 
            // for the Quality parameter category.
            System.Drawing.Imaging.Encoder myEncoder =
                System.Drawing.Imaging.Encoder.Quality;

            // Create an EncoderParameters object. 
            // An EncoderParameters object has an array of EncoderParameter 
            // objects. In this case, there is only one 
            // EncoderParameter object in the array.
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            pictureBox1.Image.Save(@"c:\TestPhotoQualityFifty.jpg", jgpEncoder, myEncoderParameters);

            myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            pictureBox1.Image.Save(@"c:\TestPhotoQualityHundred.jpg", jgpEncoder, myEncoderParameters);

            // Save the bitmap as a JPG file with zero quality level compression.
            myEncoderParameter = new EncoderParameter(myEncoder, 25L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            pictureBox1.Image.Save(@"c:\TestPhotoQualityTwentyFive.jpg", jgpEncoder, myEncoderParameters);

        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void FormCapture_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

    }
}
