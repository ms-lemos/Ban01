using System;
using System.Collections.Generic;

namespace WindowsFormsApplication1.Models
{
    public class Pedido : EntityBase<int>
    {
        public DateTime DataHoraPedido { get; set; }
        public DateTime DataHoraEntrega { get; set; }

        public Cliente Cliente { get; set; }

        public Entregador Entregador { get; set; }

        public List<Item> Itens { get; set; }
    }
}
