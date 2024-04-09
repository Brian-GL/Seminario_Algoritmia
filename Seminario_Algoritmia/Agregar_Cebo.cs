/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 23/09/2019
 * Time: 02:05 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Seminario_Algoritmia
{
	/// <summary>
	/// Description of Agregar_Agentes_Manual.
	/// </summary>
	public partial class Form_Agregar_Agentes_Manual : Form
	{
		public int numVertice;
		
		public Form_Agregar_Agentes_Manual(List<Circulo> listaVertices)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			for(int i = 0; i < listaVertices.Count;i++){
				var renglon = dgvDatosVertices.Rows.Add();
				dgvDatosVertices.Rows[renglon].Cells["Vertice"].Value = (i).ToString();
				dgvDatosVertices.Rows[renglon].Cells["X"].Value = listaVertices[i].GetPuntoCentral().X.ToString();
				dgvDatosVertices.Rows[renglon].Cells["Y"].Value = listaVertices[i].GetPuntoCentral().Y.ToString();
			}
			
		}

		void DgvDatosVerticesCellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			numVertice = e.RowIndex;
			this.Close();
		}


	}
}
