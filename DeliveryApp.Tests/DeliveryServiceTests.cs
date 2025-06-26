using DeliveryApp.Models;
using DeliveryApp.Models.DbEntities;
using DeliveryApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Runtime.CompilerServices;

namespace DeliveryApp.Tests
{
    [TestFixture]
    public class DeliveryServiceTests
    {
        private DeliveryService _deliveryService;
        private DeliveryContext _context;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<DeliveryContext>()
                .UseSqlite("Data Source=test.db")
                .Options;

            _context = new DeliveryContext(options);
            _context.Database.EnsureDeleted();  
            _context.Database.EnsureCreated();
            
            _deliveryService = new DeliveryService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task CreateOrder_ReturnsCreatedOrder()
        {
            var orderRequest = GetOrderRequest();
            var expectedOrder = Map(orderRequest, 1);

            var order = await _deliveryService.CreateOrder(orderRequest);
            CheckEquals(order, expectedOrder);
        }

        [Test]
        public void CreateOrder_WhenSenderAndReceiverLocationEqual_Throws()
        {
            var orderRequest = new OrderRequest
            {
                SenderLocation = new Location { City = "Санкт-Петербург", Address = "ул. Абвгдейкина, 35-17" },
                ReceiverLocation = new Location { City = "Санкт-Петербург", Address = "ул. Абвгдейкина, 35-17" },
                Cargo = new Cargo { Weight = 10, PickupDate = DateTime.UtcNow }
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await _deliveryService.CreateOrder(orderRequest));
        }

        [Test]
        public void GetOrder_WhenNoOrderWithSuchId_Throws()
        {
            Assert.ThrowsAsync<KeyNotFoundException>(async() => await _deliveryService.GetOrder(1234));
        }

        [Test]
        public async Task GetOrder_WhenOrderExists_ReturnsOrder()
        {
            int orderId = 1;
            var orderRequest = GetOrderRequest();
            var expectedOrder = Map(orderRequest, orderId);
            await _deliveryService.CreateOrder(orderRequest);
            var order = await _deliveryService.GetOrder(orderId);
            CheckEquals(order, expectedOrder);
        }

        [Test]
        public async Task GetOrders_WhenNoOrders_ReturnsEmptyCollection()
        {
            var orders = await _deliveryService.GetOrders();
            Assert.That(orders is not null);
            Assert.That(orders!.Count == 0);
        }

        [Test]
        public async Task GetOrders_WhenCreateFiveOrders_ReturnsFiveOrders()
        {
            int ordersCount = 5;
            List<OrderRequest> orderRequests = Enumerable.Range(1, ordersCount).Select(x => GetOrderRequest()).ToList();
            List<Order> expectedOrders = orderRequests.Select((x, i) => Map(x, i + 1)).ToList();
            
            foreach (var orderRequest in orderRequests)
                await _deliveryService.CreateOrder(orderRequest);

            var orders = await _deliveryService.GetOrders();

            Assert.That(orders, Has.Count.EqualTo(ordersCount));

            int i = 0;
            foreach (var order in orders)
            {
                CheckEquals(order, expectedOrders[i]);
                i++;
            }
        }

        private OrderRequest GetOrderRequest()
        {
            return new OrderRequest
            {
                SenderLocation = new Location { City = "Санкт-Петербург", Address = "ул. Абвгдейкина, 35-17" },
                ReceiverLocation = new Location { City = "Москва", Address = "ул. Абвгдежа, 17-28" },
                Cargo = new Cargo { Weight = 10, PickupDate = DateTime.UtcNow }
            };
        }

        private Order Map(OrderRequest orderRequest, int id)
        {
            return new Order
            {
                Id = id,
                SenderCity = orderRequest.SenderLocation.City,
                SenderAddress = orderRequest.SenderLocation.Address,
                ReceiverCity = orderRequest.ReceiverLocation.City,
                ReceiverAddress = orderRequest.ReceiverLocation.Address,
                CargoWeight = orderRequest.Cargo.Weight,
                CargoPickupDate = orderRequest.Cargo.PickupDate,
            };
        }

        private void CheckEquals(Order realOrder, Order expectedOrder)
        {
            Assert.That(AreEqual(realOrder, expectedOrder));
        }

        private static bool AreEqual(Order order, Order anotherOrder)
        {
            return anotherOrder is not null
                && order.Id == anotherOrder.Id
                && order.SenderCity == anotherOrder.SenderCity
                && order.SenderAddress == anotherOrder.SenderAddress
                && order.ReceiverCity == anotherOrder.ReceiverCity
                && order.ReceiverAddress == anotherOrder.ReceiverAddress
                && order.CargoWeight == anotherOrder.CargoWeight
                && order.CargoPickupDate == anotherOrder.CargoPickupDate;
        }
    }
}
