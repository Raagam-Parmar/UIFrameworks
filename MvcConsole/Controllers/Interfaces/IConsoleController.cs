// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MvcConsole.Controllers.Interfaces;

/// <summary>
/// A console-based controller
/// </summary>
public interface IConsoleController
{
    /// <summary>
    /// Run the controller
    /// </summary>
    void Run();
}
