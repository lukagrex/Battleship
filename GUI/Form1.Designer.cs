
namespace GUI
{
    partial class MainForm
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
            this.playerRadioButton = new System.Windows.Forms.RadioButton();
            this.computerRadioButton = new System.Windows.Forms.RadioButton();
            this.startGameButton = new System.Windows.Forms.Button();
            this.infoTextBox = new System.Windows.Forms.TextBox();
            this.restartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // playerRadioButton
            // 
            this.playerRadioButton.AutoSize = true;
            this.playerRadioButton.Location = new System.Drawing.Point(50, 45);
            this.playerRadioButton.Name = "playerRadioButton";
            this.playerRadioButton.Size = new System.Drawing.Size(69, 21);
            this.playerRadioButton.TabIndex = 0;
            this.playerRadioButton.TabStop = true;
            this.playerRadioButton.Text = "Player";
            this.playerRadioButton.UseVisualStyleBackColor = true;
            // 
            // computerRadioButton
            // 
            this.computerRadioButton.AutoSize = true;
            this.computerRadioButton.Location = new System.Drawing.Point(134, 45);
            this.computerRadioButton.Name = "computerRadioButton";
            this.computerRadioButton.Size = new System.Drawing.Size(90, 21);
            this.computerRadioButton.TabIndex = 1;
            this.computerRadioButton.TabStop = true;
            this.computerRadioButton.Text = "Computer";
            this.computerRadioButton.UseVisualStyleBackColor = true;
            // 
            // startGameButton
            // 
            this.startGameButton.Location = new System.Drawing.Point(250, 37);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(155, 36);
            this.startGameButton.TabIndex = 2;
            this.startGameButton.Text = "Start Game";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // infoTextBox
            // 
            this.infoTextBox.Enabled = false;
            this.infoTextBox.Location = new System.Drawing.Point(210, 500);
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.Size = new System.Drawing.Size(500, 22);
            this.infoTextBox.TabIndex = 3;
            this.infoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // restartButton
            // 
            this.restartButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.restartButton.Location = new System.Drawing.Point(425, 37);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(155, 36);
            this.restartButton.TabIndex = 5;
            this.restartButton.Text = "Clear Grid";
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Player to start:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Player";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(670, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Computer";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 553);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.computerRadioButton);
            this.Controls.Add(this.playerRadioButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "Battleship Lightweight";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton playerRadioButton;
        private System.Windows.Forms.RadioButton computerRadioButton;
        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.TextBox infoTextBox;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

