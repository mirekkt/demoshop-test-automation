using OpenQA.Selenium;
using UI.Template.Components.Basic;
using UI.Template.Framework.Extensions;

namespace UI.Template.Pages;

public class OrderConfirmationPage() : BaseEshopPage("/confirmation")
{
    private readonly Simple _confirmationContainer = new(By.XPath("//*[@class='order-confirmation']"));
    private readonly Simple _totalValue            = new(By.XPath("//*[@ko-id='order-total-value']"));
    private readonly Simple _paymentMethod         = new(By.XPath("//*[@ko-id='order-paymentMethod']"));
    private readonly Button _backToShopButton      = new(By.XPath("//button[contains(@class,'back')]"));

    public override bool IsReady()
        => base.IsReady() && _confirmationContainer.IsDisplayed();

    public string GetTotalPrice()
        => _totalValue.GetText().Trim();

    public string GetPaymentMethod()
        => _paymentMethod.GetText().Trim();

    public HomePage BackToShop()
    {
        WebDriver.WaitForUrlChanged(() => _backToShopButton.Click());
        return new HomePage();
    }
}