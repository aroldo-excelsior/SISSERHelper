/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 29/09/2016
 * Time: 16:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SISSERHelper.Interfaces;
using SISSERHelper.Models;
using System.Data.SqlClient;
using SISSERHelper.Enums;
using System.Collections.Generic;

namespace SISSERHelper.Repositorios
{
	/// <summary>
	/// Description of RepositorioPerfilEnvioProgramaSubvencao.
	/// </summary>
	public class RepositorioPerfilEnvioProgramaSubvencao : InterfacePerfilEnvioProgramaSubvencao
	{
		
		AppConfiguration appConfig = new AppConfiguration();
		
		
		
		
		
		public PerfilEnvioProgramaSubvencao getPerfilEnvioProgramaSubvencaoById(int id_perfEnvProSub){
		
			PerfilEnvioProgramaSubvencao perfenv = new PerfilEnvioProgramaSubvencao();
			
			SqlConnection conn = new SqlConnection(appConfig.getStrDataBase());
			conn.Open();
			
		    string sql = "select "+
							"pep.id,  "+
							"pep.descricao, "+
							"pep.id_programa_subvencao, "+
							"pep.dt_inicio_vigencia_perfil, "+
							"pep.dt_final_vigencia_perfil, "+
							"pep.peNivelCoberturaMinimo, "+
							"pep.peNivelCoberturaMaximo, "+
							"pep.cdClassificacaoProduto, "+
							"pep.id_AtividadeBacen, "+
							"pep.dt_inicio_vigencia_proposta, "+
							"pep.dt_final_vigencia_proposta, "+
		    				"pep.dt_rgs_insercao "+
						"from  "+
							"EXCD_PerfilEnvioProgramaSubvencao as pep "+
		    	"where id = "+ id_perfEnvProSub;
		    
		    SqlCommand command = new SqlCommand(sql,conn);
		    
		    SqlDataReader ler = command.ExecuteReader();
		    
		    try{
		    
		    	if(ler.HasRows){
		    	
		    		while(ler.Read()){
		    		
		    			if(!ler.IsDBNull(0))perfenv.id = ler.GetInt32(0); else perfenv.id = 0;
		    			if(!ler.IsDBNull(1))perfenv.descricao = ler.GetString(1);else perfenv.descricao = "Não Apresenta";
		    			if(!ler.IsDBNull(2))perfenv.id_programa_subvencao= ler.GetInt32(2);else perfenv.id_programa_subvencao = 0;
		    			if(!ler.IsDBNull(3))perfenv.dt_inicio_vigencia_perfil = ler.GetDateTime(3).ToString("yyyy-MM-dd hh:mm:ss.fff");else perfenv.dt_inicio_vigencia_perfil = "0000-00-00 00:00:00.000";
		    			if(!ler.IsDBNull(4))perfenv.dt_final_vigencia_perfil = ler.GetDateTime(4).ToString("yyyy-MM-dd hh:mm:ss.fff");else perfenv.dt_final_vigencia_perfil = "0000-00-00 00:00:00.000";
		    			if(!ler.IsDBNull(5))perfenv.peNivelCoberturaMinimo = ler.GetInt32(5);else perfenv.peNivelCoberturaMinimo = 0;
		    			if(!ler.IsDBNull(6))perfenv.peNivelCoberturaMaximo = ler.GetInt32(6);else perfenv.peNivelCoberturaMaximo = 0;
		    			if(!ler.IsDBNull(7))perfenv.cdClassificacaoProduto = ler.GetInt32(7);else perfenv.cdClassificacaoProduto = 0;
		    			if(!ler.IsDBNull(8))perfenv.id_atividadeBacen = ler.GetInt32(8);else perfenv.id_atividadeBacen = 0;
		    			if(!ler.IsDBNull(9))perfenv.dt_inicio_vigencia_proposta = ler.GetDateTime(9).ToString("yyyy-MM-dd hh:mm:ss.fff");else perfenv.dt_inicio_vigencia_proposta = "0000-00-00 00:00:00.000";
		    			if(!ler.IsDBNull(10))perfenv.dt_final_vigencia_proposta = ler.GetDateTime(10).ToString("yyyy-MM-dd hh:mm:ss.fff");else perfenv.dt_final_vigencia_proposta = "0000-00-00 00:00:00.000";
		    			if(!ler.IsDBNull(11))perfenv.dt_rgs_insercao = ler.GetDateTime(11).ToString("yyyy-MM-dd hh:mm:ss.fff");else perfenv.dt_rgs_insercao = "0000-00-00 00:00:00.000";
		    			
		    		}
		    	
		    		
		    	}
		    
		    	
		    	
		    }catch(SqlException e){
		    
		    	Controle.Getinstance().writeLog(e.StackTrace);
				Controle.Getinstance().writeLog(e.Message);
				Controle.Getinstance().writeLog(sql);
		    	
		    }finally{
		    
		    	ler.Close();
		    	conn.Close();	
		    }
		    
		    
		    return perfenv;
			
			
		}
		
