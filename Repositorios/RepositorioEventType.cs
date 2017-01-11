/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 23/09/2016
 * Time: 14:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SISSERHelper.Interfaces;
using SISSERHelper.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace SISSERHelper.Repositorios
{
	/// <summary>
	/// Description of RepositorioEventType.
	/// </summary>
	public class RepositorioEventType : InterfaceEventType
	{
		AppConfiguration appConf = new AppConfiguration();
		
		public EventType BuscarEventType(int id) {
		
			EventType et = new EventType();
			if(id != null){
        		string connString = appConf.getStrDataBase();        
        		SqlConnection conn = new SqlConnection(connString);
        		conn.Open();
        		string sql ="select "+
								"eet.id, "+
								"eet.descricao "+
							"from "+
								"EXCD_EventType as eet "+
							"where eet.id = "+id;
        
        		SqlCommand adapt = new SqlCommand(sql, conn);
        
        		SqlDataReader ler = adapt.ExecuteReader();
       			try{
            		if (ler.HasRows) {
        	
           				while(ler.Read()){
        		
                			if(!ler.IsDBNull(0))et.id = ler.GetInt32(0);else et.id = 0;
                			if(!ler.IsDBNull(1))et.descricao = ler.GetString(1);else et.descricao = "Não Apresenta";
                			
           		 		}
        			}else{
        				et.id = 8888;
        				et.descricao = "Não Apresenta";
        				
        				
        			}
        		}finally{
        			ler.Close();
        			conn.Close();
        	 	}
       		
			}
			
			return et;
		}
		
		
	}
}
