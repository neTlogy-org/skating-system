namespace skating_system
{
    partial class dances
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
            label1 = new Label();
            dance_TB = new TextBox();
            next_btn = new Button();
            back_btn = new Button();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(292, 27);
            label1.Name = "label1";
            label1.Size = new Size(55, 25);
            label1.TabIndex = 0;
            label1.Text = "Tanec";
            // 
            // dance_TB
            // 
            dance_TB.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            dance_TB.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            dance_TB.Location = new Point(353, 24);
            dance_TB.Name = "dance_TB";
            dance_TB.Size = new Size(156, 31);
            dance_TB.TabIndex = 1;
            // 
            // next_btn
            // 
            next_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            next_btn.Location = new Point(713, 420);
            next_btn.Name = "next_btn";
            next_btn.Size = new Size(75, 23);
            next_btn.TabIndex = 5;
            next_btn.Text = "Další";
            next_btn.UseVisualStyleBackColor = true;
            next_btn.Click += next_btn_Click;
            // 
            // back_btn
            // 
            back_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            back_btn.Enabled = false;
            back_btn.Location = new Point(12, 420);
            back_btn.Name = "back_btn";
            back_btn.Size = new Size(75, 23);
            back_btn.TabIndex = 6;
            back_btn.Text = "Zpět";
            back_btn.UseVisualStyleBackColor = true;
            back_btn.Click += back_btn_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.Location = new Point(12, 76);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 338);
            panel1.TabIndex = 7;
            // 
            // dances
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dance_TB);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(back_btn);
            Controls.Add(next_btn);
            MinimumSize = new Size(816, 489);
            Name = "dances";
            Text = "Tance";
            FormClosed += dances_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox dance_TB;
        private Button next_btn;
        private Button back_btn;
        private Panel panel1;
    }
}