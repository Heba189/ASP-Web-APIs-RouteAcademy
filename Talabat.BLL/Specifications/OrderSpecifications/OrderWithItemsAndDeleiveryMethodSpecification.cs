using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.API.Specifications;
using Talabat.DAL.Entities.Order_Aggregate;

namespace Talabat.BLL.Specifications.OrderSpecifications
{
    internal class OrderWithItemsAndDeleiveryMethodSpecification: Specification<Order>
    {
        //this ctor is used for get all orders for a specific user
        public OrderWithItemsAndDeleiveryMethodSpecification(string buyerEmail)
            :base( o => o.BuyerEmail == buyerEmail)
        {
            AddInclude(o => o.DeliveryMethod);
            AddInclude(o => o.Items);

            AddOrderByDescending(o => o.OrderDate);
        }

        //this ctor is used for get an order for a specific user
        public OrderWithItemsAndDeleiveryMethodSpecification(int orderId, string buyerEmail)
            : base(o =>(o.BuyerEmail == buyerEmail && o.Id == orderId) )
        {
            AddInclude(o => o.DeliveryMethod);
            AddInclude(o => o.Items);
        }
    }
}
