using System;
using WindowsFormsApplication1.Infra;
using WindowsFormsApplication1.Models;

namespace WindowsFormsApplication1.Services
{
    public class PedidoService : ServiceBase<Pedido>
    {
        //private readonly Database db = new Database();

        public override Pedido GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public override Pedido GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public override Pedido GetAllBetweenDates(DateTime @from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public override void Insert(Pedido entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Pedido entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Pedido entity)
        {
            throw new NotImplementedException();
        }
    }
}
