/*
 * User: aroldo.andrade
 * Date: 23/05/2016
 * Time: 11:39
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

	public class RepositorioEventLog : InterfaceEventLog
	{
		
		AppConfiguration appConf = new AppConfiguration();
		
		
		
		public EventLog ResgatarArgsStackTraceEventLogs(string IDeventlog) {
		
			EventLog u = new EventLog();
			if(IDeventlog != null){
        		string connString = appConf.getStrDataBase();        
        		SqlConnection conn = new SqlConnection(connString);
        		conn.Open();
        		string sql ="select "+
								"ee.Args as [argumento], "+
								"ee.StackTrace as [Stack_Trace]"+
							"from "+
								"EXCD_Eventlog as ee "+
							"where "+
        			"ee.id = "+IDeventlog +" and ee.id_EventType not in (999,0,11,12,1)";
        
        		SqlCommand adapt = new SqlCommand(sql, conn);
        
        		SqlDataReader ler = adapt.ExecuteReader();
       			try{
            		if (ler.HasRows) {
        	
           				while(ler.Read()){
        		
                			
                	
                			if(!ler.IsDBNull(0))u.argumento = ler.GetString(0);else u.argumento = "<Infomation><Show>Não Apresenta</Show></Infomation>";
                			if(!ler.IsDBNull(1))u.stack_Trace = ler.GetString(1);else u.stack_Trace = "<Infomation><Show>Não Apresenta</Show></Infomation>";
                			
                			
           		 		}
          			}
        		}finally{
        			ler.Close();
        			conn.Close();
        	 	}
       		
			}
			
			return u;
		}
		
		public List<EventLog> ResgatarEventLogs(string order, int id_apolice) {
        	List<EventLog> coll = new List<EventLog>();
        	int contador = 1;
        	
        		string connString = ConfigurationManager.AppSettings["strDataBaseSISSER"];
        		SqlConnection conn = new SqlConnection(connString);
        		conn.Open();
        		string sql ="select "+
								"ee.Description as [Descrição_do_Evento], "+ 
								"ee.Args as [argumento], "+
								"ee.MessageError as [Message_de_Erro], "+
								"ee.StackTrace as [Stack_Trace], "+
        						"ee.dt_rgs_insercao as [Data Inserção],"+
        						"ee.id as [IDEvento],"+
        						"ee.id_EventType as [IDEventType] "+
							"from "+
								"EXCD_EventLog ee "+
							"where "+
        						"ee.id_Apolice = "+id_apolice+" and ee.id_EventType not in(999,0,11,12,1)"+
        					" order by ee.dt_rgs_insercao "+order;
        
        		SqlCommand adapt = new SqlCommand(sql, conn);
        
        		SqlDataReader ler = adapt.ExecuteReader();
       			try{
            		if (ler.HasRows) {
        	
           				while(ler.Read()){
        		
                			EventLog u = new EventLog();
                	
                			if(!ler.IsDBNull(0))u.descricao = ler.GetString(0);else u.descricao = "Não Apresenta";
                			if(!ler.IsDBNull(1))u.argumento = ler.GetString(1);else u.argumento = "Não Apresenta";
                			if(!ler.IsDBNull(2))u.message_De_Erro = "Apresenta";else u.message_De_Erro = "Não Apresenta";
                			if(!ler.IsDBNull(3))u.stack_Trace = ler.GetString(3);else u.stack_Trace = "Não Apresenta";
                			if(!ler.IsDBNull(4))u.dt_rgs_insercao = ler.GetDateTime(4).ToString();else u.dt_rgs_insercao = "Não Apresenta";
                			if(!ler.IsDBNull(5))u.id = ler.GetInt32(5);else u.id = 0;
                			if(!ler.IsDBNull(6))u.id_eventType = ler.GetInt32(6);else u.id_eventType = 0;
                			
                			u.iDApolice = id_apolice;
                			u.sequencia = contador;
                			contador++;
                	
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
