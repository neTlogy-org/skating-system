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
            pairCnt_TB = new TextBox();
            judgeCnt_TB = new TextBox();
            danceCnt_TB = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ok_btn = new Button();
            richTextBox1 = new RichTextBox();
            next_btn = new Button();
            SuspendLayout();
            // 
            // prompt
            // 
            prompt.AutoSize = true;
            prompt.BackColor = SystemColors.Control;
            prompt.Location = new Point(168, 30);
            prompt.Name = "prompt";
            prompt.Size = new Size(142, 15);
            prompt.TabIndex = 0;
            prompt.Text = "Zadejte parametry vpravo";
            // 
            // pairCnt_TB
            // 
            pairCnt_TB.Location = new Point(556, 163);
            pairCnt_TB.Name = "pairCnt_TB";
            pairCnt_TB.Size = new Size(100, 23);
            pairCnt_TB.TabIndex = 1;
            // 
            // judgeCnt_TB
            // 
            judgeCnt_TB.Location = new Point(556, 192);
            judgeCnt_TB.Name = "judgeCnt_TB";
            judgeCnt_TB.Size = new Size(100, 23);
            judgeCnt_TB.TabIndex = 2;
            // 
            // danceCnt_TB
            // 
            danceCnt_TB.Location = new Point(556, 221);
            danceCnt_TB.Name = "danceCnt_TB";
            danceCnt_TB.Size = new Size(100, 23);
            danceCnt_TB.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(483, 166);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 4;
            label1.Text = "Počet párů:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(462, 195);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 5;
            label2.Text = "Počet porodců:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(477, 224);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 6;
            label3.Text = "Počet tanců:";
            // 
            // ok_btn
            // 
            ok_btn.Location = new Point(568, 250);
            ok_btn.Name = "ok_btn";
            ok_btn.Size = new Size(75, 23);
            ok_btn.TabIndex = 7;
            ok_btn.Text = "OK";
            ok_btn.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(60, 65);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(350, 350);
            richTextBox1.TabIndex = 8;
            richTextBox1.Text = "";
            // 
            // next_btn
            // 
            next_btn.Location = new Point(335, 421);
            next_btn.Name = "next_btn";
            next_btn.Size = new Size(75, 23);
            next_btn.TabIndex = 9;
            next_btn.Text = "Next";
            next_btn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(next_btn);
            Controls.Add(richTextBox1);
            Controls.Add(ok_btn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(danceCnt_TB);
            Controls.Add(judgeCnt_TB);
            Controls.Add(pairCnt_TB);
            Controls.Add(prompt);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label prompt;
        private TextBox pairCnt_TB;
        private TextBox judgeCnt_TB;
        private TextBox danceCnt_TB;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button ok_btn;
        private RichTextBox richTextBox1;
        private Button next_btn;
    }
}