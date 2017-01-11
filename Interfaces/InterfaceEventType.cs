/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 23/09/2016
 * Time: 14:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SISSERHelper.Models;

namespace SISSERHelper.Interfaces
{
	/// <summary>
	/// Description of IEventType.
	/// </summary>
	public interface InterfaceEventType
	{
		
		EventType BuscarEventType(int id);
	}
}
