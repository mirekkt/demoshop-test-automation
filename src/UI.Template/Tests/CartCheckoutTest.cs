using UI.Template.Data;
using UI.Template.Models;
using UI.Template.Pages;

namespace UI.Template.Tests;

[TestFixture]
public class CartCheckoutTest : BaseTest
{
    [Test]
    public void CartCheckoutWithPayPalTest()
    {
        // TC steps:
        // 1. Go to the demoEshop.
        // 2. Go to category "Cameras".
        // 3. Add "DSLR Camera X200" to cart via "Add" button.
        // 4. Open cart - verify product name, price and quantity.
        // 5. Proceed to checkout.
        // 6. Fill in all mandatory fields.
        // 7. Select PayPal as payment method.
        // 8. Click Pay and complete the order.
        // 9. Verify total price and payment method on confirmation page.

        TestProduct testProduct = TestData.CameraCheckoutProduct;

        /*** STEPS 1-3 ***/
        HomePage homePage = new();
        homePage.Open();

        bool added = homePage.AddToBasketFirstProductFromCategory(testProduct.ProductCategory);
        Assert.That(added, Is.True, "Product was not added to the basket.");

        /*** STEP 4 ***/
        homePage.Header.OpenBasketContainer();

        Assert.That(
            homePage.Header.GetNthProduct(1, out string productName, out _),
            Is.True,
            "No product found in the basket."
        );
        Assert.That(productName, Is.EqualTo(testProduct.ProductName),
            "Product name in basket does not match expected.");
        Assert.That(homePage.Header.GetBasketCount(), Is.EqualTo(1),
            "Basket count should be 1.");

        /*** STEPS 5-8 ***/
        CheckoutPage checkoutPage = homePage.Header.GoToCheckout();

        checkoutPage.FillMandatoryFields(
            firstName : "Test",
            lastName  : "User",
            street    : "Hlavní Třída 123",
            city      : "Ostrava",
            zip       : "70800",
            email     : "test@example.com",
            phone     : "123456789"
        );

        checkoutPage.SelectDeliveryMethod("Pick up at the branch (Free)");
        checkoutPage.SelectPaymentMethod("PayPal");

        OrderConfirmationPage confirmationPage = checkoutPage.Pay();

        /*** STEP 9 ***/
        Assert.Multiple(() =>
        {
            Assert.That(confirmationPage.GetPaymentMethod(),
                Does.Contain("PayPal"),
                "Payment method on confirmation page does not match.");
            Assert.That(confirmationPage.GetTotalPrice(),
                Is.Not.Empty,
                "Total price on confirmation page should not be empty.");
        });
    }
}