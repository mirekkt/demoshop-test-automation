// Copyright (c) 2026 Alza.cz a.s. All rights reserved.
//
// This code is provided solely for technical interview purposes.
// Commercial use and use outside Alza.cz recruitment process is prohibited.

using OpenQA.Selenium;
using UI.Template.Framework.Extensions;

namespace UI.Template.Components.Containers;

public class ProductGridContainer(By locator) : BaseComponent(locator)
{
    public Dictionary<string, ProductCard> GetProductCards()
    {
        Dictionary<string, ProductCard> productCards = [];
        By productCardXPathLocator = By.XPath(Locator.ToSelector() + "//div[@class='product-card']");

        if (!Wait.TryWaitWithCondition(() => WebDriver.FindElements(productCardXPathLocator).Count > 0, timeout: 5))
        {
            Logger.LogWarning("There are no products in the product grid container.");
            return productCards;
        }

        int productCardsCount = WebDriver.FindElements(productCardXPathLocator).Count;
        for (int i = 1; i <= productCardsCount; i++)
        {
            ProductCard productCard = new(By.XPath($"({productCardXPathLocator.ToSelector()})[{i}]"));
            productCard.ScrollTo();
            productCards.Add(productCard.GetName(), productCard);
        }

        return productCards;
    }
}
