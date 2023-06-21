using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace icts_test.Entities.Entities
{
    public class User : IdentityUser
    {
        [Column("USR_CPF")]
        public string Cpf { get; set; }
    }
}