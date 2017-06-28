using System;

namespace WindowsFormsApplication1.Models
{
    public class CNH : EntityBase<int>
    {
        public int Numero { get; set; }

        public DateTime DtVencimento { get; set; }

        public TipoCNH Tipo { get; set; }
    }

    public enum TipoCNH : short
    {
        A,
        B,
        C,
        D,
        E,
        AB,
        AC,
        AD,
        AE
    }
}
