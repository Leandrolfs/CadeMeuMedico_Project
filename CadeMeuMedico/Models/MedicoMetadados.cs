using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CadeMeuMedico.Models
{
    [MetadataType(typeof(MedicoMetadados))] //Informa qual é a classe que possui o MetaDados a ser utilizado.
    public partial class medicos
    {

    }

    public class MedicoMetadados
    {
        [Required(ErrorMessage="Campo obrigatorio")]
        [StringLength(30, ErrorMessage="Campo limitado a 30 caracteres")]
        public string CRM { get; set; }

        [Required(ErrorMessage="Campo obrigatorio")]
        [StringLength(50, ErrorMessage="Campo limitado a 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Campo obrigatorio")]
        [StringLength(50, ErrorMessage="Campo limitado a 50 caracteres")]
        public string Endereco { get; set; }

        [Required(ErrorMessage="Campo obrigatorio")]
        [StringLength(50, ErrorMessage="Campo limitado a 50 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage="Campo obrigatorio")]
        [StringLength(80, ErrorMessage="Campo limitado a 80 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage="Campo obrigatorio")]
        public bool AtendePorConvenio { get; set; }

        [Required(ErrorMessage="Campo obrigatorio")]
        public bool TemClinica { get; set; }

        [StringLength(80, ErrorMessage="Campo limitado a 80 caracteres")]
        public string WebSiteBlog { get; set; }

        [Required(ErrorMessage="Campo obrigatorio")]
        public int IDCidade { get; set; }

        [Required(ErrorMessage="Campo obrigatorio")]
        public int IDEspecialidade { get; set; }
    }
}