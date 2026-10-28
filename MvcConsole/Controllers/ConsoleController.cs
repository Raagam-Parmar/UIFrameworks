// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using MvcConsole.Controllers.Interfaces;
using MvcConsole.Models;
using MvcConsole.Models.Interfaces;
using MvcConsole.Views;
using MvcConsole.Views.Interfaces;

namespace MvcConsole.Controllers;

public class ConsoleController : IConsoleController
{
    private readonly ICounter _counter;
    private readonly IConsoleView _consoleView;

    public ConsoleController()
    {
        _counter = new Counter();
        _consoleView = new ConsoleView(_counter);
    }

    public void Run()
    {
        Console.WriteLine("Counter controls: (I) Increment (D) Decrement (Q) Quit");
        _consoleView.View();

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

            if (keyInfo.Key == ConsoleKey.Q)
            {
                Console.WriteLine("Quit");
                break;
            }

            if (keyInfo.Key == ConsoleKey.I)
            {
                _counter.Increment();
            }

            if (keyInfo.Key == ConsoleKey.D)
            {
                _counter.Decrement();
            }

            _consoleView.View();
        }
    }
}
