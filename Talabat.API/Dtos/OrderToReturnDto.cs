using System;
using System.Collections.Generic;
using Talabat.DAL.Entities.Order_Aggregate;

namespace Talabat.API.Dtos
{
    public class OrderToReturnDto
    {
        public int Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public Address ShipToAddress { get; set; }
        public string DeliveryMethod { get; set; }
        public decimal DeliveryCost { get; set; }
        public string Status { get; set; }
        public List<OrderItemDto> Items { get; set; }  
        public int PaymentIntentId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

    }
}
