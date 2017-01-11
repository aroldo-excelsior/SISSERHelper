/*
 * User: aroldo.andrade
 * Date: 24/05/2016
 * Time: 10:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using SISSERHelper.Models;


namespace SISSERHelper.Interfaces
{
	public interface InterfaceEventLog
	{
		
		
	List<EventLog> ResgatarEventLogs(string order, int id_apolice);
	EventLog ResgatarArgsStackTraceEventLogs(string IDeventlog);
	
	}
}
