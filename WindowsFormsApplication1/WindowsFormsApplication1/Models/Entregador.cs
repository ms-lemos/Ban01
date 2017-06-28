namespace WindowsFormsApplication1.Models
{
    public class Entregador : EntityBase<int>
    {
        public string Nome { get; set; }
        public int CPF { get; set; }
        public CNH CNH { get; set; }
    }
}
