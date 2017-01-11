/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 29/09/2016
 * Time: 16:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SISSERHelper;
using SISSERHelper.Interfaces;
using SISSERHelper.Models;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace SISSERHelper.Repositorios
{
	/// <summary>
	/// Description of RepositorioBacen.
	/// </summary>
	public class RepositorioBacen : InterfaceBacen
	{
		public RepositorioBacen()
		{
		}
		
		AppConfiguration appConfig = new AppConfiguration();
		
		public Bacen getBacenbyid(int id_bacen){
		
			
			
			string connString = appConfig.getStrDataBase();
			SqlConnection conn = new SqlConnection(connString);
			
			conn.Open();
			
			String sql =" select id, descricao from SISD_bacen where id = "+id_bacen;
			
			SqlCommand command = new SqlCommand(sql,conn);
			
			SqlDataReader ler = command.ExecuteReader();
			
			Bacen bacen = new Bacen();
			
			try{
				if(ler.HasRows){
				
					while(ler.Read()){
				
					
						if(!ler.IsDBNull(0)) bacen.id = ler.GetInt32(0); else bacen.id = 0;
						if(!ler.IsDBNull(1)) bacen.descricao = ler.GetString(1); else bacen.descricao = "Não Apresenta";
					
					}
				
				}
			}catch(SqlException e){
			
				Controle.Getinstance().writeLog(e.StackTrace);
				
			}finally{
				
				ler.Close();
				conn.Close();
				
			}
			
			return bacen;
			
		}
		
		
		public List<Bacen> getListBacen(){
		
			string connString = appConfig.getStrDataBase();
			SqlConnection conn = new SqlConnection(connString);
			
			conn.Open();
			
			String sql =" select id, descricao from SISD_bacen where status = 1 ";
			
			SqlCommand command = new SqlCommand(sql,conn);
			
			SqlDataReader ler = command.ExecuteReader();
			
			List<Bacen> lBacen = new List<Bacen>();
			
			try{
				if(ler.HasRows){
				
					while(ler.Read()){
						
						Bacen bacen = new Bacen();
					
						if(!ler.IsDBNull(0)) bacen.id = ler.GetInt32(0); else bacen.id = 0;
						if(!ler.IsDBNull(1)) bacen.descricao = ler.GetString(1); else bacen.descricao = "Não Apresenta";
					
						lBacen.Add(bacen);
						
					}
				
				}
			}catch(SqlException e){
			
				Controle.Getinstance().writeLog(e.StackTrace);
				
			}finally{
				
				ler.Close();
				conn.Close();
				
			}
			
			return lBacen;
			
		}
		
	}
}
