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
	/// Description of ProgramaSubvencao.
	/// </summary>
	public class ProgramaSubvencao
	{
		
		private int _id;
		private string _cod_Programa_Subvencao;
		private string _descricao;
		
		
		public string cod_Programa_Subvecao{
		
			get{return _cod_Programa_Subvencao;}
			set{_cod_Programa_Subvencao = value;}
			
		}
		
		public string descricao{
		
			get{return _descricao;}
			set{_descricao = value;}
			
		}
		
		
		public int id{
		
			get{return _id;}
			set{_id = value;}
			
		}
		
		public string id_descrcao{
			
			get{return _id+" - "+_descricao;}
		
		}
		
		public ProgramaSubvencao()
		{
		}
	}
}
