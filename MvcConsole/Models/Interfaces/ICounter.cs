// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MvcConsole.Models.Interfaces;


/// <summary>
/// A counter, which can count up or down, and show its current value
/// </summary>
public interface ICounter
{
    /// <summary>
    /// Get current value of the counter
    /// </summary>
    /// <returns>Current counter value</returns>
    int GetCount();

    /// <summary>
    /// Increment counter
    /// </summary>
    void Increment();

    /// <summary>
    /// Decrement counter
    /// </summary>
    void Decrement();
}
