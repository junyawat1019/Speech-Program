using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Speech_Program
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer voice;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            voice = new SpeechSynthesizer();
            cbSelect.SelectedIndex = 1;
        }

        private void cbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnSpeak_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cbSelect.SelectedIndex)
                {
                    case 0:
                        voice.SelectVoiceByHints(VoiceGender.NotSet);
                        break;
                    case 1:
                        voice.SelectVoiceByHints(VoiceGender.Male);
                        break;
                    case 2:
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        break;
                    case 3:
                        voice.SelectVoiceByHints(VoiceGender.Neutral);
                        break;
                    default:
                        break;
                }
                voice.SpeakAsync(txtMessage.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            try
            {
                voice.Pause();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnPesume_Click(object sender, EventArgs e)
        {
            try
            {
                voice.Resume();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog std = new SaveFileDialog())
                {
                    std.Filter = "Wav File|*.wav";
                    std.Title = "Save Sound File";
                    if (std.ShowDialog() == DialogResult.OK)
                    {
                        FileStream fs = new FileStream(std.FileName,FileMode.Create,FileAccess.Write);
                        voice.SetOutputToWaveStream(fs);
                        voice.Speak(txtMessage.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
