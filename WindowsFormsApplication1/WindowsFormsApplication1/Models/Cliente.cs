using System;

namespace WindowsFormsApplication1.Models
{
    public class Cliente : EntityBase<int>
    {
        public string Nome { get; set; }
        public int CPF { get; set; }
        public int TelefoneFixo { get; set; }
        public int TelefoneCelular { get; set; }
        public DateTime DtCadastro { get; set; }
        public DateTime DtAniversario { get; set; }
        public Endereco Endereco { get; set; }
    }
}
