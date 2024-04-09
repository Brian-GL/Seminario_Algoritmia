/*
 * Creado por SharpDevelop.
 * Usuario: Brian Gaytan Lomeli
 * Fecha: 24/09/2019
 * Hora: 9:21
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Seminario_Algoritmia
{
	/// <summary>
	/// Description of Agente.
	/// </summary>
	public class Agente
	{
		Point posicion;
		int velocidad;
		readonly int iD;

		public Agente(int codigo, Point b, int speed)
		{
			this.posicion = b;
			this.velocidad = speed;
			this.iD = codigo;
		}
		

		public static double GetAngulo(Point a, Point b){
			
			var radianes = Math.Atan2((b.Y-a.Y),(b.X-a.X));
			radianes = radianes*(180/Math.PI);
			
			if(radianes < 0)
				radianes+=360;
			
			
			return radianes;

		}
		
		public void SetVelocidad(int speed)
		{
			velocidad = speed;
		}
		public int GetVelocidad(){
			return velocidad;
		}
		public void SetPosicion(Point p)
		{
			posicion = p;
		}
		public Point GetPosicion(){
			return posicion;
		}

		public static Pair<Point,Point> OrderPoints_By_X(Point first,Point second){
			
			return (first.X <= second.X) ? new Pair<Point,Point>(first,second) : new Pair<Point,Point>(second,first);

		}
		
		public static Pair<Point,Point> OrderPoints_By_Y(Point first,Point second){
			return (first.Y <= second.Y) ? new Pair<Point,Point>(first,second) : new Pair<Point,Point>(second,first);
		}
		
		public int GetID(){
			return iD;
		}
	}

	public class Presa{
	
		readonly int id; //ID de la presa
		Point posicionActual; //Posición actual de la presa
		int resistencia; //Nivel de resistencia de la presa
		Depredador depredadorQueMeAcecha; //El Depredador que me acecha
		Graph<Circulo>.GraphNode<Circulo> verticeOrigen;//Vertice del grafo de donde parte
		Graph<Circulo>.GraphNode<Circulo> verticeDestino; //Vertice del grafo a donde va
		List<Graph<Circulo>.GraphNode<Circulo>> caminoDijkstra; //Camino de vértices del algoritmo Dijkstra que debe de recorrer la presa
		Queue<Point> colaDePuntos; //Representa la lista de puntos los cuales representarán el camino del vertice origen al vertice destino
		bool estaEnPeligro; //define si una presa esta en peligro
		
		public Presa(int code){
			this.resistencia = 150;
			this.id = code;
			colaDePuntos = new Queue<Point>();
			caminoDijkstra = new List<Graph<Circulo>.GraphNode<Circulo>>();
			estaEnPeligro = false;
		}
		~Presa(){
			caminoDijkstra.Clear();
			colaDePuntos.Clear();
		}
		
		public bool LLegoAlDestino(){
			return this.posicionActual.Equals(this.verticeDestino.data.GetPuntoCentral());
		}
		
		public void SetPresaEnPeligro(bool value){
			this.estaEnPeligro = value;
		}
		public bool GetEstaEnPeligro(){
			return estaEnPeligro;
		}
		
		public void ObtenerCamino()
		{
			if(verticeOrigen != null && verticeDestino != null){
				//si el vertice origen y el vertice destino no son nulos, ahora si podremos obtener el camino
				colaDePuntos.Clear();
				Point origen,destino;
				origen = verticeOrigen.data.GetPuntoCentral();
				destino = verticeDestino.data.GetPuntoCentral();
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
							colaDePuntos.Enqueue(new Point(Xk,Yk));
							Ysumante = (m * Xk)+b;
							Yk = Convert.ToInt32(Math.Round(Ysumante));
							Xk+=4;
						}
				   }
				   else{
				   		var puntos = new Pair<Point,Point>(origen,destino);
						var b = Circulo.B(puntos.firstData,m);
						var Xk = puntos.firstData.X;
						var Yk = puntos.firstData.Y;
						double Ysumante = puntos.firstData.Y;
						while(Xk >= puntos.secondData.X){
							colaDePuntos.Enqueue(new Point(Xk,Yk));
							Ysumante = (m * Xk)+b;
							Yk = Convert.ToInt32(Math.Round(Ysumante));
							Xk-=4;
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
							colaDePuntos.Enqueue(new Point(Xk,Yk));
							Xsumante = (m.Equals(0))? puntos.firstData.X : (Yk-b)/m;
							Xk = Convert.ToInt32(Math.Round(Xsumante));
							Yk+=4;
							
						}
					}
					else{
						var puntos = new Pair<Point,Point>(origen,destino);
						var b = Circulo.B(puntos.firstData,m);
						var Xk = puntos.firstData.X;
						var Yk = puntos.firstData.Y;
						double Xsumante = puntos.firstData.X;
						while(Yk >= puntos.secondData.Y){
							colaDePuntos.Enqueue(new Point(Xk,Yk));
							Xsumante = (m.Equals(0))? puntos.firstData.X : (Yk-b)/m;
							Xk = Convert.ToInt32(Math.Round(Xsumante));
							Yk-=4;
						}
					}
				}

			}
		}

		public void ObtenerCaminoDeRegreso()
		{
			
			//si el vertice origen y el vertice destino no son nulos, ahora si podremos obtener el camino
			colaDePuntos.Clear();
			var listaAuxiliar = new Stack<Point>();
			Point origen,destino;
			
			origen = verticeOrigen.data.GetPuntoCentral();
			destino = verticeDestino.data.GetPuntoCentral();
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
					while(Xk <= posicionActual.X){
						listaAuxiliar.Push(new Point(Xk,Yk));
						Ysumante = (m * Xk)+b;
						Yk = Convert.ToInt32(Math.Round(Ysumante));
						Xk+=4;
					}
			   }
			   else{
			   		var puntos = new Pair<Point,Point>(origen,destino);
					var b = Circulo.B(puntos.firstData,m);
					var Xk = puntos.firstData.X;
					var Yk = puntos.firstData.Y;
					double Ysumante = puntos.firstData.Y;
					while(Xk >= posicionActual.X){
						listaAuxiliar.Push(new Point(Xk,Yk));
						Ysumante = (m * Xk)+b;
						Yk = Convert.ToInt32(Math.Round(Ysumante));
						Xk-=4;
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
					while(Yk <= posicionActual.Y){
						listaAuxiliar.Push(new Point(Xk,Yk));
						Xsumante = (m.Equals(0))? puntos.firstData.X : (Yk-b)/m;
						Xk = Convert.ToInt32(Math.Round(Xsumante));
						Yk+=4;
						
					}
				}
				else{
					var puntos = new Pair<Point,Point>(origen,destino);
					var b = Circulo.B(puntos.firstData,m);
					var Xk = puntos.firstData.X;
					var Yk = puntos.firstData.Y;
					double Xsumante = puntos.firstData.X;
					while(Yk >= posicionActual.Y){
						listaAuxiliar.Push(new Point(Xk,Yk));
						Xsumante = (m.Equals(0))? puntos.firstData.X : (Yk-b)/m;
						Xk = Convert.ToInt32(Math.Round(Xsumante));
						Yk-=5;
					}
				}
			}
			
			while(listaAuxiliar.Count != 0)
				colaDePuntos.Enqueue(listaAuxiliar.Pop());
		}
		
		public void AgregarCamino()
		{
			if(verticeOrigen != null && verticeDestino != null){
				//si el vertice origen y el vertice destino no son nulos, ahora si podremos obtener el camino
				Point origen,destino;
				origen = verticeOrigen.data.GetPuntoCentral();
				destino = verticeDestino.data.GetPuntoCentral();
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
							colaDePuntos.Enqueue(new Point(Xk,Yk));
							Ysumante = (m * Xk)+b;
							Yk = Convert.ToInt32(Math.Round(Ysumante));
							Xk+=4;
						}
				   }
				   else{
				   		var puntos = new Pair<Point,Point>(origen,destino);
						var b = Circulo.B(puntos.firstData,m);
						var Xk = puntos.firstData.X;
						var Yk = puntos.firstData.Y;
						double Ysumante = puntos.firstData.Y;
						while(Xk >= puntos.secondData.X){
							colaDePuntos.Enqueue(new Point(Xk,Yk));
							Ysumante = (m * Xk)+b;
							Yk = Convert.ToInt32(Math.Round(Ysumante));
							Xk-=4;
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
							colaDePuntos.Enqueue(new Point(Xk,Yk));
							Xsumante = (m.Equals(0))? puntos.firstData.X : (Yk-b)/m;
							Xk = Convert.ToInt32(Math.Round(Xsumante));
							Yk+=4;
							
						}
					}
					else{
						var puntos = new Pair<Point,Point>(origen,destino);
						var b = Circulo.B(puntos.firstData,m);
						var Xk = puntos.firstData.X;
						var Yk = puntos.firstData.Y;
						double Xsumante = puntos.firstData.X;
						while(Yk >= puntos.secondData.Y){
							colaDePuntos.Enqueue(new Point(Xk,Yk));
							Xsumante = (m.Equals(0))? puntos.firstData.X : (Yk-b)/m;
							Xk = Convert.ToInt32(Math.Round(Xsumante));
							Yk-=4;
						}
					}
				}

			}
		}
		
		public void Caminar(){
			if(colaDePuntos.Count != 0)
				posicionActual = colaDePuntos.Dequeue();
		}
		public void RemoverPrimerVerticeDelCaminoDeDijkstra(){
			if(caminoDijkstra.Count != 0){
				caminoDijkstra.RemoveAt(0);
				if(caminoDijkstra.Count != 0){
					verticeOrigen = verticeDestino;
					verticeDestino = caminoDijkstra[0];
				}
				//Aqui, además de eliminar podemos asignar el nuevo vertice destino y origen
			}
		}
		public bool CaminoDeDijkstraVacio(){
			return caminoDijkstra.Count == 0;
		}
		public Queue<Point> GetListaDePuntos(){
			return colaDePuntos;
		}
		public void SetDepredadorMeSigue(Depredador d){
			this.depredadorQueMeAcecha = d;
		}
		public Depredador GetDepredadorMeSigue(){
			return depredadorQueMeAcecha;
		}
		public void SetPosicionActual(Point p){
			this.posicionActual = p;
		}
		public void SetCaminoDijkstra(List<Graph<Circulo>.GraphNode<Circulo>> list){
			this.caminoDijkstra = list;
		}
		public List<Graph<Circulo>.GraphNode<Circulo>> GetCaminoDijsktra(){
			return caminoDijkstra;
		}
		public void SetVerticeOrigen(Graph<Circulo>.GraphNode<Circulo> id){
			this.verticeOrigen = id;
			this.posicionActual = id.data.GetPuntoCentral();
		}
		public void SetVerticeDestino(Graph<Circulo>.GraphNode<Circulo> id){
			this.verticeDestino = id;
		}
		public void SetResistencia(int res){
			this.resistencia = res;
		}
		public void AumentarResistencia(){
			this.resistencia = this.resistencia+1;
		}
		public void DisminuirResistencia(){
			this.resistencia = this.resistencia-1;
		}
		public int GetID(){
			return id;
		}
		public int GetResistencia(){
			return resistencia;
		}
		public Graph<Circulo>.GraphNode<Circulo> GetVerticeOrigen(){
			return verticeOrigen;
		}
		public Graph<Circulo>.GraphNode<Circulo> GetVerticeDestino(){
			return verticeDestino;
		}
		public Point GetPosicionActual(){
			return posicionActual;
		}
		
		#region Equals and GetHashCode implementation
		public override bool Equals(object obj)
		{
			var other = obj as Presa;
				if (other == null)
					return false;
				return this.id == other.id;
		}

		public override int GetHashCode()
		{
			int hashCode = 0;
			unchecked {
				hashCode += 1000000007 * id.GetHashCode();
				// disable once NonReadonlyReferencedInGetHashCode
				hashCode += 1000000009 * posicionActual.GetHashCode();
				// disable once NonReadonlyReferencedInGetHashCode
				hashCode += 1000000021 * resistencia.GetHashCode();
			}
			return hashCode;
		}

		public static bool operator ==(Presa lhs, Presa rhs) {
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}

		public static bool operator !=(Presa lhs, Presa rhs) {
			return !(lhs == rhs);
		}

		#endregion
	}

	public class Depredador{
		readonly int iD; //ID del depredador
		Point posicionActual; //posicion actual del depredador
		int velocidad; //velocidad del depredador
		Presa presaASeguir; //presa a acechar
		Graph<Circulo>.GraphNode<Circulo> verticeOrigen; //vertice del grafo donde comienza a moverse
		Graph<Circulo>.GraphNode<Circulo> verticeDestino; //vertice del grafo a donde se quiere llegar
		List<Point> colaDePixeles; //Representarán todos los puntos que existan entre el vertice origen y el vertice destino
		
		public Depredador(int codigo){
			this.iD = codigo;
			this.velocidad = 4;
			colaDePixeles = new List<Point>();
		}
		~Depredador(){
			colaDePixeles.Clear();
		}
		
		
		public void ObtenerCamino()
		{
			if(verticeOrigen != null && verticeDestino != null){
				//si el vertice origen y el vertice destino no son nulos, ahora si podremos obtener el camino
				colaDePixeles.Clear();
				Point origen,destino;
				origen = verticeOrigen.data.GetPuntoCentral();
				destino = verticeDestino.data.GetPuntoCentral();
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
							colaDePixeles.Add(new Point(Xk,Yk));
							Ysumante = (m * Xk)+b;
							Yk = Convert.ToInt32(Math.Round(Ysumante));
							Xk++;
						}
				   }
				   else{
				   		var puntos = new Pair<Point,Point>(origen,destino);
						var b = Circulo.B(puntos.firstData,m);
						var Xk = puntos.firstData.X;
						var Yk = puntos.firstData.Y;
						double Ysumante = puntos.firstData.Y;
						while(Xk >= puntos.secondData.X){
							colaDePixeles.Add(new Point(Xk,Yk));
							Ysumante = (m * Xk)+b;
							Yk = Convert.ToInt32(Math.Round(Ysumante));
							Xk--;
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
							colaDePixeles.Add(new Point(Xk,Yk));
							Xsumante = (m.Equals(0))? puntos.firstData.X : (Yk-b)/m;
							Xk = Convert.ToInt32(Math.Round(Xsumante));
							Yk++;
							
						}
					}
					else{
						var puntos = new Pair<Point,Point>(origen,destino);
						var b = Circulo.B(puntos.firstData,m);
						var Xk = puntos.firstData.X;
						var Yk = puntos.firstData.Y;
						double Xsumante = puntos.firstData.X;
						while(Yk >= puntos.secondData.Y){
							colaDePixeles.Add(new Point(Xk,Yk));
							Xsumante = (m.Equals(0))? puntos.firstData.X : (Yk-b)/m;
							Xk = Convert.ToInt32(Math.Round(Xsumante));
							Yk--;
						}
					}
	
				}

			}
		}
		
		public void Caminar()
		{
			
			var origen = this.posicionActual;
			var destino = this.verticeDestino.data.GetPuntoCentral();
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
					if(Xk < puntos.secondData.X){
						Ysumante = (m * Xk)+b;
						Yk = Convert.ToInt32(Math.Round(Ysumante));
						Xk+=velocidad;
						posicionActual = new Point(Xk,Yk);
					}else{
						posicionActual = destino;
					}
			   }
			   else{
			   		var puntos = new Pair<Point,Point>(origen,destino);
					var b = Circulo.B(puntos.firstData,m);
					var Xk = puntos.firstData.X;
					var Yk = puntos.firstData.Y;
					double Ysumante = puntos.firstData.Y;
					if(Xk < puntos.secondData.X){
						Ysumante = (m * Xk)+b;
						Yk = Convert.ToInt32(Math.Round(Ysumante));
						Xk-=velocidad;
						posicionActual = new Point(Xk,Yk);
					}else{
						posicionActual = destino;
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
					if(Yk < puntos.secondData.Y){
						Xsumante = (m.Equals(0))? puntos.firstData.X : (Yk-b)/m;
						Xk = Convert.ToInt32(Math.Round(Xsumante));
						Yk+=velocidad;
						posicionActual = new Point(Xk,Yk);
						
					}else{
						posicionActual = destino;
					}
				}
				else{
					var puntos = new Pair<Point,Point>(origen,destino);
					var b = Circulo.B(puntos.firstData,m);
					var Xk = puntos.firstData.X;
					var Yk = puntos.firstData.Y;
					double Xsumante = puntos.firstData.X;
					if(Yk < puntos.secondData.Y){
						Xsumante = (m.Equals(0))? puntos.firstData.X : (Yk-b)/m;
						Xk = Convert.ToInt32(Math.Round(Xsumante));
						Yk-=velocidad;
						posicionActual = new Point(Xk,Yk);
						
					}else{
						posicionActual = destino;
					}
				}

			}
			
		}
		
		public void RemoverPrimerPunto(){
			if(colaDePixeles.Count != 0)
				colaDePixeles.RemoveAt(0);
		}
		
		public void SetVerticeOrigen(Graph<Circulo>.GraphNode<Circulo> nodo){
			this.verticeOrigen = nodo;
			this.posicionActual = nodo.data.GetPuntoCentral();
		}
		public Graph<Circulo>.GraphNode<Circulo> GetVerticeOrigen(){
			return verticeOrigen;
		}
		public void SetVerticeDestino(Graph<Circulo>.GraphNode<Circulo> nodo){
			this.verticeDestino = nodo;
		}
		public Graph<Circulo>.GraphNode<Circulo> GetVerticeDestino(){
			return verticeDestino;
		}
		public List<Point> GetListaDePuntos(){
			return colaDePixeles;
		}
		public static double GetAngulo(Point a, Point b){
			var radianes = Math.Atan2((b.Y-a.Y),(b.X-a.X));
			radianes = radianes*(180/Math.PI);
			if(radianes < 0)
				radianes+=360;
			return radianes;
		}
		
		public void SetVelocidad(int speed){
			velocidad = speed;
		}
		public int GetVelocidad(){
			return velocidad;
		}
		public void SetPosicionActual(Point p){
			posicionActual = p;
		}
		public Point GetPosicionActual(){
			return posicionActual;
		}
		public void SetPresaASeguir(Presa i){
			this.presaASeguir = i;
		}
		public Presa GetPresaASeguir(){
			return presaASeguir;
		}
		public int GetID(){
			return iD;
		}
		
		#region Equals and GetHashCode implementation
		public override bool Equals(object obj)
		{
			var other = obj as Depredador;
				if (other == null)
					return false;
				return this.iD == other.iD;
		}

		public override int GetHashCode()
		{
			int hashCode = 0;
			unchecked {
				hashCode += 1000000007 * posicionActual.GetHashCode();
				hashCode += 1000000009 * velocidad.GetHashCode();
				hashCode += 1000000021 * iD.GetHashCode();
			}
			return hashCode;
		}

		public static bool operator ==(Depredador lhs, Depredador rhs) {
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}

		public static bool operator !=(Depredador lhs, Depredador rhs) {
			return !(lhs == rhs);
		}

		#endregion
		
	}

}
