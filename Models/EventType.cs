/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 23/09/2016
 * Time: 14:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SISSERHelper.Models
{
	/// <summary>
	/// Description of EventType.
	/// </summary>
	public class EventType
	{
		private string _descricao;
		private int _id;
		
		
		public int id{
		
			get{return _id;}
			set{_id = value;}
		}
		
		public string descricao{
		
			get{return this._descricao;}
			set{ this._descricao = value;}
			
		}
	}
}
