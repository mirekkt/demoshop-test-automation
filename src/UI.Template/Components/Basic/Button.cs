// Copyright (c) 2026 Alza.cz a.s. All rights reserved.
//
// This code is provided solely for technical interview purposes.
// Commercial use and use outside Alza.cz recruitment process is prohibited.

using OpenQA.Selenium;

namespace UI.Template.Components.Basic;

/// <summary>
/// Wraps IWebElement and acts as a button or input[type=text] or whatever we want to be a button.
/// </summary>
public class Button : BaseComponent
{
    public Button() { }

    public Button(By locator) : base(locator) { }

    public Button(By locator, ISearchContext searchContext) : base(locator, searchContext) { }

    /// <summary>
    /// Clicks and synchronizes the code after.
    /// </summary>
    public override void Click()
    {
        WaitForEnabled();
        base.Click();
        WaitForReady();
    }

    /// <summary>
    /// Clicks using JS and synchronizes the code after.
    /// </summary>
    public override void ClickJS()
    {
        WaitForEnabled();
        base.ClickJS();
        WaitForReady();
    }
}
