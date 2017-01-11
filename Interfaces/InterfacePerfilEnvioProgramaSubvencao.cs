/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 29/09/2016
 * Time: 16:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SISSERHelper.Models;
using SISSERHelper.Enums;
using System.Collections.Generic;


namespace SISSERHelper.Interfaces
{
	/// <summary>
	/// Description of InterfacePerfilEnvioProgramaSubvencao.
	/// </summary>
	public interface InterfacePerfilEnvioProgramaSubvencao 
	{
		
		PerfilEnvioProgramaSubvencao getPerfilEnvioProgramaSubvencaoById(int id_perfEnvProSub);
		EnumInserted InsertPerfilEnvioProgramaSubvencao(PerfilEnvioProgramaSubvencao perfenvprosub);
		EnumInserted UpdatePerfilEnvioProgramaSubvencao(PerfilEnvioProgramaSubvencao perfenvprosub);
		Boolean PerfildescricaoExists(string descricao);
		List<PerfilEnvioProgramaSubvencao> getPerfils();
		List<PerfilEnvioProgramaSubvencao> getPerfilsByDate(DateTime dataini, DateTime datafin);
	}
}
