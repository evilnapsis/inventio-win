namespace inventio_win
{
    partial class AddToSellDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ix = new System.Windows.Forms.TextBox();
            this.pname = new System.Windows.Forms.TextBox();
            this.price_in = new System.Windows.Forms.TextBox();
            this.q = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Producto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Precio";
            // 
            // ix
            // 
            this.ix.Location = new System.Drawing.Point(192, 16);
            this.ix.Name = "ix";
            this.ix.ReadOnly = true;
            this.ix.Size = new System.Drawing.Size(194, 20);
            this.ix.TabIndex = 3;
            // 
            // pname
            // 
            this.pname.Location = new System.Drawing.Point(192, 42);
            this.pname.Name = "pname";
            this.pname.ReadOnly = true;
            this.pname.Size = new System.Drawing.Size(194, 20);
            this.pname.TabIndex = 4;
            // 
            // price_in
            // 
            this.price_in.Location = new System.Drawing.Point(192, 68);
            this.price_in.Name = "price_in";
            this.price_in.ReadOnly = true;
            this.price_in.Size = new System.Drawing.Size(194, 20);
            this.price_in.TabIndex = 5;
            // 
            // q
            // 
            this.q.Location = new System.Drawing.Point(192, 94);
            this.q.Name = "q";
            this.q.Size = new System.Drawing.Size(194, 20);
            this.q.TabIndex = 6;
            this.q.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cantidad";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(254, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SellDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 183);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.q);
            this.Controls.Add(this.price_in);
            this.Controls.Add(this.pname);
            this.Controls.Add(this.ix);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SellDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agregar a la venta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ix;
        private System.Windows.Forms.TextBox pname;
        private System.Windows.Forms.TextBox price_in;
        private System.Windows.Forms.TextBox q;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}