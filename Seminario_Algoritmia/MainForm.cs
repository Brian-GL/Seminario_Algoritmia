/*
 * Creado por SharpDevelop.
 * Usuario: qwert
 * Fecha: 19/08/2019
 * Hora: 14:42
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Threading;

namespace Seminario_Algoritmia
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	/// 
	
	//Lo unico que conoce el agente es el angulo hacia donde esta el cebo.
	
	public partial class MainForm : Form
	{

		public Bitmap myBitmap,copiamyBitmap;
		public List<Circulo> circleList;
		public Graph<Circulo> myCircleGraph;
		public Point puntoCebo;
		public List<Agente> agentList;
		public MainForm()
		{
			
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			circleList = new List<Circulo>();
			myCircleGraph =  new Graph<Circulo>();
			agentList = new List<Agente>();
			btnAgregarNuevoCebo.Enabled = false;
			puntoCebo = new Point(-5,-5);
			btnReset.Enabled = false;
			btnjAleatoridad.Enabled = false;

			ptbImage.BackgroundImageLayout = ImageLayout.Zoom;


		}

		void BtnAbrirImagenClick(object sender, EventArgs e)
		{
			
			if(myBitmap != null) 
				myBitmap.Dispose();
			else
				myBitmap = null;
			
			if(copiamyBitmap != null) 
				copiamyBitmap.Dispose();
			else
				copiamyBitmap = null;

			ptbImage.Image = null;
			ptbImage.BackgroundImage = null;
			dgvGraph.Rows.Clear();
			dgvVertexs.Rows.Clear();
			agentList.Clear();
			myCircleGraph.Clear();
			circleList.Clear();
			agentList.Clear();
			
			var openImagen = new OpenFileDialog();
			openImagen.Filter =  "Imágenes En Formato PNG *.png | *.png";
			var result = openImagen.ShowDialog();

			if(result.Equals(System.Windows.Forms.DialogResult.Cancel)){
				MessageBox.Show("IMAGEN INEXISTENTE","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				myBitmap = null;
				btnReset.Enabled = false;
				btnjAleatoridad.Enabled = false;
				buttonKruskal.Enabled = false;
				buttonPrim.Enabled = false;
				buttonDijkstra.Enabled = false;
				buttonPresasDepredadores.Enabled = false;
				buttonComparacion.Enabled =  false;
				
			} 
			else{
				myBitmap = copiamyBitmap = null;
				var nombre = openImagen.FileName;
				txbImageName.Text = getImageName(nombre);
				myBitmap = new Bitmap(nombre);
				
			
				ptbImage.BackgroundImage = myBitmap;

				var pregunta = MessageBox.Show("¿La Imagen Seleccionada Es Correcta?","PREGUNTA",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			
				
				//Algoritmo:
				
				if(pregunta.Equals(DialogResult.Yes)){
					
					myBitmap = Reconocimiento_Circulos(nombre);
					ptbImage.BackgroundImage = myBitmap;
					
					
					MessageBox.Show("Generacion Correcta Del Resultado\n(Imagen Guardada Como nombreImagen_Resuelto.jpg)","AVISO",MessageBoxButtons.OK,MessageBoxIcon.Information);
//					var newName = getNormalName(txbImageName.Text) + "_Resuelto.jpg";
//					ptbImage.BackgroundImage.Save(newName);
					
					btnAgregarNuevoCebo.Enabled = true;
					
					//lblAgente.Text = "Para agregar un nuevo agente\n de doble click en la fila del círculo";
					
					copiamyBitmap = new Bitmap(myBitmap);
					
					btnReset.Enabled = true;
					btnjAleatoridad.Enabled = true;
					buttonKruskal.Enabled = true;
					buttonPrim.Enabled = true;
					buttonDijkstra.Enabled = true;
					buttonPresasDepredadores.Enabled = true;
			
					buttonComparacion.Enabled =  true;
				}
				else {
					
					ptbImage.BackgroundImage = null;
					ptbImage.Image = null;
					copiamyBitmap = null;
					myBitmap = null;
				}
			}
				
		}
		void BtnAbrirImagenMouseEnter(object sender, EventArgs e)
		{
			btnAbrirImagen.BackColor = Color.Gainsboro;
		}
		void BtnAbrirImagenMouseLeave(object sender, EventArgs e)
		{
			btnAbrirImagen.BackColor = Color.White;
		}

		string getImageName(string value){
			string retorno = "";
			
			for(int i = value.Length-1;i >= 0;i--){
				if(value[i].Equals(Convert.ToChar(92))) break;
				retorno+=value[i];
			}
			
			var array = retorno.ToCharArray();
			Array.Reverse(array);
			
			return new string(array);
			
		}
		
		bool EsBuenColor(Color c){
			if(c.R != 255)
				if(c.G != 255)
					if(c.B != 255)
						return true;
			
			return false;
		}
		

		
		Bitmap Reconocimiento_Circulos(string filename){
			
			var img = new Bitmap(filename);
			
			myProgressBar.Maximum = img.Width;
			myProgressBar.Value = 0;
			for(int x = 0; x < img.Width;x++){
				for(int y = 0; y < img.Height;y++){
					
					if(img.GetPixel(x,y).ToArgb().Equals(Color.Black.ToArgb())){ //encontramos el primer punto negro
					
						//Encontramos el punto en su campo 'x' más cercano a 0 del circulo.
						var circulo = new Circulo();
						
						var diametroHorizontal = 0;
						var diametroVertical = 0;
						var radioOeste = 0;
						var radioEste = 0;
						var radioNorte = 0;
						var radioSur = 0;
						
						var auxiliarX = x;
						var auxiliarY = y;
						
						//!img.GetPixel(auxiliarX,y).ToArgb().Equals(Color.White.ToArgb())
						
						//Obtenemos el tamaño del diametro del circulo.
						while(EsBuenColor(img.GetPixel(auxiliarX,y))){ //caminamos hacia la derecha hasta que el pixel ya no sea negro.
							if(auxiliarX == img.Width-1) break;
							diametroHorizontal++;
							auxiliarX++;
						}
						
						//dividimos entre dos para obtener el punto central:
						if(diametroHorizontal%2 == 0){//el diametro es par, por lo que el residuo de la division es 0.
							radioEste = radioOeste = diametroHorizontal/2;
						}else{//la division que se genere en diametroHorizontal no es par.
							radioEste = (diametroHorizontal/2) +1;
							radioOeste = diametroHorizontal/2;
						}
						
						//obtenemos el punto norte y sur del circulo:
						
						auxiliarX = x + radioOeste; //sumamos a diametro vertical la distancia en pixeles que hay del centro hasta el último pixel negro hacia arriba
						while(EsBuenColor(img.GetPixel(auxiliarX,auxiliarY))){ //caminamos hacia arriba hasta que el pixel ya no sea negro.
							if(auxiliarY == 0) break;
							diametroVertical++;
							auxiliarY--;
						}
						
						circulo.SetPuntoNorte(auxiliarX,auxiliarY); //establecemos el punto norte
				
						
						auxiliarY = y;//sumamos a diametro vertical la distancia en pixeles que hay del centro hasta el último pixel negro hacia abajo
						while(EsBuenColor(img.GetPixel(auxiliarX,auxiliarY))){ //caminamos hacia abajo hasta que el pixel ya no sea negro.
							if(auxiliarY == img.Height-1) break;
							diametroVertical++;
							auxiliarY++;
						}
						
						
						circulo.SetPuntoSur(auxiliarX,auxiliarY); //establecemos el punto sur
						
						//dividimos diametro vertical:
						if(diametroVertical%2 == 0){//es par
							radioNorte = radioSur = diametroVertical/2;
						}else{
							radioNorte = (diametroVertical/2) + 1;
							radioSur = diametroVertical/2;
						}
						
						//obtenemos los demás puntos del circulo:
						
						circulo.SetPuntoCentral(auxiliarX,circulo.GetPuntoNorte().Y+radioNorte);
						
						
						auxiliarX = circulo.GetPuntoCentral().X;
						while(EsBuenColor(img.GetPixel(auxiliarX,circulo.GetPuntoCentral().Y))){ //caminamos hacia abajo hasta que el pixel ya no sea negro.
							if(auxiliarX == img.Width-1) break;
							auxiliarX++;
						}
						
						circulo.SetPuntoEste(auxiliarX,circulo.GetPuntoCentral().Y);
						
						auxiliarX = circulo.GetPuntoCentral().X;
						while(EsBuenColor(img.GetPixel(auxiliarX,circulo.GetPuntoCentral().Y))){ //caminamos hacia abajo hasta que el pixel ya no sea negro.
							if(auxiliarX == 0) break;
							auxiliarX--;
						}
						
						circulo.SetPuntoOeste(auxiliarX,circulo.GetPuntoCentral().Y);							

						if(circulo.IsCircle()){
							
							paintCircle(circulo,img);
							circleList.Add(circulo);	
						}
						else{
							paintNoCircle(circulo,img);
						}
						
						
						
						
					}//end if punto es negro
				}//end for y (Height)
				
				myProgressBar.Value = x;

			}//end for x (Width)
			
									
			//algoritmo fuerza bruta:
			
			OrderByRatio(ref circleList);

			for(int i = 0; i < circleList.Count;i++){
				circleList[i].SetID(i);
				myCircleGraph.Insert_Node(circleList[i]);
				
			}
			
			var col = Color.FromArgb(30,144,255);
			var listaLineas = new List<Pair<Point,Point>>();
			for(int i = 0; i < circleList.Count;i++){
				for(int j = i+1;j < circleList.Count;j++){
					var dda = DDA_Algorithm(circleList[i],circleList[j],img);
					
					
					if(dda){
						var distancia = Circulo.Distance(circleList[i].GetPuntoCentral(),circleList[j].GetPuntoCentral());
						DrawLine(circleList[i].GetPuntoCentral(),circleList[j].GetPuntoCentral(),img,col);
						//listaLineas.Add(new Pair<Point, Point>(circleList[i].GetPuntoCentral(),circleList[j].GetPuntoCentral()));
						myCircleGraph.Insert_Edge(distancia,circleList[i],circleList[j]);
						myCircleGraph.Insert_Edge(distancia,circleList[j],circleList[i]);
						
						int renglon = dgvGraph.Rows.Add();
						dgvGraph.Rows[renglon].Cells["Origin"].Value = i.ToString();
						dgvGraph.Rows[renglon].Cells["Weight"].Value =  distancia;
						dgvGraph.Rows[renglon].Cells["Destination"].Value = j.ToString();
					}
					
				}
				
				
			}
			
			dgvVertexs.Rows.Clear();
			for(int i = 0; i < circleList.Count;i++){
				int renglon = dgvVertexs.Rows.Add();
				dgvVertexs.Rows[renglon].Cells["Vertex"].Value = (i).ToString();
				dgvVertexs.Rows[renglon].Cells["X"].Value = circleList[i].GetPuntoCentral().X;
				dgvVertexs.Rows[renglon].Cells["Y"].Value = circleList[i].GetPuntoCentral().Y;
				dgvVertexs.Rows[renglon].Cells["Vertical_Ratio"].Value = circleList[i].VerticalRatio();
				dgvVertexs.Rows[renglon].Cells["Horizontal_Ratio"].Value = circleList[i].HorizontalRatio();

				var graficos = Graphics.FromImage(img);
				var drawFont = new Font("Arial", circleList[i].GetRadioNorte());
				graficos.DrawString((renglon).ToString(),drawFont,new SolidBrush(Color.Black),circleList[i].GetPuntoCentral().X,circleList[i].GetPuntoCentral().Y);
				int centro = (circleList[i].GetRadioNorte() + circleList[i].GetRadioSur()) / 10;
				graficos.FillRectangle(new SolidBrush(Color.Black), new Rectangle(circleList[i].GetPuntoCentral().X,circleList[i].GetPuntoCentral().Y,centro,centro));
				graficos.Dispose();
			}
			
			if(circleList.Count != 0){
				var par = Closets_Pair_Point(circleList);				
				DrawLine(par.firstData.GetPuntoCentral(),par.secondData.GetPuntoCentral(),img,Color.Red);
			}			
				
			return img;
			
		}

		string getNormalName(string value){
			var retorno = "";
			for(int i = 0; i < value.Length;i++){
				if(value[i].Equals('.'))
					break;
				retorno+=value[i].ToString();
				
			}
			return retorno;
		}
		
		void paintCircle(Circulo c, Bitmap bmp){

			var graficos = Graphics.FromImage(bmp);
	
			var i = c.GetPuntoOeste().X;
			
			graficos.FillEllipse(new SolidBrush(Color.Green),c.GetPuntoOeste().X,c.GetPuntoNorte().Y,c.GetRadioHorizontal(),c.GetRadioVertical());
			graficos.Dispose();
			
			//!bmp.GetPixel(i,c.GetPuntoOeste().Y).ToArgb().Equals(Color.White.ToArgb()

			while(EsBuenColor(bmp.GetPixel(i,c.GetPuntoOeste().Y)) && i < bmp.Width){
				
				var j = c.GetPuntoCentral().Y;
				//!bmp.GetPixel(i,j).ToArgb().Equals(Color.White.ToArgb()
				while(EsBuenColor(bmp.GetPixel(i,j)) && j > 0){
					bmp.SetPixel(i,j,Color.Green);
					j--;
					
				}
				j =  c.GetPuntoCentral().Y;
				//!bmp.GetPixel(i,j).ToArgb().Equals(Color.White.ToArgb()
				while(EsBuenColor(bmp.GetPixel(i,j)) && j < bmp.Height){
					bmp.SetPixel(i,j,Color.Green);
					j++;
				}

				i++;
			
			}

		}

		void paintNoCircle(Circulo c, Bitmap bmp){
//			
//			var graficos = Graphics.FromImage(bmp);
//			graficos.FillEllipse(new SolidBrush(Color.White),c.GetPuntoOeste().X,c.GetPuntoNorte().Y,c.GetRadioHorizontal(),c.GetRadioVertical());
//			graficos.Dispose();
			
			var graficos = Graphics.FromImage(bmp);
	
			var i = c.GetPuntoOeste().X;
			
			graficos.FillEllipse(new SolidBrush(Color.White),c.GetPuntoOeste().X,c.GetPuntoNorte().Y,c.GetRadioHorizontal(),c.GetRadioVertical());
			graficos.Dispose();
			
			//!bmp.GetPixel(i,c.GetPuntoOeste().Y).ToArgb().Equals(Color.White.ToArgb()

			while(EsBuenColor(bmp.GetPixel(i,c.GetPuntoOeste().Y)) && i <= bmp.Width){
				
				var j = c.GetPuntoCentral().Y;
				//!bmp.GetPixel(i,j).ToArgb().Equals(Color.White.ToArgb()
				while(EsBuenColor(bmp.GetPixel(i,j)) && j >= 0){
					bmp.SetPixel(i,j,Color.White);
					j--;
					
				}
				j =  c.GetPuntoCentral().Y;
				//!bmp.GetPixel(i,j).ToArgb().Equals(Color.White.ToArgb()
				while(EsBuenColor(bmp.GetPixel(i,j)) && j <= bmp.Height){
					bmp.SetPixel(i,j,Color.White);
					j++;
				}

				i++;
			
			}

		}
		
		void DrawLine(Point a, Point b, Image bmp, Color c){
			var graficos = Graphics.FromImage(bmp);
			graficos.DrawLine(new Pen(c),a.X,a.Y,b.X,b.Y);
			graficos.Dispose();
		}
		
		Pair<Circulo,Circulo> Closets_Pair_Point(IList<Circulo> listCircle){
			
			if(listCircle.Count == 1) return new Pair<Circulo, Circulo>(listCircle.First(),listCircle.First());
			
			double minimun = 1000000000;
			var listPair = new List<Pair<Circulo,Circulo>>();
			
			for(int i = 0; i < listCircle.Count;i++){
				
				for(int j = i+1; j < listCircle.Count;j++){
					
					var distancia = Circulo.Distance(listCircle[i].GetPuntoCentral(),listCircle[j].GetPuntoCentral());
					if(distancia < minimun){
						if(listPair.Count != 0)
							listPair.RemoveAt(0);
						minimun = distancia;
						listPair.Add(new Pair<Circulo,Circulo>(listCircle[i],listCircle[j]));
					}
						
					
				}//end for j

			}//end for i
			
			return listPair.First();
			
		}
		
		void OrderByRatio(ref List<Circulo> C){
			var min = 0;
			for (int i = 0; i < C.Count; ++i) {
		        min = i;
		        for (int j = i+1; j < C.Count; ++j) {
		        	if(C[j].VerticalRatio() < C[min].VerticalRatio()){
		                min = j;
		            }
		
		        }
		        var intercambio = C[i];
		        C[i] = C[min];
		        C[min] = intercambio;
		    }
			
			
			
		}
		

		bool DDA_Algorithm(Circulo c1, Circulo c2, Bitmap bmp){
			
			//pendiente:
			var m = Circulo.Pendiente(c1.GetPuntoCentral(),c2.GetPuntoCentral());
	
			var dy = Math.Abs(c1.GetPuntoCentral().Y - c2.GetPuntoCentral().Y);
			var dx = Math.Abs(c1.GetPuntoCentral().X - c2.GetPuntoCentral().X);
			
			if(dx >= dy){
			   //y = mx + b	
				var puntos = Agente.OrderPoints_By_X(c1.GetPuntoCentral(),c2.GetPuntoCentral());
				var b = Circulo.B(puntos.firstData,m);
				var Xk = puntos.firstData.X;
				var Yk = puntos.firstData.Y;
				double Ysumante = puntos.firstData.Y;
				while(Xk <= puntos.secondData.X){
					if(!Circulo.IsGoodColor(bmp.GetPixel(Xk,Yk),new Point(Xk,Yk),c1,c2)) return false;
					Ysumante = (m * Xk)+b;
					Yk = Convert.ToInt32(Math.Round(Ysumante));
					Xk++;
				}
				
			}
			else{
				// x = (y-b)/m
				var puntos = Agente.OrderPoints_By_Y(c1.GetPuntoCentral(),c2.GetPuntoCentral());
				var b = Circulo.B(puntos.firstData,m);
				var Xk = puntos.firstData.X;
				var Yk = puntos.firstData.Y;
				double Xsumante = puntos.firstData.X;
				while(Yk <= puntos.secondData.Y){
					if(!Circulo.IsGoodColor(bmp.GetPixel(Xk,Yk),new Point(Xk,Yk),c1,c2)) return false;
					Xsumante = (m.Equals(0))? puntos.firstData.X : (Yk-b)/m;
					Xk = Convert.ToInt32(Math.Round(Xsumante));
					Yk++;
				}
				
			}

			return true;
		    
		}
		
		void BtnSimularClick(object sender, EventArgs e){
		
			if(agentList.Count == 0 || puntoCebo.X == -5 && puntoCebo.Y == -5){
				MessageBox.Show("Ingrese Primeramente Un Cebo Y Un Agente","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}else{
				var bmp = new Bitmap(myBitmap);
				
				var graficos = Graphics.FromImage(bmp);
				graficos.FillEllipse(new SolidBrush(Color.Black),new Rectangle(puntoCebo.X,puntoCebo.Y,20,20));
				
				var simulationForm = new Formulario_De_Animacion(bmp,copiamyBitmap,ref agentList,myCircleGraph,puntoCebo);
				simulationForm.ShowDialog();

				//La simulacion acabo, entonces debemos de mover los puntos a sus nuevas posiciones:
				
				//agentList.Clear();
				copiamyBitmap.Dispose();
				//agentList = simulationForm.agentList;
				copiamyBitmap = new Bitmap(myBitmap);
				ptbImage.Image = copiamyBitmap;
				ptbImage.Refresh();
				
				
				for(int i = 0; i < agentList.Count;i++){
					//DIBUJAR AGENTE:
					var grafics = Graphics.FromImage(copiamyBitmap);
					grafics.FillEllipse(new SolidBrush(Color.DarkRed),new Rectangle(agentList[i].GetPosicion().X,agentList[i].GetPosicion().Y,20,20));
					ptbImage.Refresh();
					grafics.Dispose();
				}
				
				puntoCebo = new Point(-1,-1);
				btnAgregarNuevoCebo.Enabled = true;
				btnSimular.Enabled = false;
				
				simulationForm.Dispose();
			}
			
		}

		void BtnAgregarNuevoCeboClick(object sender, EventArgs e)
		{
			//CEBO:

			var agregarAgenteDeFormaManual = new Form_Agregar_Agentes_Manual(circleList);
			agregarAgenteDeFormaManual.ShowDialog();
		
			puntoCebo = circleList[agregarAgenteDeFormaManual.numVertice].GetPuntoCentral();
			var validacion = true;
			for(int i = 0; i < agentList.Count;i++){
				if(agentList[i].GetPosicion().Equals(circleList[agregarAgenteDeFormaManual.numVertice].GetPuntoCentral())){
					MessageBox.Show("Ya Existe Un Agente En Dicha Posicion","ADVERTENCIA",MessageBoxButtons.OK,MessageBoxIcon.Error);
					validacion = false; 
					break;
				}
			}
			
			if(validacion){
				var graficos = Graphics.FromImage(copiamyBitmap);
				graficos.FillEllipse(new SolidBrush(Color.Black),new Rectangle(circleList[agregarAgenteDeFormaManual.numVertice].GetPuntoCentral().X,circleList[agregarAgenteDeFormaManual.numVertice].GetPuntoCentral().Y,20,20));
				graficos.Dispose();
				ptbImage.Image = copiamyBitmap;
				
				puntoCebo = circleList[agregarAgenteDeFormaManual.numVertice].GetPuntoCentral();
	
				btnAgregarNuevoCebo.Enabled = false;
				btnSimular.Enabled = true;
			}
			
			agregarAgenteDeFormaManual.Dispose();
			
		}

		int getPosicionCirculoEnLista(Point p){
			var pos = -1;
			for(int i = 0; i < circleList.Count;i++){
				if(circleList[i].GetPuntoCentral().X == p.X &&
				   circleList[i].GetPuntoCentral().Y == p.Y){
					pos = i; break;
				}
			}
			
			return pos;
		}
		
		bool EqualColor(Color c1, Color c2){
			
			if(c1.R == c2.R)
				if(c2.G == c1.G)
					if(c1.B == c2.B)
						return true;
			
			return false;
			
		}

		void DgvVertexsCellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if(agentList.Count < myCircleGraph.Size_Nodes()){
				var validacion = true;
				for(int i = 0; i < agentList.Count;i++){
					if(agentList[i].GetPosicion().Equals(circleList[e.RowIndex].GetPuntoCentral())){
						MessageBox.Show("Ya Existe Un Agente En Dicha Posicion","ADVERTENCIA",MessageBoxButtons.OK,MessageBoxIcon.Error);
						validacion = false; 
						break;
					}
				}
				
				if(validacion){
					
					if(puntoCebo.Equals(circleList[e.RowIndex].GetPuntoCentral())){
						MessageBox.Show("Existe Un Cebo En Dicha Posicion","ADVERTENCIA",MessageBoxButtons.OK,MessageBoxIcon.Error);
					}else{
						var graficos = Graphics.FromImage(copiamyBitmap);
						graficos.FillEllipse(new SolidBrush(Color.DarkRed),new Rectangle(circleList[e.RowIndex].GetPuntoCentral().X,circleList[e.RowIndex].GetPuntoCentral().Y,20,20));
						graficos.Dispose();
						ptbImage.Image = copiamyBitmap;
						var code = agentList.Count;
						agentList.Add(new Agente(code,circleList[e.RowIndex].GetPuntoCentral(),5));
						
						
						
					}
					
				}

			}
			else{
				MessageBox.Show("Ha Sobrepasado El Número De Agentes","ADVERTENCIA",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}

		}
		void BtnResetClick(object sender, EventArgs e)
		{
			var confirmation = MessageBox.Show("¿Está Seguro De Resetar A Los Agente Y Al Cebo?","PREGUNTA",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
			
			if(confirmation == DialogResult.Yes){
				//reseteamos:
				
				var graficos = Graphics.FromImage(copiamyBitmap);
				graficos.Clear(Color.Transparent);
				graficos.Dispose();
				
				ptbImage.Refresh();
				
				if(!btnAgregarNuevoCebo.Enabled)
					btnAgregarNuevoCebo.Enabled = true;
				
				agentList.Clear();
				
				puntoCebo = new Point(-1,-1);
				
			}
				
			
		}
		void BtnjAleatoridadClick(object sender, EventArgs e)
		{
			//Creacion de aleatoridad:
			//abrimos el form
			
			if(puntoCebo.X < 0 && puntoCebo.Y < 0){
				MessageBox.Show("¡Ingrese Primeramente Un Cebo!","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}else{
				var aleatoriedad = new Aleatoriedad_Form(circleList,puntoCebo,agentList.Count);
				
				aleatoriedad.ShowDialog();
				
				for(int i = 0; i < aleatoriedad.listaAgentes.Count;i++){
					agentList.Add(aleatoriedad.listaAgentes[i]);
					//Dibujar agente
					var graficos = Graphics.FromImage(copiamyBitmap);
					graficos.FillEllipse(new SolidBrush(Color.DarkRed),new Rectangle(aleatoriedad.listaAgentes[i].GetPosicion().X,aleatoriedad.listaAgentes[i].GetPosicion().Y,20,20));
					graficos.Dispose();
					ptbImage.Image = copiamyBitmap;
					
				}
				
				aleatoriedad.Dispose();
			}
			
			
		}
		void PtbImageDoubleClick(object sender, EventArgs e)
		{
			var verImagen = new ImagenGrande(myBitmap);
			verImagen.ShowDialog();
		}
		void ButtonKruskalClick(object sender, EventArgs e)
		{
			var kruskal = new Formulario_De_Kruskal(myCircleGraph,myBitmap);
			kruskal.ShowDialog();
		}
		void ButtonPrimClick(object sender, EventArgs e)
		{
			var prim = new Formulario_De_Prim(myCircleGraph,myBitmap);
			prim.ShowDialog();
		}
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			myCircleGraph.Clear();
			
			circleList.Clear();
			agentList.Clear();

			if(myBitmap != null) 
				myBitmap.Dispose();
			
			if(copiamyBitmap != null) 
				copiamyBitmap.Dispose();
			
			this.Dispose();
		}
		void ButtonComparacionClick(object sender, EventArgs e)
		{
			var fc = new Formulario_Comparacion(myCircleGraph,myBitmap);
			fc.ShowDialog();
		}
		void ButtonDijkstraClick(object sender, EventArgs e)
		{
			var dijsktra = new Formulario_De_Dijkstra(myCircleGraph,myBitmap);
			dijsktra.ShowDialog();
		}
		void ButtonPresasDepredadoresClick(object sender, EventArgs e)
		{
			var presaDepredador = new PresasDepredadores(myCircleGraph,myBitmap);
			presaDepredador.ShowDialog();
		}
	
		

	}
}
