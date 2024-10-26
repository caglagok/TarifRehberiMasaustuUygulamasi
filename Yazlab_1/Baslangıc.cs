using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yazlab_1
{
    public partial class Baslangıc : Form
    {
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;
        public Baslangıc()
        {
            InitializeComponent();
            Core.Initialize(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ana_Sayfa anasayfaForm = new Ana_Sayfa();
            anasayfaForm.ShowDialog();
        }

        private void Baslangıc_Load(object sender, EventArgs e)
        {
            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);

            var videoView = new LibVLCSharp.WinForms.VideoView
            {
                Dock = DockStyle.Fill
            };

            panel1.Controls.Add(videoView);
            videoView.MediaPlayer = _mediaPlayer;

            var videoPath = @"C:\Users\CAGLA\Desktop\Yazlab1\Yazlab_1\Yazlab_1\TarifResimleri\Dökülüyor.mp4";
            var media = new Media(_libVLC, new Uri(videoPath));

            _mediaPlayer.Play(media);
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _mediaPlayer?.Dispose();
            _libVLC?.Dispose();
            base.OnFormClosing(e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
