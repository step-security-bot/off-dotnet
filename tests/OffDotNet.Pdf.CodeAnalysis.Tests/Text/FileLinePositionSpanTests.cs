﻿// <copyright file="FileLinePositionSpanTests.cs" company="Sunt Programator">
// Copyright (c) Sunt Programator. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace OffDotNet.Pdf.CodeAnalysis.Tests.Text;

using System.Diagnostics.CodeAnalysis;
using OffDotNet.Pdf.CodeAnalysis.Text;

public class FileLinePositionSpanTests
{
    [Fact(DisplayName = $"The constructor must throw an {nameof(ArgumentNullException)} when the {nameof(FileLinePositionSpan.Path)} is null.")]
    [SuppressMessage("ReSharper", "UnusedVariable", Justification = "The variable is used in the assertion.")]
    [SuppressMessage("Minor Code Smell", "S1481:Unused local variables should be removed", Justification = "The variable is used in the assertion.")]
    [SuppressMessage("ReSharper", "MoveLocalFunctionAfterJumpStatement", Justification = "The local function is used in the assertion.")]
    public void Constructor_EmptyPath_MustThrowArgumentNullException()
    {
        // Arrange

        // Assert
        static void FileLinePositionSpanFunc()
        {
            FileLinePositionSpan fileLinePositionSpan = new(string.Empty, default);
        }

        // Act
        Assert.Throws<ArgumentNullException>(FileLinePositionSpanFunc);
    }

    [Fact(DisplayName = $"The {nameof(FileLinePositionSpan.Path)} property must be assigned from the constructor.")]
    public void PathProperty_MustBeAssignedFromConstructor()
    {
        // Arrange
        LinePosition start = new(1, 0);
        LinePosition end = new(5, 0);
        const string path = @"C:\1.pdf";

        // Act
        FileLinePositionSpan fileLinePositionSpan = new(path, start, end);
        string actualPath = fileLinePositionSpan.Path;

        // Assert
        Assert.Equal(path, actualPath);
    }

    [Fact(DisplayName = $"The {nameof(FileLinePositionSpan.Span)} property must be assigned from the constructor.")]
    public void SpanProperty_MustBeAssignedFromConstructor()
    {
        // Arrange
        LinePosition start = new(1, 0);
        LinePosition end = new(5, 0);
        const string path = @"C:\1.pdf";
        LinePositionSpan expectedSpan = new(start, end);

        // Act
        FileLinePositionSpan fileLinePositionSpan = new(path, start, end);
        LinePositionSpan actualSpan = fileLinePositionSpan.Span;

        // Assert
        Assert.Equal(expectedSpan, actualSpan);
    }

    [Fact(DisplayName = $"The {nameof(FileLinePositionSpan.StartLinePosition)} property must be computed from the {nameof(FileLinePositionSpan.Span)} property.")]
    public void StartLinePositionProperty_MustBeComputedFromSpan()
    {
        // Arrange
        LinePosition start = new(1, 0);
        LinePosition end = new(5, 0);
        const string path = @"C:\1.pdf";

        // Act
        FileLinePositionSpan fileLinePositionSpan = new(path, start, end);
        LinePosition actualLinePosition = fileLinePositionSpan.StartLinePosition;

        // Assert
        Assert.Equal(start, actualLinePosition);
    }

    [Fact(DisplayName = $"The {nameof(FileLinePositionSpan.EndLinePosition)} property must be computed from the {nameof(FileLinePositionSpan.Span)} property.")]
    public void EndLinePositionProperty_MustBeComputedFromSpan()
    {
        // Arrange
        LinePosition start = new(1, 0);
        LinePosition end = new(5, 0);
        const string path = @"C:\1.pdf";

        // Act
        FileLinePositionSpan fileLinePositionSpan = new(path, start, end);
        LinePosition actualLinePosition = fileLinePositionSpan.EndLinePosition;

        // Assert
        Assert.Equal(end, actualLinePosition);
    }

