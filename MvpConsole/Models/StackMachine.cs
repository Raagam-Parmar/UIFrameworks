// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using MvpConsole.Models.Interfaces;

namespace MvpConsole.Models;

/// <inheritdoc/>
public class StackMachine : IStackMachine
{
    private readonly Stack<double> _stack = [];

    public double? GetTop()
    {
        if (_stack.Count == 0)
        {
            return null;
        }

        return _stack.First();
    }

    public void Push(double operand)
    {
        _stack.Push(operand);
    }

    public NonDivisionError Negate()
    {
        if (_stack.Count < 1)
        {
            return new NonDivisionError.UnderFlow();
        }

        double top = _stack.Pop();
        double result = -top;
        _stack.Push(result);
        return new NonDivisionError.Success();
    }

    public NonDivisionError Add()
    {
        if (_stack.Count < 2)
        {
            return new NonDivisionError.UnderFlow();
        }

        double top = _stack.Pop();
        double second_top = _stack.Pop();
        double result = top + second_top;
        _stack.Push(result);
        return new NonDivisionError.Success();
    }

    public NonDivisionError Subtract()
    {
        if (_stack.Count < 2)
        {
            return new NonDivisionError.UnderFlow();
        }

        double top = _stack.Pop();
        double second_top = _stack.Pop();
        double result = top - second_top;
        _stack.Push(result);
        return new NonDivisionError.Success();
    }


    public NonDivisionError Multiply()
    {
        if (_stack.Count < 2)
        {
            return new NonDivisionError.UnderFlow();
        }

        double top = _stack.Pop();
        double second_top = _stack.Pop();
        double result = top * second_top;
        _stack.Push(result);
        return new NonDivisionError.Success();
    }

    public DivisionError Divide()
    {
        if (_stack.Count < 2)
        {
            return new DivisionError.UnderFlow();
        }

        double top = _stack.Pop();
        double second_top = _stack.Pop();

        if (second_top == 0)
        {
            // restore stack
            _stack.Push(second_top);
            _stack.Push(top);

            return new DivisionError.ZeroDivision();
        }

        double result = top / second_top;
        _stack.Push(result);
        return new DivisionError.Success();
    }
}
