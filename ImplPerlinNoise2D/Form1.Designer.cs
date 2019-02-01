namespace ImplPerlinNoise2D {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.pictureBox_result = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox_noise = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_smooth = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox_seed = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.comboBox_interpolation = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_attach = new System.Windows.Forms.TextBox();
            this.textBox_redistribution = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_amplitude = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_frequency = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button8 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_octave_persistence = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_octave_octave = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.checkBox_outputColorful = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_result)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_result
            // 
            this.pictureBox_result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_result.Location = new System.Drawing.Point(312, 31);
            this.pictureBox_result.Name = "pictureBox_result";
            this.pictureBox_result.Size = new System.Drawing.Size(512, 512);
            this.pictureBox_result.TabIndex = 0;
            this.pictureBox_result.TabStop = false;
            this.pictureBox_result.DoubleClick += new System.EventHandler(this.pictureBox_result_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 479);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox_noise
            // 
            this.listBox_noise.FormattingEnabled = true;
            this.listBox_noise.ItemHeight = 12;
            this.listBox_noise.Location = new System.Drawing.Point(6, 6);
            this.listBox_noise.Name = "listBox_noise";
            this.listBox_noise.Size = new System.Drawing.Size(268, 124);
            this.listBox_noise.TabIndex = 2;
            this.listBox_noise.DoubleClick += new System.EventHandler(this.listBox_noise_DoubleClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(43, 136);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(29, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "-";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(78, 136);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(29, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "U";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_smooth);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.textBox_seed);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_name);
            this.groupBox1.Controls.Add(this.comboBox_interpolation);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBox_attach);
            this.groupBox1.Controls.Add(this.textBox_redistribution);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_amplitude);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_frequency);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 337);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Value setting";
            // 
            // textBox_smooth
            // 
            this.textBox_smooth.Location = new System.Drawing.Point(3, 262);
            this.textBox_smooth.Name = "textBox_smooth";
            this.textBox_smooth.Size = new System.Drawing.Size(262, 21);
            this.textBox_smooth.TabIndex = 15;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(216, 66);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(51, 23);
            this.button7.TabIndex = 9;
            this.button7.Text = "RND";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // textBox_seed
            // 
            this.textBox_seed.Location = new System.Drawing.Point(5, 68);
            this.textBox_seed.Name = "textBox_seed";
            this.textBox_seed.Size = new System.Drawing.Size(205, 21);
            this.textBox_seed.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(2, 247);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(227, 12);
            this.label13.TabIndex = 14;
            this.label13.Text = "Smooth sampling range: (Int32 &&&& >=0)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Seed: (Int32 &&&& >=0)";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(6, 29);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(261, 21);
            this.textBox_name.TabIndex = 7;
            // 
            // comboBox_interpolation
            // 
            this.comboBox_interpolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_interpolation.FormattingEnabled = true;
            this.comboBox_interpolation.Items.AddRange(new object[] {
            "Nearest Neighbor Interpolation",
            "Bilinear Interpolation",
            "Bicubic Interpolation",
            "Sine Interpolation",
            "Ken Perlin (3*t^2-2*t^3)",
            "Optimized Ken Perlin (6*t^5-15*t^4+10*t^3)"});
            this.comboBox_interpolation.Location = new System.Drawing.Point(4, 224);
            this.comboBox_interpolation.Name = "comboBox_interpolation";
            this.comboBox_interpolation.Size = new System.Drawing.Size(261, 20);
            this.comboBox_interpolation.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Name:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 170);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "Redistribution: (>0)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 209);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 12;
            this.label12.Text = "Interpolation:";
            // 
            // textBox_attach
            // 
            this.textBox_attach.Location = new System.Drawing.Point(4, 301);
            this.textBox_attach.Name = "textBox_attach";
            this.textBox_attach.Size = new System.Drawing.Size(262, 21);
            this.textBox_attach.TabIndex = 5;
            // 
            // textBox_redistribution
            // 
            this.textBox_redistribution.Location = new System.Drawing.Point(4, 185);
            this.textBox_redistribution.Name = "textBox_redistribution";
            this.textBox_redistribution.Size = new System.Drawing.Size(262, 21);
            this.textBox_redistribution.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Attach percentage: (>=0 &&&& <=1)";
            // 
            // textBox_amplitude
            // 
            this.textBox_amplitude.Location = new System.Drawing.Point(5, 146);
            this.textBox_amplitude.Name = "textBox_amplitude";
            this.textBox_amplitude.Size = new System.Drawing.Size(262, 21);
            this.textBox_amplitude.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Amplitude: (>0)";
            // 
            // textBox_frequency
            // 
            this.textBox_frequency.Location = new System.Drawing.Point(5, 107);
            this.textBox_frequency.Name = "textBox_frequency";
            this.textBox_frequency.Size = new System.Drawing.Size(262, 21);
            this.textBox_frequency.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Frequency: (>0)";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(224, 136);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(51, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "Save";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(294, 535);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.listBox_noise);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(286, 509);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Noise list";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(167, 136);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(51, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "Clear";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.textBox_octave_persistence);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textBox_octave_octave);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(286, 509);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Octaves helper";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(6, 479);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(262, 23);
            this.button8.TabIndex = 17;
            this.button8.Text = "Add into noise list";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(6, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "Amplitude = Persistence^i";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(6, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "Frequency = 2^i";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "Formula tips:";
            // 
            // textBox_octave_persistence
            // 
            this.textBox_octave_persistence.Location = new System.Drawing.Point(7, 134);
            this.textBox_octave_persistence.Name = "textBox_octave_persistence";
            this.textBox_octave_persistence.Size = new System.Drawing.Size(262, 21);
            this.textBox_octave_persistence.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "Persistence: (>0)";
            // 
            // textBox_octave_octave
            // 
            this.textBox_octave_octave.Location = new System.Drawing.Point(7, 95);
            this.textBox_octave_octave.Name = "textBox_octave_octave";
            this.textBox_octave_octave.Size = new System.Drawing.Size(262, 21);
            this.textBox_octave_octave.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "Octave(i): (Int32 &&&& >=1)";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.checkBox_outputColorful);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(286, 509);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Generate setting";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // checkBox_outputColorful
            // 
            this.checkBox_outputColorful.AutoSize = true;
            this.checkBox_outputColorful.Location = new System.Drawing.Point(14, 12);
            this.checkBox_outputColorful.Name = "checkBox_outputColorful";
            this.checkBox_outputColorful.Size = new System.Drawing.Size(114, 16);
            this.checkBox_outputColorful.TabIndex = 2;
            this.checkBox_outputColorful.Text = "Colorful output";
            this.checkBox_outputColorful.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 559);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox_result);
            this.Name = "Form1";
            this.Text = "The Implement of 2D Perlin Noise";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_result)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_result;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox_noise;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_attach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_amplitude;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_frequency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox_seed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox checkBox_outputColorful;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox_octave_persistence;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_octave_octave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox textBox_redistribution;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox_interpolation;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_smooth;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

