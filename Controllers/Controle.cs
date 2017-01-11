/*
 * User: aroldo.andrade
 * Date: 24/05/2016
 * Time: 10:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using SISSERHelper.Models;
using SISSERHelper.Repositorios;

namespace SISSERHelper
{
	public class Controle
	{
		
		private List<EventLog> coll = new List<EventLog>();
		private static Controle control = new Controle();
		
		public static Controle Getinstance(){
			
			if(control == null){
			
				control = new Controle();
				return control;
			}else{
				return control;
			}
			
		}
		
		public Enums.EnumInserted InsertPerfilEnvioProgramaSubvencao(PerfilEnvioProgramaSubvencao perfenvprosub){
		
			RepositorioPerfilEnvioProgramaSubvencao repper = new RepositorioPerfilEnvioProgramaSubvencao();
			
			return repper.InsertPerfilEnvioProgramaSubvencao(perfenvprosub);
			
		}
		
		public List<PerfilEnvioProgramaSubvencao> getPerfils(){
		
			RepositorioPerfilEnvioProgramaSubvencao repperfenv = new RepositorioPerfilEnvioProgramaSubvencao();
			
			return repperfenv.getPerfils();
			
		}
		
		public PerfilEnvioProgramaSubvencao getPerfilEnvioProgramaSubvencaoById(int id_perfEnvProSub){
		
			RepositorioPerfilEnvioProgramaSubvencao repperfenv = new RepositorioPerfilEnvioProgramaSubvencao();
			
			return repperfenv.getPerfilEnvioProgramaSubvencaoById(id_perfEnvProSub);
			
		
		}
		
		public List<PerfilEnvioProgramaSubvencao> getPerfilsByDate(DateTime dataini, DateTime datafin){
		
			RepositorioPerfilEnvioProgramaSubvencao repperfenv = new RepositorioPerfilEnvioProgramaSubvencao();
			
			return repperfenv.getPerfilsByDate(dataini,datafin);
			
			
		}
		
		public Enums.EnumInserted UpdatePerfilEnvioProgramaSubvencao(PerfilEnvioProgramaSubvencao perfenvprosub){
			
			RepositorioPerfilEnvioProgramaSubvencao repper = new RepositorioPerfilEnvioProgramaSubvencao();
			
			return repper.UpdatePerfilEnvioProgramaSubvencao(perfenvprosub);
		
		}
		
		public List<Bacen> getListBacen(){
		
			RepositorioBacen repba = new RepositorioBacen();
			
			return repba.getListBacen();
			
		}
		
		public Boolean PerfildescricaoExists(string descricao){
		
			RepositorioPerfilEnvioProgramaSubvencao repper = new RepositorioPerfilEnvioProgramaSubvencao();
			
			return repper.PerfildescricaoExists(descricao);
			
		}
		
		public List<Produto> getListProduto(){
		
			RepositorioProduto prod = new RepositorioProduto();
			
			return prod.getListProduto();
			
		}
		
		public Produto getProdutoByCodProdutoSoftwareOrigem(int cod_Produto_SoftwareOrigem){
		
			RepositorioProduto repprod = new RepositorioProduto();
			
			return repprod.getProdutoByCodProdutoSoftwareOrigem(cod_Produto_SoftwareOrigem);
			
		}
		
		public List<ProgramaSubvencao> getListProgramaSubvencao(){
		
			RepositorioProgramaSubvencao repprosub = new RepositorioProgramaSubvencao();
			
			return repprosub.getListProgramaSubvencao();
			
		}
		
		public ProgramaSubvencao getProgramaSubvencaoById(int id_programaSubvencao){
			
			RepositorioProgramaSubvencao repprosub = new RepositorioProgramaSubvencao();
			
			return repprosub.getProgramaSubvencaoById(id_programaSubvencao);
		
		}
		
		public Bacen getBacenbyid(int id_bacen){
		
			RepositorioBacen repba = new RepositorioBacen();
			
			return repba.getBacenbyid(id_bacen);
			
		}
		
		public ProgramaSubvencaoApolice BuscarProgramaSubvencaoApolice(int id_apolice) {
		
			RepositorioProgramaSubvencaoApolice reppro = new RepositorioProgramaSubvencaoApolice();
			return reppro.BuscarProgramaSubvencaoApolice(id_apolice);
		
		}
		
		public EventType BuscarEventType(int id){
		
			RepositorioEventType evet = new RepositorioEventType();
			return evet.BuscarEventType(id);
		}
		
		public Proposta BuscarProposta(string nrProposta){
		
			RepositorioProposta reppro = new RepositorioProposta();
			return reppro.BuscarProposta(nrProposta);
		}
		
		public List<Proposta> ResgatarPropostas(String order,String DataIni, String DataFin){
			
			RepositorioProposta reppro = new RepositorioProposta();
			
			
			return reppro.ResgatarPropostas(order, DataIni,  DataFin);
		
		}
		
		public EventLog ResgatarArgsStackTraceEventLogs(string IDeventlog){
			
			RepositorioEventLog repEven = new RepositorioEventLog();
		
			return repEven.ResgatarArgsStackTraceEventLogs(IDeventlog);
			
		}
		
		
		public List<EventLog> ResgatarEventLogs(String order, int id_apolice){
			
			RepositorioEventLog repEven = new RepositorioEventLog();
			
			coll = repEven.ResgatarEventLogs(order,id_apolice);
			
			return coll;
		
		}
		
		public void writeLog(string error){
		
			try{
			
			if(!Directory.Exists("c:/logsSISSER/")){
				Directory.CreateDirectory("c:/logsSISSER/");	
			}
			
			
			List<string> errors = new List<string>();
			errors.Add(error + " - "+ DateTime.Now);
			errors.Add(" -------------------------------------------------------------------- ");
			errors.Add(" -------------------------------------------------------------------- ");
			String[] array = errors.ToArray();
			if(System.IO.File.Exists("c:/logsSISSER/log.txt"))
				System.IO.File.AppendAllLines("c:/logsSISSER/log.txt",array);
			else
				System.IO.File.WriteAllLines("c:/logsSISSER/log.txt",array);
			
			
			}catch(Exception e){}
				
			}
		
		private Controle()
		{
		
		}
	}
}
