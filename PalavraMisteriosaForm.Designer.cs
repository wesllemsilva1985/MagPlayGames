namespace MagiPlay
{
    partial class PalavraMisteriosaForm
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
            this.components = new System.ComponentModel.Container();
            this.labelPalavraAtual = new System.Windows.Forms.Label();
            this.textBoxPalavraInformada = new System.Windows.Forms.TextBox();
            this.tmrTeste = new System.Windows.Forms.Timer(this.components);
            this.lblPalavraSorteada = new System.Windows.Forms.Label();
            this.buttonRevelarPalavra = new System.Windows.Forms.Button();
            this.buttonRevelarLetra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelPalavraAtual
            // 
            this.labelPalavraAtual.AutoSize = true;
            this.labelPalavraAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPalavraAtual.Location = new System.Drawing.Point(12, 20);
            this.labelPalavraAtual.Name = "labelPalavraAtual";
            this.labelPalavraAtual.Size = new System.Drawing.Size(156, 24);
            this.labelPalavraAtual.TabIndex = 0;
            this.labelPalavraAtual.Text = "Palavra Sorteada:";
            // 
            // textBoxPalavraInformada
            // 
            this.textBoxPalavraInformada.Location = new System.Drawing.Point(104, 247);
            this.textBoxPalavraInformada.Name = "textBoxPalavraInformada";
            this.textBoxPalavraInformada.Size = new System.Drawing.Size(353, 20);
            this.textBoxPalavraInformada.TabIndex = 2;
            // 
            // tmrTeste
            // 
            this.tmrTeste.Enabled = true;
            this.tmrTeste.Interval = 1000;
            this.tmrTeste.Tick += new System.EventHandler(this.tmrTeste_Tick);
            // 
            // lblPalavraSorteada
            // 
            this.lblPalavraSorteada.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalavraSorteada.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblPalavraSorteada.Location = new System.Drawing.Point(174, 20);
            this.lblPalavraSorteada.Name = "lblPalavraSorteada";
            this.lblPalavraSorteada.Size = new System.Drawing.Size(372, 24);
            this.lblPalavraSorteada.TabIndex = 3;
            this.lblPalavraSorteada.Text = "---";
            // 
            // buttonRevelarPalavra
            // 
            this.buttonRevelarPalavra.Location = new System.Drawing.Point(16, 102);
            this.buttonRevelarPalavra.Name = "buttonRevelarPalavra";
            this.buttonRevelarPalavra.Size = new System.Drawing.Size(75, 23);
            this.buttonRevelarPalavra.TabIndex = 4;
            this.buttonRevelarPalavra.Text = "button1";
            this.buttonRevelarPalavra.UseVisualStyleBackColor = true;
            this.buttonRevelarPalavra.Click += new System.EventHandler(this.buttonRevelarPalavra_Click);
            // 
            // buttonRevelarLetra
            // 
            this.buttonRevelarLetra.Location = new System.Drawing.Point(104, 102);
            this.buttonRevelarLetra.Name = "buttonRevelarLetra";
            this.buttonRevelarLetra.Size = new System.Drawing.Size(75, 23);
            this.buttonRevelarLetra.TabIndex = 5;
            this.buttonRevelarLetra.Text = "button1";
            this.buttonRevelarLetra.UseVisualStyleBackColor = true;
            this.buttonRevelarLetra.Click += new System.EventHandler(this.buttonRevelarLetra_Click);
            // 
            // PalavraMisteriosaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonRevelarLetra);
            this.Controls.Add(this.buttonRevelarPalavra);
            this.Controls.Add(this.lblPalavraSorteada);
            this.Controls.Add(this.textBoxPalavraInformada);
            this.Controls.Add(this.labelPalavraAtual);
            this.Name = "PalavraMisteriosaForm";
            this.Text = "PalavraMisteriosaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPalavraAtual;
        private System.Windows.Forms.TextBox textBoxPalavraInformada;
        private System.Windows.Forms.Timer tmrTeste;
        private System.Windows.Forms.Label lblPalavraSorteada;
        private System.Windows.Forms.Button buttonRevelarPalavra;
        private System.Windows.Forms.Button buttonRevelarLetra;
    }
}