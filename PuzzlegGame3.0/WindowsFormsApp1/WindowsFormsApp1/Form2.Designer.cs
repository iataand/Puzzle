namespace WindowsFormsApp1
{
    partial class Form2
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
            this.buttonJocNou = new System.Windows.Forms.Button();
            this.buttonClasament = new System.Windows.Forms.Button();
            this.buttonIesire = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonJocNou
            // 
            this.buttonJocNou.Location = new System.Drawing.Point(202, 194);
            this.buttonJocNou.Name = "buttonJocNou";
            this.buttonJocNou.Size = new System.Drawing.Size(75, 23);
            this.buttonJocNou.TabIndex = 1;
            this.buttonJocNou.Text = "Joc nou";
            this.buttonJocNou.UseVisualStyleBackColor = true;
            this.buttonJocNou.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonClasament
            // 
            this.buttonClasament.Location = new System.Drawing.Point(202, 223);
            this.buttonClasament.Name = "buttonClasament";
            this.buttonClasament.Size = new System.Drawing.Size(75, 23);
            this.buttonClasament.TabIndex = 2;
            this.buttonClasament.Text = "Clasament";
            this.buttonClasament.UseVisualStyleBackColor = true;
            this.buttonClasament.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonIesire
            // 
            this.buttonIesire.Location = new System.Drawing.Point(202, 252);
            this.buttonIesire.Name = "buttonIesire";
            this.buttonIesire.Size = new System.Drawing.Size(75, 23);
            this.buttonIesire.TabIndex = 3;
            this.buttonIesire.Text = "Iesire";
            this.buttonIesire.UseVisualStyleBackColor = true;
            this.buttonIesire.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Introdu Username:";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(202, 92);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(100, 20);
            this.userName.TabIndex = 5;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 350);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonIesire);
            this.Controls.Add(this.buttonClasament);
            this.Controls.Add(this.buttonJocNou);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonJocNou;
        private System.Windows.Forms.Button buttonClasament;
        private System.Windows.Forms.Button buttonIesire;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userName;
    }
}