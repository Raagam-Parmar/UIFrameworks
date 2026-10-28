// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MvpConsole.Models.Interfaces;

public abstract record NonDivisionError
{
    private NonDivisionError() { }

    public sealed record Success() : NonDivisionError;
    public sealed record UnderFlow() : NonDivisionError;
}

public abstract record DivisionError
{
    private DivisionError() { }

    public sealed record Success() : DivisionError;
    public sealed record UnderFlow() : DivisionError;
    public sealed record ZeroDivision() : DivisionError;
}

/// <summary>
/// A stack machine with operations like negation, +, -, *, / and ^
/// </summary>
public interface IStackMachine
{
    /// <summary>
    /// Get the top of the stack
    /// </summary>
    /// <returns>Top of the stack if stack is non empty, null otherwise</returns>
    double? GetTop();

    /// <summary>
    /// Push an operand to the stack
    /// </summary>
    /// <param name="operand">Operand to push</param>
    void Push(double operand);

    /// <summary>
    /// Negate the top of the stack
    /// </summary>
    /// <returns>Returns <see cref="NonDivisionError.UnderFlow"/> on underflow, stack is not modified, otherwise,
    /// returns <see cref="NonDivisionError.Success"/></returns>
    NonDivisionError Negate();

    /// <summary>
    /// Pop and add the top two elements on the stack,
    /// top + second-to-top element,
    /// and push the result to the stack
    /// </summary>
    /// <returns>Returns <see cref="NonDivisionError.UnderFlow"/> on underflow, stack is not modified, otherwise,
    /// returns <see cref="NonDivisionError.Success"/></returns>
    NonDivisionError Add();

    /// <summary>
    /// Pop and subtract the top two elements on the stack,
    /// top - second-to-top element,
    /// and push the result to the stack
    /// </summary>
    /// <returns>Returns <see cref="NonDivisionError.UnderFlow"/> on underflow, stack is not modified, otherwise,
    /// returns <see cref="NonDivisionError.Success"/></returns>
    NonDivisionError Subtract();

    /// <summary>
    /// Pop and multiply the top two elements on the stack,
    /// top * second-to-top element,
    /// and push the result to the stack
    /// </summary>
    /// <returns>Returns <see cref="NonDivisionError.UnderFlow"/> on underflow, stack is not modified, otherwise,
    /// returns <see cref="NonDivisionError.Success"/></returns>
    NonDivisionError Multiply();

    /// <summary>
    /// Pop and divide the top two elements on the stack,
    /// top / second-to-top element,
    /// and push the result to the stack
    /// </summary>
    /// <returns>Returns <see cref="DivisionError.UnderFlow"/> on underflow, stack is not modified,
    /// returns <see cref="DivisionError.ZeroDivision"/> if division by zero is attempted, otherwise,
    /// returns <see cref="DivisionError.Success"/> on success.</returns>
    DivisionError Divide();
}
