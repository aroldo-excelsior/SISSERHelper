/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 23/09/2016
 * Time: 14:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SISSERHelper.Models;

namespace SISSERHelper.Interfaces
{
	/// <summary>
	/// Description of IProgramaSubvencaoApolice.
	/// </summary>
	public interface InterfaceProgramaSubvencaoApolice
	{
		
		
		ProgramaSubvencaoApolice BuscarProgramaSubvencaoApolice(int id_apolice);
		
		
		
	}
}
