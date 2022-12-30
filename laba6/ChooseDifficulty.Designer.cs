namespace laba6
{
    partial class ChooseDifficulty
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
            this.btnMedium = new System.Windows.Forms.Button();
            this.btnEasy = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnHard = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMedium
            // 
            this.btnMedium.Font = new System.Drawing.Font("SimSun-ExtB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMedium.Location = new System.Drawing.Point(562, 285);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Size = new System.Drawing.Size(245, 109);
            this.btnMedium.TabIndex = 3;
            this.btnMedium.Text = "Medium";
            this.btnMedium.UseVisualStyleBackColor = true;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);
            // 
            // btnEasy
            // 
            this.btnEasy.Font = new System.Drawing.Font("SimSun-ExtB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEasy.Location = new System.Drawing.Point(562, 152);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(245, 109);
            this.btnEasy.TabIndex = 2;
            this.btnEasy.Text = "Easy";
            this.btnEasy.UseVisualStyleBackColor = true;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Font = new System.Drawing.Font("SimSun-ExtB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMenu.Location = new System.Drawing.Point(562, 546);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(245, 109);
            this.btnMenu.TabIndex = 5;
            this.btnMenu.Text = "Back To Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnHard
            // 
            this.btnHard.Font = new System.Drawing.Font("SimSun-ExtB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHard.Location = new System.Drawing.Point(562, 413);
            this.btnHard.Name = "btnHard";
            this.btnHard.Size = new System.Drawing.Size(245, 109);
            this.btnHard.TabIndex = 4;
            this.btnHard.Text = "Hard";
            this.btnHard.UseVisualStyleBackColor = true;
            this.btnHard.Click += new System.EventHandler(this.btnHard_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(522, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 36);
            this.label1.TabIndex = 6;
            this.label1.Text = "CHOOSE DIFFICULTY";
            // 
            // ChooseDifficulty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 697);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnHard);
            this.Controls.Add(this.btnMedium);
            this.Controls.Add(this.btnEasy);
            this.Name = "ChooseDifficulty";
            this.Text = "ChooseDifficulty";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnMedium;
        private Button btnEasy;
        private Button btnMenu;
        private Button btnHard;
        private Label label1;
    }
}