namespace Chess
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Player1NameTextbox = new System.Windows.Forms.TextBox();
            this.Player2NameTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TimeTextbox = new System.Windows.Forms.TextBox();
            this.HKMCheckbox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(34, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chess";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name of Player 1:";
            // 
            // Player1NameTextbox
            // 
            this.Player1NameTextbox.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Player1NameTextbox.Location = new System.Drawing.Point(17, 104);
            this.Player1NameTextbox.MaxLength = 9;
            this.Player1NameTextbox.Name = "Player1NameTextbox";
            this.Player1NameTextbox.Size = new System.Drawing.Size(211, 20);
            this.Player1NameTextbox.TabIndex = 2;
            this.Player1NameTextbox.Text = "Player1";
            // 
            // Player2NameTextbox
            // 
            this.Player2NameTextbox.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Player2NameTextbox.Location = new System.Drawing.Point(17, 159);
            this.Player2NameTextbox.MaxLength = 9;
            this.Player2NameTextbox.Name = "Player2NameTextbox";
            this.Player2NameTextbox.Size = new System.Drawing.Size(211, 20);
            this.Player2NameTextbox.TabIndex = 4;
            this.Player2NameTextbox.Text = "Player2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "Name of Player 2:";
            // 
            // StartGameButton
            // 
            this.StartGameButton.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartGameButton.Location = new System.Drawing.Point(17, 296);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(214, 63);
            this.StartGameButton.TabIndex = 5;
            this.StartGameButton.Text = "Start Game";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Code", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(80, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "Time:";
            // 
            // TimeTextbox
            // 
            this.TimeTextbox.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeTextbox.Location = new System.Drawing.Point(17, 213);
            this.TimeTextbox.MaxLength = 9;
            this.TimeTextbox.Name = "TimeTextbox";
            this.TimeTextbox.Size = new System.Drawing.Size(176, 20);
            this.TimeTextbox.TabIndex = 7;
            this.TimeTextbox.Text = "360";
            // 
            // HKMCheckbox
            // 
            this.HKMCheckbox.AutoSize = true;
            this.HKMCheckbox.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HKMCheckbox.ForeColor = System.Drawing.SystemColors.Control;
            this.HKMCheckbox.Location = new System.Drawing.Point(17, 251);
            this.HKMCheckbox.Name = "HKMCheckbox";
            this.HKMCheckbox.Size = new System.Drawing.Size(203, 21);
            this.HKMCheckbox.TabIndex = 8;
            this.HKMCheckbox.Text = "Harder knight movement";
            this.HKMCheckbox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(196, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "(s)";
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.Location = new System.Drawing.Point(207, 9);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(30, 30);
            this.ExitButton.TabIndex = 10;
            this.ExitButton.Text = "X";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(243, 371);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.HKMCheckbox);
            this.Controls.Add(this.TimeTextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StartGameButton);
            this.Controls.Add(this.Player2NameTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Player1NameTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Player1NameTextbox;
        private System.Windows.Forms.TextBox Player2NameTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TimeTextbox;
        private System.Windows.Forms.CheckBox HKMCheckbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ExitButton;
    }
}