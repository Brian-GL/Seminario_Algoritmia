/*
 * Creado por SharpDevelop.
 * Usuario: Brian Gaytan Lomeli
 * Fecha: 13/10/2019
 * Hora: 19:33
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Seminario_Algoritmia
{
	/// <summary>
	/// Description of Aleatoriedad_Form.
	/// </summary>
	public partial class Aleatoriedad_Form : Form
	{
		
		public List<Agente> listaAgentes = new List<Agente>();
		public List<Circulo> listCirculo;
		public Point puntoCebo;
		public int indice;
		public Aleatoriedad_Form(List<Circulo> circleList, Point p,int index)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			//Llenar datagridview
			
			indice = index;
			puntoCebo = p;
			listCirculo = circleList;
			
			for(int i = 0; i < circleList.Count;i++){
				
				if(circleList[i].GetAgentesQueMeHanVisitado().Empty() && circleList[i].GetPuntoCentral() != p){
					int renglon = dgvVertexs.Rows.Add();
					dgvVertexs.Rows[renglon].Cells["Vertex"].Value = (i).ToString();
					dgvVertexs.Rows[renglon].Cells["X"].Value = circleList[i].GetPuntoCentral().X;
					dgvVertexs.Rows[renglon].Cells["Y"].Value = circleList[i].GetPuntoCentral().Y;
					dgvVertexs.Rows[renglon].Cells["Vertical_Ratio"].Value = circleList[i].VerticalRatio();
					dgvVertexs.Rows[renglon].Cells["Horizontal_Ratio"].Value = circleList[i].HorizontalRatio();
				}
				
			}
			
			nudValor.Maximum = dgvVertexs.RowCount;
			

		}
		void BtnAcceptClick(object sender, EventArgs e)
		{
	
			
			for(int i = 0; i < nudValor.Value;i++){
				var newRandom = new Random();
				var value = newRandom.Next(0,listCirculo.Count-1);
				
				while(!ExistID(value)){
					value = newRandom.Next(0,listCirculo.Count-1);
				}
				
				//agregar el nuevo agente en la posicion value
				listaAgentes.Add(new Agente(indice,listCirculo[value].GetPuntoCentral(),20));
				listCirculo[value].SetAgenteQueMeHaVisitado(listaAgentes.Last().GetID(),0);
				indice++;
			}

			//Generar una lista
			
			this.Close();
			
		}
		
		bool ExistID(int id){
			
			if(listCirculo[id].GetAgentesQueMeHanVisitado().Empty() && listCirculo[id].GetPuntoCentral() != puntoCebo)
				return true;
			
			return false;
		}
		
	}
}
