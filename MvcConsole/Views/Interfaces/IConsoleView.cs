// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MvcConsole.Views.Interfaces;

/// <summary>
/// A simple view for consoles
/// </summary>
public interface IConsoleView
{
    /// <summary>
    /// Clear the console and show the new view
    /// </summary>
    public void View();
}
