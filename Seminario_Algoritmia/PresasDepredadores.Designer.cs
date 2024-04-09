/*
 * Creado por SharpDevelop.
 * Usuario: Brian Gaytan Lomeli
 * Fecha: 04/12/2019
 * Hora: 11:52
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace Seminario_Algoritmia
{
	partial class PresasDepredadores
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.PictureBox pictureBoxGrafo;
		private System.Windows.Forms.Label labelPresaOrigen;
		private System.Windows.Forms.Label labelPresaDestino;
		private System.Windows.Forms.ComboBox comboBoxPresaOrigen;
		private System.Windows.Forms.ComboBox comboBoxPresasDestino;
		private System.Windows.Forms.Button buttonAgregarPresa;
		private System.Windows.Forms.ComboBox comboBoxDepredador;
		private System.Windows.Forms.Label labelOrigenDepredador;
		private System.Windows.Forms.Button buttonAgregarDepredador;
		private System.Windows.Forms.DataGridView dataGridViewInformacionPresas;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID_PRESA;
		private System.Windows.Forms.DataGridViewTextBoxColumn RESISTENCIA_PRESA;
		private System.Windows.Forms.DataGridViewTextBoxColumn NODO_ORIGEN_PRESA;
		private System.Windows.Forms.DataGridViewTextBoxColumn NODO_DESTINO_PRESA;
		private System.Windows.Forms.DataGridViewTextBoxColumn CAMINO_PRESA;
		private System.Windows.Forms.DataGridView dataGridViewInformacionDepredadores;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID_DEPREDADOR;
		private System.Windows.Forms.DataGridViewTextBoxColumn DEPREDADOR_NODO_ORIGEN;
		private System.Windows.Forms.DataGridViewTextBoxColumn DEPREDADOR_ID_PRESA;
		private System.Windows.Forms.Button buttonSimular;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID_DEPREDADOR_ACECHO;
		private System.Windows.Forms.NumericUpDown numericUpDownPresas;
		private System.Windows.Forms.NumericUpDown numericUpDownDepredadores;
		private System.Windows.Forms.Label labelAleatoriedad;
		private System.Windows.Forms.Label labelPresasAleatoriedad;
		private System.Windows.Forms.Label labelDepredadoresAleatoriedad;
		private System.Windows.Forms.Button buttonAgregar;
		private System.Windows.Forms.DataGridViewTextBoxColumn DEPREDADOR_NODO_DESTINO;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pictureBoxGrafo = new System.Windows.Forms.PictureBox();
			this.labelPresaOrigen = new System.Windows.Forms.Label();
			this.labelPresaDestino = new System.Windows.Forms.Label();
			this.comboBoxPresaOrigen = new System.Windows.Forms.ComboBox();
			this.comboBoxPresasDestino = new System.Windows.Forms.ComboBox();
			this.buttonAgregarPresa = new System.Windows.Forms.Button();
			this.comboBoxDepredador = new System.Windows.Forms.ComboBox();
			this.labelOrigenDepredador = new System.Windows.Forms.Label();
			this.buttonAgregarDepredador = new System.Windows.Forms.Button();
			this.dataGridViewInformacionPresas = new System.Windows.Forms.DataGridView();
			this.ID_PRESA = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RESISTENCIA_PRESA = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.NODO_ORIGEN_PRESA = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.NODO_DESTINO_PRESA = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CAMINO_PRESA = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ID_DEPREDADOR_ACECHO = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewInformacionDepredadores = new System.Windows.Forms.DataGridView();
			this.buttonSimular = new System.Windows.Forms.Button();
			this.numericUpDownPresas = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownDepredadores = new System.Windows.Forms.NumericUpDown();
			this.labelAleatoriedad = new System.Windows.Forms.Label();
			this.labelPresasAleatoriedad = new System.Windows.Forms.Label();
			this.labelDepredadoresAleatoriedad = new System.Windows.Forms.Label();
			this.buttonAgregar = new System.Windows.Forms.Button();
			this.ID_DEPREDADOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DEPREDADOR_NODO_ORIGEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DEPREDADOR_NODO_DESTINO = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DEPREDADOR_ID_PRESA = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrafo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewInformacionPresas)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewInformacionDepredadores)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPresas)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDepredadores)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxGrafo
			// 
			this.pictureBoxGrafo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxGrafo.BackColor = System.Drawing.Color.White;
			this.pictureBoxGrafo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBoxGrafo.Location = new System.Drawing.Point(3, 2);
			this.pictureBoxGrafo.Name = "pictureBoxGrafo";
			this.pictureBoxGrafo.Size = new System.Drawing.Size(719, 692);
			this.pictureBoxGrafo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxGrafo.TabIndex = 0;
			this.pictureBoxGrafo.TabStop = false;
			this.pictureBoxGrafo.DoubleClick += new System.EventHandler(this.PictureBoxGrafoDoubleClick);
			// 
			// labelPresaOrigen
			// 
			this.labelPresaOrigen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPresaOrigen.BackColor = System.Drawing.Color.Transparent;
			this.labelPresaOrigen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelPresaOrigen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.labelPresaOrigen.Font = new System.Drawing.Font("Maiandra GD", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPresaOrigen.ForeColor = System.Drawing.Color.White;
			this.labelPresaOrigen.Location = new System.Drawing.Point(728, 7);
			this.labelPresaOrigen.Name = "labelPresaOrigen";
			this.labelPresaOrigen.Size = new System.Drawing.Size(110, 32);
			this.labelPresaOrigen.TabIndex = 2;
			this.labelPresaOrigen.Text = "ORIGEN:";
			this.labelPresaOrigen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPresaDestino
			// 
			this.labelPresaDestino.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPresaDestino.BackColor = System.Drawing.Color.Transparent;
			this.labelPresaDestino.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelPresaDestino.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.labelPresaDestino.Font = new System.Drawing.Font("Maiandra GD", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPresaDestino.ForeColor = System.Drawing.Color.White;
			this.labelPresaDestino.Location = new System.Drawing.Point(728, 51);
			this.labelPresaDestino.Name = "labelPresaDestino";
			this.labelPresaDestino.Size = new System.Drawing.Size(110, 32);
			this.labelPresaDestino.TabIndex = 3;
			this.labelPresaDestino.Text = "DESTINO:";
			this.labelPresaDestino.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBoxPresaOrigen
			// 
			this.comboBoxPresaOrigen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxPresaOrigen.Cursor = System.Windows.Forms.Cursors.Hand;
			this.comboBoxPresaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxPresaOrigen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.comboBoxPresaOrigen.Font = new System.Drawing.Font("Maiandra GD", 15F);
			this.comboBoxPresaOrigen.FormattingEnabled = true;
			this.comboBoxPresaOrigen.Location = new System.Drawing.Point(844, 7);
			this.comboBoxPresaOrigen.Name = "comboBoxPresaOrigen";
			this.comboBoxPresaOrigen.Size = new System.Drawing.Size(115, 32);
			this.comboBoxPresaOrigen.TabIndex = 4;
			// 
			// comboBoxPresasDestino
			// 
			this.comboBoxPresasDestino.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxPresasDestino.Cursor = System.Windows.Forms.Cursors.Hand;
			this.comboBoxPresasDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxPresasDestino.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.comboBoxPresasDestino.Font = new System.Drawing.Font("Maiandra GD", 15F);
			this.comboBoxPresasDestino.FormattingEnabled = true;
			this.comboBoxPresasDestino.Location = new System.Drawing.Point(844, 51);
			this.comboBoxPresasDestino.Name = "comboBoxPresasDestino";
			this.comboBoxPresasDestino.Size = new System.Drawing.Size(115, 32);
			this.comboBoxPresasDestino.TabIndex = 5;
			// 
			// buttonAgregarPresa
			// 
			this.buttonAgregarPresa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAgregarPresa.BackColor = System.Drawing.Color.White;
			this.buttonAgregarPresa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonAgregarPresa.Font = new System.Drawing.Font("Maiandra GD", 15F);
			this.buttonAgregarPresa.Location = new System.Drawing.Point(965, 7);
			this.buttonAgregarPresa.Name = "buttonAgregarPresa";
			this.buttonAgregarPresa.Size = new System.Drawing.Size(112, 76);
			this.buttonAgregarPresa.TabIndex = 6;
			this.buttonAgregarPresa.Text = "AGREGAR PRESA";
			this.buttonAgregarPresa.UseVisualStyleBackColor = false;
			this.buttonAgregarPresa.Click += new System.EventHandler(this.ButtonAgregarPresaClick);
			// 
			// comboBoxDepredador
			// 
			this.comboBoxDepredador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxDepredador.Cursor = System.Windows.Forms.Cursors.Hand;
			this.comboBoxDepredador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDepredador.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.comboBoxDepredador.Font = new System.Drawing.Font("Maiandra GD", 15F);
			this.comboBoxDepredador.FormattingEnabled = true;
			this.comboBoxDepredador.Location = new System.Drawing.Point(1209, 8);
			this.comboBoxDepredador.Name = "comboBoxDepredador";
			this.comboBoxDepredador.Size = new System.Drawing.Size(135, 32);
			this.comboBoxDepredador.TabIndex = 9;
			// 
			// labelOrigenDepredador
			// 
			this.labelOrigenDepredador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelOrigenDepredador.BackColor = System.Drawing.Color.Transparent;
			this.labelOrigenDepredador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelOrigenDepredador.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.labelOrigenDepredador.Font = new System.Drawing.Font("Maiandra GD", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelOrigenDepredador.ForeColor = System.Drawing.Color.White;
			this.labelOrigenDepredador.Location = new System.Drawing.Point(1093, 7);
			this.labelOrigenDepredador.Name = "labelOrigenDepredador";
			this.labelOrigenDepredador.Size = new System.Drawing.Size(110, 32);
			this.labelOrigenDepredador.TabIndex = 8;
			this.labelOrigenDepredador.Text = "ORIGEN:";
			this.labelOrigenDepredador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonAgregarDepredador
			// 
			this.buttonAgregarDepredador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAgregarDepredador.BackColor = System.Drawing.Color.White;
			this.buttonAgregarDepredador.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonAgregarDepredador.Font = new System.Drawing.Font("Maiandra GD", 15F);
			this.buttonAgregarDepredador.Location = new System.Drawing.Point(1093, 51);
			this.buttonAgregarDepredador.Name = "buttonAgregarDepredador";
			this.buttonAgregarDepredador.Size = new System.Drawing.Size(251, 32);
			this.buttonAgregarDepredador.TabIndex = 10;
			this.buttonAgregarDepredador.Text = "AGREGAR DEPREDADOR";
			this.buttonAgregarDepredador.UseVisualStyleBackColor = false;
			this.buttonAgregarDepredador.Click += new System.EventHandler(this.ButtonAgregarDepredadorClick);
			// 
			// dataGridViewInformacionPresas
			// 
			this.dataGridViewInformacionPresas.AllowDrop = true;
			this.dataGridViewInformacionPresas.AllowUserToAddRows = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Maiandra GD", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
			this.dataGridViewInformacionPresas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridViewInformacionPresas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewInformacionPresas.BackgroundColor = System.Drawing.Color.White;
			this.dataGridViewInformacionPresas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dataGridViewInformacionPresas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewInformacionPresas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewInformacionPresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewInformacionPresas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.ID_PRESA,
			this.RESISTENCIA_PRESA,
			this.NODO_ORIGEN_PRESA,
			this.NODO_DESTINO_PRESA,
			this.CAMINO_PRESA,
			this.ID_DEPREDADOR_ACECHO});
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Eras Medium ITC", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewInformacionPresas.DefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewInformacionPresas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dataGridViewInformacionPresas.Location = new System.Drawing.Point(728, 89);
			this.dataGridViewInformacionPresas.Name = "dataGridViewInformacionPresas";
			this.dataGridViewInformacionPresas.ReadOnly = true;
			this.dataGridViewInformacionPresas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Lucida Bright", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewInformacionPresas.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewInformacionPresas.RowHeadersVisible = false;
			this.dataGridViewInformacionPresas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
			this.dataGridViewInformacionPresas.RowsDefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridViewInformacionPresas.RowTemplate.Height = 20;
			this.dataGridViewInformacionPresas.RowTemplate.ReadOnly = true;
			this.dataGridViewInformacionPresas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewInformacionPresas.Size = new System.Drawing.Size(616, 249);
			this.dataGridViewInformacionPresas.TabIndex = 11;
			// 
			// ID_PRESA
			// 
			this.ID_PRESA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.ID_PRESA.HeaderText = "ID Presa";
			this.ID_PRESA.Name = "ID_PRESA";
			this.ID_PRESA.ReadOnly = true;
			this.ID_PRESA.Width = 71;
			// 
			// RESISTENCIA_PRESA
			// 
			this.RESISTENCIA_PRESA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.RESISTENCIA_PRESA.HeaderText = "Salud";
			this.RESISTENCIA_PRESA.Name = "RESISTENCIA_PRESA";
			this.RESISTENCIA_PRESA.ReadOnly = true;
			this.RESISTENCIA_PRESA.Width = 62;
			// 
			// NODO_ORIGEN_PRESA
			// 
			this.NODO_ORIGEN_PRESA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.NODO_ORIGEN_PRESA.HeaderText = "Nodo Origen";
			this.NODO_ORIGEN_PRESA.Name = "NODO_ORIGEN_PRESA";
			this.NODO_ORIGEN_PRESA.ReadOnly = true;
			// 
			// NODO_DESTINO_PRESA
			// 
			this.NODO_DESTINO_PRESA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.NODO_DESTINO_PRESA.HeaderText = "Nodo Destino";
			this.NODO_DESTINO_PRESA.Name = "NODO_DESTINO_PRESA";
			this.NODO_DESTINO_PRESA.ReadOnly = true;
			// 
			// CAMINO_PRESA
			// 
			this.CAMINO_PRESA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.CAMINO_PRESA.HeaderText = "Camino";
			this.CAMINO_PRESA.Name = "CAMINO_PRESA";
			this.CAMINO_PRESA.ReadOnly = true;
			// 
			// ID_DEPREDADOR_ACECHO
			// 
			this.ID_DEPREDADOR_ACECHO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.ID_DEPREDADOR_ACECHO.HeaderText = "ID Depredador";
			this.ID_DEPREDADOR_ACECHO.Name = "ID_DEPREDADOR_ACECHO";
			this.ID_DEPREDADOR_ACECHO.ReadOnly = true;
			// 
			// dataGridViewInformacionDepredadores
			// 
			this.dataGridViewInformacionDepredadores.AllowDrop = true;
			this.dataGridViewInformacionDepredadores.AllowUserToAddRows = false;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Maiandra GD", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Teal;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
			this.dataGridViewInformacionDepredadores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridViewInformacionDepredadores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewInformacionDepredadores.BackgroundColor = System.Drawing.Color.White;
			this.dataGridViewInformacionDepredadores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dataGridViewInformacionDepredadores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewInformacionDepredadores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
			this.dataGridViewInformacionDepredadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewInformacionDepredadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.ID_DEPREDADOR,
			this.DEPREDADOR_NODO_ORIGEN,
			this.DEPREDADOR_NODO_DESTINO,
			this.DEPREDADOR_ID_PRESA});
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Eras Medium ITC", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewInformacionDepredadores.DefaultCellStyle = dataGridViewCellStyle8;
			this.dataGridViewInformacionDepredadores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dataGridViewInformacionDepredadores.Location = new System.Drawing.Point(728, 345);
			this.dataGridViewInformacionDepredadores.Name = "dataGridViewInformacionDepredadores";
			this.dataGridViewInformacionDepredadores.ReadOnly = true;
			this.dataGridViewInformacionDepredadores.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Lucida Bright", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewInformacionDepredadores.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
			this.dataGridViewInformacionDepredadores.RowHeadersVisible = false;
			this.dataGridViewInformacionDepredadores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle10.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
			this.dataGridViewInformacionDepredadores.RowsDefaultCellStyle = dataGridViewCellStyle10;
			this.dataGridViewInformacionDepredadores.RowTemplate.Height = 20;
			this.dataGridViewInformacionDepredadores.RowTemplate.ReadOnly = true;
			this.dataGridViewInformacionDepredadores.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewInformacionDepredadores.Size = new System.Drawing.Size(616, 197);
			this.dataGridViewInformacionDepredadores.TabIndex = 12;
			// 
			// buttonSimular
			// 
			this.buttonSimular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSimular.BackColor = System.Drawing.Color.White;
			this.buttonSimular.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonSimular.Font = new System.Drawing.Font("Maiandra GD", 16F);
			this.buttonSimular.Location = new System.Drawing.Point(728, 643);
			this.buttonSimular.Name = "buttonSimular";
			this.buttonSimular.Size = new System.Drawing.Size(616, 51);
			this.buttonSimular.TabIndex = 13;
			this.buttonSimular.Text = "SIMULAR";
			this.buttonSimular.UseVisualStyleBackColor = false;
			this.buttonSimular.Click += new System.EventHandler(this.ButtonSimularClick);
			// 
			// numericUpDownPresas
			// 
			this.numericUpDownPresas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDownPresas.Font = new System.Drawing.Font("Maiandra GD", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownPresas.Location = new System.Drawing.Point(880, 593);
			this.numericUpDownPresas.Maximum = new decimal(new int[] {
			5000,
			0,
			0,
			0});
			this.numericUpDownPresas.Name = "numericUpDownPresas";
			this.numericUpDownPresas.Size = new System.Drawing.Size(120, 33);
			this.numericUpDownPresas.TabIndex = 14;
			this.numericUpDownPresas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownPresas.ValueChanged += new System.EventHandler(this.NumericUpDownPresasValueChanged);
			// 
			// numericUpDownDepredadores
			// 
			this.numericUpDownDepredadores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDownDepredadores.Font = new System.Drawing.Font("Maiandra GD", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownDepredadores.Location = new System.Drawing.Point(1009, 593);
			this.numericUpDownDepredadores.Maximum = new decimal(new int[] {
			5000,
			0,
			0,
			0});
			this.numericUpDownDepredadores.Name = "numericUpDownDepredadores";
			this.numericUpDownDepredadores.Size = new System.Drawing.Size(120, 33);
			this.numericUpDownDepredadores.TabIndex = 15;
			this.numericUpDownDepredadores.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownDepredadores.ValueChanged += new System.EventHandler(this.NumericUpDownDepredadoresValueChanged);
			// 
			// labelAleatoriedad
			// 
			this.labelAleatoriedad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.labelAleatoriedad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelAleatoriedad.Cursor = System.Windows.Forms.Cursors.Default;
			this.labelAleatoriedad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.labelAleatoriedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAleatoriedad.ForeColor = System.Drawing.Color.White;
			this.labelAleatoriedad.Location = new System.Drawing.Point(728, 557);
			this.labelAleatoriedad.Name = "labelAleatoriedad";
			this.labelAleatoriedad.Size = new System.Drawing.Size(140, 69);
			this.labelAleatoriedad.TabIndex = 16;
			this.labelAleatoriedad.Text = "Aleatoriedad:";
			this.labelAleatoriedad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPresasAleatoriedad
			// 
			this.labelPresasAleatoriedad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPresasAleatoriedad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelPresasAleatoriedad.Cursor = System.Windows.Forms.Cursors.Default;
			this.labelPresasAleatoriedad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.labelPresasAleatoriedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPresasAleatoriedad.ForeColor = System.Drawing.Color.White;
			this.labelPresasAleatoriedad.Location = new System.Drawing.Point(880, 557);
			this.labelPresasAleatoriedad.Name = "labelPresasAleatoriedad";
			this.labelPresasAleatoriedad.Size = new System.Drawing.Size(120, 33);
			this.labelPresasAleatoriedad.TabIndex = 17;
			this.labelPresasAleatoriedad.Text = "Presas:";
			this.labelPresasAleatoriedad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelDepredadoresAleatoriedad
			// 
			this.labelDepredadoresAleatoriedad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDepredadoresAleatoriedad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelDepredadoresAleatoriedad.Cursor = System.Windows.Forms.Cursors.Default;
			this.labelDepredadoresAleatoriedad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.labelDepredadoresAleatoriedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDepredadoresAleatoriedad.ForeColor = System.Drawing.Color.White;
			this.labelDepredadoresAleatoriedad.Location = new System.Drawing.Point(1009, 557);
			this.labelDepredadoresAleatoriedad.Name = "labelDepredadoresAleatoriedad";
			this.labelDepredadoresAleatoriedad.Size = new System.Drawing.Size(120, 33);
			this.labelDepredadoresAleatoriedad.TabIndex = 18;
			this.labelDepredadoresAleatoriedad.Text = "Depredadores:";
			this.labelDepredadoresAleatoriedad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonAgregar
			// 
			this.buttonAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAgregar.BackColor = System.Drawing.Color.White;
			this.buttonAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonAgregar.Font = new System.Drawing.Font("Maiandra GD", 16F);
			this.buttonAgregar.Location = new System.Drawing.Point(1145, 567);
			this.buttonAgregar.Name = "buttonAgregar";
			this.buttonAgregar.Size = new System.Drawing.Size(191, 44);
			this.buttonAgregar.TabIndex = 19;
			this.buttonAgregar.Text = "AGREGAR";
			this.buttonAgregar.UseVisualStyleBackColor = false;
			this.buttonAgregar.Click += new System.EventHandler(this.ButtonAgregarClick);
			// 
			// ID_DEPREDADOR
			// 
			this.ID_DEPREDADOR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ID_DEPREDADOR.HeaderText = "ID Depredador";
			this.ID_DEPREDADOR.Name = "ID_DEPREDADOR";
			this.ID_DEPREDADOR.ReadOnly = true;
			// 
			// DEPREDADOR_NODO_ORIGEN
			// 
			this.DEPREDADOR_NODO_ORIGEN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.DEPREDADOR_NODO_ORIGEN.HeaderText = "Nodo Origen";
			this.DEPREDADOR_NODO_ORIGEN.Name = "DEPREDADOR_NODO_ORIGEN";
			this.DEPREDADOR_NODO_ORIGEN.ReadOnly = true;
			// 
			// DEPREDADOR_NODO_DESTINO
			// 
			this.DEPREDADOR_NODO_DESTINO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.DEPREDADOR_NODO_DESTINO.HeaderText = "Nodo Destino";
			this.DEPREDADOR_NODO_DESTINO.Name = "DEPREDADOR_NODO_DESTINO";
			this.DEPREDADOR_NODO_DESTINO.ReadOnly = true;
			// 
			// DEPREDADOR_ID_PRESA
			// 
			this.DEPREDADOR_ID_PRESA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.DEPREDADOR_ID_PRESA.HeaderText = "ID Presa";
			this.DEPREDADOR_ID_PRESA.Name = "DEPREDADOR_ID_PRESA";
			this.DEPREDADOR_ID_PRESA.ReadOnly = true;
			// 
			// PresasDepredadores
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1348, 697);
			this.Controls.Add(this.buttonAgregar);
			this.Controls.Add(this.labelDepredadoresAleatoriedad);
			this.Controls.Add(this.labelPresasAleatoriedad);
			this.Controls.Add(this.labelAleatoriedad);
			this.Controls.Add(this.numericUpDownDepredadores);
			this.Controls.Add(this.numericUpDownPresas);
			this.Controls.Add(this.buttonSimular);
			this.Controls.Add(this.dataGridViewInformacionDepredadores);
			this.Controls.Add(this.dataGridViewInformacionPresas);
			this.Controls.Add(this.buttonAgregarDepredador);
			this.Controls.Add(this.comboBoxDepredador);
			this.Controls.Add(this.labelOrigenDepredador);
			this.Controls.Add(this.buttonAgregarPresa);
			this.Controls.Add(this.comboBoxPresasDestino);
			this.Controls.Add(this.comboBoxPresaOrigen);
			this.Controls.Add(this.labelPresaDestino);
			this.Controls.Add(this.labelPresaOrigen);
			this.Controls.Add(this.pictureBoxGrafo);
			this.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.MinimumSize = new System.Drawing.Size(1364, 736);
			this.Name = "PresasDepredadores";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Presas & Depredadores";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PresasDepredadoresFormClosing);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrafo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewInformacionPresas)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewInformacionDepredadores)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPresas)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDepredadores)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
