using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImplPerlinNoise2D {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            noiseListData = ImplPerlinNoise2D.Utility.Storage.StorageManager.Read();
            SyncData();
        }

        //generate
        private void button1_Click(object sender, EventArgs e) {
            try {
                var res = Kernel.Generate(noiseListData.NoiseList);
                pictureBox_result.Image = res;
                MessageBox.Show("OK");
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        #region normal operation

        ImplPerlinNoise2D.Utility.Storage.RootObject noiseListData;

        //add
        private void button2_Click(object sender, EventArgs e) {
            if (!CheckInput()) {
                MessageBox.Show("Illegal value.");
                return;
            }

            var newData = new ImplPerlinNoise2D.Utility.Storage.NoiseData() {
                Name = textBox_name.Text,
                Frequency = Int32.Parse(textBox_frequency.Text),
                Amplitude = Double.Parse(textBox_amplitude.Text),
                AttachPercentage = Double.Parse(textBox_attach.Text),
                Seed = Int32.Parse(textBox_seed.Text)
            };
            noiseListData.NoiseList.Add(newData);
            SyncData();
        }
        //remove
        private void button3_Click(object sender, EventArgs e) {
            if (listBox_noise.SelectedIndex < 0) {
                MessageBox.Show("No selected item.");
                return;
            }

            noiseListData.NoiseList.RemoveAt(listBox_noise.SelectedIndex);
            SyncData();
        }
        //update
        private void button4_Click(object sender, EventArgs e) {
            if (!CheckInput()) {
                MessageBox.Show("Illegal value.");
                return;
            }
            if (listBox_noise.SelectedIndex < 0) {
                MessageBox.Show("No selected item.");
                return;
            }

            var index = listBox_noise.SelectedIndex;
            noiseListData.NoiseList[index].Name = textBox_name.Text;
            noiseListData.NoiseList[index].Frequency = Int32.Parse(textBox_frequency.Text);
            noiseListData.NoiseList[index].Amplitude = Double.Parse(textBox_amplitude.Text);
            noiseListData.NoiseList[index].AttachPercentage = Double.Parse(textBox_attach.Text);
            noiseListData.NoiseList[index].Seed = Int32.Parse(textBox_seed.Text);

            SyncData();
        }

        //load data
        private void listBox_noise_DoubleClick(object sender, EventArgs e) {
            if (listBox_noise.SelectedIndex < 0) {
                MessageBox.Show("No selected item.");
                return;
            }
            
            var index = listBox_noise.SelectedIndex;
            textBox_name.Text = noiseListData.NoiseList[index].Name;
            textBox_frequency.Text = noiseListData.NoiseList[index].Frequency.ToString();
            textBox_amplitude.Text = noiseListData.NoiseList[index].Amplitude.ToString();
            textBox_attach.Text = noiseListData.NoiseList[index].AttachPercentage.ToString();
            textBox_seed.Text = noiseListData.NoiseList[index].Seed.ToString();
        }
        //save data
        private void button5_Click(object sender, EventArgs e) {
            ImplPerlinNoise2D.Utility.Storage.StorageManager.Write(noiseListData);
            MessageBox.Show("Save successfully!");
        }

        void SyncData() {
            listBox_noise.Items.Clear();
            foreach (var item in noiseListData.NoiseList) {
                listBox_noise.Items.Add(item.Name);
            }
        }

        bool CheckInput() {
            try {
                var frequency = Int32.Parse(textBox_frequency.Text);
                var amplitude = Double.Parse(textBox_amplitude.Text);
                var attach = Double.Parse(textBox_attach.Text);
                var seed = Int32.Parse(textBox_seed.Text);

                if (textBox_name.Text == "") return false;
                if (frequency < 1) return false;
                if (amplitude <= 0) return false;
                if (!(attach >= 0 && attach <= 1)) return false;
                return true;
            } catch (Exception) {
                return false;
            }
        }

        #endregion

        private void pictureBox_result_DoubleClick(object sender, EventArgs e) {
            pictureBox_result.Image.Save("saved.png", System.Drawing.Imaging.ImageFormat.Png);
            MessageBox.Show("Save image into saved.png successfully.");
        }
    }
}
