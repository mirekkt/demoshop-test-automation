// Copyright (c) 2026 Alza.cz a.s. All rights reserved.
//
// This code is provided solely for technical interview purposes.
// Commercial use and use outside Alza.cz recruitment process is prohibited.

namespace UI.Template.Models;

public class TestProduct
{
    public string ProductCategory { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string ProductUrl { get; set; } = string.Empty;
    public double ProductPrice { get; set; }
    public int ProductStock { get; set; }
    public string ProductImage { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
}
