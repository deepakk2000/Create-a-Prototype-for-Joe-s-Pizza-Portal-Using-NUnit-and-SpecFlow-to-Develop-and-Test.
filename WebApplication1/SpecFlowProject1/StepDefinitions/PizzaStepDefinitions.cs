using System;
using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WebApplication1.Controllers;
using Assert = NUnit.Framework.Assert;

namespace WebApplication1.SpecFlow.StepDefinitions
{
    [Binding]
    public class PizzaStepDefinitions
    {
        private readonly PizzaController pizzaController;
        private IActionResult actionResult;
        private ViewResult viewResult;

        public PizzaStepDefinitions()
        {
            pizzaController = new PizzaController();
        }

        [Given(@"I am on the Pizza Selection page")]
        public void GivenIAmOnThePizzaSelectionPage()
        {
            actionResult = pizzaController.Index();
        }

        [When(@"I select ""([^""]*)"" from the menu")]
        public void WhenISelectFromTheMenu(string pizzaType)
        {
            var id = GetPizzaIdByType(pizzaType);
            actionResult = pizzaController.Cart(id);
        }

        [When(@"I proceed to checkout")]
        public void WhenIProceedToCheckout()
        {
            viewResult = actionResult as ViewResult;
            Assert.IsNotNull(viewResult);
        }

        [Then(@"I should be on the Order Checkout page")]
        public void ThenIShouldBeOnTheOrderCheckoutPage()
        {
            Assert.IsNotNull(viewResult);
            Assert.AreEqual("Cart", viewResult.ViewName);
        }

        [When(@"I select an invalid pizza type ""([^""]*)""")]
        public void WhenISelectAnInvalidPizzaType(string invalidPizza)
        {
            actionResult = pizzaController.Cart(0); // Assuming 0 is an invalid PizzaId
        }

        [Then(@"I should be redirected to the Pizza Selection page")]
        public void ThenIShouldBeRedirectedToThePizzaSelectionPage()
        {
            var redirectToActionResult = actionResult as RedirectToActionResult;
            Assert.IsNotNull(redirectToActionResult);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private int GetPizzaIdByType(string pizzaType)
        {
            foreach (var pizza in PizzaController.pizzadetails)
            {
                if (pizza.Type.Equals(pizzaType, StringComparison.OrdinalIgnoreCase))
                {
                    return pizza.PizzaId;
                }
            }
            return 0; // Return 0 for an invalid PizzaId
        }
    }
}