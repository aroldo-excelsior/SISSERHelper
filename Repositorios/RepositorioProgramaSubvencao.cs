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
using System.Collections.Generic;

namespace SISSERHelper.Repositorios
{
	/// <summary>
	/// Description of RepositorioProgramaSubvencao.
	/// </summary>
	public class RepositorioProgramaSubvencao : InterfaceProgramaSubvencao
	{
		
		AppConfiguration appConfig = new AppConfiguration();
		
		public ProgramaSubvencao getProgramaSubvencaoById(int id_programaSubvencao){
			
			ProgramaSubvencao prosub = new ProgramaSubvencao();
			
			SqlConnection conn = new SqlConnection(appConfig.getStrDataBase());
			conn.Open();
			
			string sql = "select id, cod_programa_subvencao, descricao from EXCD_ProgramaSubvencao where id = "+id_programaSubvencao;
			
			SqlCommand command = new SqlCommand(sql, conn);
			
			SqlDataReader ler = command.ExecuteReader();
			
			try{
			
				if(ler.HasRows){
			
					while(ler.Read()){
				
						if(!ler.IsDBNull(0)) prosub.id = ler.GetInt32(0); else prosub.id = 0;
						if(!ler.IsDBNull(1)) prosub.cod_Programa_Subvecao = ler.GetString(1); else prosub.cod_Programa_Subvecao = "Não Apresenta";
						if(!ler.IsDBNull(2)) prosub.descricao = ler.GetString(2); else prosub.descricao = "Não Apresenta";
					
					
					}
				}
			}catch(SqlException e){
			
				Controle.Getinstance().writeLog(e.StackTrace);
				
			}finally{
			
				ler.Close();
				conn.Close();	
			}
			
			return prosub;
			
			
		}
		
		public List<ProgramaSubvencao> getListProgramaSubvencao(){
			
			List<ProgramaSubvencao> lProsub = new List<ProgramaSubvencao>();
			
			SqlConnection conn = new SqlConnection(appConfig.getStrDataBase());
			conn.Open();
			
			string sql = "select id, cod_programa_subvencao, descricao from EXCD_ProgramaSubvencao where status = 1";
			
			SqlCommand command = new SqlCommand(sql, conn);
			
			SqlDataReader ler = command.ExecuteReader();
			
			try{
			
				if(ler.HasRows){
			
					while(ler.Read()){
						
						ProgramaSubvencao prosub = new ProgramaSubvencao();
				
						if(!ler.IsDBNull(0)) prosub.id = ler.GetInt32(0); else prosub.id = 0;
						if(!ler.IsDBNull(1)) prosub.cod_Programa_Subvecao = ler.GetString(1); else prosub.cod_Programa_Subvecao = "Não Apresenta";
						if(!ler.IsDBNull(2)) prosub.descricao = ler.GetString(2); else prosub.descricao = "Não Apresenta";
					
						lProsub.Add(prosub);
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
			
			return lProsub;
			
			
		}
		
		
		public RepositorioProgramaSubvencao()
		{
			
		}
		
	}
}
