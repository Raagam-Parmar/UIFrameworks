// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using MvpConsole.Models;
using MvpConsole.Models.Interfaces;
using MvpConsole.Presenters;
using MvpConsole.Presenters.Interfaces;
using MvpConsole.Views;
using MvpConsole.Views.Interfaces;

namespace MvpConsole;

internal class Program
{
    static void Main(string[] args)
    {
        IStackMachine machine = new StackMachine();
        IConsoleView consoleView = new ConsoleView();
        IConsolePresenter consolePresenter = new ConsolePresenter(machine, consoleView);

        consoleView.Run();
    }
}
