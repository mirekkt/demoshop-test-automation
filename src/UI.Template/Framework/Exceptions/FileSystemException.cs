// Copyright (c) 2026 Alza.cz a.s. All rights reserved.
//
// This code is provided solely for technical interview purposes.
// Commercial use and use outside Alza.cz recruitment process is prohibited.

namespace UI.Template.Framework.Exceptions;

/// <summary>
/// Represents an exception that is thrown when some error is raised during reading or writing to the file system.
/// E.g. file is not found, cannot create new directory or file.
/// </summary>
public class FileSystemException : Exception
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    public FileSystemException()
    {
    }

    /// <summary>
    /// Constructor with message.
    /// </summary>
    /// <param name="message">Message to be printed in exception.</param>
    public FileSystemException(string message) : base(message)
    {
    }

    /// <summary>
    /// Constructor with message.
    /// </summary>
    /// <param name="message">Message to be printed in exception.</param>
    /// <param name="innerException">Exception from <see cref="Exception.InnerException"/></param>
    public FileSystemException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
