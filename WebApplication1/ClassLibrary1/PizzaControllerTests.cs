using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace ClassLibrary1
{
    [TestFixture]
    public class PizzaControllerTests
    {
        private PizzaController pizzaController;

        [SetUp]
        public void Setup()
        {
            // Assuming you have any necessary setup logic here
            pizzaController = new PizzaController();
        }

        [Test]
        public void Index_ReturnsViewWithPizzaDetails()
        {
            // Arrange & Act
            var result = pizzaController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<Pizza>>(result.Model);
        }
        [Test]
        public void Index_ReturnsFirstPizza()
        {
            // Act
            var result = pizzaController.Index();

            // Assert
            Assert.IsNotNull(result);
            
        }
       

        [Test]
        public void Checkout_ReturnsViewWithOrderDetails()
        {
            // Arrange & Act
            var result = pizzaController.Checkout() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<OrderInfo>>(result.Model);
        }

        // Add more tests as needed for your specific actions in PizzaController
    }
}
