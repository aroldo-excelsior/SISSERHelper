/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 23/09/2016
 * Time: 11:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using SISSERHelper.Models;

namespace SISSERHelper.Interfaces
{
	/// <summary>
	/// Description of AccessForConsultationProposta.
	/// </summary>
	public interface InterfaceProposta
	{
		
		List<Proposta> ResgatarPropostas(String order,String dataIni, String dataFin);
		
	}
}
