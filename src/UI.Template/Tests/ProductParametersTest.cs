// Copyright (c) 2026 Alza.cz a.s. All rights reserved.
//
// This code is provided solely for technical interview purposes.
// Commercial use and use outside Alza.cz recruitment process is prohibited.

using UI.Template.Components;
using UI.Template.Data;
using UI.Template.Framework.Extensions;
using UI.Template.Models;
using UI.Template.Pages;

namespace UI.Template.Tests;

[TestFixture]
public class ProductParametersTest : BaseTest
{
    [Test]
    public void CheckProductParametersTest()
    {
        // TC description:
        // 1. Go to the demoshop homepage.
        // 2. Check that the current category is "All".
        // 3. Get values for the "Wireless Mouse" card:
        //   - Heading: Wireless Mouse
        //   - Price: 30.00
        //   - Availability: 50
        // 5. Open the "Wireless Mouse" detail in the "Accessories" category.
        // 6. Verify/Compare card values vs. detail values.


        TestProduct _testProduct = TestData.ParametersTestProduct;

        /*** STEPS 1-2 ***/
        HomePage homePage = new();
        homePage.Open();

        homePage.WaitForReady();

        Assert.Multiple(() =>
        {
            Assert.That(WebDriver.UrlPath(), Is.EqualTo("/"), "Homepage is not opened");
            Assert.That(homePage.GetCurrentCategory(), Is.EqualTo("All"), "Active category does not match expected 'All'");
        });


        /*** STEP 3 ***/
        if (!homePage.TryGetProductCardByName(_testProduct.ProductName, out ProductCard productCard))
        {
            Assert.Fail($"Product '{_testProduct.ProductName}' not found on the home page.");
        }

        productCard.WaitForReady();
        Product productModelFromCard = productCard.ToProductModel();

        Assert.Multiple(() =>
        {
            Assert.That(productModelFromCard.Name, Is.Not.Null.And.Not.Empty, "Failed to find product name");
            Assert.That(productModelFromCard.Price, Is.GreaterThan(0), "Failed to find product price");
            Assert.That(productModelFromCard.Stock, Is.GreaterThan(0), "Failed to find product availability");
        });


        /*** STEP 5 ***/
        ProductDetailPage productDetail = homePage.OpenProductByNameFromCategory(_testProduct.ProductCategory,
                                                                                 _testProduct.ProductName);

        productDetail.WaitForReady();
        Product productModelFromDetail = productDetail.ProductInfoForm.ToProductModel();

        Assert.That(WebDriver.UrlPath(), Is.EqualTo(_testProduct.ProductUrl), "Product URL does not match expected URL");


        /*** STEP 6 ***/
        Assert.Multiple(() =>
        {
            Assert.That(productModelFromDetail.Name, Is.Not.Null.And.Not.Empty, "Failed to find product name");
            Assert.That(productModelFromDetail.Price, Is.GreaterThan(0), "Failed to find product price");
            Assert.That(productModelFromDetail.Stock, Is.GreaterThan(0), "Failed to find product availability");
        });

        List<string> diffs = [.. productModelFromDetail.GetDifferences(productModelFromCard)];
        Assert.That(diffs, Is.Empty, $"The product info on the card and detail page are different: {string.Join("; ", diffs)}");
    }
}
