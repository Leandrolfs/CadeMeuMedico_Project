using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CadeMeuMedico.Models
{
    [MetadataType(typeof(CidadeMetadados))]
    public partial class cidades
    {

    }

    public class CidadeMetadados
    {
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        [StringLength(30, ErrorMessage="Campo limitado a 30 caracteres")]
        public string Nome { get; set; }
    }
}