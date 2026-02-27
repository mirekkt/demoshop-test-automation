// Copyright (c) 2026 Alza.cz a.s. All rights reserved.
//
// This code is provided solely for technical interview purposes.
// Commercial use and use outside Alza.cz recruitment process is prohibited.

using UI.Template.Data;
using UI.Template.Models;
using UI.Template.Pages;

namespace UI.Template.Tests;

[TestFixture]
public class CartTest : BaseTest
{
    [Test]
    public void AddProductToCartTest()
    {
        // TC description:
        // 1. Go to the demoshop homepage.
        // 2. Check that the current category is "All".
        // 3. Go to the "Accessories" section.
        // 4. Go to the "Gaming Keyboard RGB" product detail.
        // 5. Add 1 item to the cart using the "Add to Cart" button.
        // 6. Open the cart and check the items in it.
        // 7. Close the cart by clicking the "X".
        // 8. Return to the homepage from the product detail page.
        // 9. Check that the current category is "All".

        TestProduct _testProduct = TestData.CardTestProduct;

        //*** STEP 1 ***/
        HomePage homePage = new();
        homePage.Open();

        //*** STEP 2 ***/
        Assert.That(homePage.GetCurrentCategory(), Is.EqualTo("All"), "The current category is not 'All'");

        //*** STEPS 3-4 ***/
        ProductDetailPage productDetail = homePage.OpenProductByNameFromCategory(_testProduct.ProductCategory, _testProduct.ProductName);

        //*** STEP 5 ***/
        productDetail.ProductInfoForm.AddToCart();
        Assert.That(productDetail.Header.GetBasketCount(), Is.EqualTo(1), "Basket count is not 1. Check Add to Cart functionality.");

        //*** STEP 6 ***/
        productDetail.Header.OpenBasketContainer();
        Assert.That(productDetail.Header.GetNthProduct(1, out string productName, out _), Is.True, "The first product in the basket was not found");
        Assert.That(productName, Is.EqualTo(_testProduct.ProductName), "The name of product in the basket is not same as in test data");

        //*** STEP 7 ***/
        productDetail.Header.CloseBasketContainer();

        //*** STEPS 8-9 ***/
        productDetail.ProductInfoForm.BackToShop();
        Assert.That(homePage.GetCurrentCategory(), Is.EqualTo("All"), "The current category is not 'All'");
    }
}
