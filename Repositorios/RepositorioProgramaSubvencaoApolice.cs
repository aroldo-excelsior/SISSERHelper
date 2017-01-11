/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 23/09/2016
 * Time: 14:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SISSERHelper.Interfaces;
using SISSERHelper.Models;
using System.Data.SqlClient;

namespace SISSERHelper.Repositorios
{
	/// <summary>
	/// Description of RepositorioProgramaSubvencaoApolice.
	/// </summary>
	public class RepositorioProgramaSubvencaoApolice : InterfaceProgramaSubvencaoApolice
	{
		
		AppConfiguration appConf = new AppConfiguration();
		
		public ProgramaSubvencaoApolice BuscarProgramaSubvencaoApolice(int id_apolice) {
		
			ProgramaSubvencaoApolice psa = new ProgramaSubvencaoApolice();
			psa.codigo_Proposta_SISSER  = "Não Apresenta";
			
        		string connString = appConf.getStrDataBase();        
        		SqlConnection conn = new SqlConnection(connString);
        		conn.Open();
        		string sql ="select "+
								"epap.id, "+
								"case when epap.cdPropostaSISSER is null then convert(varchar,'Não Apresenta') "+
        						"when epap.cdPropostaSISSER = 0 then convert(varchar,'Não Apresenta') "+
        						"else convert(varchar,epap.cdPropostaSISSER) "+
								"end as codigoSISSER "+
							"from "+
								"EXCD_ProgramaSubvencao_Apolice as epap "+
							"where epap.id_apolice = "+id_apolice ;
        
        		SqlCommand adapt = new SqlCommand(sql, conn);
        		
        		
        
        		SqlDataReader ler = adapt.ExecuteReader();
       			try{
            		if (ler.HasRows) {
        	
           				while(ler.Read()){
        		
                			if(!ler.IsDBNull(0))psa.id = ler.GetInt32(0);else psa.id = 0;
                			if(!ler.IsDBNull(1))psa.codigo_Proposta_SISSER = ler.GetString(1);else psa.codigo_Proposta_SISSER  = "Não Apresenta";
                			
           		 		}
          			}
        		}finally{
        			ler.Close();
        			conn.Close();
        	 	}
       		
			return psa;
		}
		
	}
}
