/*
 * Creado por SharpDevelop.
 * Usuario: Brian Gaytan Lomeli
 * Fecha: 25/11/2019
 * Hora: 15:03
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace Seminario_Algoritmia
{
	partial class Formulario_De_Dijkstra
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.PictureBox pictureBoxDijsktra;
		private System.Windows.Forms.DataGridView dataGridViewCaminos;
		private System.Windows.Forms.DataGridViewTextBoxColumn ORIGEN;
		private System.Windows.Forms.DataGridViewTextBoxColumn DESTINO;
		private System.Windows.Forms.DataGridViewTextBoxColumn CAMINO;
		private System.Windows.Forms.DataGridViewTextBoxColumn PESO;
		private System.Windows.Forms.Label labelNodoIncial;
		private System.Windows.Forms.Button buttonObtenerCaminos;
		private System.Windows.Forms.ComboBox comboBoxNodos;
		private System.Windows.Forms.DataGridViewButtonColumn MOSTRAR_CAMINO;
		private System.Windows.Forms.Button buttonLimpiarCaminos;
		private System.Windows.Forms.Label labelCebo;
		private System.Windows.Forms.ComboBox comboBoxCebos;
		private System.Windows.Forms.Button buttonAnimarRecorrido;
		
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
			this.pictureBoxDijsktra = new System.Windows.Forms.PictureBox();
			this.dataGridViewCaminos = new System.Windows.Forms.DataGridView();
			this.ORIGEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DESTINO = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CAMINO = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PESO = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MOSTRAR_CAMINO = new System.Windows.Forms.DataGridViewButtonColumn();
			this.labelNodoIncial = new System.Windows.Forms.Label();
			this.buttonObtenerCaminos = new System.Windows.Forms.Button();
			this.comboBoxNodos = new System.Windows.Forms.ComboBox();
			this.buttonLimpiarCaminos = new System.Windows.Forms.Button();
			this.labelCebo = new System.Windows.Forms.Label();
			this.comboBoxCebos = new System.Windows.Forms.ComboBox();
			this.buttonAnimarRecorrido = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDijsktra)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewCaminos)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxDijsktra
			// 
			this.pictureBoxDijsktra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left)));
			this.pictureBoxDijsktra.BackColor = System.Drawing.Color.White;
			this.pictureBoxDijsktra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxDijsktra.Location = new System.Drawing.Point(12, 12);
			this.pictureBoxDijsktra.Name = "pictureBoxDijsktra";
			this.pictureBoxDijsktra.Size = new System.Drawing.Size(954, 703);
			this.pictureBoxDijsktra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxDijsktra.TabIndex = 1;
			this.pictureBoxDijsktra.TabStop = false;
			// 
			// dataGridViewCaminos
			// 
			this.dataGridViewCaminos.AllowUserToAddRows = false;
			this.dataGridViewCaminos.AllowUserToDeleteRows = false;
			this.dataGridViewCaminos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewCaminos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewCaminos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.ORIGEN,
			this.DESTINO,
			this.CAMINO,
			this.PESO,
			this.MOSTRAR_CAMINO});
			this.dataGridViewCaminos.Location = new System.Drawing.Point(972, 12);
			this.dataGridViewCaminos.Name = "dataGridViewCaminos";
			this.dataGridViewCaminos.RowHeadersVisible = false;
			this.dataGridViewCaminos.RowTemplate.ReadOnly = true;
			this.dataGridViewCaminos.Size = new System.Drawing.Size(367, 320);
			this.dataGridViewCaminos.TabIndex = 2;
			this.dataGridViewCaminos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCaminosCellContentClick);
			// 
			// ORIGEN
			// 
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.Format = "N0";
			dataGridViewCellStyle1.NullValue = "-1";
			this.ORIGEN.DefaultCellStyle = dataGridViewCellStyle1;
			this.ORIGEN.HeaderText = "ORIGEN";
			this.ORIGEN.Name = "ORIGEN";
			// 
			// DESTINO
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.Format = "N0";
			dataGridViewCellStyle2.NullValue = "-1";
			this.DESTINO.DefaultCellStyle = dataGridViewCellStyle2;
			this.DESTINO.HeaderText = "DESTINO";
			this.DESTINO.Name = "DESTINO";
			// 
			// CAMINO
			// 
			this.CAMINO.HeaderText = "CAMINO";
			this.CAMINO.Name = "CAMINO";
			// 
			// PESO
			// 
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.Format = "N5";
			dataGridViewCellStyle3.NullValue = "0";
			this.PESO.DefaultCellStyle = dataGridViewCellStyle3;
			this.PESO.HeaderText = "PESO";
			this.PESO.Name = "PESO";
			// 
			// MOSTRAR_CAMINO
			// 
			this.MOSTRAR_CAMINO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.MOSTRAR_CAMINO.HeaderText = "MOSTRAR CAMINO";
			this.MOSTRAR_CAMINO.Name = "MOSTRAR_CAMINO";
			// 
			// labelNodoIncial
			// 
			this.labelNodoIncial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.labelNodoIncial.BackColor = System.Drawing.Color.Transparent;
			this.labelNodoIncial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelNodoIncial.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelNodoIncial.ForeColor = System.Drawing.Color.White;
			this.labelNodoIncial.Location = new System.Drawing.Point(972, 335);
			this.labelNodoIncial.Name = "labelNodoIncial";
			this.labelNodoIncial.Size = new System.Drawing.Size(367, 23);
			this.labelNodoIncial.TabIndex = 31;
			this.labelNodoIncial.Text = "Nodo Inicial:";
			// 
			// buttonObtenerCaminos
			// 
			this.buttonObtenerCaminos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.buttonObtenerCaminos.BackColor = System.Drawing.Color.White;
			this.buttonObtenerCaminos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonObtenerCaminos.Font = new System.Drawing.Font("Lucida Bright", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonObtenerCaminos.Location = new System.Drawing.Point(972, 401);
			this.buttonObtenerCaminos.Name = "buttonObtenerCaminos";
			this.buttonObtenerCaminos.Size = new System.Drawing.Size(367, 34);
			this.buttonObtenerCaminos.TabIndex = 29;
			this.buttonObtenerCaminos.Text = "OBTENER CAMINOS";
			this.buttonObtenerCaminos.UseVisualStyleBackColor = false;
			this.buttonObtenerCaminos.Click += new System.EventHandler(this.ButtonObtenerCaminosClick);
			// 
			// comboBoxNodos
			// 
			this.comboBoxNodos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxNodos.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxNodos.FormattingEnabled = true;
			this.comboBoxNodos.Location = new System.Drawing.Point(972, 361);
			this.comboBoxNodos.Name = "comboBoxNodos";
			this.comboBoxNodos.Size = new System.Drawing.Size(367, 24);
			this.comboBoxNodos.TabIndex = 30;
			// 
			// buttonLimpiarCaminos
			// 
			this.buttonLimpiarCaminos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.buttonLimpiarCaminos.BackColor = System.Drawing.Color.White;
			this.buttonLimpiarCaminos.Enabled = false;
			this.buttonLimpiarCaminos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonLimpiarCaminos.Font = new System.Drawing.Font("Lucida Bright", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonLimpiarCaminos.Location = new System.Drawing.Point(972, 451);
			this.buttonLimpiarCaminos.Name = "buttonLimpiarCaminos";
			this.buttonLimpiarCaminos.Size = new System.Drawing.Size(367, 34);
			this.buttonLimpiarCaminos.TabIndex = 32;
			this.buttonLimpiarCaminos.Text = "LIMPIAR CAMINOS";
			this.buttonLimpiarCaminos.UseVisualStyleBackColor = false;
			this.buttonLimpiarCaminos.Click += new System.EventHandler(this.ButtonLimpiarCaminosClick);
			// 
			// labelCebo
			// 
			this.labelCebo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.labelCebo.BackColor = System.Drawing.Color.Transparent;
			this.labelCebo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelCebo.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCebo.ForeColor = System.Drawing.Color.White;
			this.labelCebo.Location = new System.Drawing.Point(972, 520);
			this.labelCebo.Name = "labelCebo";
			this.labelCebo.Size = new System.Drawing.Size(367, 23);
			this.labelCebo.TabIndex = 34;
			this.labelCebo.Text = "Cebo:";
			// 
			// comboBoxCebos
			// 
			this.comboBoxCebos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxCebos.Enabled = false;
			this.comboBoxCebos.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxCebos.FormattingEnabled = true;
			this.comboBoxCebos.Location = new System.Drawing.Point(972, 546);
			this.comboBoxCebos.Name = "comboBoxCebos";
			this.comboBoxCebos.Size = new System.Drawing.Size(367, 24);
			this.comboBoxCebos.TabIndex = 33;
			// 
			// buttonAnimarRecorrido
			// 
			this.buttonAnimarRecorrido.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAnimarRecorrido.BackColor = System.Drawing.Color.White;
			this.buttonAnimarRecorrido.Enabled = false;
			this.buttonAnimarRecorrido.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonAnimarRecorrido.Font = new System.Drawing.Font("Lucida Bright", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonAnimarRecorrido.Location = new System.Drawing.Point(972, 593);
			this.buttonAnimarRecorrido.Name = "buttonAnimarRecorrido";
			this.buttonAnimarRecorrido.Size = new System.Drawing.Size(367, 34);
			this.buttonAnimarRecorrido.TabIndex = 35;
			this.buttonAnimarRecorrido.Text = "ANIMAR RECORRIDO";
			this.buttonAnimarRecorrido.UseVisualStyleBackColor = false;
			this.buttonAnimarRecorrido.Click += new System.EventHandler(this.ButtonAnimarRecorridoClick);
			// 
			// Formulario_De_Dijkstra
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1348, 727);
			this.Controls.Add(this.buttonAnimarRecorrido);
			this.Controls.Add(this.labelCebo);
			this.Controls.Add(this.comboBoxCebos);
			this.Controls.Add(this.buttonLimpiarCaminos);
			this.Controls.Add(this.labelNodoIncial);
			this.Controls.Add(this.buttonObtenerCaminos);
			this.Controls.Add(this.comboBoxNodos);
			this.Controls.Add(this.dataGridViewCaminos);
			this.Controls.Add(this.pictureBoxDijsktra);
			this.MinimumSize = new System.Drawing.Size(1364, 766);
			this.Name = "Formulario_De_Dijkstra";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DIJKSTRA";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Formulario_De_DijkstraFormClosing);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDijsktra)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewCaminos)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
