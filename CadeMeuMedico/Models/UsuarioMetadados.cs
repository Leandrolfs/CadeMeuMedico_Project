using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CadeMeuMedico.Models
{
    [MetadataType(typeof(UsuarioMetadados))]
    public partial class usuarios
    {

    }

    public class UsuarioMetadados
    {
        [Required(ErrorMessage="Esse campo é obrigatorio")]
        [StringLength(50, ErrorMessage="Campo limitado a 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Esse campo é obrigatorio")]
        [StringLength(100, ErrorMessage="Campo limitado a 100 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage="Esse campo é obrigatorio")]
        [StringLength(100, ErrorMessage="Campo limitado a 100 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage="Esse campo é obrigatorio")]
        [StringLength(50, ErrorMessage="Campo limitado a 50 caracteres")]
        public string Email { get; set; }
    }
}