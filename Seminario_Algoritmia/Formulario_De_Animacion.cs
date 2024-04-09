/*
 * Creado por SharpDevelop.
 * Usuario: Brian Gaytan Lomeli
 * Fecha: 05/10/2019
 * Hora: 13:09
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace Seminario_Algoritmia
{
	/// <summary>
	/// Description of Formulario_De_Animacion.
	/// </summary>
	public partial class Formulario_De_Animacion : Form

	{
		//REVISAR QUE SEA EL CEBO
		//REVISAR CUANDO NO HAYA MÁS CAMINO
		public Bitmap copiamyBitmap,myBitmap;
		public List<Agente> agentList;
		public Point puntoCebo;
		public Graph<Circulo> myCircleGraph;
		public Formulario_De_Animacion(Bitmap fondo, Bitmap imagen, ref List<Agente> listadeAgentes, Graph<Circulo> grafo,Point p)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//get
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			myBitmap = fondo;
			ptbImagen.BackgroundImage = fondo;
			copiamyBitmap = imagen;
			myCircleGraph = grafo;
			agentList = listadeAgentes;
			ptbImagen.BackgroundImageLayout = ImageLayout.Zoom;
			ptbImagen.Image = imagen;
			puntoCebo = p;
			
			for(int i = 0; i < myCircleGraph.Size_Nodes();i++){
				for(int j = 0; j < agentList.Count;j++){
					myCircleGraph[i].data.SetAgenteQueMeHaVisitado(agentList[j].GetID(),0);
				}
			}
			
			
			//incrementar banderas de los agentes:
			
			for(int i = 0; i < agentList.Count;i++){
				for(int j = 0;j < myCircleGraph.Size_Nodes();j++){
					if(agentList[i].GetPosicion().Equals(myCircleGraph[j].data.GetPuntoCentral())){
						myCircleGraph[j].data.incrementBandera(agentList[i]);
						break;
					}
				}
			}
		}		
		
		
		void PtbImagenDoubleClick(object sender, EventArgs e)
		{
			//inicializar la animacion:
			
			var quiebra = false;
			var listaAuxiliar = agentList;

			while(true){
				
				var listaPuntosFinales = new List<Point>();
				var listaPuntos = new List<List<Point>>();
				
				for(int i = 0; i < agentList.Count;i++){
					
					var puntoAgente = agentList[i].GetPosicion();
					var puntoDestino = Get_Point_To_Go(agentList[i]);
					
					listaPuntosFinales.Add(puntoDestino);
					listaPuntos.Add(GetWay(puntoAgente,puntoDestino,agentList[i].GetVelocidad()));
	
				}
				
				var booleano = false;
				for(int i = 0; i < listaAuxiliar.Count;i++){
					if(listaAuxiliar[i].GetPosicion() != listaPuntosFinales[i]){
						booleano = true;
						break;
					}
				}
				
				
				if(!booleano){	
					MessageBox.Show("!Ya No Hay Más Camino!","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Error);
					break;
				}
				
				OrdenarListas(ref listaPuntos, ref listaPuntosFinales, ref agentList);

				for(int i = 0; i < listaPuntos.Last().Count;i++){
					
					for(int j = 0; j < listaPuntos.Count;j++){
						if(i < listaPuntos[j].Count)
							DrawCircle(listaPuntos[j][i]);						
						else
							DrawCircle(listaPuntos[j].Last());
					}
					ptbImagen.Refresh();
					ClearBitmap();
				}
				
				
				
				for(int i = 0; i < listaPuntosFinales.Count;i++){
					
					agentList[i].SetPosicion(listaPuntosFinales[i]);
					if(agentList[i].GetPosicion().Equals(puntoCebo)){
						quiebra = true;
						agentList[i].SetVelocidad(agentList[i].GetVelocidad()+1);
					}
				}
				
				if(quiebra){
					MessageBox.Show("Simulacion Realizada Correctamente","INFORMACION",MessageBoxButtons.OK,MessageBoxIcon.Information);
					break;
				}

			}
			
			for(int  i = 0; i < myCircleGraph.Size_Nodes();i++){
				myCircleGraph[i].data.ClearAgentesQueMeHanVisitado();
			}
			
			this.Close();
		}
		
		void DrawCircle(Point p){
			var graficos = Graphics.FromImage(copiamyBitmap);	
			graficos.FillEllipse(new SolidBrush(Color.DarkRed),new Rectangle(p.X,p.Y,20,20));
			var nuevoPunto = new Point(p.X+10,p.Y+10);
			var angulo = Agente.GetAngulo(nuevoPunto,puntoCebo);
			angulo = angulo*(Math.PI/180);
			var x = Math.Cos(angulo)*40;
			var y = Math.Sin(angulo)*40;
			var newPen = new Pen(Color.DarkViolet,5);
			newPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
			graficos.DrawLine(newPen,nuevoPunto.X,nuevoPunto.Y,Convert.ToInt32(nuevoPunto.X+x),Convert.ToInt32(nuevoPunto.Y+y));
			newPen.Dispose();
			graficos.Dispose();
		}	
		
		Circulo OrdenarAngulos(ref List<Pair<Circulo,double>> lista,Agente agent,double anguloNodo){
			var min = 0;
			//anguloNodo = anguloGraphNode			

			for (int i = 0; i < lista.Count; ++i) {
				min = i;
				
		        for (int j = i+1; j < lista.Count; ++j){
					double diferenciaJ = Math.Abs(anguloNodo-lista[j].secondData);
					double diferenciaMin = Math.Abs(anguloNodo-lista[min].secondData);
		        	if(diferenciaJ < diferenciaMin)
		                min = j;
				}
				
				var intercambio = lista[i];
		        lista[i] = lista[min];
		        lista[min] = intercambio;
		        
		    }
			
			min = 0;
			for (int i = 0; i < lista.Count; ++i) {
		        min = i;
		        for (int j = i+1; j < lista.Count; ++j) {
		        	if(lista[j].firstData.getBandera(agent) < lista[min].firstData.getBandera(agent)){
		                min = j;
		            }
		        }
		
		        var intercambio = lista[i];
		        lista[i] = lista[min];
		        lista[min] = intercambio;
		    }

			
			lista.First().firstData.incrementBandera(agent);
			
			return  lista.First().firstData;
			
		}
	
		void ClearBitmap(){
			var graficos = Graphics.FromImage(copiamyBitmap);
			graficos.Clear(Color.Transparent);
			graficos.Dispose();
		}
		
		Point Get_Point_To_Go(Agente a){
			
			var graphNode = Get_Node(a); //obtener el nodo mediante el punto del agente
			
			if(graphNode != null){
				var listaAdyacencias = ListaAdyacencia(graphNode,a);//obtener los nodos adyacentes que aún se puedan visitar
				//es decir, que la bandera no esté en -1
				var anguloGraphNode = Agente.GetAngulo(graphNode.data.GetPuntoCentral(),puntoCebo);
				anguloGraphNode = 360 - anguloGraphNode;
				//anguloGraphNode = 360-anguloGraphNode;
				//MessageBox.Show(anguloGraphNode.ToString(),"ANGULO GRAPH NODE DEL "+graphNode.data.GetPuntoCentral()+" TO "+puntoCebo);
	
				if(listaAdyacencias.Count == 0)	
					return a.GetPosicion(); 
				
				if(listaAdyacencias.Count == 1){//hay solo una arista

					graphNode.data.setBandera(a,-1);
					listaAdyacencias.First().data.incrementBandera(a);//aumentamos el contador de visitas;
					return listaAdyacencias.First().data.GetPuntoCentral();
				}
				else{//hay aristas para viajar 
					//Buscar la mejor ruta
					var nodoRetorno = graphNode;
					var colaAngular = new List<Pair<Circulo,double>>();
					
					for(int j = 0; j < listaAdyacencias.Count;j++){
						
						if(listaAdyacencias[j].data.GetPuntoCentral().Equals(puntoCebo))
							return listaAdyacencias[j].data.GetPuntoCentral();
						
						//var anguloArista = Agente.GetAngulo(listaAdyacencias[j].data.GetPuntoCentral(),puntoCebo);
						var anguloArista = Agente.GetAngulo(graphNode.data.GetPuntoCentral(),listaAdyacencias[j].data.GetPuntoCentral());
						anguloArista = 360-anguloArista;
						//MessageBox.Show("ANGULO CON RESPECTO AL NODO: "+listaAdyacencias[j].data.GetID()+": "+anguloArista,"ANGULO DEL NODO ACTUAL AL CEBO: "+anguloGraphNode);
						
						//colaAngular.Add(new Pair<Circulo, double>(listaAdyacencias[j].data,anguloArista));
						colaAngular.Add(new Pair<Circulo, double>(listaAdyacencias[j].data,anguloArista));
						colaAngular.Add(new Pair<Circulo, double>(listaAdyacencias[j].data,anguloArista+360));
						
					}
					
					//ordenar la cola:
					
					var circle = OrdenarAngulos(ref colaAngular,a,anguloGraphNode);
					
					//colaAngular.First().firstData.incrementBandera(a);
					return circle.GetPuntoCentral();
				   	
				}
				
			}

			return a.GetPosicion();
			
		}
		
		void DrawNode(Circulo c){
			var graficos = Graphics.FromImage(myBitmap);
			graficos.FillEllipse(new SolidBrush(Color.DarkBlue),c.GetPuntoOeste().X,c.GetPuntoNorte().Y,c.GetRadioHorizontal(),c.GetRadioVertical());
			graficos.Dispose();
			ptbImagen.Refresh();
			
			
		}
	
		void OrdenarListas(ref List<List<Point>> C, ref List<Point> p, ref List<Agente> a){
			
			var min = 0;
			for (int i = 0; i < C.Count; ++i) {
		        min = i;
		        for (int j = i+1; j < C.Count; ++j) {
		        	if(C[j].Count < C[min].Count){
		                min = j;
		            }
		        }
		
		        var intercambio = C[i];
		        C[i] = C[min];
		        C[min] = intercambio;
		        var exchange = p[i];
		        p[i] = p[min];
		       	p[min] = exchange;
		       	var cambeo = a[i];
		       	a[i] = a[min];
		       	a[min] = cambeo;
		    }
		}
				
		public List<Point> GetWay(Point origen, Point destino, int velocidad)
		{
			var Posiciones = new List<Point>();
			var m = Circulo.Pendiente(origen,destino);
	
			var dy = Math.Abs(origen.Y - destino.Y);
			var dx = Math.Abs(origen.X - destino.X);
			
			if(dx >= dy){
			   //y = mx + b	
				
			   if(origen.X <= destino.X){
				   	var puntos = Agente.OrderPoints_By_X(origen,destino);
					var b = Circulo.B(puntos.firstData,m);
					var Xk = puntos.firstData.X;
					var Yk = puntos.firstData.Y;
					double Ysumante = puntos.firstData.Y;
					while(Xk <= puntos.secondData.X){
						Posiciones.Add(new Point(Xk,Yk));
						Ysumante = (m * Xk)+b;
						Yk = Convert.ToInt32(Math.Round(Ysumante));
						Xk+=velocidad;
					}
			   }
			   else{
			   		var puntos = new Pair<Point,Point>(origen,destino);
					var b = Circulo.B(puntos.firstData,m);
					var Xk = puntos.firstData.X;
					var Yk = puntos.firstData.Y;
					double Ysumante = puntos.firstData.Y;
					while(Xk >= puntos.secondData.X){
						Posiciones.Add(new Point(Xk,Yk));
						Ysumante = (m * Xk)+b;
						Yk = Convert.ToInt32(Math.Round(Ysumante));
						Xk-=velocidad;
					}
			   }
			}
			else{
				// x = (y-b)/m
				if(origen.Y <= destino.Y){
					var puntos = Agente.OrderPoints_By_Y(origen,destino);
					var b = Circulo.B(puntos.firstData,m);
					var Xk = puntos.firstData.X;
					var Yk = puntos.firstData.Y;
					double Xsumante = puntos.firstData.X;
					while(Yk <= puntos.secondData.Y){
						Posiciones.Add(new Point(Xk,Yk));
						Xsumante = (m.Equals(0))? puntos.firstData.X : (Yk-b)/m;
						Xk = Convert.ToInt32(Math.Round(Xsumante));
						Yk+=velocidad;
						
					}
				}
				else{
					var puntos = new Pair<Point,Point>(origen,destino);
					var b = Circulo.B(puntos.firstData,m);
					var Xk = puntos.firstData.X;
					var Yk = puntos.firstData.Y;
					double Xsumante = puntos.firstData.X;
					while(Yk >= puntos.secondData.Y){
						Posiciones.Add(new Point(Xk,Yk));
						Xsumante = (m.Equals(0))? puntos.firstData.X : (Yk-b)/m;
						Xk = Convert.ToInt32(Math.Round(Xsumante));
						Yk-=velocidad;
					}
				}

			}
			
			return Posiciones;
		
		}
		
		Graph<Circulo>.GraphNode<Circulo> Get_Node(Agente a){
			//Buscar el vertice que tenga la misma posicion que el agente:
			for(int i = 0; i < myCircleGraph.Size_Nodes();i++){
				if(myCircleGraph[i].data.GetPuntoCentral().Equals(a.GetPosicion())){
					return myCircleGraph[i];
				}
			}
			
			return null;
		}
		void Formulario_De_AnimacionFormClosing(object sender, FormClosingEventArgs e)
		{
			this.Dispose();
		}
		
		List<Graph<Circulo>.GraphNode<Circulo>> ListaAdyacencia(Graph<Circulo>.GraphNode<Circulo> nodo, Agente a){
			var lista = new List<Graph<Circulo>.GraphNode<Circulo>>();
			
			var aux = nodo.adyacentEdge;
			while(aux != null){
				var listaAux = aux.adyacentNode.data.GetAgentesQueMeHanVisitado();
				var seAgrega = true;
				
				for(int i = 0; i < listaAux.Size();i++){
					if(listaAux[i].firstData == a.GetID() && 
					   listaAux[i].secondData == -1
					   || listaAux[i].secondData > 20){
						seAgrega = false;
						break;
					}
				}
				
				if(seAgrega)
					lista.Add(aux.adyacentNode);
				
				aux = aux.nextEdge;
			}
			
			return lista;
		}

		
	}
}
