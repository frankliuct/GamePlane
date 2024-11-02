namespace ThunderFighter_Server
{
    partial class ConsoleWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ipAddrTexBox = new TextBox();
            portTextBox = new TextBox();
            startListenBt = new Button();
            userComboBox = new ComboBox();
            startGameBt = new Button();
            logListBox = new ListBox();
            SuspendLayout();
            // 
            // ipAddrTexBox
            // 
            ipAddrTexBox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ipAddrTexBox.Location = new Point(69, 41);
            ipAddrTexBox.Name = "ipAddrTexBox";
            ipAddrTexBox.Size = new Size(178, 28);
            ipAddrTexBox.TabIndex = 0;
            ipAddrTexBox.Text = "127.0.0.1";
            // 
            // portTextBox
            // 
            portTextBox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            portTextBox.Location = new Point(314, 41);
            portTextBox.Name = "portTextBox";
            portTextBox.Size = new Size(100, 28);
            portTextBox.TabIndex = 1;
            portTextBox.Text = "23333";
            // 
            // startListenBt
            // 
            startListenBt.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            startListenBt.Location = new Point(465, 36);
            startListenBt.Name = "startListenBt";
            startListenBt.Size = new Size(97, 33);
            startListenBt.TabIndex = 2;
            startListenBt.Text = "开始监听";
            startListenBt.UseVisualStyleBackColor = true;
            startListenBt.Click += startListenBt_Click;
            // 
            // userComboBox
            // 
            userComboBox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            userComboBox.FormattingEnabled = true;
            userComboBox.Location = new Point(602, 40);
            userComboBox.Name = "userComboBox";
            userComboBox.Size = new Size(121, 29);
            userComboBox.TabIndex = 3;
            // 
            // startGameBt
            // 
            startGameBt.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            startGameBt.Location = new Point(626, 362);
            startGameBt.Name = "startGameBt";
            startGameBt.Size = new Size(97, 33);
            startGameBt.TabIndex = 4;
            startGameBt.Text = "开始游戏";
            startGameBt.UseVisualStyleBackColor = true;
            startGameBt.Click += startGameBt_Click;
            // 
            // logListBox
            // 
            logListBox.FormattingEnabled = true;
            logListBox.ItemHeight = 17;
            logListBox.Location = new Point(69, 92);
            logListBox.Name = "logListBox";
            logListBox.Size = new Size(654, 259);
            logListBox.TabIndex = 5;
            // 
            // ConsoleWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(logListBox);
            Controls.Add(startGameBt);
            Controls.Add(userComboBox);
            Controls.Add(startListenBt);
            Controls.Add(portTextBox);
            Controls.Add(ipAddrTexBox);
            Name = "ConsoleWindow";
            Text = "ConsoleWindow";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ipAddrTexBox;
        private TextBox portTextBox;
        private Button startListenBt;
        private ComboBox userComboBox;
        private Button startGameBt;
        private ListBox logListBox;
    }
}