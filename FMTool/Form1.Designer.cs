namespace FMTool
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
            btnStart = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(271, 146);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(157, 59);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(83, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(521, 27);
            textBox1.TabIndex = 2;
            textBox1.Text = "C:\\Users\\vinhd\\Downloads\\new tool\\Demo tool (3)\\Demo tool\\testXML\\e_FCMP.mif";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 217);
            Controls.Add(textBox1);
            Controls.Add(btnStart);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnStart;
        private TextBox textBox1;
    }
}