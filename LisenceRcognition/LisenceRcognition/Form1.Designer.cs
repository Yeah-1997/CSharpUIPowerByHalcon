namespace LisenceRcognition
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.recognize_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hWindowControl2 = new HalconDotNet.HWindowControl();
            this.single = new System.Windows.Forms.RadioButton();
            this.multiples = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openPic_button = new System.Windows.Forms.Button();
            this.state = new System.Windows.Forms.Label();
            this.hWindowControl3 = new HalconDotNet.HWindowControl();
            this.label3 = new System.Windows.Forms.Label();
            this.exit_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.time_label = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hWindowControl1
            // 
            this.hWindowControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hWindowControl1.BackColor = System.Drawing.Color.Black;
            this.hWindowControl1.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl1.Location = new System.Drawing.Point(764, 178);
            this.hWindowControl1.Name = "hWindowControl1";
            this.hWindowControl1.Size = new System.Drawing.Size(300, 180);
            this.hWindowControl1.TabIndex = 0;
            this.hWindowControl1.WindowSize = new System.Drawing.Size(300, 180);
            // 
            // recognize_button
            // 
            this.recognize_button.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.recognize_button.Location = new System.Drawing.Point(470, 452);
            this.recognize_button.Name = "recognize_button";
            this.recognize_button.Size = new System.Drawing.Size(128, 67);
            this.recognize_button.TabIndex = 2;
            this.recognize_button.Text = "开始识别";
            this.recognize_button.UseVisualStyleBackColor = true;
            this.recognize_button.Click += new System.EventHandler(this.recognize_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(122, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "原图";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(879, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "识别结果";
            // 
            // hWindowControl2
            // 
            this.hWindowControl2.BackColor = System.Drawing.Color.Black;
            this.hWindowControl2.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl2.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl2.Location = new System.Drawing.Point(16, 178);
            this.hWindowControl2.Name = "hWindowControl2";
            this.hWindowControl2.Size = new System.Drawing.Size(300, 180);
            this.hWindowControl2.TabIndex = 1;
            this.hWindowControl2.WindowSize = new System.Drawing.Size(300, 180);
            // 
            // single
            // 
            this.single.AutoSize = true;
            this.single.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.single.Location = new System.Drawing.Point(6, 20);
            this.single.Name = "single";
            this.single.Size = new System.Drawing.Size(107, 23);
            this.single.TabIndex = 6;
            this.single.TabStop = true;
            this.single.Text = "单张识别";
            this.single.UseVisualStyleBackColor = true;
            // 
            // multiples
            // 
            this.multiples.AutoSize = true;
            this.multiples.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.multiples.Location = new System.Drawing.Point(6, 63);
            this.multiples.Name = "multiples";
            this.multiples.Size = new System.Drawing.Size(107, 23);
            this.multiples.TabIndex = 7;
            this.multiples.TabStop = true;
            this.multiples.Text = "连续识别";
            this.multiples.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.single);
            this.groupBox1.Controls.Add(this.multiples);
            this.groupBox1.Location = new System.Drawing.Point(25, 452);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openPic_button
            // 
            this.openPic_button.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.openPic_button.Location = new System.Drawing.Point(283, 452);
            this.openPic_button.Name = "openPic_button";
            this.openPic_button.Size = new System.Drawing.Size(129, 66);
            this.openPic_button.TabIndex = 9;
            this.openPic_button.Text = "选择图片";
            this.openPic_button.UseVisualStyleBackColor = true;
            this.openPic_button.Click += new System.EventHandler(this.openPic_button_Click);
            // 
            // state
            // 
            this.state.AutoSize = true;
            this.state.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.state.Location = new System.Drawing.Point(755, 454);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(64, 19);
            this.state.TabIndex = 10;
            this.state.Text = "Ready";
            // 
            // hWindowControl3
            // 
            this.hWindowControl3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.hWindowControl3.BackColor = System.Drawing.Color.Black;
            this.hWindowControl3.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl3.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl3.Location = new System.Drawing.Point(379, 178);
            this.hWindowControl3.Name = "hWindowControl3";
            this.hWindowControl3.Size = new System.Drawing.Size(301, 180);
            this.hWindowControl3.TabIndex = 11;
            this.hWindowControl3.WindowSize = new System.Drawing.Size(301, 180);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(431, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "图像恢复后车牌区域";
            // 
            // exit_button
            // 
            this.exit_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exit_button.BackColor = System.Drawing.Color.Red;
            this.exit_button.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exit_button.Location = new System.Drawing.Point(1027, 515);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(121, 62);
            this.exit_button.TabIndex = 13;
            this.exit_button.Text = "退出";
            this.exit_button.UseVisualStyleBackColor = false;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Salmon;
            this.label4.Font = new System.Drawing.Font("宋体", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(187, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(743, 64);
            this.label4.TabIndex = 14;
            this.label4.Text = "矿车车牌识别系统演示版";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(640, 452);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "识别结果：";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_label.Location = new System.Drawing.Point(12, 9);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(31, 19);
            this.time_label.TabIndex = 16;
            this.time_label.Text = "na";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 682);
            this.Controls.Add(this.time_label);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.state);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hWindowControl3);
            this.Controls.Add(this.openPic_button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.recognize_button);
            this.Controls.Add(this.hWindowControl2);
            this.Controls.Add(this.hWindowControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "矿车车牌识别系统演示版本byYeah";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HalconDotNet.HWindowControl hWindowControl1;
        private System.Windows.Forms.Button recognize_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private HalconDotNet.HWindowControl hWindowControl2;
        private System.Windows.Forms.RadioButton single;
        private System.Windows.Forms.RadioButton multiples;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openPic_button;
        private System.Windows.Forms.Label state;
        private HalconDotNet.HWindowControl hWindowControl3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label time_label;
    }
}

