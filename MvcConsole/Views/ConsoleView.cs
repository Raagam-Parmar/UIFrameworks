// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using MvcConsole.Models.Interfaces;

namespace MvcConsole.Views;

public class ConsoleView(ICounter counter)
{
    public void View()
    {
        Console.Clear();
        Console.WriteLine($"Counter: {counter.GetCount()}");
    }
}
