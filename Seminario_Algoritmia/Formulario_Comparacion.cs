/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 13/11/2019
 * Time: 01:43 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Seminario_Algoritmia
{
	/// <summary>
	/// Description of Formulario_Comparacion.
	/// </summary>
	public partial class Formulario_Comparacion : Form
	{
		
		Bitmap bitmapFondo, bitmapFrente;
		Graph<Circulo> myCircleGraph = new Graph<Circulo>();
		
		public Formulario_Comparacion(Graph<Circulo> grafo, Bitmap bmp)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			bitmapFondo = new Bitmap(bmp);

			myCircleGraph = grafo;
			
			pictureBoxGrafo.BackgroundImage = bitmapFondo;
			pictureBoxGrafo.BackgroundImageLayout = ImageLayout.Zoom;
			DrawWeight(myCircleGraph);
			for(int i = 0; i < myCircleGraph.Size_Nodes();i++){
				comboBoxNodos.Items.Add(myCircleGraph[i].data.ToString());
				
			}
			
			
			
			
		}
		
		void DrawWeight(Graph<Circulo> graph){
			var graficos = Graphics.FromImage(pictureBoxGrafo.BackgroundImage);
			var listaAristas = graph.GetEdges();
			for(int i = 0; i <listaAristas.Count;i++){
				
				var drawFont = new Font("Arial", 8);
				var middlePoint = GetMiddlePoint(listaAristas[i].firstData.GetPuntoCentral(),listaAristas[i].thirdData.GetPuntoCentral());
				var cadena = Convert.ToInt32(listaAristas[i].secondData).ToString();
				graficos.DrawString((cadena),drawFont,new SolidBrush(Color.Black),middlePoint.X,middlePoint.Y);
				
	
			}
			graficos.Dispose();
			pictureBoxGrafo.Refresh();
		}

		Point GetMiddlePoint(Point a, Point b){
			double middleX = 0;
			double middleY = 0;
			
			middleX = (a.X + b.X) /2;
			middleY = (a.Y + b.Y)/2;
			
			return new Point(Convert.ToInt32(middleX),Convert.ToInt32(middleY));
		}
		
		
		
		void ButtonAnimarClick(object sender, EventArgs e)
		{
			if(comboBoxNodos.Text.Length > 0){
				var listaPrim =  myCircleGraph.PrimFullList(GetCirculo(int.Parse(comboBoxNodos.SelectedItem.ToString())));
				var kruskalList = myCircleGraph.KruskalFullList().firstData;
				
				
				double sumaPrim = 0;

				for(int i = 0; i < listaPrim.Count;i++){
					
					DrawARM(listaPrim[i].firstData,listaPrim[i].secondData,listaPrim[i].thirdData,Color.DarkBlue,10);
					
					sumaPrim+=listaPrim[i].secondData;
					int renglon = dgvGraphPrim.Rows.Add();
					dgvGraphPrim.Rows[renglon].Cells["dataGridViewButtonColumn1"].Value = listaPrim[i].firstData.ToString();
					dgvGraphPrim.Rows[renglon].Cells["dataGridViewButtonColumn2"].Value =  listaPrim[i].secondData;
					dgvGraphPrim.Rows[renglon].Cells["dataGridViewButtonColumn3"].Value = listaPrim[i].thirdData;
					

				}
				
				double sumaKruskal = 0;
				for(int i = 0; i < kruskalList.Count;i++){
					
					DrawARM(kruskalList[i].firstData,kruskalList[i].secondData,kruskalList[i].thirdData,Color.DarkRed,3);
			
					sumaKruskal+=kruskalList[i].secondData;
					int renglon = dgvGraphKruskal.Rows.Add();
					dgvGraphKruskal.Rows[renglon].Cells["Origin"].Value = kruskalList[i].firstData.ToString();
					dgvGraphKruskal.Rows[renglon].Cells["Weight"].Value =  kruskalList[i].secondData;
					dgvGraphKruskal.Rows[renglon].Cells["Destination"].Value = kruskalList[i].thirdData;

				}
				
				
				
				MessageBox.Show("ANIMACIÓN COMPLETADA","INFORMACIÓN",MessageBoxButtons.OK,MessageBoxIcon.Information);
				buttonAnimar.Enabled = false;
				labelPesoKruskal.Text = sumaKruskal.ToString();
				labelPesoPrim.Text = sumaPrim.ToString();
				bitmapFrente = new Bitmap(bitmapFondo);
				pictureBoxGrafo.Image = bitmapFrente;
				comboBoxNodos.Enabled = false;
			}
		}
		
		Point GetPoint(int id){
			
			for(int i = 0; i  < myCircleGraph.Size_Nodes();i++){
				if(myCircleGraph[i].data.GetID() == id){
					return myCircleGraph[i].data.GetPuntoCentral();
				}
			}
			
			return new Point(-1,-1);
			
		}
		Circulo GetCirculo(int id){
			
			for(int i = 0; i  < myCircleGraph.Size_Nodes();i++){
				if(myCircleGraph[i].data.GetID() == id){
					return myCircleGraph[i].data;
				}
			}
			
			return null;
			
		}
		
		void DrawARM(Circulo c1,double w,Circulo c2, Color c, int size){
			var graficos = Graphics.FromImage(bitmapFondo);
			//drawNode
			graficos.DrawLine(new Pen(c,size),c1.GetPuntoCentral().X,c1.GetPuntoCentral().Y,c2.GetPuntoCentral().X,c2.GetPuntoCentral().Y);
			graficos.FillEllipse(new SolidBrush(c),c1.GetPuntoOeste().X,c1.GetPuntoNorte().Y,c1.GetRadioHorizontal(),c1.GetRadioVertical());
			graficos.FillEllipse(new SolidBrush(c),c2.GetPuntoOeste().X,c2.GetPuntoNorte().Y,c2.GetRadioHorizontal(),c2.GetRadioVertical());
			//drawdata
			graficos.Dispose();
			DrawData(c1); DrawData(c2);
			pictureBoxGrafo.Refresh();
		}
		
		void DrawData(Circulo c1){
			var graficos = Graphics.FromImage(bitmapFondo);
			var drawFont = new Font("Arial", c1.GetRadioNorte());
			graficos.DrawString(c1.ToString(),drawFont,new SolidBrush(Color.Black),c1.GetPuntoCentral().X,c1.GetPuntoCentral().Y);
			int centro = (c1.GetRadioNorte() + c1.GetRadioSur()) / 10;
			graficos.FillRectangle(new SolidBrush(Color.Black), new Rectangle(c1.GetPuntoCentral().X,c1.GetPuntoCentral().Y,centro,centro));
			graficos.Dispose();
		}
		
		
		
	}
}
