namespace Formularios
{
    partial class FrmPrincipal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rtxt_VentasPendientes = new System.Windows.Forms.RichTextBox();
            this.btn_GenerarVenta = new System.Windows.Forms.Button();
            this.rtxt_VentasEntregadas = new System.Windows.Forms.RichTextBox();
            this.lbl_Ventas = new System.Windows.Forms.Label();
            this.lbl_PendientesEntrega = new System.Windows.Forms.Label();
            this.lbl_VentasEntregadas = new System.Windows.Forms.Label();
            this.lbl_MisProductos = new System.Windows.Forms.Label();
            this.lbl_Stock = new System.Windows.Forms.Label();
            this.lbl_Precio = new System.Windows.Forms.Label();
            this.lbl_Descripcion = new System.Windows.Forms.Label();
            this.lbl_Tipo = new System.Windows.Forms.Label();
            this.txt_Stock = new System.Windows.Forms.TextBox();
            this.txt_Precio = new System.Windows.Forms.TextBox();
            this.cmb_Tipo = new System.Windows.Forms.ComboBox();
            this.txt_Descripcion = new System.Windows.Forms.TextBox();
            this.btn_AgregarProducto = new System.Windows.Forms.Button();
            this.btn_GenerarStock = new System.Windows.Forms.Button();
            this.dgv_Productos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Productos)).BeginInit();
            this.SuspendLayout();
            // 
            // rtxt_VentasPendientes
            // 
            this.rtxt_VentasPendientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.rtxt_VentasPendientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxt_VentasPendientes.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_VentasPendientes.ForeColor = System.Drawing.Color.White;
            this.rtxt_VentasPendientes.Location = new System.Drawing.Point(417, 51);
            this.rtxt_VentasPendientes.Name = "rtxt_VentasPendientes";
            this.rtxt_VentasPendientes.ReadOnly = true;
            this.rtxt_VentasPendientes.Size = new System.Drawing.Size(333, 385);
            this.rtxt_VentasPendientes.TabIndex = 15;
            this.rtxt_VentasPendientes.Text = "";
            // 
            // btn_GenerarVenta
            // 
            this.btn_GenerarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GenerarVenta.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GenerarVenta.Location = new System.Drawing.Point(591, 451);
            this.btn_GenerarVenta.Name = "btn_GenerarVenta";
            this.btn_GenerarVenta.Size = new System.Drawing.Size(333, 31);
            this.btn_GenerarVenta.TabIndex = 5;
            this.btn_GenerarVenta.Text = "Generar venta";
            this.btn_GenerarVenta.UseVisualStyleBackColor = true;
            this.btn_GenerarVenta.Click += new System.EventHandler(this.btn_GenerarVenta_Click);
            // 
            // rtxt_VentasEntregadas
            // 
            this.rtxt_VentasEntregadas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.rtxt_VentasEntregadas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxt_VentasEntregadas.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_VentasEntregadas.ForeColor = System.Drawing.Color.White;
            this.rtxt_VentasEntregadas.Location = new System.Drawing.Point(760, 51);
            this.rtxt_VentasEntregadas.Name = "rtxt_VentasEntregadas";
            this.rtxt_VentasEntregadas.ReadOnly = true;
            this.rtxt_VentasEntregadas.Size = new System.Drawing.Size(333, 385);
            this.rtxt_VentasEntregadas.TabIndex = 16;
            this.rtxt_VentasEntregadas.Text = "";
            // 
            // lbl_Ventas
            // 
            this.lbl_Ventas.AutoSize = true;
            this.lbl_Ventas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ventas.Location = new System.Drawing.Point(724, 10);
            this.lbl_Ventas.Name = "lbl_Ventas";
            this.lbl_Ventas.Size = new System.Drawing.Size(61, 19);
            this.lbl_Ventas.TabIndex = 8;
            this.lbl_Ventas.Text = "Ventas";
            // 
            // lbl_PendientesEntrega
            // 
            this.lbl_PendientesEntrega.AutoSize = true;
            this.lbl_PendientesEntrega.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PendientesEntrega.Location = new System.Drawing.Point(502, 32);
            this.lbl_PendientesEntrega.Name = "lbl_PendientesEntrega";
            this.lbl_PendientesEntrega.Size = new System.Drawing.Size(154, 16);
            this.lbl_PendientesEntrega.TabIndex = 7;
            this.lbl_PendientesEntrega.Text = "Pendientes de entrega";
            // 
            // lbl_VentasEntregadas
            // 
            this.lbl_VentasEntregadas.AutoSize = true;
            this.lbl_VentasEntregadas.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_VentasEntregadas.Location = new System.Drawing.Point(885, 32);
            this.lbl_VentasEntregadas.Name = "lbl_VentasEntregadas";
            this.lbl_VentasEntregadas.Size = new System.Drawing.Size(82, 16);
            this.lbl_VentasEntregadas.TabIndex = 9;
            this.lbl_VentasEntregadas.Text = "Entregadas";
            // 
            // lbl_MisProductos
            // 
            this.lbl_MisProductos.AutoSize = true;
            this.lbl_MisProductos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MisProductos.Location = new System.Drawing.Point(153, 29);
            this.lbl_MisProductos.Name = "lbl_MisProductos";
            this.lbl_MisProductos.Size = new System.Drawing.Size(114, 19);
            this.lbl_MisProductos.TabIndex = 24;
            this.lbl_MisProductos.Text = "Mis productos";
            // 
            // lbl_Stock
            // 
            this.lbl_Stock.AutoSize = true;
            this.lbl_Stock.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Stock.Location = new System.Drawing.Point(9, 416);
            this.lbl_Stock.Name = "lbl_Stock";
            this.lbl_Stock.Size = new System.Drawing.Size(43, 16);
            this.lbl_Stock.TabIndex = 28;
            this.lbl_Stock.Text = "Stock";
            // 
            // lbl_Precio
            // 
            this.lbl_Precio.AutoSize = true;
            this.lbl_Precio.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Precio.Location = new System.Drawing.Point(9, 389);
            this.lbl_Precio.Name = "lbl_Precio";
            this.lbl_Precio.Size = new System.Drawing.Size(48, 16);
            this.lbl_Precio.TabIndex = 27;
            this.lbl_Precio.Text = "Precio";
            // 
            // lbl_Descripcion
            // 
            this.lbl_Descripcion.AutoSize = true;
            this.lbl_Descripcion.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Descripcion.Location = new System.Drawing.Point(9, 362);
            this.lbl_Descripcion.Name = "lbl_Descripcion";
            this.lbl_Descripcion.Size = new System.Drawing.Size(85, 16);
            this.lbl_Descripcion.TabIndex = 26;
            this.lbl_Descripcion.Text = "Descripción";
            // 
            // lbl_Tipo
            // 
            this.lbl_Tipo.AutoSize = true;
            this.lbl_Tipo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Tipo.Location = new System.Drawing.Point(9, 333);
            this.lbl_Tipo.Name = "lbl_Tipo";
            this.lbl_Tipo.Size = new System.Drawing.Size(35, 16);
            this.lbl_Tipo.TabIndex = 25;
            this.lbl_Tipo.Text = "Tipo";
            // 
            // txt_Stock
            // 
            this.txt_Stock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.txt_Stock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Stock.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Stock.ForeColor = System.Drawing.Color.White;
            this.txt_Stock.Location = new System.Drawing.Point(105, 415);
            this.txt_Stock.Name = "txt_Stock";
            this.txt_Stock.Size = new System.Drawing.Size(301, 21);
            this.txt_Stock.TabIndex = 21;
            this.txt_Stock.Leave += new System.EventHandler(this.txt_Stock_Leave);
            // 
            // txt_Precio
            // 
            this.txt_Precio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.txt_Precio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Precio.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Precio.ForeColor = System.Drawing.Color.White;
            this.txt_Precio.Location = new System.Drawing.Point(105, 388);
            this.txt_Precio.Name = "txt_Precio";
            this.txt_Precio.Size = new System.Drawing.Size(301, 21);
            this.txt_Precio.TabIndex = 20;
            this.txt_Precio.Leave += new System.EventHandler(this.txt_Precio_Leave);
            // 
            // cmb_Tipo
            // 
            this.cmb_Tipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.cmb_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Tipo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_Tipo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Tipo.ForeColor = System.Drawing.Color.White;
            this.cmb_Tipo.FormattingEnabled = true;
            this.cmb_Tipo.Location = new System.Drawing.Point(105, 331);
            this.cmb_Tipo.Name = "cmb_Tipo";
            this.cmb_Tipo.Size = new System.Drawing.Size(301, 23);
            this.cmb_Tipo.TabIndex = 18;
            // 
            // txt_Descripcion
            // 
            this.txt_Descripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.txt_Descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Descripcion.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Descripcion.ForeColor = System.Drawing.Color.White;
            this.txt_Descripcion.Location = new System.Drawing.Point(105, 361);
            this.txt_Descripcion.Name = "txt_Descripcion";
            this.txt_Descripcion.Size = new System.Drawing.Size(301, 21);
            this.txt_Descripcion.TabIndex = 19;
            this.txt_Descripcion.Leave += new System.EventHandler(this.txt_Descripcion_Leave);
            // 
            // btn_AgregarProducto
            // 
            this.btn_AgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AgregarProducto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AgregarProducto.Location = new System.Drawing.Point(12, 451);
            this.btn_AgregarProducto.Name = "btn_AgregarProducto";
            this.btn_AgregarProducto.Size = new System.Drawing.Size(394, 31);
            this.btn_AgregarProducto.TabIndex = 22;
            this.btn_AgregarProducto.Text = "Agregar producto";
            this.btn_AgregarProducto.UseVisualStyleBackColor = true;
            this.btn_AgregarProducto.Click += new System.EventHandler(this.btn_AgregarProducto_Click);
            // 
            // btn_GenerarStock
            // 
            this.btn_GenerarStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GenerarStock.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GenerarStock.Location = new System.Drawing.Point(209, 276);
            this.btn_GenerarStock.Name = "btn_GenerarStock";
            this.btn_GenerarStock.Size = new System.Drawing.Size(197, 26);
            this.btn_GenerarStock.TabIndex = 23;
            this.btn_GenerarStock.Text = "Pedir stock a proveedores";
            this.btn_GenerarStock.UseVisualStyleBackColor = true;
            this.btn_GenerarStock.Click += new System.EventHandler(this.btn_GenerarStock_Click);
            // 
            // dgv_Productos
            // 
            this.dgv_Productos.AllowUserToAddRows = false;
            this.dgv_Productos.AllowUserToDeleteRows = false;
            this.dgv_Productos.AllowUserToResizeColumns = false;
            this.dgv_Productos.AllowUserToResizeRows = false;
            this.dgv_Productos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Productos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.dgv_Productos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Productos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Productos.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_Productos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.dgv_Productos.Location = new System.Drawing.Point(12, 51);
            this.dgv_Productos.MultiSelect = false;
            this.dgv_Productos.Name = "dgv_Productos";
            this.dgv_Productos.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Productos.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_Productos.RowHeadersVisible = false;
            this.dgv_Productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Productos.Size = new System.Drawing.Size(394, 219);
            this.dgv_Productos.TabIndex = 29;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(1105, 494);
            this.Controls.Add(this.lbl_MisProductos);
            this.Controls.Add(this.lbl_Stock);
            this.Controls.Add(this.lbl_Precio);
            this.Controls.Add(this.lbl_Descripcion);
            this.Controls.Add(this.lbl_Tipo);
            this.Controls.Add(this.txt_Stock);
            this.Controls.Add(this.txt_Precio);
            this.Controls.Add(this.cmb_Tipo);
            this.Controls.Add(this.txt_Descripcion);
            this.Controls.Add(this.btn_AgregarProducto);
            this.Controls.Add(this.btn_GenerarStock);
            this.Controls.Add(this.dgv_Productos);
            this.Controls.Add(this.lbl_VentasEntregadas);
            this.Controls.Add(this.lbl_PendientesEntrega);
            this.Controls.Add(this.lbl_Ventas);
            this.Controls.Add(this.rtxt_VentasEntregadas);
            this.Controls.Add(this.btn_GenerarVenta);
            this.Controls.Add(this.rtxt_VentasPendientes);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.Text = "Comercio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Productos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxt_VentasPendientes;
        private System.Windows.Forms.Button btn_GenerarVenta;
        private System.Windows.Forms.RichTextBox rtxt_VentasEntregadas;
        private System.Windows.Forms.Label lbl_Ventas;
        private System.Windows.Forms.Label lbl_PendientesEntrega;
        private System.Windows.Forms.Label lbl_VentasEntregadas;
        private System.Windows.Forms.Label lbl_MisProductos;
        private System.Windows.Forms.Label lbl_Stock;
        private System.Windows.Forms.Label lbl_Precio;
        private System.Windows.Forms.Label lbl_Descripcion;
        private System.Windows.Forms.Label lbl_Tipo;
        private System.Windows.Forms.TextBox txt_Stock;
        private System.Windows.Forms.TextBox txt_Precio;
        private System.Windows.Forms.ComboBox cmb_Tipo;
        private System.Windows.Forms.TextBox txt_Descripcion;
        private System.Windows.Forms.Button btn_AgregarProducto;
        private System.Windows.Forms.Button btn_GenerarStock;
        private System.Windows.Forms.DataGridView dgv_Productos;
    }
}