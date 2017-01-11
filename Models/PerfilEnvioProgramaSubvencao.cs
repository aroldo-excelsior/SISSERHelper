/*
 * Created by SharpDevelop.
 * User: aroldo.andrade
 * Date: 29/09/2016
 * Time: 16:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SISSERHelper.Interfaces;
using SISSERHelper;
using SISSERHelper.Models;
using System.ComponentModel.DataAnnotations;
using SISSERHelper.Enums;

namespace SISSERHelper.Models
{
	/// <summary>
	/// Description of PerfilEnvioProgramaSubvencao.
	/// </summary>
	public class PerfilEnvioProgramaSubvencao
	{
		
		
		private string _descricao;
		private int _id_programa_subvencao;
		private ProgramaSubvencao _programaSubvencao;
		private string _dt_inicio_vigencia_perfil;
		private string _dt_final_vigencia_perfil;
		private int _peNivelCoberturaMinimo;
		private int _peNivelCoberturaMaximo;
		private int _cdClassificacaoProduto;
		private Produto _produto;
		private int _id_atividadeBacen;
		private Bacen _bacen;
		private string _dt_inicio_vigencia_proposta;
		private string _dt_final_vigencia_proposta;
		private string _dt_rgs_insercao;
		private int _id;
		private EnumInserted _inserted;
		private Boolean _isvalid;
		
		
		public int id{
		
			get{return _id;}
			set{_id = value;}
			
		}
		
		public string dt_rgs_insercao{
		
			get{return _dt_rgs_insercao;}
			set{_dt_rgs_insercao = value;}
			
		}
		
		[Required(ErrorMessage = "*Informe o campo \"Conbertuda Minima\".")]
		[Display(Name = "Conbertuda Minima")]
		public int peNivelCoberturaMinimo{
		
			get{return _peNivelCoberturaMinimo;}
			set{_peNivelCoberturaMinimo = value;}
			
		}
		[Required(ErrorMessage = "*Informe o campo \"Conbertuda Maxima\".")]
		[Display(Name = "Conbertuda Maxima")]
		public int peNivelCoberturaMaximo{
		
		
			get{return _peNivelCoberturaMaximo;}
			set{_peNivelCoberturaMaximo = value;}
			
			
		}
		[Required(ErrorMessage = "*Informe o campo \"Classificação Produto\".")]
		[Display(Name = "Classificação Produto")]
		public int cdClassificacaoProduto{
		
			get{return _cdClassificacaoProduto;}
			set{_cdClassificacaoProduto = value;}
			
		}
		
		public Produto produto{
		
			get{return Controle.Getinstance().getProdutoByCodProdutoSoftwareOrigem(cdClassificacaoProduto);}
			set{_produto = value;}
		
			
		}
		
		[Required(ErrorMessage = "*Informe o campo \" Atividade Bacen\".")]
		[Display(Name = "Atividade Bacen")]
		public int id_atividadeBacen{
		
			get{return _id_atividadeBacen;}
			set{_id_atividadeBacen = value;}
		
			
		}
		
		public Bacen bacen{
		
			get{return Controle.Getinstance().getBacenbyid(id_atividadeBacen);}
			set{_bacen = value;}
			
		}
		
		[Required(ErrorMessage = "*Informe o campo \"Início de Vigência da Proposta\".")]
		[Display(Name="Início de Vigência da Proposta")]
		public string dt_inicio_vigencia_proposta{
		
			get{return _dt_inicio_vigencia_proposta;}
			set{_dt_inicio_vigencia_proposta = value;}
			
		}
		
		
		[Required(ErrorMessage = "*Informe o campo \"Final de Vigência da Proposta\".")]
		[Display(Name="Final de Vigência da Proposta")]
		public string dt_final_vigencia_proposta{
		
			get{return _dt_final_vigencia_proposta;}
			set{_dt_final_vigencia_proposta = value;}
			
		}
		
		[Required(ErrorMessage = "*Informe o campo\"Final de Vigência do Perfil\".")]
		[Display(Name="Final de Vigência do Perfil")]
		public string dt_final_vigencia_perfil{
		
			get{return _dt_final_vigencia_perfil;}
			set{_dt_final_vigencia_perfil = value;}
			
		}
		[Required(ErrorMessage = "*Informe o campo \"Início de Vigência do Perfil\".")]
		[Display(Name="Início de Vigência do Perfil")]
		public string dt_inicio_vigencia_perfil{
		
			get{return _dt_inicio_vigencia_perfil;}
			set{_dt_inicio_vigencia_perfil = value;}
			
		}
		
		public Boolean isvalid{
		
			get{return _isvalid;}
			set{_isvalid = value;}
		
			
		}
		
		public ProgramaSubvencao programaSubvencao{
		
			get{return Controle.Getinstance().getProgramaSubvencaoById(id_programa_subvencao);}
			set{_programaSubvencao = value;}
			
			
		}
		
		[Required(ErrorMessage = "*Informe o campo \"Programa Subvenção\".")]
		[Display(Name="Programa Subvenção")]
		public int id_programa_subvencao{
		
			get{return _id_programa_subvencao;}
			set{_id_programa_subvencao = value;}
			
		}
		
		[Required(ErrorMessage = "*Informe o campo \"Descrição\".")]
		[Display(Name="Descrição")]
		public string descricao{
		
			get{return _descricao;}
			set{_descricao = value;}
			
		}
		
		public EnumInserted inserted{
			
			get{return _inserted;}
			set{_inserted = value;}
		
			
		}
		
		
		public PerfilEnvioProgramaSubvencao()
		{
		}
	}
}
