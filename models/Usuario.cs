using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaCSharp.models
{
   public class Usuario
{
    public int Id { get; set; }
    public string User { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
}
}