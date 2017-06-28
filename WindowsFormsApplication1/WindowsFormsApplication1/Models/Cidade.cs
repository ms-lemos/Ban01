namespace WindowsFormsApplication1.Models
{
    public class Cidade : EntityBase<int>
    {
        public short DDD { get; set; }
        public string Nome { get; set; }

        public Estado Estado { get; set; }
    }
}
