/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 29/09/2016
 * Time: 16:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using SISSERHelper.Models;

namespace SISSERHelper.Interfaces
{
	/// <summary>
	/// Description of InterfaceBacen.
	/// </summary>
	public interface InterfaceBacen
	{
		
		Bacen getBacenbyid(int id_bacen);
		List<Bacen> getListBacen();
			
	}
}
