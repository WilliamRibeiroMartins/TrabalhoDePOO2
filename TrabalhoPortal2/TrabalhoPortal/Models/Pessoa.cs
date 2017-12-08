using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portal.Models
{
	public class Pessoa
	{
		[Display(Name = "Matricula")]
		public string matricula { get; set; }
    [Required]
		[Display(Name = "Nome")]
		public string nome { get; set; }
    [Required]
		[StringLength(11, MinimumLength = 11, ErrorMessage = "Digite um cpf valido (Somente números)")]
		[Display(Name = "CPF")]
		public string cpf {get; set; }
    [Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string email { get; set; }
    [Required]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		[Display(Name = "Data de Nascimento")]
    [DataType(DataType.Date)]
    public DateTime dataNascimento { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 6, ErrorMessage =
            "A senha deve ter o minimo de 6 caracteres")]
    [Display(Name = "Password", Description = "Digite um password de no minimo 6 caracteres")]
		[DataType(DataType.Password)]
		public string password { get; set; }
	}
}