using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Portal.Models
{
  [Table("Professores")]
  public class Professor : Pessoa
	{
		[Key]
		public int codprofessor { get; set; }

	}
}