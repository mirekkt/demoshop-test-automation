using OpenQA.Selenium;
using UI.Template.Components.Basic;

namespace UI.Template.Pages;

public class CheckoutPage() : BaseEshopPage("/checkout")
{
    private readonly TextInput _firstName    = new(By.Id("firstName"));
    private readonly TextInput _lastName     = new(By.Id("lastName"));
    private readonly TextInput _street       = new(By.Id("street"));
    private readonly TextInput _city         = new(By.Id("city"));
    private readonly TextInput _zipCode      = new(By.Id("zipCode"));
    private readonly TextInput _email        = new(By.Id("email"));
    private readonly TextInput _phoneNumber  = new(By.Id("phoneNumber"));
    private readonly DropDownList _delivery  = new(By.Id("deliveryMethod"));
    private readonly DropDownList _payment   = new(By.Id("paymentMethod"));
    private readonly Button _payButton       = new(By.XPath("//button[@class='pay-button']"));

    public void FillMandatoryFields(
        string firstName, string lastName, string street,
        string city, string zip, string email, string phone)
    {
        _firstName.Clear();
        _firstName.SendKeys(firstName);
        _lastName.Clear();
        _lastName.SendKeys(lastName);
        _street.Clear();
        _street.SendKeys(street);
        _city.Clear();
        _city.SendKeys(city);
        _zipCode.Clear();
        _zipCode.SendKeys(zip);
        _email.Clear();
        _email.SendKeys(email);
        _phoneNumber.Clear();
        _phoneNumber.SendKeys(phone);
    }

    public void SelectDeliveryMethod(string method)
        => _delivery.SelectByText(method);

    public void SelectPaymentMethod(string method)
        => _payment.SelectByText(method);

    public OrderConfirmationPage Pay()
    {
        _payButton.Click();
        OrderConfirmationPage confirmationPage = new();
        confirmationPage.WaitForReady();
        return confirmationPage;
    }
}