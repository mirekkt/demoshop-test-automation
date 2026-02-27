// Copyright (c) 2026 Alza.cz a.s. All rights reserved.
//
// This code is provided solely for technical interview purposes.
// Commercial use and use outside Alza.cz recruitment process is prohibited.

using System.Globalization;
using OpenQA.Selenium;
using UI.Template.Components.Basic;
using UI.Template.Framework.Extensions;

namespace UI.Template.Components.Containers;

public class EditProductContainer(By locator) : BaseComponent(locator)
{
    public TextInput Name => new(By.XPath($"{Locator.ToSelector()}//*[@id='name']"));
    public DropDownList Category => new(By.XPath($"{Locator.ToSelector()}//*[@id='category']"));
    public TextInput Price => new(By.XPath($"{Locator.ToSelector()}//*[@id='price']"));
    public TextInput Stock => new(By.XPath($"{Locator.ToSelector()}//*[@id='stock']"));
    public DropDownList Image => new(By.XPath($"{Locator.ToSelector()}//*[@id='imageUrl']"));
    public TextInput Description => new(By.XPath($"{Locator.ToSelector()}//*[@id='description']"));
    public Button SaveButton => new(By.XPath($"{Locator.ToSelector()}//button[@class='save-button']"));

    /// <summary>
    /// Sets the name of the product.
    /// </summary>
    /// <param name="value">The name to set.</param>
    public void SetName(string value)
    {
        Name.Clear();
        Name.SendKeys(value);
    }

    /// <summary>
    /// Selects category from the dropdown.
    /// </summary>
    /// <param name="categoryName">The category name for selection.</param>
    public void SelectCategory(string categoryName) => Category.SelectByText(categoryName);

    /// <summary>
    /// Sets the price of the product.
    /// </summary>
    /// <param name="value">The price to set.</param>
    public void SetPrice(double value)
    {
        Price.Clear();
        Price.SendKeys(value.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Opens the basket container.
    /// </summary>
    public void SetStock(int value)
    {
        Stock.Clear();
        Stock.SendKeys(value.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Selects image from the dropdown.
    /// </summary>
    public void SelectImage(string imageName)
    {
        Image.SelectByText(imageName);
    }

    /// <summary>
    /// Sets the description of the product.
    /// </summary>
    /// <param name="value">The description to set.</param>
    public void SetDescription(string value)
    {
        Description.Clear();
        Description.SendKeys(value);
    }

    /// <summary>
    /// Clicks the UpdateProductButton button.
    /// </summary>
    public void SaveChanges()
    {
        SaveButton.Click();
        WaitForNotDisplayed();
    }

}
