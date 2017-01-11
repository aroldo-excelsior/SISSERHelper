/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 29/09/2016
 * Time: 16:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SISSERHelper.Models
{
	/// <summary>
	/// Description of Bacen.
	/// </summary>
	public class Bacen
	{
		
		private int _id;
		private string _descricao;
		
		public int id{
		
			get{return _id;}
			set{_id = value;}
			
		}
		
		public string descricao{
		
			get{return _descricao;}
			set{_descricao = value;}
			
		}
		
		public Bacen(){
			
			
			
		}
	}
}
