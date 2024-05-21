namespace Integração
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
            Integrar = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // Integrar
            // 
            Integrar.BackColor = Color.Red;
            Integrar.Location = new Point(281, 159);
            Integrar.Name = "Integrar";
            Integrar.Size = new Size(229, 57);
            Integrar.TabIndex = 0;
            Integrar.Text = "INTEGRAR";
            Integrar.UseVisualStyleBackColor = false;
            Integrar.Click += Integrar_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.DarkSlateGray;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.ForeColor = Color.GhostWhite;
            label2.Location = new Point(-4, 399);
            label2.Name = "label2";
            label2.Size = new Size(796, 50);
            label2.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(791, 450);
            Controls.Add(label2);
            Controls.Add(Integrar);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }





        #endregion

        private Button Integrar;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
    }
}