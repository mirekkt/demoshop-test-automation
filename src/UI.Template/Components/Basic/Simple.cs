// Copyright (c) 2026 Alza.cz a.s. All rights reserved.
//
// This code is provided solely for technical interview purposes.
// Commercial use and use outside Alza.cz recruitment process is prohibited.

using OpenQA.Selenium;

namespace UI.Template.Components.Basic;

/// <summary>
/// Wraps IWebElement so that it behaves like any other BaseComponent.
/// </summary>
///
/// We can use methods like:
/// - WaitForDisplayed
/// - WaitForPresent
/// ... see BaseComponent for more
public class Simple : BaseComponent
{
    public Simple(By locator) : base(locator) { }

    public Simple(By locator, ISearchContext searchContext) : base(locator, searchContext) { }

    /// <inheritdoc/>
    public override void ScrollToAndClick()
    {
        ScrollTo();
        Click();
    }
}
