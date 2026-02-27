// Copyright (c) 2026 Alza.cz a.s. All rights reserved.
//
// This code is provided solely for technical interview purposes.
// Commercial use and use outside Alza.cz recruitment process is prohibited.

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using UI.Template.Framework.Configurations;
using UI.Template.Framework.Extensions;

namespace UI.Template.Framework.Factories;

/// <summary>
/// Holds logic for constructing and deconstructing <see cref="IWebDriver"/> object.
/// </summary>
public static class WebDriverFactory
{
    /// <summary>
    /// Method initialize <see cref="IWebDriver"/> session
    /// </summary>
    /// <param name="driverOptions">specific <see cref="DriverOptions"/> to be applied to local or remote webdriver</param>
    /// <returns>New created WebDriver session</returns>
    public static IWebDriver InitializeWebDriver(DriverOptions? driverOptions = null)
    {
        Globals.Logger.LogInformation("Initializing a WebDriver session");
        IWebDriver webDriver;
        driverOptions ??= CreateDefaultChromeOptions();

        if (TestConfiguration.IsRemote)
        {
            webDriver = new RemoteWebDriver(new Uri(TestConfiguration.SeleniumHubUrl), driverOptions);
        }
        else
        {
            // Always ensure driverOptions is ChromeOptions and not null
            var chromeOptions = driverOptions as ChromeOptions ?? throw new ArgumentException("driverOptions must be of type ChromeOptions for local execution.");
            webDriver = new ChromeDriver(chromeOptions);
        }

        webDriver.SetWindowSize(TestConfiguration.WindowSize);
        Globals.Logger.LogVerbose($"New created WebDriver session is '{webDriver.GetSessionId()}'");
        return webDriver;
    }

    /// <summary>
    /// Creates default ChromeOptions with recommended settings.
    /// </summary>
    public static ChromeOptions CreateDefaultChromeOptions()
    {
        var options = new ChromeOptions
        {
            PageLoadStrategy = PageLoadStrategy.Default
        };
        options.SetLoggingPreference(LogType.Browser, LogLevel.All);
        if (TestConfiguration.IsHeadless)
            AddArgument(options, "--headless=new");
        AddArgument(options, "--remote-allow-origins=*");
        AddArgument(options, "--disable-dev-shm-usage");
        AddArgument(options, "--disable-search-engine-choice-screen");
        AddArgument(options, "--incognito");
        return options;
    }

    private static void AddArgument(ChromeOptions options, string argument)
    {
        if (!options.Arguments.Contains(argument))
            options.AddArgument(argument);
    }

    /// <summary>
    /// Creates a default ChromeDriverService with recommended settings.
    /// </summary>
    public static ChromeDriverService CreateDefaultChromeDriverService()
    {
        var service = ChromeDriverService.CreateDefaultService();
        service.LogPath = "../../../chromedriver.log";
        service.EnableVerboseLogging = true;
        return service;
    }
}
