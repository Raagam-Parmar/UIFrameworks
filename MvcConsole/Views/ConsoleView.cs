// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using MvcConsole.Models.Interfaces;
using MvcConsole.Views.Interfaces;

namespace MvcConsole.Views;

/// <inheritdoc/>
public class ConsoleView(ICounter counter) : IConsoleView
{
    public void View()
    {
        // \r moves the cursor to the start of the line.
        // \u001b[2K clears the current line to prevent trailing characters if the number shrinks.
        Console.Write($"\u001b[2K\rCounter: {counter.GetCount()}");
    }
}
