using DomainLayer4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer4
{
    public interface IOrdertbBusiness
    {
        public Task<List<Orderstb>> GetAllOrders();
        public Task<Orderstb> GetOrderById(int id);
        public Task InsertOrder(Orderstb order);
        public Task UpdateOrder(Orderstb order);
        public Task DeleteOrderById(int id);
    }
}
