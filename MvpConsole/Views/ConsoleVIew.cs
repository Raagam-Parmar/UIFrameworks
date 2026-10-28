// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using MvpConsole.Views.Interfaces;

namespace MvpConsole.Views;

public class ConsoleView : IConsoleView
{
    private string _inputBuffer = "";
    private string _responseBuffer = "Waiting for user input";
    private List<double> _stack = [];

    public event Action? PlusPressed;
    public event Action? MinusPressed;
    public event Action? StarPressed;
    public event Action? ForwardSlashPressed;
    public event Action? TildePressed;
    public event Action? ReturnPressed;

    private void DrawHeading()
    {
        Console.WriteLine($"Calculator");
        Console.WriteLine($"  ( [0-9](.[0-9]*)? ) Input a decimal number");
        Console.WriteLine($"  (~) Negate (+) Add (-) Subtract (*) Multiply (/) Divide");
        Console.WriteLine($"  (Q) Quit");
    }

    /// <summary>
    /// Draw the input buffer
    /// </summary>
    private void DrawInputBuffer()
    {
        Console.WriteLine($"> {_inputBuffer}");
    }

    /// <summary>
    /// Draw the response buffer
    /// </summary>
    private void DrawResponseBuffer()
    {
        Console.WriteLine($"* {_responseBuffer} *");
    }

    /// <summary>
    /// Display the number stack
    /// </summary>
    private void DrawStack()
    {
        for (int i = 0; i < _stack.Count; i++)
        {
            Console.WriteLine($"  {_stack[i]}");
        }
    }

    public void Redraw()
    {
        Console.Clear();

        DrawHeading();
        DrawInputBuffer();
        DrawResponseBuffer();

        Console.WriteLine();

        DrawStack();
    }

    public void Response(string eventResponse)
    {
        _responseBuffer = eventResponse;
    }

    public string GetInputBuffer()
    {
        return _inputBuffer;
    }

    public void ClearInputBuffer()
    {
        _inputBuffer = "";
    }

    public void UpdateStack(List<double> newStack)
    {
        _stack = newStack;
    }

    public void Run()
    {
        Redraw();

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                ReturnPressed?.Invoke();
                Redraw();
                continue;
            }

            if (keyInfo.Key == ConsoleKey.Q)
            {
                break;
            }

            switch (keyInfo.KeyChar)
            {
                case '~':
                    TildePressed?.Invoke();
                    break;
                case '+':
                    PlusPressed?.Invoke();
                    break;
                case '-':
                    MinusPressed?.Invoke();
                    break;
                case '*':
                    StarPressed?.Invoke();
                    break;
                case '/':
                    ForwardSlashPressed?.Invoke();
                    break;
                case '.':
                    _inputBuffer += ".";
                    break;
                default:
                    if (char.IsDigit(keyInfo.KeyChar))
                    {
                        _inputBuffer += keyInfo.KeyChar;
                    }
                    break;
            }

            Redraw();
        }
    }
}
