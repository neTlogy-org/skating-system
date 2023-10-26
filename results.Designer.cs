namespace skating_system
{
    partial class results
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
            export_btn = new Button();
            exit_btn = new Button();
            saveFileDialog1 = new SaveFileDialog();
            label1 = new Label();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.Location = new Point(12, 39);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 374);
            panel1.TabIndex = 0;
            // 
            // export_btn
            // 
            export_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            export_btn.Location = new Point(632, 421);
            export_btn.Name = "export_btn";
            export_btn.Size = new Size(75, 23);
            export_btn.TabIndex = 1;
            export_btn.Text = "Exportovat";
            export_btn.UseVisualStyleBackColor = true;
            export_btn.Click += export_btn_Click;
            // 
            // exit_btn
            // 
            exit_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            exit_btn.Location = new Point(713, 421);
            exit_btn.Name = "exit_btn";
            exit_btn.Size = new Size(75, 23);
            exit_btn.TabIndex = 2;
            exit_btn.Text = "Odejít";
            exit_btn.UseVisualStyleBackColor = true;
            exit_btn.Click += exit_btn_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(367, 9);
            label1.Name = "label1";
            label1.Size = new Size(82, 25);
            label1.TabIndex = 3;
            label1.Text = "Výsledky";
            // 
            // results
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(exit_btn);
            Controls.Add(export_btn);
            Controls.Add(panel1);
            Name = "results";
            Text = "results";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button export_btn;
        private Button exit_btn;
        private SaveFileDialog saveFileDialog1;
        private Label label1;
    }
}