		public List<PerfilEnvioProgramaSubvencao> getPerfilsByDate(DateTime dataini, DateTime datafin){
		
			
			List<PerfilEnvioProgramaSubvencao> perfis = getPerfils();
			List<PerfilEnvioProgramaSubvencao> returperfis = new List<PerfilEnvioProgramaSubvencao>();
			
			
			
			foreach(var p in perfis){
				
				//Controle.Getinstance().writeLog("Perfis: "+perfis.Count+" ini: "+dataini.ToShortDateString()+" pini: "+DateTime.Parse(p.dt_inicio_vigencia_perfil)+" Fin: "+datafin.ToShortDateString()+" pFin: "+DateTime.Parse(p.dt_final_vigencia_perfil));
				
				if(dataini.CompareTo(DateTime.Parse(p.dt_inicio_vigencia_perfil)) <= 0  && datafin.CompareTo(DateTime.Parse(p.dt_final_vigencia_perfil)) >= 0){
				
					returperfis.Add(p);
					
				}
			}
			
			return returperfis;
			
		}
		
		
		
		public List<PerfilEnvioProgramaSubvencao> getPerfils(){
		
			List<PerfilEnvioProgramaSubvencao> lperfenv = new List<PerfilEnvioProgramaSubvencao>();
			
			SqlConnection conn = new SqlConnection(appConfig.getStrDataBase());
			conn.Open();
			
		    string sql = "select "+
							"pep.id,  "+
							"pep.descricao, "+
							"pep.id_programa_subvencao, "+
							"pep.dt_inicio_vigencia_perfil, "+
							"pep.dt_final_vigencia_perfil, "+
							"pep.peNivelCoberturaMinimo, "+
							"pep.peNivelCoberturaMaximo, "+
							"pep.cdClassificacaoProduto, "+
							"pep.id_AtividadeBacen, "+
							"pep.dt_inicio_vigencia_proposta, "+
							"pep.dt_final_vigencia_proposta, "+
		    				"pep.dt_rgs_insercao "+
						"from  "+
		    				"EXCD_PerfilEnvioProgramaSubvencao as pep ";
		    	
		    
		    SqlCommand command = new SqlCommand(sql,conn);
		    
		    SqlDataReader ler = null;
		    
		    try{
		    	ler = command.ExecuteReader();
		    	if(ler.HasRows){
		    	
		    		while(ler.Read()){
		    		
		    			PerfilEnvioProgramaSubvencao perfenv = new PerfilEnvioProgramaSubvencao();
		    			
		    			if(!ler.IsDBNull(0))perfenv.id = ler.GetInt32(0); else perfenv.id = 0;
		    			if(!ler.IsDBNull(1))perfenv.descricao = ler.GetString(1);else perfenv.descricao = "Não Apresenta";
		    			if(!ler.IsDBNull(2))perfenv.id_programa_subvencao= ler.GetInt32(2);else perfenv.id_programa_subvencao = 0;
		    			if(!ler.IsDBNull(3))perfenv.dt_inicio_vigencia_perfil = ler.GetDateTime(3).ToString("dd-MM-yyyy hh:mm:ss.fff");else perfenv.dt_inicio_vigencia_perfil = "0000-00-00 00:00:00.000";
		    			if(!ler.IsDBNull(4))perfenv.dt_final_vigencia_perfil = ler.GetDateTime(4).ToString("dd-MM-yyyy hh:mm:ss.fff");else perfenv.dt_final_vigencia_perfil = "0000-00-00 00:00:00.000";
		    			if(!ler.IsDBNull(5))perfenv.peNivelCoberturaMinimo = ler.GetInt32(5);else perfenv.peNivelCoberturaMinimo = 0;
		    			if(!ler.IsDBNull(6))perfenv.peNivelCoberturaMaximo = ler.GetInt32(6);else perfenv.peNivelCoberturaMaximo = 0;
		    			if(!ler.IsDBNull(7))perfenv.cdClassificacaoProduto = ler.GetInt32(7);else perfenv.cdClassificacaoProduto = 0;
		    			if(!ler.IsDBNull(8))perfenv.id_atividadeBacen = ler.GetInt32(8);else perfenv.id_atividadeBacen = 0;
		    			if(!ler.IsDBNull(9))perfenv.dt_inicio_vigencia_proposta = ler.GetDateTime(9).ToString("dd-MM-yyyy hh:mm:ss.fff");else perfenv.dt_inicio_vigencia_proposta = "0000-00-00 00:00:00.000";
		    			if(!ler.IsDBNull(10))perfenv.dt_final_vigencia_proposta = ler.GetDateTime(10).ToString("dd-MM-yyyy hh:mm:ss.fff");else perfenv.dt_final_vigencia_proposta = "0000-00-00 00:00:00.000";
		    			if(!ler.IsDBNull(11))perfenv.dt_rgs_insercao = ler.GetDateTime(11).ToString("dd-MM-yyyy hh:mm:ss.fff");else perfenv.dt_rgs_insercao = "0000-00-00 00:00:00.000";
		    			
		    			lperfenv.Add(perfenv);
		    			
		    		}
		    	
		    		
		    	}
		    
		    	
		    	
		    }catch(SqlException e){
		    
		    	Controle.Getinstance().writeLog(e.StackTrace);
				Controle.Getinstance().writeLog(e.Message);
				Controle.Getinstance().writeLog(sql);
		    	
		    }finally{
		    
		    	conn.Close();	
		    }
		    
		    
		    return lperfenv;
			
			
		}
		
