// Copyright (c) 2026 Alza.cz a.s. All rights reserved.
//
// This code is provided solely for technical interview purposes.
// Commercial use and use outside Alza.cz recruitment process is prohibited.

namespace UI.Template.Framework.Attributes;

/// <summary>
/// Attribute to use for enum values to provide a name/alternative name for the value.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public class NameAttribute(string name) : Attribute
{
    /// <summary>
    /// Value of the attribute
    /// </summary>
    public string Name { get; } = name;
}
