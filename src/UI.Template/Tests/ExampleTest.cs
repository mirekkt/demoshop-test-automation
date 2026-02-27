// Copyright (c) 2026 Alza.cz a.s. All rights reserved.
//
// This code is provided solely for technical interview purposes.
// Commercial use and use outside Alza.cz recruitment process is prohibited.

using UI.Template.Pages;

namespace UI.Template.Tests;

[TestFixture]
public class ExampleTest : BaseTest
{
    [Test]
    public void HomePageTest()
    {
        HomePage homePage = new();
        homePage.Open();
        bool addedToBasket = homePage.AddToBasketFirstProductFromCategory("Electronics");

        Assert.That(addedToBasket, Is.True, "Product was not added to the basket.");
    }
}
