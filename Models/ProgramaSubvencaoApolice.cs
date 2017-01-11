/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 23/09/2016
 * Time: 14:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SISSERHelper.Models
{
	/// <summary>
	/// Description of ProgramaSubvencaoApolice.
	/// </summary>
	public class ProgramaSubvencaoApolice
	{
		
		private string _cdPropostaSISSER;
		private int _id;
		private int _id_apolice;
		
		
		public int id_apolice{
		
			get{return _id_apolice;}
			set{_id_apolice = value;}
		}
		
		public int id{
		
			get{return _id;}
			set{_id = value;}
		}
		
		
		public string codigo_Proposta_SISSER{
		
			get{return this._cdPropostaSISSER;}
			set{this._cdPropostaSISSER = value;}
			
		}
		
	}
	
	
	
}
