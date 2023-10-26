namespace skating_system
{
    partial class paramsForm
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
            panel2 = new Panel();
            label1 = new Label();
            label2 = new Label();
            next_btn = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Location = new Point(12, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(248, 345);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(266, 55);
            panel2.Name = "panel2";
            panel2.Size = new Size(522, 345);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(103, 21);
            label1.Name = "label1";
            label1.Size = new Size(60, 28);
            label1.TabIndex = 0;
            label1.Text = "Tance";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(454, 21);
            label2.Name = "label2";
            label2.Size = new Size(141, 28);
            label2.TabIndex = 2;
            label2.Text = "Čísla tanečníků";
            // 
            // next_btn
            // 
            next_btn.Location = new Point(713, 415);
            next_btn.Name = "next_btn";
            next_btn.Size = new Size(75, 23);
            next_btn.TabIndex = 3;
            next_btn.Text = "Další";
            next_btn.UseVisualStyleBackColor = true;
            next_btn.Click += next_btn_Click;
            // 
            // paramsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(next_btn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "paramsForm";
            Text = "Podrobnosti";
            FormClosing += paramsForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Label label2;
        private Button next_btn;
    }
}