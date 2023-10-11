namespace skating_system
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
            prompt = new Label();
            coupleCnt_TB = new TextBox();
            judgeCnt_TB = new TextBox();
            danceCnt_TB = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            next_btn = new Button();
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
            coupleCnt_TB.Location = new Point(382, 178);
            coupleCnt_TB.Name = "coupleCnt_TB";
            coupleCnt_TB.Size = new Size(100, 23);
            coupleCnt_TB.TabIndex = 1;
            coupleCnt_TB.KeyDown += coupleCnt_TB_KeyDown;
            coupleCnt_TB.KeyPress += coupleCnt_TB_KeyPress;
            // 
            // judgeCnt_TB
            // 
            judgeCnt_TB.Location = new Point(382, 207);
            judgeCnt_TB.Name = "judgeCnt_TB";
            judgeCnt_TB.Size = new Size(100, 23);
            judgeCnt_TB.TabIndex = 2;
            judgeCnt_TB.KeyDown += judgeCnt_TB_KeyDown;
            judgeCnt_TB.KeyPress += judgeCnt_TB_KeyPress;
            // 
            // danceCnt_TB
            // 
            danceCnt_TB.Location = new Point(382, 236);
            danceCnt_TB.Name = "danceCnt_TB";
            danceCnt_TB.Size = new Size(100, 23);
            danceCnt_TB.TabIndex = 3;
            danceCnt_TB.KeyDown += danceCnt_TB_KeyDown;
            danceCnt_TB.KeyPress += danceCnt_TB_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(309, 181);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 4;
            label1.Text = "Počet párů:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(288, 210);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 5;
            label2.Text = "Počet porotců:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(303, 239);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 6;
            label3.Text = "Počet tanců:";
            // 
            // next_btn
            // 
            next_btn.Location = new Point(394, 265);
            next_btn.Name = "next_btn";
            next_btn.Size = new Size(75, 23);
            next_btn.TabIndex = 7;
            next_btn.Text = "Další";
            next_btn.UseVisualStyleBackColor = true;
            next_btn.Click += next_btn_Click;
            next_btn.KeyDown += next_btn_KeyDown;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(next_btn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(danceCnt_TB);
            Controls.Add(judgeCnt_TB);
            Controls.Add(coupleCnt_TB);
            Controls.Add(prompt);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Skating system";
            Load += Form1_Load;
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
    }
}