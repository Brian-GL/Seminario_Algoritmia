/*
 * Created by SharpDevelop.
 * User: Usuario
 * Date: 21/08/2019
 * Time: 01:29 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Seminario_Algoritmia
{
	/// <summary>
	/// Description of Circulo.
	/// </summary>
	public class Circulo
	{
		private Point puntoCentral;
		private Point puntoNorte;
		private Point puntoSur;
		private Point puntoEste;
		private Point puntoOeste;
		private Double_List<int,int> agentesQueMeHanVisitado;
		private int myId;
		
		public Circulo()
		{
			puntoCentral = new Point();
			puntoNorte = new Point();
			puntoEste = new Point();
			puntoOeste = new Point();
			puntoSur = new Point();
			agentesQueMeHanVisitado = new Double_List<int,int>();
		}
		
		public void SetID(int value){
			myId = value;
		}
		public int GetID(){
			return myId;
		}
		
		public void SetAgenteQueMeHaVisitado(int idAgente, int contador){
			agentesQueMeHanVisitado.Push_Back(idAgente,contador);
		}
		
		public Double_List<int,int> GetAgentesQueMeHanVisitado(){
			return agentesQueMeHanVisitado;
		}
		public void setBandera(Agente a, int bandera){
			for(int i = 0; i < agentesQueMeHanVisitado.Size();i++){
				if(agentesQueMeHanVisitado[i].firstData == a.GetID()){
					agentesQueMeHanVisitado[i].secondData = bandera;
					break;
				}
			}
		}
		public void setBandera(int a, int bandera){
			for(int i = 0; i < agentesQueMeHanVisitado.Size();i++){
				if(agentesQueMeHanVisitado[i].firstData == a){
					agentesQueMeHanVisitado[i].secondData = bandera;
					break;
				}
			}
		}
		
		public int getBandera(Agente a){
			for(int i = 0; i < agentesQueMeHanVisitado.Size();i++){
				if(agentesQueMeHanVisitado[i].firstData == a.GetID()){
					return agentesQueMeHanVisitado[i].secondData;
				}
			}
			return -2;
		}
		public int getBandera(int a){
			for(int i = 0; i < agentesQueMeHanVisitado.Size();i++){
				if(agentesQueMeHanVisitado[i].firstData == a){
					return agentesQueMeHanVisitado[i].secondData;
				}
			}
			return -2;
		}

		public void incrementBandera(Agente a){
			for(int i = 0; i < agentesQueMeHanVisitado.Size();i++){
				if(agentesQueMeHanVisitado[i].firstData == a.GetID()){
					agentesQueMeHanVisitado[i].secondData = agentesQueMeHanVisitado[i].secondData + 1;
				}
			}
			
		}
		public void incrementBandera(int a){
			for(int i = 0; i < agentesQueMeHanVisitado.Size();i++){
				if(agentesQueMeHanVisitado[i].firstData == a){
					agentesQueMeHanVisitado[i].secondData = agentesQueMeHanVisitado[i].secondData + 1;
				}
			}
			
		}
		
		public void SetPuntoCentral(int x, int y){
			puntoCentral.X = x;
			puntoCentral.Y = y;
		}

		public void SetPuntoNorte(int x, int y){
			puntoNorte.X = x;
			puntoNorte.Y = y;
		}

		public void SetPuntoSur(int x, int y){
			puntoSur.X = x;
			puntoSur.Y = y;
		}

		public void SetPuntoEste(int x, int y){
			puntoEste.X = x;
			puntoEste.Y = y;
		}
		
		public void SetPuntoOeste(int x, int y){
			puntoOeste.X = x;
			puntoOeste.Y = y;
		}
		
		public Point GetPuntoCentral(){
			return puntoCentral;
		}
		public Point GetPuntoNorte(){
			return puntoNorte;
		}
		public Point GetPuntoSur(){
			return puntoSur;
		}
		public Point GetPuntoEste(){
			return puntoEste;
		}
		public Point GetPuntoOeste(){
			return puntoOeste;
		}

		public static double Distance(Point a,Point b){
			double retorno = 0;
			retorno = Math.Pow((b.X-a.X),2);
			retorno = retorno + Math.Pow(a.Y-b.Y,2);
			return Math.Sqrt(retorno);
		}
		
		public static int Distancia(Point a,Point b){
			int retorno = 0;
			retorno = Convert.ToInt32(Math.Pow((b.X-a.X),2));
			retorno = Convert.ToInt32(retorno + Math.Pow(a.Y-b.Y,2));
			return Convert.ToInt32(Math.Sqrt(retorno));
		}
		
		public void ClearAgentesQueMeHanVisitado(){
			this.GetAgentesQueMeHanVisitado().Clear();
		}
		
		public bool IsCircle(){
			
			if(this.GetRadioHorizontal() < 3 || GetRadioVertical() < 3) return false;
			
			var lista = new List<int>();
			
			lista.Add(GetRadioVertical());
			lista.Add(GetRadioHorizontal());

			//buscamos el menor de la lista:
			
			lista.Sort();

			var retorno = true;
			//revisar que no sobrepase al menor valor 10 pixeles.
			for(int i = 1; i < lista.Count;i++){
				if(lista.First()+10 < lista[i]){
					retorno = false;
					break;
				}
			}
			
			lista.Clear();
			
			return retorno;
					
		}
		
		public static double Pendiente(Point a, Point b){
			double dx = a.X-b.X;
			double dy = a.Y-b.Y;
			
			if(dx.Equals(0) ||  dy.Equals(0))
				return 0;
			
			
			return dy/dx;

		}

		public int GetRadioNorte(){
			return Convert.ToInt32(Distance(GetPuntoNorte(),GetPuntoCentral()));
		}
		public int GetRadioSur(){
			return Convert.ToInt32(Distance(GetPuntoSur(),GetPuntoCentral()));
		}
		public int GetRadioEste(){
			return Convert.ToInt32(Distance(GetPuntoEste(),GetPuntoCentral()));
		}
		public int GetRadioOeste(){
			return Convert.ToInt32(Distance(GetPuntoOeste(),GetPuntoCentral()));
		}
		public int GetRadioVertical(){
			return GetRadioNorte() + GetRadioSur();
		}
		public int GetRadioHorizontal(){
			return GetRadioEste() + GetRadioOeste();
		}
		
		public bool IsInTheRadio(double distancia){
			
			return distancia <= this.GetRadioHorizontal()
				|| distancia <= this.GetRadioVertical();
		}
		
		public static bool IsGoodColor(Color c,Point p, Circulo circle1, Circulo circle2){

			
			if(c.R == 30 && c.G == 144 && c.B == 255)  //BLUE LINE
				return true;

			if(c.R == 0 && c.G == 128 && c.B == 0){
				//GREEN

				var distance_center_one = Distance(p,circle1.GetPuntoCentral());
				var distance_center_two = Distance(p,circle2.GetPuntoCentral());
				
				if(circle1.IsInTheRadio(distance_center_one)) return  true;
				if(circle2.IsInTheRadio(distance_center_two)) return  true;
				
			}
				
			if(c.R >= 250 && c.G >= 250 && c.B >= 250) //White tone
				return true;
			

			return false;	
		}
		
		
		public static double B(Point a, double pendiente){
			//y = mx + b;
			//b = y - mx;
			
			return a.Y - (pendiente * a.X);
			
		}
		
		//x = (y-b/m)
		
		public decimal VerticalRatio(){
			return (GetRadioNorte() + GetRadioSur())/2;
		}
		
		public decimal HorizontalRatio(){
			return (GetRadioOeste() + GetRadioEste())/2;
		}
		
		#region Equals and GetHashCode implementation
		public override bool Equals(object obj)
		{
			var other = obj as Circulo;
				if (other == null)
					return false;
				return this.GetPuntoCentral().Equals(other.GetPuntoCentral()) && this.GetID() == other.GetID();
		}

		public override int GetHashCode()
		{
			int hashCode = 0;
			unchecked {
				hashCode += 1000000007 * puntoCentral.GetHashCode();
				hashCode += 1000000009 * puntoNorte.GetHashCode();
				hashCode += 1000000021 * puntoSur.GetHashCode();
				hashCode += 1000000033 * puntoEste.GetHashCode();
				hashCode += 1000000087 * puntoOeste.GetHashCode();
				if (agentesQueMeHanVisitado != null)
					hashCode += 1000000093 * agentesQueMeHanVisitado.GetHashCode();
				hashCode += 1000000097 * myId.GetHashCode();
			}
			return hashCode;
		}

		public static bool operator ==(Circulo lhs, Circulo rhs) {
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}

		public static bool operator !=(Circulo lhs, Circulo rhs) {
			return !(lhs == rhs);
		}

		#endregion

		public override string ToString()
		{
			return this.GetID().ToString();
		}
	}
	
	
	public class ComparadorDeCirculos:IComparer<Circulo>
	{
		public int Compare(Circulo c1,Circulo c2){
			return c1.GetID().CompareTo(c2.GetID());
		}
		
	}
	
}
