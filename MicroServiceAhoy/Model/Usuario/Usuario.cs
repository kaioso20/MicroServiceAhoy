using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServiceAhoy.Model.Usuario
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [Column(Order = 1)]
        public long IdUsuario { get; set; }
        [Column(Order = 2)]
        public string Nome { get; set; }
        [Column(Order = 3)]
        public string Email { get; set; }
        [Column(Order = 4)]
        public DateTime DtNasc { get; set; }
        [Column(Order = 5)]
        public string Token { get; set; }
        [Column(Order = 6)]
        public bool? Ativo { get; set; }
        [Column(Order = 7)]
        public string Senha { get; set; }

    }
}
