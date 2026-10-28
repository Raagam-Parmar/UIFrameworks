// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MvpConsole.Views.Interfaces;

/// <summary>
/// A console view for the calculator
/// </summary>
public interface IConsoleView
{
    /// <summary>
    /// Key <c>+</c> pressed
    /// </summary>
    event Action PlusPressed;

    /// <summary>
    /// Key <c>-</c> pressed
    /// </summary>
    event Action MinusPressed;

    /// <summary>
    /// Key <c>*</c> pressed
    /// </summary>
    event Action StarPressed;

    /// <summary>
    /// Key <c>/</c> pressed
    /// </summary>
    event Action ForwardSlashPressed;

    /// <summary>
    /// Key <c>~</c> pressed
    /// </summary>
    event Action TildePressed;

    /// <summary>
    /// Key <c>Enter</c> pressed
    /// </summary>
    event Action ReturnPressed;

    /// <summary>
    /// Response of the most recent action, from the presenter
    /// </summary>
    /// <param name="eventResponse">Presenter response</param>
    void Response(string eventResponse);

    /// <summary>
    /// Update the displayed stack 
    /// </summary>
    /// <param name="newStack">New stack to display</param>
    void UpdateStack(List<double> newStack);

    /// <summary>
    /// Redraw the view
    /// </summary>
    void Redraw();

    /// <summary>
    /// Run the view
    /// </summary>
    void Run();
}
