// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using MvpConsole.Models.Interfaces;
using MvpConsole.Presenters.Interfaces;
using MvpConsole.Views.Interfaces;

namespace MvpConsole.Presenters;

public class ConsolePresenter : IConsolePresenter
{
    private readonly IStackMachine _machine;
    private readonly IConsoleView _consoleView;

    private readonly string _underflowResponse = "Not enough elements";
    private readonly string _zeroDivisionResponse = "Can not divide by zero";
    private readonly string _nanResponse = "Not a number";
    private readonly Func<string, string> _successResponse = (operation) => $"Executed {operation}";

    public ConsolePresenter(IStackMachine machine, IConsoleView consoleView)
    {
        _machine = machine;
        _consoleView = consoleView;

        _consoleView.TildePressed += OnTildePressed;
        _consoleView.PlusPressed += OnPlusPressed;
        _consoleView.MinusPressed += OnMinusPressed;
        _consoleView.StarPressed += OnStarPressed;
        _consoleView.ForwardSlashPressed += OnForwardSlashPressed;
        _consoleView.ReturnPressed += OnReturnPressed;
    }

    private void OnTildePressed()
    {
        NonDivisionError result = _machine.Negate();

        switch (result)
        {
            case NonDivisionError.UnderFlow:
                _consoleView.Response(_underflowResponse);
                break;

            case NonDivisionError.Success:
                _consoleView.Response(_successResponse("~"));
                _consoleView.UpdateStack(_machine.GetStack());
                break;
        }
    }

    private void OnPlusPressed()
    {
        NonDivisionError result = _machine.Add();

        switch (result)
        {
            case NonDivisionError.UnderFlow:
                _consoleView.Response(_underflowResponse);
                break;

            case NonDivisionError.Success:
                _consoleView.Response(_successResponse("+"));
                _consoleView.UpdateStack(_machine.GetStack());
                break;
        }
    }

    private void OnMinusPressed()
    {
        NonDivisionError result = _machine.Subtract();

        switch (result)
        {
            case NonDivisionError.UnderFlow:
                _consoleView.Response(_underflowResponse);
                break;

            case NonDivisionError.Success:
                _consoleView.Response(_successResponse("-"));
                _consoleView.UpdateStack(_machine.GetStack());
                break;
        }
    }

    private void OnStarPressed()
    {
        NonDivisionError result = _machine.Multiply();

        switch (result)
        {
            case NonDivisionError.UnderFlow:
                _consoleView.Response(_underflowResponse);
                break;

            case NonDivisionError.Success:
                _consoleView.Response(_successResponse("*"));
                _consoleView.UpdateStack(_machine.GetStack());
                break;
        }
    }

    private void OnForwardSlashPressed()
    {
        DivisionError result = _machine.Divide();

        switch (result)
        {
            case DivisionError.UnderFlow:
                _consoleView.Response(_underflowResponse);
                break;

            case DivisionError.ZeroDivision:
                _consoleView.Response(_zeroDivisionResponse);
                break;

            case DivisionError.Success:
                _consoleView.Response(_successResponse("/"));
                _consoleView.UpdateStack(_machine.GetStack());
                break;
        }
    }

    private void OnReturnPressed()
    {
        string inputBuffer = _consoleView.GetInputBuffer();

        if (double.TryParse(inputBuffer, out double inputNumber))
        {
            _machine.Push(inputNumber);
            _consoleView.UpdateStack(_machine.GetStack());
            _consoleView.ClearInputBuffer();
        }
        else
        {
            _consoleView.Response(_nanResponse);
            _consoleView.ClearInputBuffer();
        }

    }
}
