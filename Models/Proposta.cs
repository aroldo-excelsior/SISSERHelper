/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 26/08/2016
 * Time: 16:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections.Generic;

namespace SISSERHelper.Models
{
	/// <summary>
	/// Description of Proposta.
	/// </summary>
	public class Proposta
	{
		
		
		private int _id;
		private string _dt_proposta;
		private string _nrProposta;
		private string _nmSegurado;
		private long _nrCpfCnpjSegurado;
		private int _autorizacao_usuario;
		private ProgramaSubvencaoApolice _programaSubvencaoApolice;
		
		
		public ProgramaSubvencaoApolice programaSubvencaoApolice{
		
			get{
				
				return Controle.Getinstance().BuscarProgramaSubvencaoApolice(id);
				
			}
			set{_programaSubvencaoApolice = value;}
		}
		
		public Proposta()
		{
			
		}
		
		public int id{
		
			get{return this._id;}
			set{this._id = value;}
			
		}
		
		public int autorizacao_usuario{
		
			get{return this._autorizacao_usuario;}
			set{this._autorizacao_usuario = value;}
			
		}
		
		public string dt_proposta{
		
			get{return this._dt_proposta;}
			set{this._dt_proposta = value;}
			
		}
		
		public string nrProposta{
		
			get{return this._nrProposta;}
			set{this._nrProposta = value;}
			
		}
		
		public long nrCpfCnpjSegurado{
		
			get{return this._nrCpfCnpjSegurado;}
			set{this._nrCpfCnpjSegurado = value;}
			
		}
		
		public string nmSegurado{
		
			get{return this._nmSegurado;}
			set{this._nmSegurado = value;}
			
		}
		
		
		
	}
}