		public Boolean PerfildescricaoExists(string descricao){
		
			SqlConnection conn = new SqlConnection(appConfig.getStrDataBase());
			
			string sql = "select descricao from EXCD_PerfilEnvioProgramaSubvencao where descricao = '"+descricao+"' ";
			conn.Open();
			
			SqlCommand command = new SqlCommand(sql,conn);
			
			SqlDataReader ler = command.ExecuteReader();
			
			if(ler.HasRows){
			
				return true;
			}else{
				return false;
			}
		}
		
		public EnumInserted InsertPerfilEnvioProgramaSubvencao(PerfilEnvioProgramaSubvencao perfenvprosub){
		
			PerfilEnvioProgramaSubvencao perfenv = perfenvprosub;
			
			int ret = 99;
			
			SqlConnection conn = new SqlConnection(appConfig.getStrDataBase());
			
		    string sql = "insert into EXCD_PerfilEnvioProgramaSubvencao ( "+
							"pep.descricao, "+
							"pep.id_programa_subvencao, "+
							"pep.dt_inicio_vigencia_perfil, "+
							"pep.dt_final_vigencia_perfil, "+
							"pep.peNivelCoberturaMinimo, "+
							"pep.peNivelCoberturaMaximo, "+
							"pep.cdClassificacaoProduto, "+
							"pep.id_AtividadeBacen, "+
							"pep.dt_inicio_vigencia_proposta, "+
							"pep.dt_final_vigencia_proposta,status) "+
						" values "+
							" (@descricao,"+
		    				"@id_programa_subvencao,"+
		    				"@dt_inicio_vigencia_perfil,"+
		    				"@dt_final_vigencia_perfil,"+
		    				"@peNivelCoberturaMinimo,"+
		    				"@peNivelCoberturaMaximo,"+
		    				"@cdClassificacaoProduto,"+
		    				"@id_AtividadeBacen,"+
		    				"@dt_inicio_vigencia_proposta,"+
		    				"@dt_final_vigencia_proposta,1)";
		    conn.Open();
		    SqlCommand command = new SqlCommand(sql,conn);
		    
		    
		    
		    command.Parameters.AddWithValue("@descricao",perfenv.descricao);
		    command.Parameters.AddWithValue("@id_programa_subvencao",perfenv.id_programa_subvencao);
		    command.Parameters.AddWithValue("@dt_inicio_vigencia_perfil",DateTime.Parse(perfenv.dt_inicio_vigencia_perfil).ToString("yyyyMMdd"));
		    command.Parameters.AddWithValue("@dt_final_vigencia_perfil",DateTime.Parse(perfenv.dt_final_vigencia_perfil).ToString("yyyyMMdd"));
		    command.Parameters.AddWithValue("@peNivelCoberturaMinimo",perfenv.peNivelCoberturaMinimo);
		    command.Parameters.AddWithValue("@peNivelCoberturaMaximo",perfenv.peNivelCoberturaMaximo);
		    command.Parameters.AddWithValue("@cdClassificacaoProduto",perfenv.cdClassificacaoProduto);
		    command.Parameters.AddWithValue("@id_AtividadeBacen",perfenv.id_atividadeBacen);
		    command.Parameters.AddWithValue("@dt_inicio_vigencia_proposta",DateTime.Parse(perfenv.dt_inicio_vigencia_proposta).ToString("yyyyMMdd"));
		    command.Parameters.AddWithValue("@dt_final_vigencia_proposta",DateTime.Parse(perfenv.dt_final_vigencia_proposta).ToString("yyyyMMdd"));
		   
		    
		    try{
		    
		    	ret = command.ExecuteNonQuery();
		    	
		    }catch(SqlException e){
		    
		    	Controle.Getinstance().writeLog(e.StackTrace);
		    	Controle.Getinstance().writeLog(e.Message);
		    	Controle.Getinstance().writeLog(sql);
		    	
		    }finally{
		    
		    	conn.Close();	
		    }
		    
		   
		    if(ret == 1)
		    	return EnumInserted.InsertSuccess;
		    else if(ret == 0)
		    	return EnumInserted.SQLErro;
		    else
		    	return EnumInserted.UnknownError;
		    
		}
		
		
		public EnumInserted UpdatePerfilEnvioProgramaSubvencao(PerfilEnvioProgramaSubvencao perfenvprosub){
		
			PerfilEnvioProgramaSubvencao perfenv = perfenvprosub;
			
			int ret = 99;
			
			SqlConnection conn = new SqlConnection(appConfig.getStrDataBase());
			
		    string sql = "update EXCD_PerfilEnvioProgramaSubvencao set "+
							"descricao = @descricao, "+
							"id_programa_subvencao = @id_programa_subvencao, "+
							"dt_inicio_vigencia_perfil = @dt_inicio_vigencia_perfil, "+
							"dt_final_vigencia_perfil = @dt_final_vigencia_perfil, "+
							"peNivelCoberturaMinimo = @peNivelCoberturaMinimo, "+
							"peNivelCoberturaMaximo = @peNivelCoberturaMaximo, "+
							"cdClassificacaoProduto = @cdClassificacaoProduto, "+
							"id_AtividadeBacen = @id_AtividadeBacen, "+
							"dt_inicio_vigencia_proposta  = @dt_inicio_vigencia_proposta, "+
							"dt_final_vigencia_proposta = @dt_final_vigencia_proposta, "+
							"status = 1 "+
							"where id = "+perfenvprosub.id;
		    
		    conn.Open();
		    SqlCommand command = new SqlCommand(sql,conn);
		    
		    
		    
		    command.Parameters.AddWithValue("@descricao",perfenv.descricao);
		    command.Parameters.AddWithValue("@id_programa_subvencao",perfenv.id_programa_subvencao);
		    command.Parameters.AddWithValue("@dt_inicio_vigencia_perfil",DateTime.Parse(perfenv.dt_inicio_vigencia_perfil).ToString("yyyyMMdd"));
		    command.Parameters.AddWithValue("@dt_final_vigencia_perfil",DateTime.Parse(perfenv.dt_final_vigencia_perfil).ToString("yyyyMMdd"));
		    command.Parameters.AddWithValue("@peNivelCoberturaMinimo",perfenv.peNivelCoberturaMinimo);
		    command.Parameters.AddWithValue("@peNivelCoberturaMaximo",perfenv.peNivelCoberturaMaximo);
		    command.Parameters.AddWithValue("@cdClassificacaoProduto",perfenv.cdClassificacaoProduto);
		    command.Parameters.AddWithValue("@id_AtividadeBacen",perfenv.id_atividadeBacen);
		    command.Parameters.AddWithValue("@dt_inicio_vigencia_proposta",DateTime.Parse(perfenv.dt_inicio_vigencia_proposta).ToString("yyyyMMdd"));
		    command.Parameters.AddWithValue("@dt_final_vigencia_proposta",DateTime.Parse(perfenv.dt_final_vigencia_proposta).ToString("yyyyMMdd"));
		   
		    
		    try{
		    
		    	ret = command.ExecuteNonQuery();
		    	
		    }catch(SqlException e){
		    
		    	Controle.Getinstance().writeLog(e.StackTrace);
		    	Controle.Getinstance().writeLog(e.Message);
		    	Controle.Getinstance().writeLog(sql);
		    	
		    	
		    }finally{
		    
		    	conn.Close();	    	
		    }
		    
		   
		    if(ret == 1){
		    	return EnumInserted.UpdateSucess;
		    }else if(ret == 0){
		    	return EnumInserted.SQLErro;
		    }else
		    	return EnumInserted.UnknownError;
		    
		}
		
		public RepositorioPerfilEnvioProgramaSubvencao()
		{
		}
	}
}
