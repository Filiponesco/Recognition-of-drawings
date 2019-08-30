namespace Rozpoznawanie_rysunkow
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnNaucz = new System.Windows.Forms.Button();
            this.btnZgadnij = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnWyczysc = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.BackColor = System.Drawing.Color.Black;
            this.PictureBox.Location = new System.Drawing.Point(12, 41);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(280, 280);
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            this.PictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            this.PictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            this.PictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseMove);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(311, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(232, 264);
            this.listBox1.TabIndex = 1;
            // 
            // btnNaucz
            // 
            this.btnNaucz.Location = new System.Drawing.Point(313, 12);
            this.btnNaucz.Name = "btnNaucz";
            this.btnNaucz.Size = new System.Drawing.Size(75, 23);
            this.btnNaucz.TabIndex = 2;
            this.btnNaucz.Text = "Ucz się";
            this.btnNaucz.UseVisualStyleBackColor = true;
            this.btnNaucz.Click += new System.EventHandler(this.btnNaucz_Click);
            // 
            // btnZgadnij
            // 
            this.btnZgadnij.Location = new System.Drawing.Point(93, 12);
            this.btnZgadnij.Name = "btnZgadnij";
            this.btnZgadnij.Size = new System.Drawing.Size(75, 23);
            this.btnZgadnij.TabIndex = 3;
            this.btnZgadnij.Text = "Zgadnij";
            this.btnZgadnij.UseVisualStyleBackColor = true;
            this.btnZgadnij.Click += new System.EventHandler(this.btnZgadnij_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(394, 12);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnWyczysc
            // 
            this.btnWyczysc.Location = new System.Drawing.Point(12, 12);
            this.btnWyczysc.Name = "btnWyczysc";
            this.btnWyczysc.Size = new System.Drawing.Size(75, 23);
            this.btnWyczysc.TabIndex = 5;
            this.btnWyczysc.Text = "Wyczyść";
            this.btnWyczysc.UseVisualStyleBackColor = true;
            this.btnWyczysc.Click += new System.EventHandler(this.btnWyczysc_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(311, 311);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(232, 10);
            this.progressBar.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 359);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnWyczysc);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnZgadnij);
            this.Controls.Add(this.btnNaucz);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.PictureBox);
            this.Name = "Form1";
            this.Text = "Rozpoznawanie rysunku";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnNaucz;
        private System.Windows.Forms.Button btnZgadnij;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnWyczysc;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

