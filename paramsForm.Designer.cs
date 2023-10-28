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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(paramsForm));
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            label2 = new Label();
            next_btn = new Button();
            stt4_btn = new Button();
            stt5_btn = new Button();
            lat4_btn = new Button();
            lat5_btn = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Location = new Point(12, 79);
            panel1.Name = "panel1";
            panel1.Size = new Size(248, 321);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(266, 79);
            panel2.Name = "panel2";
            panel2.Size = new Size(522, 321);
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
            // stt4_btn
            // 
            stt4_btn.Location = new Point(38, 57);
            stt4_btn.Name = "stt4_btn";
            stt4_btn.Size = new Size(46, 23);
            stt4_btn.TabIndex = 4;
            stt4_btn.Text = "STT 4";
            stt4_btn.UseVisualStyleBackColor = true;
            stt4_btn.Click += stt4_btn_Click;
            // 
            // stt5_btn
            // 
            stt5_btn.Location = new Point(88, 57);
            stt5_btn.Name = "stt5_btn";
            stt5_btn.Size = new Size(46, 23);
            stt5_btn.TabIndex = 5;
            stt5_btn.Text = "STT 5";
            stt5_btn.UseVisualStyleBackColor = true;
            stt5_btn.Click += stt5_btn_Click;
            // 
            // lat4_btn
            // 
            lat4_btn.Location = new Point(138, 57);
            lat4_btn.Name = "lat4_btn";
            lat4_btn.Size = new Size(46, 23);
            lat4_btn.TabIndex = 6;
            lat4_btn.Text = "LAT 4";
            lat4_btn.UseVisualStyleBackColor = true;
            lat4_btn.Click += lat4_btn_Click;
            // 
            // lat5_btn
            // 
            lat5_btn.Location = new Point(188, 57);
            lat5_btn.Name = "lat5_btn";
            lat5_btn.Size = new Size(46, 23);
            lat5_btn.TabIndex = 7;
            lat5_btn.Text = "LAT 5";
            lat5_btn.UseVisualStyleBackColor = true;
            lat5_btn.Click += lat5_btn_Click;
            // 
            // paramsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lat5_btn);
            Controls.Add(lat4_btn);
            Controls.Add(stt5_btn);
            Controls.Add(stt4_btn);
            Controls.Add(next_btn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private Button stt4_btn;
        private Button stt5_btn;
        private Button lat4_btn;
        private Button lat5_btn;
    }
}