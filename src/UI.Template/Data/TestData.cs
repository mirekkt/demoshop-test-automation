// Copyright (c) 2026 Alza.cz a.s. All rights reserved.
//
// This code is provided solely for technical interview purposes.
// Commercial use and use outside Alza.cz recruitment process is prohibited.

using UI.Template.Models;

namespace UI.Template.Data;

public static class TestData
{
    public static TestProduct ParametersTestProduct { get; } = new TestProduct
    {
        ProductCategory = "Accessories",
        ProductName = "Wireless Mouse",
        ProductUrl = "/product/2"
    };

    public static TestProduct CardTestProduct { get; } = new TestProduct
    {
        ProductCategory = "Accessories",
        ProductName = "Gaming Keyboard RGB"
    };

    public static TestProduct NewCameraProduct { get; } = new TestProduct
    {
        ProductCategory = "Cameras",
        ProductName = "Camera M25",
        ProductPrice = 50.5,
        ProductStock = 5,
        ProductImage = "Camera 2",
        ProductDescription = "Camera"
    };

    public static TestProduct CameraCheckoutProduct { get; } = new TestProduct
    {
        ProductCategory = "Cameras",
        ProductName = "DSLR Camera X200"
    };
}
