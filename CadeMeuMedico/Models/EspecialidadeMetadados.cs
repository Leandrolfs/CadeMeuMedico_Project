using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CadeMeuMedico.Models
{
    [MetadataType(typeof(EspecialidadeMetadados))]
    public partial class especialidades
    {

    }

    public class EspecialidadeMetadados
    {
        [Required(ErrorMessage="Esse campo é obrigatorio")]
        [StringLength(50, ErrorMessage="Campo limitado a 50 caracteres")]
        public string Nome { get; set; }
    }
}