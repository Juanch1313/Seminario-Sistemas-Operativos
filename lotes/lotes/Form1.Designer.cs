namespace lotes
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DgvLote = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lotte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tiempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFinalizados = new System.Windows.Forms.DataGridView();
            this.LbPendientes = new System.Windows.Forms.Label();
            this.lbID = new System.Windows.Forms.Label();
            this.LbOperator = new System.Windows.Forms.Label();
            this.LbTime = new System.Windows.Forms.Label();
            this.LbTimeTrans = new System.Windows.Forms.Label();
            this.LbTimeRes = new System.Windows.Forms.Label();
            this.LbValor1 = new System.Windows.Forms.Label();
            this.LbValor2 = new System.Windows.Forms.Label();
            this.LbReloj = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TbNumProcesos = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinalizados)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvLote
            // 
            this.DgvLote.AllowUserToAddRows = false;
            this.DgvLote.AllowUserToDeleteRows = false;
            this.DgvLote.BackgroundColor = System.Drawing.Color.White;
            this.DgvLote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLote.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Lotte,
            this.Valor1,
            this.Tipo,
            this.Valor2,
            this.Tiempo});
            this.DgvLote.Location = new System.Drawing.Point(23, 81);
            this.DgvLote.Name = "DgvLote";
            this.DgvLote.ReadOnly = true;
            this.DgvLote.Size = new System.Drawing.Size(341, 143);
            this.DgvLote.TabIndex = 16;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 50;
            // 
            // Lotte
            // 
            this.Lotte.HeaderText = "Lote";
            this.Lotte.Name = "Lotte";
            this.Lotte.ReadOnly = true;
            this.Lotte.Width = 50;
            // 
            // Valor1
            // 
            this.Valor1.HeaderText = "Valor1";
            this.Valor1.Name = "Valor1";
            this.Valor1.ReadOnly = true;
            this.Valor1.Width = 50;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 50;
            // 
            // Valor2
            // 
            this.Valor2.HeaderText = "Valor2";
            this.Valor2.Name = "Valor2";
            this.Valor2.ReadOnly = true;
            this.Valor2.Width = 50;
            // 
            // Tiempo
            // 
            this.Tiempo.HeaderText = "Tiempo";
            this.Tiempo.Name = "Tiempo";
            this.Tiempo.ReadOnly = true;
            this.Tiempo.Width = 50;
            // 
            // dgvFinalizados
            // 
            this.dgvFinalizados.AllowUserToDeleteRows = false;
            this.dgvFinalizados.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dgvFinalizados.BackgroundColor = System.Drawing.Color.White;
            this.dgvFinalizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFinalizados.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFinalizados.Location = new System.Drawing.Point(100, 19);
            this.dgvFinalizados.Name = "dgvFinalizados";
            this.dgvFinalizados.ReadOnly = true;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFinalizados.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFinalizados.Size = new System.Drawing.Size(846, 258);
            this.dgvFinalizados.TabIndex = 18;
            // 
            // LbPendientes
            // 
            this.LbPendientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LbPendientes.AutoSize = true;
            this.LbPendientes.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbPendientes.ForeColor = System.Drawing.Color.White;
            this.LbPendientes.Location = new System.Drawing.Point(20, 20);
            this.LbPendientes.Name = "LbPendientes";
            this.LbPendientes.Size = new System.Drawing.Size(130, 21);
            this.LbPendientes.TabIndex = 19;
            this.LbPendientes.Text = "Lotes pendientes:";
            // 
            // lbID
            // 
            this.lbID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbID.AutoSize = true;
            this.lbID.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbID.ForeColor = System.Drawing.Color.White;
            this.lbID.Location = new System.Drawing.Point(421, 82);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(28, 21);
            this.lbID.TabIndex = 22;
            this.lbID.Text = "ID:";
            // 
            // LbOperator
            // 
            this.LbOperator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LbOperator.AutoSize = true;
            this.LbOperator.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbOperator.ForeColor = System.Drawing.Color.White;
            this.LbOperator.Location = new System.Drawing.Point(421, 164);
            this.LbOperator.Name = "LbOperator";
            this.LbOperator.Size = new System.Drawing.Size(82, 21);
            this.LbOperator.TabIndex = 23;
            this.LbOperator.Text = "Operación";
            // 
            // LbTime
            // 
            this.LbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LbTime.AutoSize = true;
            this.LbTime.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTime.ForeColor = System.Drawing.Color.White;
            this.LbTime.Location = new System.Drawing.Point(734, 82);
            this.LbTime.Name = "LbTime";
            this.LbTime.Size = new System.Drawing.Size(122, 21);
            this.LbTime.TabIndex = 24;
            this.LbTime.Text = "Tiempo maximo";
            // 
            // LbTimeTrans
            // 
            this.LbTimeTrans.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LbTimeTrans.AutoSize = true;
            this.LbTimeTrans.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTimeTrans.ForeColor = System.Drawing.Color.White;
            this.LbTimeTrans.Location = new System.Drawing.Point(734, 164);
            this.LbTimeTrans.Name = "LbTimeTrans";
            this.LbTimeTrans.Size = new System.Drawing.Size(142, 21);
            this.LbTimeTrans.TabIndex = 25;
            this.LbTimeTrans.Text = "Tiempo trascurrido";
            // 
            // LbTimeRes
            // 
            this.LbTimeRes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LbTimeRes.AutoSize = true;
            this.LbTimeRes.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTimeRes.ForeColor = System.Drawing.Color.White;
            this.LbTimeRes.Location = new System.Drawing.Point(734, 122);
            this.LbTimeRes.Name = "LbTimeRes";
            this.LbTimeRes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LbTimeRes.Size = new System.Drawing.Size(122, 21);
            this.LbTimeRes.TabIndex = 26;
            this.LbTimeRes.Text = "Tiempo restante";
            // 
            // LbValor1
            // 
            this.LbValor1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LbValor1.AutoSize = true;
            this.LbValor1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbValor1.ForeColor = System.Drawing.Color.White;
            this.LbValor1.Location = new System.Drawing.Point(421, 122);
            this.LbValor1.Name = "LbValor1";
            this.LbValor1.Size = new System.Drawing.Size(84, 21);
            this.LbValor1.TabIndex = 30;
            this.LbValor1.Text = "Numero 1:";
            // 
            // LbValor2
            // 
            this.LbValor2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LbValor2.AutoSize = true;
            this.LbValor2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbValor2.ForeColor = System.Drawing.Color.White;
            this.LbValor2.Location = new System.Drawing.Point(421, 203);
            this.LbValor2.Name = "LbValor2";
            this.LbValor2.Size = new System.Drawing.Size(84, 21);
            this.LbValor2.TabIndex = 31;
            this.LbValor2.Text = "Numero 2:";
            // 
            // LbReloj
            // 
            this.LbReloj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LbReloj.AutoSize = true;
            this.LbReloj.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbReloj.ForeColor = System.Drawing.Color.White;
            this.LbReloj.Location = new System.Drawing.Point(571, 20);
            this.LbReloj.Name = "LbReloj";
            this.LbReloj.Size = new System.Drawing.Size(161, 21);
            this.LbReloj.TabIndex = 32;
            this.LbReloj.Text = "Temporizador global: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(115)))), ((int)(((byte)(94)))));
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lbID);
            this.groupBox2.Controls.Add(this.LbReloj);
            this.groupBox2.Controls.Add(this.LbOperator);
            this.groupBox2.Controls.Add(this.LbValor2);
            this.groupBox2.Controls.Add(this.LbTime);
            this.groupBox2.Controls.Add(this.LbValor1);
            this.groupBox2.Controls.Add(this.LbTimeTrans);
            this.groupBox2.Controls.Add(this.DgvLote);
            this.groupBox2.Controls.Add(this.LbTimeRes);
            this.groupBox2.Controls.Add(this.LbPendientes);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(7, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1035, 258);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Procesamiento";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(421, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 21);
            this.label10.TabIndex = 34;
            this.label10.Text = "Proceso en ejecución";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(19, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 21);
            this.label8.TabIndex = 33;
            this.label8.Text = "Lote en ejecución";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(115)))), ((int)(((byte)(94)))));
            this.groupBox3.Controls.Add(this.dgvFinalizados);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(7, 382);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1035, 287);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Procesos terminados";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(84)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(587, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 51);
            this.button2.TabIndex = 15;
            this.button2.Text = "GO!";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(393, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "Numero de procesos";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(6, 40);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(297, 21);
            this.label17.TabIndex = 28;
            this.label17.Text = "Proceso por lotes con Multiprogramación";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(115)))), ((int)(((byte)(94)))));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TbNumProcesos);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1034, 100);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos necesarios";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(834, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 42);
            this.label1.TabIndex = 30;
            this.label1.Text = "Carlos Alberto Ceja Zapata\r\nJuan Rodríguez Tabares\r\n";
            // 
            // TbNumProcesos
            // 
            this.TbNumProcesos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TbNumProcesos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(84)))));
            this.TbNumProcesos.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbNumProcesos.ForeColor = System.Drawing.Color.White;
            this.TbNumProcesos.Location = new System.Drawing.Point(423, 40);
            this.TbNumProcesos.Name = "TbNumProcesos";
            this.TbNumProcesos.Size = new System.Drawing.Size(100, 28);
            this.TbNumProcesos.TabIndex = 29;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(84)))));
            this.ClientSize = new System.Drawing.Size(1054, 681);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Proceso por lotes con Multiprogramación";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvLote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinalizados)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView DgvLote;
        private System.Windows.Forms.DataGridView dgvFinalizados;
        private System.Windows.Forms.Label LbPendientes;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label LbOperator;
        private System.Windows.Forms.Label LbTime;
        private System.Windows.Forms.Label LbTimeTrans;
        private System.Windows.Forms.Label LbTimeRes;
        private System.Windows.Forms.Label LbValor1;
        private System.Windows.Forms.Label LbValor2;
        private System.Windows.Forms.Label LbReloj;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lotte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tiempo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TbNumProcesos;
        private System.Windows.Forms.Label label1;
    }
}

