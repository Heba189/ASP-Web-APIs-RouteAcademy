using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.BLL.Interfaces;
using Talabat.BLL.Specifications.OrderSpecifications;
using Talabat.DAL.Entities;
using Talabat.DAL.Entities.Order_Aggregate;

namespace Talabat.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepository;
        //private readonly IGenericRepository<Product> _productRepo;
        //private readonly IGenericRepository<DeliveryMethod> _deliveryMethod;
        //private readonly IGenericRepository<Order> _orderRepo;
        IUnitOfWork _unitOfWork;

        public OrderService(IBasketRepository basketRepository , 
            //IGenericRepository<Product> ProductRepo ,
            //IGenericRepository<DeliveryMethod> deliveryMethod ,
            //IGenericRepository<Order> orderRepo)
            IUnitOfWork unitOfWork)
        {
           _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
            //_productRepo = ProductRepo;
            //_deliveryMethod = deliveryMethod;
            //_orderRepo = orderRepo;
        }
        public async Task<Order> CreateOrderAsync(string buyerEmail, string basketId, int deliveryMethodId, Address shipToAddress)
        {
            //1- get basket from baskets Repo
             var basket = await _basketRepository.GetCustomerBasket(basketId);
            //2- get selected items at basket from products repo
            var orderItems = new List<OrderItem>();

            foreach(var item in basket.Items)
            {
               // var product = await _productRepo.GetAsync(item.Id);
                var product = await _unitOfWork.Repository<Product>().GetAsync(item.Id);
                var productItemOrdered = new ProductItemOrdered(product.Id, product.Name, product.PictureUrl);

                var orderItem = new OrderItem(productItemOrdered, product.Price, item.Quantity);
                orderItems.Add(orderItem);

            }
            //3- get delivery method from deliveryMethods repo
             //var deliveryMethod = await _deliveryMethod.GetAsync(deliveryMethodId);
             var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetAsync(deliveryMethodId);

            //4- calculate subtotal
            var subtotal = orderItems.Sum(item => item.Price * item.Quantity);

            //5- create order

            var order = new Order(buyerEmail, shipToAddress, deliveryMethod,orderItems,subtotal);
            

            //await _orderRepo.Add(order);
            await _unitOfWork.Repository<Order>().Add(order);
            //6-save to database
            int result = await _unitOfWork.Complete();
            if(result <= 0) return null;

            return order; 
        }

  
       

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _unitOfWork.Repository<DeliveryMethod>().GetAllAsync();    
        }

        public async Task<Order> GetOrderByIdForUser(int orderId, string buyerEmail)
        {
            var spec = new OrderWithItemsAndDeleiveryMethodSpecification(orderId, buyerEmail);
            var order = await _unitOfWork.Repository<Order>().GetEntityWithSpecAsync(spec);

            return order;
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            var spec = new OrderWithItemsAndDeleiveryMethodSpecification(buyerEmail);
            var orders = await _unitOfWork.Repository<Order>().GetAllWithSpecAsync(spec);

            return orders;
        }


    }
}
