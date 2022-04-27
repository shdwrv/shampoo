using System;
using System.IO;
using System.Media;
using System.Net;
using System.Windows.Forms;

namespace shampoo
{
    public partial class Form1 : Form
    {
        WebClient webClient = new WebClient();
        Uri shampoos = new Uri("https://cdn.discordapp.com/attachments/966780583600619594/967199545928859699/shampoo.wav", UriKind.Absolute);
        SoundPlayer simpleSound = new SoundPlayer(Path.GetTempPath() + "\\shampoo.wav");

        public Form1()
        {
            this.KeyPreview = true;
            int x = 1;
            InitializeComponent();
            webClient.DownloadFile(shampoos, Path.GetTempPath() + "\\shampoo.wav");
            simpleSound.Play();
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 10000;
            timer1.Start();
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            simpleSound.Play();
        }
    }
}
