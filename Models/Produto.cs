/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 30/09/2016
 * Time: 11:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SISSERHelper.Models
{
	/// <summary>
	/// Description of Produto.
	/// </summary>
	public class Produto
	{
		
		private string _descricao;
		private int _cod_Produto_SoftwareOrigem;
		private int _id;
		
		
		
		public int id{
		
			get{return _id;}
			set{_id = value;}
			
		}
		
		
		public string descricao{
		
			get{return _descricao;}
			set{_descricao = value;}
		
		}
		
		public int cod_Produto_SoftwareOrigem{
		
			get{return _cod_Produto_SoftwareOrigem;}
			set{_cod_Produto_SoftwareOrigem = value;}
			
		}
		
		public Produto()
		{
			
			
		}
	}
}
