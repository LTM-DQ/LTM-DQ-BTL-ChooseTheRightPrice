namespace Client3
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnJoinRoomRandom = new System.Windows.Forms.Button();
            this.btnJoinRoomByCode = new System.Windows.Forms.Button();
            this.txtRoomCodeInput = new System.Windows.Forms.TextBox();
            this.btnCreateRoom = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Font = new System.Drawing.Font("Minion Pro", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(982, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Logout";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Minion Pro", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(168, 67);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(79, 24);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "username";
            // 
            // btnJoinRoomRandom
            // 
            this.btnJoinRoomRandom.BackColor = System.Drawing.Color.Olive;
            this.btnJoinRoomRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJoinRoomRandom.ForeColor = System.Drawing.Color.White;
            this.btnJoinRoomRandom.Location = new System.Drawing.Point(185, 222);
            this.btnJoinRoomRandom.Name = "btnJoinRoomRandom";
            this.btnJoinRoomRandom.Size = new System.Drawing.Size(280, 83);
            this.btnJoinRoomRandom.TabIndex = 3;
            this.btnJoinRoomRandom.Text = "Play Now";
            this.btnJoinRoomRandom.UseVisualStyleBackColor = false;
            this.btnJoinRoomRandom.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnJoinRoomByCode
            // 
            this.btnJoinRoomByCode.BackColor = System.Drawing.Color.Olive;
            this.btnJoinRoomByCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJoinRoomByCode.ForeColor = System.Drawing.Color.White;
            this.btnJoinRoomByCode.Location = new System.Drawing.Point(559, 52);
            this.btnJoinRoomByCode.Name = "btnJoinRoomByCode";
            this.btnJoinRoomByCode.Size = new System.Drawing.Size(125, 36);
            this.btnJoinRoomByCode.TabIndex = 4;
            this.btnJoinRoomByCode.Text = "Join Room";
            this.btnJoinRoomByCode.UseVisualStyleBackColor = false;
            this.btnJoinRoomByCode.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtRoomCodeInput
            // 
            this.txtRoomCodeInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomCodeInput.Location = new System.Drawing.Point(559, 12);
            this.txtRoomCodeInput.Name = "txtRoomCodeInput";
            this.txtRoomCodeInput.Size = new System.Drawing.Size(146, 34);
            this.txtRoomCodeInput.TabIndex = 5;
            // 
            // btnCreateRoom
            // 
            this.btnCreateRoom.BackColor = System.Drawing.Color.Olive;
            this.btnCreateRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateRoom.ForeColor = System.Drawing.Color.White;
            this.btnCreateRoom.Location = new System.Drawing.Point(185, 408);
            this.btnCreateRoom.Name = "btnCreateRoom";
            this.btnCreateRoom.Size = new System.Drawing.Size(280, 83);
            this.btnCreateRoom.TabIndex = 6;
            this.btnCreateRoom.Text = "Create room";
            this.btnCreateRoom.UseVisualStyleBackColor = false;
            this.btnCreateRoom.Click += new System.EventHandler(this.btnCreateRoom_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Minion Pro", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(473, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "RoomID";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Orator Std", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(145, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 31);
            this.label2.TabIndex = 8;
            this.label2.Text = "Welcome !";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client3.Properties.Resources.mainform;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1136, 604);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCreateRoom);
            this.Controls.Add(this.txtRoomCodeInput);
            this.Controls.Add(this.btnJoinRoomByCode);
            this.Controls.Add(this.btnJoinRoomRandom);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnJoinRoomRandom;
        private System.Windows.Forms.Button btnJoinRoomByCode;
        private System.Windows.Forms.TextBox txtRoomCodeInput;
        private System.Windows.Forms.Button btnCreateRoom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}