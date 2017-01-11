/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 26/08/2016
 * Time: 16:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;


namespace SISSERHelper.Models
{
	/// <summary>
	/// Description of EventLog.
	/// </summary>
	public class EventLog
	{
		public EventLog()
		{
			
		}
		
		
		private int _Sequencia;
		private int _id; 
		private	string _Description;
		private string _Args;
		private string _MessageError;
		private string _StackTrace;
		private int _IDApolice; 
		private string _dt_rgs_insercao;
		private int _id_eventType;
		private EventType _eventType;
		
		public EventType eventType{
			
			get{
				return Controle.Getinstance().BuscarEventType(id_eventType);
			}
			set{_eventType = value;}
			
		}
		
		public int id_eventType{
		
			get{return this._id_eventType;}
			set{this._id_eventType = value;}
			
		}
		
		public string dt_rgs_insercao{
		
			get{return this._dt_rgs_insercao;}
			set{this._dt_rgs_insercao = value;}
			
		}
		
		public int id{
			
			get{return this._id;}
			set{this._id = value;}	
			
		}
		
		public int sequencia{
		
			get{return this._Sequencia;}
			set{this._Sequencia = value;}
			
		}
		
		public int iDApolice{
		
			get{return this._IDApolice;}
			set{this._IDApolice = value;}
			
		}
		
	
		public string descricao{
		
			get{return this._Description;}
			set{this._Description = value;}
		}
		
		public string argumento{
		
			get{return _Args;}
			set{this._Args = value;}
		}
		
		public string message_De_Erro{
		
			get{return this._MessageError;}
			set{this._MessageError = value;}
			
		}
		
		public string stack_Trace{
		
			get{return this._StackTrace;}
			set{this._StackTrace = value;}
		}
		
		
		
	}
}
