/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 30/09/2016
 * Time: 11:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using SISSERHelper.Models;
using System.Data.SqlClient;

namespace SISSERHelper.Repositorios
{
	/// <summary>
	/// Description of RepositorioProduto.
	/// </summary>
	public class RepositorioProduto
	{
		
		AppConfiguration appConfig = new AppConfiguration();
		
		public Produto getProdutoByCodProdutoSoftwareOrigem(int cod_Produto_SoftwareOrigem){
		
			Produto prod = new Produto();
			
			SqlConnection conn = new SqlConnection(appConfig.getStrDataBase());
			
			conn.Open();
			
			string sql = "select id, cod_Produto_SoftwareOrigem, descricao from EXCD_Produto where cod_Produto_SoftwareOrigem = "+cod_Produto_SoftwareOrigem;
			
			SqlCommand command = new SqlCommand(sql, conn);
			
			SqlDataReader ler = command.ExecuteReader();
			
			try{
			
				if(ler.HasRows){
				
					while(ler.Read()){
					
						if(!ler.IsDBNull(0)) prod.id = ler.GetInt32(0); else prod.id = 0;
						if(!ler.IsDBNull(1)) prod.cod_Produto_SoftwareOrigem = int.Parse(ler.GetString(1)); else prod.cod_Produto_SoftwareOrigem = 0;
						if(!ler.IsDBNull(2)) prod.descricao = ler.GetString(2); else prod.descricao = "Não Apresenta";
					
						
					}
				}
				
			
			}catch(SqlException e){
			
			
				Controle.Getinstance().writeLog(e.StackTrace);
			}finally{
			
				ler.Close();
				conn.Close();
				
			}
			
			return prod;
		}
		
		public List<Produto> getListProduto(){
		
			List<Produto> lProd = new List<Produto>();
			
			SqlConnection conn = new SqlConnection(appConfig.getStrDataBase());
			
			conn.Open();
			
			string sql = "select id, cod_Produto_SoftwareOrigem, descricao from EXCD_Produto";
			
			SqlCommand command = new SqlCommand(sql, conn);
			
			SqlDataReader ler = command.ExecuteReader();
			
			try{
			
				if(ler.HasRows){
				
					while(ler.Read()){
					
						Produto prod = new Produto();
							
						if(!ler.IsDBNull(0)) prod.id = ler.GetInt32(0); else prod.id = 0;
						if(!ler.IsDBNull(1)) prod.cod_Produto_SoftwareOrigem = int.Parse(ler.GetString(1)); else prod.cod_Produto_SoftwareOrigem = 0;
						if(!ler.IsDBNull(2)) prod.descricao = ler.GetString(2); else prod.descricao = "Não Apresenta";
					
						lProd.Add(prod);
						
					}
				}
				
			
			}catch(SqlException e){
			
			
				Controle.Getinstance().writeLog(e.StackTrace);
			}finally{
			
				ler.Close();
				conn.Close();
				
			}
			
			return lProd;
		}
		
		public RepositorioProduto()
		{
		}
	}
}
