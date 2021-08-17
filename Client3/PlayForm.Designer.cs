namespace Client3
{
    partial class PlayForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlPlaying = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlStartGame = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUser4 = new System.Windows.Forms.Label();
            this.lblUser3 = new System.Windows.Forms.Label();
            this.lblUser2 = new System.Windows.Forms.Label();
            this.lblUser1 = new System.Windows.Forms.Label();
            this.picBoxUser4 = new System.Windows.Forms.PictureBox();
            this.picBoxUser3 = new System.Windows.Forms.PictureBox();
            this.picBoxUser1 = new System.Windows.Forms.PictureBox();
            this.picBoxUser2 = new System.Windows.Forms.PictureBox();
            this.lblRoomCode = new System.Windows.Forms.Label();
            this.pnlPlaying.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlStartGame.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1229, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Leave";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "RoomCode";
            // 
            // pnlPlaying
            // 
            this.pnlPlaying.Controls.Add(this.label4);
            this.pnlPlaying.Controls.Add(this.button2);
            this.pnlPlaying.Controls.Add(this.txtAnswer);
            this.pnlPlaying.Controls.Add(this.pictureBox1);
            this.pnlPlaying.Controls.Add(this.label3);
            this.pnlPlaying.Controls.Add(this.label2);
            this.pnlPlaying.Location = new System.Drawing.Point(26, 80);
            this.pnlPlaying.Name = "pnlPlaying";
            this.pnlPlaying.Size = new System.Drawing.Size(1278, 409);
            this.pnlPlaying.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(933, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Price You Guess";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(936, 266);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(254, 67);
            this.button2.TabIndex = 8;
            this.button2.Text = "Submit";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txtAnswer
            // 
            this.txtAnswer.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnswer.Location = new System.Drawing.Point(936, 178);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(254, 39);
            this.txtAnswer.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Client3.Properties.Resources.egg;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(481, 106);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(301, 227);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(541, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "What is the price of 10 eggs?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1175, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 46);
            this.label2.TabIndex = 4;
            this.label2.Text = "30";
            // 
            // pnlStartGame
            // 
            this.pnlStartGame.Controls.Add(this.label5);
            this.pnlStartGame.Controls.Add(this.btnStartGame);
            this.pnlStartGame.Location = new System.Drawing.Point(26, 80);
            this.pnlStartGame.Name = "pnlStartGame";
            this.pnlStartGame.Size = new System.Drawing.Size(1275, 409);
            this.pnlStartGame.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(466, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(268, 43);
            this.label5.TabIndex = 1;
            this.label5.Text = "What\'s up bros";
            // 
            // btnStartGame
            // 
            this.btnStartGame.BackColor = System.Drawing.Color.ForestGreen;
            this.btnStartGame.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGame.ForeColor = System.Drawing.Color.White;
            this.btnStartGame.Location = new System.Drawing.Point(481, 161);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(235, 79);
            this.btnStartGame.TabIndex = 0;
            this.btnStartGame.Text = "Start game";
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblUser4);
            this.panel2.Controls.Add(this.lblUser3);
            this.panel2.Controls.Add(this.lblUser2);
            this.panel2.Controls.Add(this.lblUser1);
            this.panel2.Controls.Add(this.picBoxUser4);
            this.panel2.Controls.Add(this.picBoxUser3);
            this.panel2.Controls.Add(this.picBoxUser1);
            this.panel2.Controls.Add(this.picBoxUser2);
            this.panel2.Location = new System.Drawing.Point(26, 495);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1278, 244);
            this.panel2.TabIndex = 4;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lblUser4
            // 
            this.lblUser4.AutoSize = true;
            this.lblUser4.Location = new System.Drawing.Point(1029, 166);
            this.lblUser4.Name = "lblUser4";
            this.lblUser4.Size = new System.Drawing.Size(0, 17);
            this.lblUser4.TabIndex = 7;
            // 
            // lblUser3
            // 
            this.lblUser3.AutoSize = true;
            this.lblUser3.Location = new System.Drawing.Point(763, 166);
            this.lblUser3.Name = "lblUser3";
            this.lblUser3.Size = new System.Drawing.Size(0, 17);
            this.lblUser3.TabIndex = 6;
            // 
            // lblUser2
            // 
            this.lblUser2.AutoSize = true;
            this.lblUser2.Location = new System.Drawing.Point(505, 166);
            this.lblUser2.Name = "lblUser2";
            this.lblUser2.Size = new System.Drawing.Size(0, 17);
            this.lblUser2.TabIndex = 5;
            // 
            // lblUser1
            // 
            this.lblUser1.AutoSize = true;
            this.lblUser1.Location = new System.Drawing.Point(242, 166);
            this.lblUser1.Name = "lblUser1";
            this.lblUser1.Size = new System.Drawing.Size(0, 17);
            this.lblUser1.TabIndex = 4;
            // 
            // picBoxUser4
            // 
            this.picBoxUser4.Location = new System.Drawing.Point(990, 41);
            this.picBoxUser4.Name = "picBoxUser4";
            this.picBoxUser4.Size = new System.Drawing.Size(103, 86);
            this.picBoxUser4.TabIndex = 3;
            this.picBoxUser4.TabStop = false;
            this.picBoxUser4.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // picBoxUser3
            // 
            this.picBoxUser3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxUser3.Location = new System.Drawing.Point(730, 41);
            this.picBoxUser3.Name = "picBoxUser3";
            this.picBoxUser3.Size = new System.Drawing.Size(103, 86);
            this.picBoxUser3.TabIndex = 2;
            this.picBoxUser3.TabStop = false;
            // 
            // picBoxUser1
            // 
            this.picBoxUser1.Location = new System.Drawing.Point(209, 41);
            this.picBoxUser1.Name = "picBoxUser1";
            this.picBoxUser1.Size = new System.Drawing.Size(103, 86);
            this.picBoxUser1.TabIndex = 0;
            this.picBoxUser1.TabStop = false;
            // 
            // picBoxUser2
            // 
            this.picBoxUser2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxUser2.Location = new System.Drawing.Point(481, 41);
            this.picBoxUser2.Name = "picBoxUser2";
            this.picBoxUser2.Size = new System.Drawing.Size(103, 86);
            this.picBoxUser2.TabIndex = 1;
            this.picBoxUser2.TabStop = false;
            // 
            // lblRoomCode
            // 
            this.lblRoomCode.AutoSize = true;
            this.lblRoomCode.Location = new System.Drawing.Point(125, 38);
            this.lblRoomCode.Name = "lblRoomCode";
            this.lblRoomCode.Size = new System.Drawing.Size(46, 17);
            this.lblRoomCode.TabIndex = 5;
            this.lblRoomCode.Text = "label9";
            // 
            // PlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 751);
            this.Controls.Add(this.pnlStartGame);
            this.Controls.Add(this.lblRoomCode);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlPlaying);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "PlayForm";
            this.Text = "PlayForm";
            this.Load += new System.EventHandler(this.PlayForm_Load);
            this.pnlPlaying.ResumeLayout(false);
            this.pnlPlaying.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlStartGame.ResumeLayout(false);
            this.pnlStartGame.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUser2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlPlaying;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblUser4;
        private System.Windows.Forms.Label lblUser3;
        private System.Windows.Forms.Label lblUser2;
        private System.Windows.Forms.Label lblUser1;
        private System.Windows.Forms.PictureBox picBoxUser4;
        private System.Windows.Forms.PictureBox picBoxUser3;
        private System.Windows.Forms.PictureBox picBoxUser2;
        private System.Windows.Forms.PictureBox picBoxUser1;
        private System.Windows.Forms.Label lblRoomCode;
        private System.Windows.Forms.Panel pnlStartGame;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStartGame;
    }
}