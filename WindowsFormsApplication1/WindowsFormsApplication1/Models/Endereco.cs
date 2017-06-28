namespace WindowsFormsApplication1.Models
{
    public class Endereco : EntityBase<int>
    {
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public short Numero { get; set; }
        public int CEP { get; set; }
        public Cidade Cidade { get; set; }
    }
}
