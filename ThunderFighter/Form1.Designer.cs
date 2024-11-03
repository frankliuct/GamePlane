namespace ThunderFighter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            startGameBt = new Button();
            portTextBox = new TextBox();
            ipAddrTexBox = new TextBox();
            timer2 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 50;
            timer1.Tick += timer1_Tick;
            // 
            // startGameBt
            // 
            startGameBt.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            startGameBt.Location = new Point(131, 598);
            startGameBt.Name = "startGameBt";
            startGameBt.Size = new Size(97, 33);
            startGameBt.TabIndex = 5;
            startGameBt.Text = "开始游戏";
            startGameBt.UseVisualStyleBackColor = true;
            startGameBt.Click += startGameBt_Click;
            // 
            // portTextBox
            // 
            portTextBox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            portTextBox.Location = new Point(239, 77);
            portTextBox.Name = "portTextBox";
            portTextBox.Size = new Size(100, 28);
            portTextBox.TabIndex = 4;
            portTextBox.Text = "23333";
            // 
            // ipAddrTexBox
            // 
            ipAddrTexBox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ipAddrTexBox.Location = new Point(12, 77);
            ipAddrTexBox.Name = "ipAddrTexBox";
            ipAddrTexBox.Size = new Size(201, 28);
            ipAddrTexBox.TabIndex = 3;
            ipAddrTexBox.Text = "127.0.0.1";
            // 
            // timer2
            // 
            timer2.Enabled = true;
            timer2.Interval = 1000;
            timer2.Tick += timer2_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(361, 657);
            Controls.Add(startGameBt);
            Controls.Add(portTextBox);
            Controls.Add(ipAddrTexBox);
            DoubleBuffered = true;
            Margin = new Padding(2, 3, 2, 3);
            MaximumSize = new Size(377, 696);
            MinimumSize = new Size(377, 696);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Paint += Form1_Paint;
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Button startGameBt;
        private TextBox portTextBox;
        private TextBox ipAddrTexBox;
        private System.Windows.Forms.Timer timer2;
    }
}
