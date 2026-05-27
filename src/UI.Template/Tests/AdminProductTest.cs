using UI.Template.Data;
using UI.Template.Models;
using UI.Template.Pages;

namespace UI.Template.Tests;

[TestFixture]
public class AdminProductTest : BaseTest
{
    [Test]
    public void AddAndVerifyNewProductTest()
    {
        // TC steps:
        // 1. Go to the Admin panel.
        // 2. Add a new product with specified parameters.
        // 3. Save the new product.
        // 4. Navigate from Admin panel to the eshop.
        // 5. Go to the "Cameras" category.
        // 6. Open the detail of the newly added product "Camera M25".
        // 7. Compare Name, Price and Stock values with those entered in step 2

        TestProduct testProduct = TestData.NewCameraProduct;

        /*** STEP 1 ***/
        AdminPage adminPage = new();
        adminPage.Open();

        /*** STEP 2 ***/
        var editContainer = adminPage.OpenAddNewProductContainer();
        editContainer.SetName(testProduct.ProductName);
        editContainer.SelectCategory(testProduct.ProductCategory);
        editContainer.SetPrice(testProduct.ProductPrice);
        editContainer.SetStock(testProduct.ProductStock);
        editContainer.SelectImage(testProduct.ProductImage);
        editContainer.SetDescription(testProduct.ProductDescription);

        /*** STEP 3 ***/
        editContainer.SaveChanges();

        Assert.That(
            adminPage.TryGetProductCardByName(testProduct.ProductName, out _),
            Is.True,
            $"Product '{testProduct.ProductName}' was not found in the admin panel after saving."
        );

        /*** STEP 4 ***/
        HomePage homePage = adminPage.GoToEshopHome();

        /*** STEPS 5-6 ***/
        ProductDetailPage productDetail = homePage.OpenProductByNameFromCategory(
            testProduct.ProductCategory,
            testProduct.ProductName
        );

        productDetail.WaitForReady();
        Product productModel = productDetail.ProductInfoForm.ToProductModel();

        /*** STEP 7 ***/
        Assert.Multiple(() =>
        {
            Assert.That(productModel.Name, Is.EqualTo(testProduct.ProductName),   
                "Product name on detail page does not match the entered value.");
            Assert.That(productModel.Price, Is.EqualTo(testProduct.ProductPrice),
                "Product price on detail page does not match the entered value.");
            Assert.That(productModel.Stock, Is.EqualTo(testProduct.ProductStock),
                "Product stock on detail page does not match the entered value.");
        });
    }
}