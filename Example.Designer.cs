namespace Animator
{
    partial class Example
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_animate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_animate
            // 
            this.btn_animate.Location = new System.Drawing.Point(12, 12);
            this.btn_animate.Name = "btn_animate";
            this.btn_animate.Size = new System.Drawing.Size(191, 60);
            this.btn_animate.TabIndex = 0;
            this.btn_animate.Text = "ANIMATE !";
            this.btn_animate.UseVisualStyleBackColor = true;
            this.btn_animate.Click += new System.EventHandler(this.btn_animate_Click);
            // 
            // Example
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 87);
            this.Controls.Add(this.btn_animate);
            this.Name = "Example";
            this.Text = "C# Animator - Example";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_animate;
    }
}

