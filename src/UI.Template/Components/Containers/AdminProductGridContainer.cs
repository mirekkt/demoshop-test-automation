// Copyright (c) 2026 Alza.cz a.s. All rights reserved.
//
// This code is provided solely for technical interview purposes.
// Commercial use and use outside Alza.cz recruitment process is prohibited.

using OpenQA.Selenium;
using UI.Template.Framework.Extensions;

namespace UI.Template.Components.Containers;

public class AdminProductGridContainer(By locator) : BaseComponent(locator)
{
    /// <summary>
    /// Gets all product cards in the admin product grid container.
    /// </summary>
    /// <returns>A dictionary of product names and their corresponding product cards.</returns>
    public Dictionary<string, AdminProductCard> GetProductCards()
    {
        Dictionary<string, AdminProductCard> productCards = [];
        By productCardXPathLocator = By.XPath(Locator.ToSelector() + "//div[@class='product-card']");

        if (!Wait.TryWaitWithCondition(() => WebDriver.FindElements(productCardXPathLocator).Count > 0, timeout: 5))
        {
            Logger.LogWarning("There are no products in the admin product grid container.");
            return productCards;
        }

        int productCardsCount = WebDriver.FindElements(productCardXPathLocator).Count;
        for (int i = 1; i <= productCardsCount; i++)
        {
            AdminProductCard productCard = new(By.XPath($"({productCardXPathLocator.ToSelector()})[{i}]"));
            productCard.ScrollTo();
            productCards.Add(productCard.GetName(), productCard);
        }

        return productCards;
    }
}
