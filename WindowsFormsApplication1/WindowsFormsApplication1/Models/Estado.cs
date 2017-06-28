namespace WindowsFormsApplication1.Models
{
    public class Estado : EntityBase<int>
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
    }
}
