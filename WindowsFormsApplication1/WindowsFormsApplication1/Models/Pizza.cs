using System.Collections.Generic;

namespace WindowsFormsApplication1.Models
{
    public class Pizza : Item
    {
        public List<Sabor> Sabores { get; set; }
        public int TamanhoId { get; set; }
    }
}
