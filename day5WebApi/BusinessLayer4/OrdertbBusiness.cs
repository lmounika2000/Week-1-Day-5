using DataAccesslayer;
using DataAccesslayer;
using DataAcessLayer.Models;
using DomainLayer4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer4
{
    public class OrdertbBusiness : IOrdertbBusiness
    {
        private readonly IOrdertbData _ordertbdata;

        public OrdertbBusiness(IOrdertbData ordertbdata)
        {
            _ordertbdata = ordertbdata;
        }

        public async Task DeleteOrderById(int id)
        {
            await _ordertbdata.DeleteOrderById(id);
        }

        public async Task<List<Orderstb>> GetAllOrders()
        {
            return await _ordertbdata.GetAllOrders();
        }

        public async Task<Orderstb> GetOrderById(int id)
        {
            return await _ordertbdata.GetOrderById(id);
        }

        public async Task InsertOrder(Orderstb orderstb)
        {
            await _ordertbdata.InsertOrder(orderstb);
        }

        public async Task UpdateOrder(Orderstb orderstb)
        {
            await _ordertbdata.UpdateOrder(orderstb);
        }
    }

}       
