using System.Collections.Generic;

namespace WindowsFormsApplication1.Models
{
    public class Sabor : EntityBase<int>
    {
        public string Nome { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
    }
}
