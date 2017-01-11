/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 23/09/2016
 * Time: 11:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using SISSERHelper.Interfaces;
using SISSERHelper.Models;

namespace SISSERHelper.Repositorios
{
	/// <summary>
	/// Description of RepositorioProposta.
	/// </summary>
	public class RepositorioProposta : InterfaceProposta
	{
		
		AppConfiguration appConf = new AppConfiguration();
		
		public Proposta BuscarProposta(string nrProposta){
		
			Proposta u = new Proposta();
			string connString = appConf.getStrDataBase();
        	SqlConnection conn = new SqlConnection(connString);
        	conn.Open();
        	string sql ="select "+
								"eap.id as [Id Apolice],"+
								"eap.dt_proposta as [Data Inserção],"+
        						"eap.nrProposta as [Numero Proposta],"+
								"eap.nmSegurado as [Nome Segurado],"+
        						"eap.nrCpfCnpjSegurado as [CPF/CNPJ],"+
        						"eap.autorizacao_usuario as [Autorização Usuario] "+
							"from "+
        						"EXCD_Apolice as eap "+
        					"where eap.nrProposta = "+ nrProposta;
        	
						
        	SqlCommand adapt = new SqlCommand(sql, conn);
        
        	SqlDataReader ler = adapt.ExecuteReader();
       		try{
            		if (ler.HasRows) {
        	
           				while(ler.Read()){
        					
        					
                			if(!ler.IsDBNull(0))u.id = ler.GetInt32(0);else u.id = 0;
                			if(!ler.IsDBNull(1))u.dt_proposta = ler.GetDateTime(1).ToString();else u.dt_proposta = "Não Apresenta";
                			if(!ler.IsDBNull(2))u.nrProposta = ler.GetString(2);else u.nrProposta = "Não Apresenta";
                			if(!ler.IsDBNull(3))u.nmSegurado = ler.GetString(3);else u.nmSegurado = "Não Apresenta";
                			if(!ler.IsDBNull(4))u.nrCpfCnpjSegurado = ler.GetInt64(4);else u.nrCpfCnpjSegurado = 0;
                			if(!ler.IsDBNull(5))u.autorizacao_usuario = ler.GetInt32(5);else u.autorizacao_usuario = 0;
                			
                			
           		 		}
          			}
        		}finally{
        			ler.Close();
        			conn.Close();
        	 	}
			
        		return u;
			
		}
		
		public List<Proposta> ResgatarPropostas(String order,String dataIni, String dataFin){
		
			List<Proposta> coll = new List<Proposta>();
			
			
			
			string connString = appConf.getStrDataBase();
        		SqlConnection conn = new SqlConnection(connString);
        		conn.Open();
        		string sql ="select "+
								"eap.id as [Id Apolice],"+
								"eap.dt_proposta as [Data Inserção],"+
        						"eap.nrProposta as [Numero Proposta],"+
								"eap.nmSegurado as [Nome Segurado],"+
        						"eap.nrCpfCnpjSegurado as [CPF/CNPJ],"+
        						"eap.autorizacao_usuario as [Autorização Usuario] "+
							"from "+
        						"EXCD_Apolice as eap "+
        					"where eap.dt_proposta BETWEEN '"+dataIni+"' and '"+dataFin+
        					"' order by eap.dt_proposta, eap.id "+order;
        		
        		//Console.Write("sql: "+sql);
							
        		SqlCommand adapt = new SqlCommand(sql, conn);
        
        		SqlDataReader ler = adapt.ExecuteReader();
       			try{
            		if (ler.HasRows) {
        	
           				while(ler.Read()){
        					
        					Proposta u = new Proposta();
        					
                			if(!ler.IsDBNull(0))u.id = ler.GetInt32(0);else u.id = 0;
                			if(!ler.IsDBNull(1))u.dt_proposta = ler.GetDateTime(1).ToString();else u.dt_proposta = "Não Apresenta";
                			if(!ler.IsDBNull(2))u.nrProposta = ler.GetString(2);else u.nrProposta = "Não Apresenta";
                			if(!ler.IsDBNull(3))u.nmSegurado = ler.GetString(3);else u.nmSegurado = "Não Apresenta";
                			if(!ler.IsDBNull(4))u.nrCpfCnpjSegurado = ler.GetInt64(4);else u.nrCpfCnpjSegurado = 0;
                			if(!ler.IsDBNull(5))u.autorizacao_usuario = ler.GetInt32(5);else u.autorizacao_usuario = 0;
                			
                			coll.Add(u);
                			
           		 		}
          			}
        		}finally{
        			ler.Close();
        			conn.Close();
        	 	}
       		
        		return coll;
			
		}
	}
}
