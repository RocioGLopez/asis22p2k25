
namespace CapaVista_Seguridad
{
    partial class frmBitacora
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
            this.Dgv_Bitacora = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Dtp_PrimeraFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.Dtp_SegundaFecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.Btn_BuscarRango = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Bitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // Dgv_Bitacora
            // 
            this.Dgv_Bitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Bitacora.Location = new System.Drawing.Point(28, 120);
            this.Dgv_Bitacora.Name = "Dgv_Bitacora";
            this.Dgv_Bitacora.RowHeadersWidth = 51;
            this.Dgv_Bitacora.RowTemplate.Height = 24;
            this.Dgv_Bitacora.Size = new System.Drawing.Size(789, 422);
            this.Dgv_Bitacora.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Consulta de Bitacora";
            // 
            // Dtp_PrimeraFecha
            // 
            this.Dtp_PrimeraFecha.Location = new System.Drawing.Point(220, 88);
            this.Dtp_PrimeraFecha.Name = "Dtp_PrimeraFecha";
            this.Dtp_PrimeraFecha.Size = new System.Drawing.Size(200, 22);
            this.Dtp_PrimeraFecha.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Primera Fecha";
            // 
            // Dtp_SegundaFecha
            // 
            this.Dtp_SegundaFecha.Location = new System.Drawing.Point(440, 88);
            this.Dtp_SegundaFecha.Name = "Dtp_SegundaFecha";
            this.Dtp_SegundaFecha.Size = new System.Drawing.Size(200, 22);
            this.Dtp_SegundaFecha.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(437, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Segunda Fecha";
            // 
            // Btn_BuscarRango
            // 
            this.Btn_BuscarRango.Location = new System.Drawing.Point(670, 38);
            this.Btn_BuscarRango.Name = "Btn_BuscarRango";
            this.Btn_BuscarRango.Size = new System.Drawing.Size(98, 72);
            this.Btn_BuscarRango.TabIndex = 6;
            this.Btn_BuscarRango.Text = "Buscar Rango";
            this.Btn_BuscarRango.UseVisualStyleBackColor = true;
            this.Btn_BuscarRango.Click += new System.EventHandler(this.Btn_BuscarRango_Click);
            // 
            // frmBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 571);
            this.Controls.Add(this.Btn_BuscarRango);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Dtp_SegundaFecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Dtp_PrimeraFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Dgv_Bitacora);
            this.Name = "frmBitacora";
            this.Text = "frmBitacora";
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Bitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Dgv_Bitacora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker Dtp_PrimeraFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker Dtp_SegundaFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Btn_BuscarRango;
    }
}