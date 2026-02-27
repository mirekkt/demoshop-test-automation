// Copyright (c) 2026 Alza.cz a.s. All rights reserved.
//
// This code is provided solely for technical interview purposes.
// Commercial use and use outside Alza.cz recruitment process is prohibited.

using Serilog.Core;
using Serilog.Events;
using UI.Template.NUnit;

namespace UI.Template.Framework.Logging;

/// <summary>
/// Enriches the logger with the test class name.
/// </summary>
public sealed class TestClassLogEnricher : ILogEventEnricher
{
    /// <inheritdoc />
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        ArgumentNullException.ThrowIfNull(logEvent);

        logEvent.AddPropertyIfAbsent(new LogEventProperty("TestClass", new ScalarValue(TestInfo.ClassName)));
    }
}
