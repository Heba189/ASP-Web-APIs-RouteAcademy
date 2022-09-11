using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.DAL.Entities.Order_Aggregate
{
    public class Order:BaseEntity
    {
        public Order()
        {

        }
        public Order(string buyerEmail, Address shipToAddress, DeliveryMethod deliveryMethod, List<OrderItem> items, decimal subtotal)
        {
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            Items = items;
            Subtotal = subtotal;
        }

        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public Address ShipToAddress { get; set; }
        public DeliveryMethod   DeliveryMethod { get; set; } //navigation property [one => Eager Loading]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public List<OrderItem>  Items { get; set; }  //navigation property [Many -> must include items so using  => Eager Loading]
        public int PaymentIntentId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal GetTotal()
            => Subtotal + DeliveryMethod.Cost;
    }
}
