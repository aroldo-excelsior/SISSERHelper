/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 30/09/2016
 * Time: 11:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SISSERHelper.Models;
using System.Collections.Generic;

namespace SISSERHelper.Interfaces
{
	/// <summary>
	/// Description of InterfaceProduto.
	/// </summary>
	public interface InterfaceProduto
	{
		
		
		Produto getProdutoByCodProdutoSoftwareOrigem(int cod_Produto_SoftwareOrigem);
		List<Produto> getListProduto();
		
		
	}
}
