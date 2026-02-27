// Copyright (c) 2026 Alza.cz a.s. All rights reserved.
//
// This code is provided solely for technical interview purposes.
// Commercial use and use outside Alza.cz recruitment process is prohibited.

using OpenQA.Selenium;
using UI.Template.Framework.Helpers;

namespace UI.Template.Framework.Extensions;

/// <summary>
/// Holds extension methods for <see cref="By"/> locators.
/// </summary>
public static class ByExtensions
{
    /// <summary>
    /// Returns locator as string.
    /// </summary>
    /// <param name="by"><see cref="By"/></param>
    /// <returns>string</returns>
    public static string ToSelector(this By by)
    {
        var s = by.ToString();
        return GeneratedRegex.SelectorRegex().Replace(s, "$1");
    }
}
