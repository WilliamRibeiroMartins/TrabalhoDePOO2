using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Portal.Models
{
  [Table("Trabalhos")]
  public class Trabalho
	{
		[Key]
		public int codtrabalho { get; set; }
    [Required]
    [Display(Name = "Nome")]
    public string nome { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    [Display(Name = "Data da Publicação")]
    public DateTime DataPublicacao { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    [DataType(DataType.Date)]
    [Display(Name = "Data Limite")]
    public DateTime DataLimite { get; set; }

		public Disciplina disciplina { get; set; }
    public Professor professor { get; set; }
  }
}