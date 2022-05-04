using DataAcessLayer.Models;
using DomainLayer4;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesslayer
{
    public class OrdertbData : IOrdertbData
    {

        public async Task<List<Orderstb>> GetAllOrders()
        {

            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var amazontb = await dbContext.Orders.ToListAsync();

                List<Orderstb> domainModels = new List<Orderstb>();
                foreach (var amz in amazontb)
                {
                    domainModels.Add(new Orderstb
                    {
                        Id = amz.Id,
                        UserName = amz.UserName,
                        Cost = (int)amz.Cost,
                        ItemQty = amz.ItemQty,
                        CreatedDate = (DateTime)amz.CreatedDate,
                        UpdatedDate = (DateTime)amz.UpdatedDate,
                        AmazonID = (int)amz.AmazonId
                    });
                }
                return domainModels;
            }
        }

        public async Task InsertOrder(Orderstb orderstb)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var dbModel = new Order
                {
                    UserName = orderstb.UserName,
                    Cost = orderstb.Cost,
                    ItemQty = orderstb.ItemQty,
                    CreatedDate = orderstb.CreatedDate,
                    UpdatedDate = orderstb.UpdatedDate,
                    AmazonId = orderstb.AmazonID
                };

                dbContext.Orders.Add(dbModel);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateOrder(Orderstb orderstb)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == orderstb.Id);

                findOrder.UserName = orderstb.UserName;
                findOrder.Cost = orderstb.Cost;
                findOrder.ItemQty = orderstb.ItemQty;

                dbContext.Orders.Update(findOrder);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderById(int Id)
        {
            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var findOrder = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == Id);
                dbContext.Orders.Remove(findOrder);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<Orderstb> GetOrderById(int id)
        {
            // return TempData.Data.Find(x => x.Id == id);
            // return TempData.Data.FirstOrDefault(x => x.Id == id);

            using (OrdersDbContext dbContext = new OrdersDbContext())
            {
                var orderstb = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

                Orderstb domainModel = new Orderstb
                {
                    AmazonID = orderstb.Id,
                    UserName = orderstb.UserName,
                    Cost = (int)orderstb.Cost,
                    ItemQty = orderstb.ItemQty,
                    CreatedDate = (DateTime)orderstb.CreatedDate,
                    UpdatedDate = (DateTime)orderstb.UpdatedDate,

                };

                return domainModel;
            }
        }

        
    }
}