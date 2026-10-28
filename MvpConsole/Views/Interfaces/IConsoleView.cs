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
    /// Key <c>p</c> pressed
    /// </summary>
    event Action PPressed;

    /// <summary>
    /// Key <c>c</c> pressed
    /// </summary>
    event Action CPressed;

    /// <summary>
    /// Response of the most recent action, from the presenter
    /// </summary>
    /// <param name="eventResponse">Presenter response</param>
    void Response(string eventResponse);

    /// <summary>
    /// Get the contents of the input buffer
    /// </summary>
    /// <returns>Contents of input buffer</returns>
    string GetInputBuffer();

    /// <summary>
    /// Set the contents of the input buffer
    /// </summary>
    /// <param name="contents">Content to set</param>
    void SetInputBuffer(string contents);

    /// <summary>
    /// Clear the input buffer
    /// </summary>
    void ClearInputBuffer();

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
