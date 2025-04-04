﻿namespace decoder
{
    partial class AboutForm
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
            panel1 = new Panel();
            label2 = new Label();
            buttonClose = new Button();
            logoImage = new PictureBox();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            linkLabel1 = new LinkLabel();
            Close = new Button();
            label7 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoImage).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(buttonClose);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(418, 47);
            panel1.TabIndex = 0;
            panel1.MouseDown += mouse_Down;
            panel1.MouseMove += mouse_Move;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Image = Properties.Resources.icons8_64_bit_32;
            label2.ImageAlign = ContentAlignment.MiddleLeft;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(328, 25);
            label2.TabIndex = 9;
            label2.Text = "      About base64 clipboard convertor";
            label2.TextAlign = ContentAlignment.MiddleRight;
            label2.MouseDown += mouse_Down;
            label2.MouseMove += mouse_Move;
            // 
            // buttonClose
            // 
            buttonClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonClose.BackColor = SystemColors.ControlLight;
            buttonClose.BackgroundImage = Properties.Resources.icons8_close_window_24;
            buttonClose.BackgroundImageLayout = ImageLayout.Zoom;
            buttonClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 128);
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Location = new Point(381, 7);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(30, 30);
            buttonClose.TabIndex = 7;
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // logoImage
            // 
            logoImage.BackgroundImage = Properties.Resources.icons8_64_bit_32;
            logoImage.BackgroundImageLayout = ImageLayout.Zoom;
            logoImage.Dock = DockStyle.Top;
            logoImage.Location = new Point(0, 47);
            logoImage.Name = "logoImage";
            logoImage.Size = new Size(418, 69);
            logoImage.TabIndex = 10;
            logoImage.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(101, 124);
            label1.Name = "label1";
            label1.Size = new Size(212, 21);
            label1.TabIndex = 11;
            label1.Text = "Base64 clipboard convertor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(182, 156);
            label3.Name = "label3";
            label3.Size = new Size(45, 21);
            label3.TabIndex = 12;
            label3.Text = "0.0.2";
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 189);
            label4.Name = "label4";
            label4.Size = new Size(394, 84);
            label4.TabIndex = 13;
            label4.Text = "  A utility application designed to seamlessly convert Base64-encoded strings into plain text and automatically copy the result to your clipboard for efficient integration and use.";
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 11.25F);
            label5.Location = new Point(12, 366);
            label5.Name = "label5";
            label5.Size = new Size(394, 51);
            label5.TabIndex = 14;
            label5.Text = "This project is open-source and licensed under the MIT License.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F);
            label6.Location = new Point(13, 419);
            label6.Name = "label6";
            label6.Size = new Size(228, 20);
            label6.TabIndex = 15;
            label6.Text = "The source code can be found at:";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.Location = new Point(247, 417);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(42, 20);
            linkLabel1.TabIndex = 16;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "[link]";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Close
            // 
            Close.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Close.Location = new Point(305, 454);
            Close.Name = "Close";
            Close.Size = new Size(101, 34);
            Close.TabIndex = 17;
            Close.Text = "Close";
            Close.UseVisualStyleBackColor = true;
            Close.Click += Close_Click;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(12, 276);
            label7.Name = "label7";
            label7.Size = new Size(394, 84);
            label7.TabIndex = 18;
            label7.Text = "This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.";
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 501);
            Controls.Add(label7);
            Controls.Add(Close);
            Controls.Add(linkLabel1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(logoImage);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AboutForm";
            Text = "AboutForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button buttonClose;
        private Label label2;
        private PictureBox logoImage;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private LinkLabel linkLabel1;
        private Button Close;
        private Label label7;
    }
}