    [Fact(DisplayName = $"The struct must implement the {nameof(IEquatable<FileLinePositionSpan>)} interface.")]
    public void Struct_MustImplementIEquatable()
    {
        // Arrange
        LinePosition start = new(1, 0);
        LinePosition end = new(5, 0);
        const string path = @"C:\1.pdf";

        // Act
        FileLinePositionSpan fileLinePositionSpan = new(path, start, end);

        // Assert
        Assert.IsAssignableFrom<IEquatable<FileLinePositionSpan>>(fileLinePositionSpan);
    }

    [Fact(DisplayName = "The Equals() method must return true.")]
    public void EqualsMethod_MustReturnTrue()
    {
        // Arrange
        LinePosition start = new(1, 0);
        LinePosition end = new(5, 0);
        const string path = @"C:\1.pdf";
        FileLinePositionSpan fileLinePositionSpan1 = new(path, start, end);
        FileLinePositionSpan fileLinePositionSpan2 = new(path, start, end);

        // Act
        bool actualEquals1 = fileLinePositionSpan1.Equals(fileLinePositionSpan2);
        bool actualEquals2 = fileLinePositionSpan1.Equals((object?)fileLinePositionSpan2);
        bool actualEquals3 = fileLinePositionSpan1 == fileLinePositionSpan2;
        bool actualEquals4 = fileLinePositionSpan1 != fileLinePositionSpan2;

        // Assert
        Assert.True(actualEquals1);
        Assert.True(actualEquals2);
        Assert.True(actualEquals3);
        Assert.False(actualEquals4);
    }

    [Fact(DisplayName = "The Equals() method must return false.")]
    public void EqualsMethod_MustReturnFalse()
    {
        // Arrange
        LinePosition start1 = new(1, 0);
        LinePosition start2 = new(2, 0);
        LinePosition end1 = new(5, 0);
        LinePosition end2 = new(3, 0);
        const string path1 = @"C:\1.pdf";
        const string path2 = @"C:\2.pdf";
        FileLinePositionSpan fileLinePositionSpan1 = new(path1, start1, end1);
        FileLinePositionSpan fileLinePositionSpan2 = new(path2, start2, end2);

        // Act
        bool actualEquals1 = fileLinePositionSpan1.Equals(fileLinePositionSpan2);
        bool actualEquals2 = fileLinePositionSpan1.Equals((object?)fileLinePositionSpan2);
        bool actualEquals3 = fileLinePositionSpan1 == fileLinePositionSpan2;
        bool actualEquals4 = fileLinePositionSpan1 != fileLinePositionSpan2;

        // Assert
        Assert.False(actualEquals1);
        Assert.False(actualEquals2);
        Assert.False(actualEquals3);
        Assert.True(actualEquals4);
    }

    [Fact(DisplayName = $"The GetHashCode() method must include the {nameof(FileLinePositionSpan.Path)} and {nameof(FileLinePositionSpan.Span)} properties.")]
    public void GetHashCodeMethod_MustIncludeLineAndCharacter()
    {
        // Arrange
        LinePosition start = new(1, 0);
        LinePosition end = new(5, 0);
        const string path = @"C:\1.pdf";
        int expectedHashCode = HashCode.Combine(path, new LinePositionSpan(start, end));

        // Act
        FileLinePositionSpan fileLinePositionSpan = new(path, start, end);
        int actualHashCode = fileLinePositionSpan.GetHashCode();

        // Assert
        Assert.Equal(expectedHashCode, actualHashCode);
    }

    [Fact(DisplayName = $"The ToString() method must include the {nameof(FileLinePositionSpan.Path)} and {nameof(FileLinePositionSpan.Span)} properties.")]
    public void ToStringMethod_MustIncludePathAndSpan()
    {
        // Arrange
        LinePosition start = new(1, 0);
        LinePosition end = new(5, 0);
        const string path = @"C:\1.pdf";
        string expectedToString = $"{path}: ({start})-({end})";

        // Act
        FileLinePositionSpan fileLinePositionSpan = new(path, start, end);
        string actualToString = fileLinePositionSpan.ToString();

        // Assert
        Assert.Equal(expectedToString, actualToString);
    }
}
