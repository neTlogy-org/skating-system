﻿namespace skating_system
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            prompt = new Label();
            coupleCnt_TB = new TextBox();
            judgeCnt_TB = new TextBox();
            danceCnt_TB = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            next_btn = new Button();
            label4 = new Label();
            contestName_TB = new TextBox();
            SuspendLayout();
            // 
            // prompt
            // 
            prompt.AutoSize = true;
            prompt.BackColor = SystemColors.Control;
            prompt.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            prompt.Location = new Point(263, 64);
            prompt.Name = "prompt";
            prompt.Size = new Size(293, 28);
            prompt.TabIndex = 0;
            prompt.Text = "Vítejte v Artimo skating systému";
            // 
            // coupleCnt_TB
            // 
            coupleCnt_TB.Location = new Point(392, 158);
            coupleCnt_TB.Name = "coupleCnt_TB";
            coupleCnt_TB.Size = new Size(100, 23);
            coupleCnt_TB.TabIndex = 1;
            coupleCnt_TB.KeyDown += coupleCnt_TB_KeyDown;
            coupleCnt_TB.KeyPress += coupleCnt_TB_KeyPress;
            // 
            // judgeCnt_TB
            // 
            judgeCnt_TB.Location = new Point(392, 187);
            judgeCnt_TB.Name = "judgeCnt_TB";
            judgeCnt_TB.Size = new Size(100, 23);
            judgeCnt_TB.TabIndex = 2;
            judgeCnt_TB.KeyDown += judgeCnt_TB_KeyDown;
            judgeCnt_TB.KeyPress += judgeCnt_TB_KeyPress;
            // 
            // danceCnt_TB
            // 
            danceCnt_TB.Location = new Point(392, 216);
            danceCnt_TB.Name = "danceCnt_TB";
            danceCnt_TB.Size = new Size(100, 23);
            danceCnt_TB.TabIndex = 3;
            danceCnt_TB.KeyDown += danceCnt_TB_KeyDown;
            danceCnt_TB.KeyPress += danceCnt_TB_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(319, 161);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 4;
            label1.Text = "Počet párů:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(298, 190);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 5;
            label2.Text = "Počet porotců:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(313, 219);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 6;
            label3.Text = "Počet tanců:";
            // 
            // next_btn
            // 
            next_btn.Location = new Point(404, 245);
            next_btn.Name = "next_btn";
            next_btn.Size = new Size(75, 23);
            next_btn.TabIndex = 7;
            next_btn.Text = "Další";
            next_btn.UseVisualStyleBackColor = true;
            next_btn.Click += next_btn_Click;
            next_btn.KeyDown += next_btn_KeyDown;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(301, 132);
            label4.Name = "label4";
            label4.Size = new Size(85, 15);
            label4.TabIndex = 9;
            label4.Text = "Název soutěže:";
            // 
            // contestName_TB
            // 
            contestName_TB.Location = new Point(392, 129);
            contestName_TB.Name = "contestName_TB";
            contestName_TB.Size = new Size(100, 23);
            contestName_TB.TabIndex = 8;
            contestName_TB.KeyDown += contestName_TB_KeyDown;
            contestName_TB.KeyPress += contestName_TB_KeyPress;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(contestName_TB);
            Controls.Add(next_btn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(danceCnt_TB);
            Controls.Add(judgeCnt_TB);
            Controls.Add(coupleCnt_TB);
            Controls.Add(prompt);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "Skating system";
            FormClosing += Form1_FormClosing;
            Shown += Form1_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label prompt;
        private TextBox coupleCnt_TB;
        private TextBox judgeCnt_TB;
        private TextBox danceCnt_TB;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button next_btn;
        private Label label4;
        private TextBox contestName_TB;
    }
}