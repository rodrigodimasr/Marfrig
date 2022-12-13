namespace Marfrig.UI.Forms
{
    partial class Consulta
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
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.materialRaisedButton3 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lblId = new MaterialSkin.Controls.MaterialLabel();
            this.lblDtEntrega = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.dtCompraGado = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pecuarista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtId = new System.Windows.Forms.TextBox();
            this.cbPecuarista = new System.Windows.Forms.ComboBox();
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtDe = new System.Windows.Forms.MaskedTextBox();
            this.txtAte = new System.Windows.Forms.MaskedTextBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnAvancar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtCompraGado)).BeginInit();
            this.SuspendLayout();
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(3, 78);
            this.materialDivider1.Margin = new System.Windows.Forms.Padding(2);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(846, 16);
            this.materialDivider1.TabIndex = 0;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // materialRaisedButton3
            // 
            this.materialRaisedButton3.Depth = 0;
            this.materialRaisedButton3.Location = new System.Drawing.Point(736, 512);
            this.materialRaisedButton3.Margin = new System.Windows.Forms.Padding(2);
            this.materialRaisedButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton3.Name = "materialRaisedButton3";
            this.materialRaisedButton3.Primary = true;
            this.materialRaisedButton3.Size = new System.Drawing.Size(141, 34);
            this.materialRaisedButton3.TabIndex = 4;
            this.materialRaisedButton3.Text = "Novo";
            this.materialRaisedButton3.UseVisualStyleBackColor = true;
            this.materialRaisedButton3.Click += new System.EventHandler(this.materialRaisedButton3_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Depth = 0;
            this.lblId.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblId.Location = new System.Drawing.Point(8, 112);
            this.lblId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblId.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(25, 19);
            this.lblId.TabIndex = 8;
            this.lblId.Text = "Id:";
            // 
            // lblDtEntrega
            // 
            this.lblDtEntrega.AutoSize = true;
            this.lblDtEntrega.Depth = 0;
            this.lblDtEntrega.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblDtEntrega.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDtEntrega.Location = new System.Drawing.Point(8, 162);
            this.lblDtEntrega.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDtEntrega.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDtEntrega.Name = "lblDtEntrega";
            this.lblDtEntrega.Size = new System.Drawing.Size(119, 19);
            this.lblDtEntrega.TabIndex = 10;
            this.lblDtEntrega.Text = "Data de Entrega:";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(433, 160);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(32, 19);
            this.materialLabel3.TabIndex = 14;
            this.materialLabel3.Text = "Até";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(430, 115);
            this.materialLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(80, 19);
            this.materialLabel4.TabIndex = 12;
            this.materialLabel4.Text = "Pecuarista";
            // 
            // dtCompraGado
            // 
            this.dtCompraGado.AllowUserToAddRows = false;
            this.dtCompraGado.AllowUserToDeleteRows = false;
            this.dtCompraGado.AllowUserToResizeColumns = false;
            this.dtCompraGado.AllowUserToResizeRows = false;
            this.dtCompraGado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtCompraGado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Pecuarista,
            this.DataEntrega,
            this.ValorTotal});
            this.dtCompraGado.Location = new System.Drawing.Point(12, 254);
            this.dtCompraGado.Margin = new System.Windows.Forms.Padding(2);
            this.dtCompraGado.Name = "dtCompraGado";
            this.dtCompraGado.RowHeadersWidth = 62;
            this.dtCompraGado.RowTemplate.Height = 28;
            this.dtCompraGado.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dtCompraGado.Size = new System.Drawing.Size(865, 234);
            this.dtCompraGado.TabIndex = 15;
            this.dtCompraGado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtCompraGado_CellClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "Id";
            this.ID.HeaderText = "Id";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ID.Width = 125;
            // 
            // Pecuarista
            // 
            this.Pecuarista.DataPropertyName = "Pecuarista";
            this.Pecuarista.HeaderText = "Pecuarista";
            this.Pecuarista.MinimumWidth = 6;
            this.Pecuarista.Name = "Pecuarista";
            this.Pecuarista.ReadOnly = true;
            this.Pecuarista.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Pecuarista.Width = 125;
            // 
            // DataEntrega
            // 
            this.DataEntrega.DataPropertyName = "DataEntrega";
            this.DataEntrega.HeaderText = "Data Entrega";
            this.DataEntrega.MinimumWidth = 6;
            this.DataEntrega.Name = "DataEntrega";
            this.DataEntrega.ReadOnly = true;
            this.DataEntrega.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataEntrega.Width = 125;
            // 
            // ValorTotal
            // 
            this.ValorTotal.DataPropertyName = "ValorTotal";
            this.ValorTotal.HeaderText = "Valor Total";
            this.ValorTotal.MinimumWidth = 6;
            this.ValorTotal.Name = "ValorTotal";
            this.ValorTotal.ReadOnly = true;
            this.ValorTotal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ValorTotal.Width = 125;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(153, 115);
            this.txtId.Margin = new System.Windows.Forms.Padding(2);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(198, 20);
            this.txtId.TabIndex = 16;
            // 
            // cbPecuarista
            // 
            this.cbPecuarista.FormattingEnabled = true;
            this.cbPecuarista.Location = new System.Drawing.Point(514, 117);
            this.cbPecuarista.Margin = new System.Windows.Forms.Padding(2);
            this.cbPecuarista.Name = "cbPecuarista";
            this.cbPecuarista.Size = new System.Drawing.Size(335, 21);
            this.cbPecuarista.TabIndex = 19;
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Location = new System.Drawing.Point(708, 200);
            this.materialRaisedButton2.Margin = new System.Windows.Forms.Padding(2);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(141, 34);
            this.materialRaisedButton2.TabIndex = 20;
            this.materialRaisedButton2.Text = "Pesquisar";
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            this.materialRaisedButton2.Click += new System.EventHandler(this.materialRaisedButton2_Click);
            // 
            // txtDe
            // 
            this.txtDe.Location = new System.Drawing.Point(153, 163);
            this.txtDe.Mask = "00/00/0000";
            this.txtDe.Name = "txtDe";
            this.txtDe.Size = new System.Drawing.Size(198, 20);
            this.txtDe.TabIndex = 21;
            this.txtDe.ValidatingType = typeof(System.DateTime);
            // 
            // txtAte
            // 
            this.txtAte.Location = new System.Drawing.Point(514, 163);
            this.txtAte.Mask = "00/00/0000";
            this.txtAte.Name = "txtAte";
            this.txtAte.Size = new System.Drawing.Size(335, 20);
            this.txtAte.TabIndex = 22;
            this.txtAte.ValidatingType = typeof(System.DateTime);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(327, 493);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 23);
            this.btnVoltar.TabIndex = 23;
            this.btnVoltar.Text = "< Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnAvancar
            // 
            this.btnAvancar.Location = new System.Drawing.Point(437, 493);
            this.btnAvancar.Name = "btnAvancar";
            this.btnAvancar.Size = new System.Drawing.Size(75, 23);
            this.btnAvancar.TabIndex = 24;
            this.btnAvancar.Text = "Avançar >";
            this.btnAvancar.UseVisualStyleBackColor = true;
            this.btnAvancar.Click += new System.EventHandler(this.btnAvancar_Click);
            // 
            // Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 557);
            this.Controls.Add(this.btnAvancar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.txtAte);
            this.Controls.Add(this.txtDe);
            this.Controls.Add(this.materialRaisedButton2);
            this.Controls.Add(this.cbPecuarista);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.dtCompraGado);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.lblDtEntrega);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.materialRaisedButton3);
            this.Controls.Add(this.materialDivider1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Consulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta";
            ((System.ComponentModel.ISupportInitialize)(this.dtCompraGado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton3;
        private MaterialSkin.Controls.MaterialLabel lblId;
        private MaterialSkin.Controls.MaterialLabel lblDtEntrega;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.DataGridView dtCompraGado;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ComboBox cbPecuarista;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pecuarista;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotal;
        private System.Windows.Forms.MaskedTextBox txtDe;
        private System.Windows.Forms.MaskedTextBox txtAte;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnAvancar;
    }
}