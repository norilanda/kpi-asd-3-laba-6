namespace laba6
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
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnQuite = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartGame
            // 
            this.btnStartGame.Font = new System.Drawing.Font("SimSun-ExtB", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStartGame.Image = global::laba6.Properties.Resources.start_game;
            this.btnStartGame.Location = new System.Drawing.Point(471, 143);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(421, 119);
            this.btnStartGame.TabIndex = 0;
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // btnQuite
            // 
            this.btnQuite.Font = new System.Drawing.Font("SimSun-ExtB", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnQuite.Image = global::laba6.Properties.Resources.quite;
            this.btnQuite.Location = new System.Drawing.Point(556, 320);
            this.btnQuite.Name = "btnQuite";
            this.btnQuite.Size = new System.Drawing.Size(245, 109);
            this.btnQuite.TabIndex = 1;
            this.btnQuite.UseVisualStyleBackColor = true;
            this.btnQuite.Click += new System.EventHandler(this.btnQuite_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 697);
            this.Controls.Add(this.btnQuite);
            this.Controls.Add(this.btnStartGame);
            this.Name = "Form1";
            this.Text = "Skrap";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnStartGame;
        private Button btnQuite;
    }
}