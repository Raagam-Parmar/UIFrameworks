// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using MvcConsole.Controllers;
using MvcConsole.Controllers.Interfaces;

namespace MvcConsole;

internal class Program
{
    private static readonly IConsoleController s_consoleController = new ConsoleController();

    static void Main(string[] args)
    {
        s_consoleController.Run();
    }
}
