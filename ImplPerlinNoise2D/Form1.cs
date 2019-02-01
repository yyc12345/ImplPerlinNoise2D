using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ImplPerlinNoise2D {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            //set io
            comboBox_interpolation.SelectedIndex = 5;
            toolTip1.SetToolTip(button4, "Update selected item.");
            toolTip1.SetToolTip(pictureBox_result, "Double click to save result.");

            //load data
            noiseListData = ImplPerlinNoise2D.Utility.Storage.StorageManager.Read();
            SyncData();
        }

        //generate
        private void button1_Click(object sender, EventArgs e) {
            button1.Text = "Generating...";
            button1.Enabled = false;

            try {
                var res = Kernel.Generate(noiseListData.NoiseList, useColorfulOutput);
                pictureBox_result.Image = res;
                MessageBox.Show("OK", "Perlin Noise", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Perlin Noise", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            button1.Text = "Generate";
            button1.Enabled = true;
        }

        #region normal operation

        ImplPerlinNoise2D.Utility.Storage.RootObject noiseListData;
        bool useColorfulOutput { get { return checkBox_outputColorful.Checked; } }

        //add
        private void button2_Click(object sender, EventArgs e) {
            if (!CheckInput()) {
                MessageBox.Show("Illegal value.", "Perlin Noise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newData = new ImplPerlinNoise2D.Utility.Storage.NoiseData() {
                Name = textBox_name.Text,
                Frequency = Double.Parse(textBox_frequency.Text),
                Amplitude = Double.Parse(textBox_amplitude.Text),
                AttachPercentage = Double.Parse(textBox_attach.Text),
                Seed = Int32.Parse(textBox_seed.Text),
                Redistribution = Double.Parse(textBox_redistribution.Text),
                Interpolation = (InterpolationMethod)comboBox_interpolation.SelectedIndex,
                Smooth = Int32.Parse(textBox_smooth.Text)
            };
            noiseListData.NoiseList.Add(newData);
            SyncData();
        }
        //remove
        private void button3_Click(object sender, EventArgs e) {
            if (listBox_noise.SelectedIndex < 0) {
                MessageBox.Show("No selected item.", "Perlin Noise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            noiseListData.NoiseList.RemoveAt(listBox_noise.SelectedIndex);
            SyncData();
        }
        //update
        private void button4_Click(object sender, EventArgs e) {
            if (!CheckInput()) {
                MessageBox.Show("Illegal value.", "Perlin Noise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (listBox_noise.SelectedIndex < 0) {
                MessageBox.Show("No selected item.", "Perlin Noise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var index = listBox_noise.SelectedIndex;
            noiseListData.NoiseList[index].Name = textBox_name.Text;
            noiseListData.NoiseList[index].Frequency = Double.Parse(textBox_frequency.Text);
            noiseListData.NoiseList[index].Amplitude = Double.Parse(textBox_amplitude.Text);
            noiseListData.NoiseList[index].AttachPercentage = Double.Parse(textBox_attach.Text);
            noiseListData.NoiseList[index].Seed = Int32.Parse(textBox_seed.Text);
            noiseListData.NoiseList[index].Redistribution = Double.Parse(textBox_redistribution.Text);
            noiseListData.NoiseList[index].Interpolation = (InterpolationMethod)comboBox_interpolation.SelectedIndex;
            noiseListData.NoiseList[index].Smooth = Int32.Parse(textBox_smooth.Text);

            SyncData();
        }

        //load data
        private void listBox_noise_DoubleClick(object sender, EventArgs e) {
            if (listBox_noise.SelectedIndex < 0) {
                MessageBox.Show("No selected item.", "Perlin Noise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var index = listBox_noise.SelectedIndex;
            textBox_name.Text = noiseListData.NoiseList[index].Name;
            textBox_frequency.Text = noiseListData.NoiseList[index].Frequency.ToString();
            textBox_amplitude.Text = noiseListData.NoiseList[index].Amplitude.ToString();
            textBox_attach.Text = noiseListData.NoiseList[index].AttachPercentage.ToString();
            textBox_seed.Text = noiseListData.NoiseList[index].Seed.ToString();
            textBox_redistribution.Text = noiseListData.NoiseList[index].Redistribution.ToString();
            textBox_smooth.Text = noiseListData.NoiseList[index].Smooth.ToString();
            comboBox_interpolation.SelectedIndex = (Int32)(noiseListData.NoiseList[index].Interpolation);
        }
        //save data
        private void button5_Click(object sender, EventArgs e) {
            ImplPerlinNoise2D.Utility.Storage.StorageManager.Write(noiseListData);
            MessageBox.Show("Save successfully!", "Perlin Noise", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //clear all data
        private void button6_Click(object sender, EventArgs e) {
            noiseListData.NoiseList.Clear();
            SyncData();
        }

        void SyncData() {
            listBox_noise.Items.Clear();
            foreach (var item in noiseListData.NoiseList) {
                listBox_noise.Items.Add(item.Name);
            }
        }

        bool CheckInput() {
            try {
                var frequency = Double.Parse(textBox_frequency.Text);
                var amplitude = Double.Parse(textBox_amplitude.Text);
                var attach = Double.Parse(textBox_attach.Text);
                var seed = Int32.Parse(textBox_seed.Text);
                var redistribution = Double.Parse(textBox_redistribution.Text);
                var smooth = Int32.Parse(textBox_smooth.Text);

                if (textBox_name.Text == "") return false;
                if (!(comboBox_interpolation.SelectedIndex >= 0 && comboBox_interpolation.SelectedIndex < comboBox_interpolation.Items.Count)) return false;
                if (frequency <= 0) return false;
                if (amplitude <= 0) return false;
                if (!(attach >= 0 && attach <= 1)) return false;
                if (redistribution <= 0) return false;
                if (smooth < 0) return false;
                return true;
            } catch (Exception) {
                return false;
            }
        }

        //save output image
        private void pictureBox_result_DoubleClick(object sender, EventArgs e) {
            if (pictureBox_result.Image is null) return;
            pictureBox_result.Image.Save("saved.png", System.Drawing.Imaging.ImageFormat.Png);
            MessageBox.Show("Save image into saved.png successfully.", "Perlin Noise", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //generate random seed
        private void button7_Click(object sender, EventArgs e) {
            var rnd = new Random();
            textBox_seed.Text = rnd.Next().ToString();
        }
        #endregion

        #region generate octave

        bool CheckOctaveInput() {
            try {
                var octave = Int32.Parse(textBox_octave_octave.Text);
                var persistence = Double.Parse(textBox_octave_persistence.Text);

                if (octave < 1) return false;
                if (persistence <= 0) return false;
                return true;
            } catch (Exception) {
                return false;
            }
        }

        //generate list
        private void button8_Click(object sender, EventArgs e) {
            if (!CheckOctaveInput()) {
                MessageBox.Show("Illegal value.", "Perlin Noise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var octave = (double)(Int32.Parse(textBox_octave_octave.Text));
            var persistence = Double.Parse(textBox_octave_persistence.Text);
            var rnd = new Random();

            for (int i = 0; i < octave; i++) {
                var newItem = new ImplPerlinNoise2D.Utility.Storage.NoiseData();
                newItem.Name = $"Octave_Layer_{i + 1}";
                newItem.Frequency = Math.Pow(2, i + 1);
                newItem.Amplitude = Math.Pow(persistence, i + 1);
                newItem.AttachPercentage = 1;
                newItem.Seed = rnd.Next();
                newItem.Redistribution = 1;
                newItem.Interpolation = InterpolationMethod.OptimizedKenPerlinInterpolation;
                newItem.Smooth = 0;

                noiseListData.NoiseList.Add(newItem);
            }

            SyncData();
            MessageBox.Show("OK", "Perlin Noise", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

    }
}
