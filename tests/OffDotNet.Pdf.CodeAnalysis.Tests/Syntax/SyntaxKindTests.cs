// <copyright file="SyntaxKindTests.cs" company="Sunt Programator">
// Copyright (c) Sunt Programator. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using OffDotNet.Pdf.CodeAnalysis.Syntax;

namespace OffDotNet.Pdf.CodeAnalysis.Tests.Syntax;

public class SyntaxKindTests
{
    [Theory(DisplayName = "The SyntaxKind enum must have predefined and immutable values.")]
    [InlineData(SyntaxKind.None, 0)]
    [InlineData(SyntaxKind.LeftParenthesisToken, 8100)]
    [InlineData(SyntaxKind.RightParenthesisToken, 8101)]
    [InlineData(SyntaxKind.LessThanToken, 8102)]
    [InlineData(SyntaxKind.GreaterThanToken, 8103)]
    [InlineData(SyntaxKind.LeftSquareBracketToken, 8104)]
    [InlineData(SyntaxKind.RightSquareBracketToken, 8105)]
    [InlineData(SyntaxKind.LeftCurlyBracketToken, 8106)]
    [InlineData(SyntaxKind.RightCurlyBracketToken, 8107)]
    [InlineData(SyntaxKind.LessThanLessThanToken, 8108)]
    [InlineData(SyntaxKind.GreaterThanGreaterThanToken, 8109)]
    [InlineData(SyntaxKind.SolidusToken, 8110)]
    [InlineData(SyntaxKind.PercentSignToken, 8111)]
    [InlineData(SyntaxKind.PlusToken, 8112)]
    [InlineData(SyntaxKind.MinusToken, 8113)]
    [InlineData(SyntaxKind.TrueKeyword, 8300)]
    [InlineData(SyntaxKind.FalseKeyword, 8301)]
    [InlineData(SyntaxKind.NullKeyword, 8302)]
    [InlineData(SyntaxKind.StartObjectKeyword, 8303)]
    [InlineData(SyntaxKind.EndObjectKeyword, 8304)]
    [InlineData(SyntaxKind.IndirectReferenceKeyword, 8305)]
    [InlineData(SyntaxKind.StartStreamKeyword, 8306)]
    [InlineData(SyntaxKind.EndStreamKeyword, 8307)]
    [InlineData(SyntaxKind.XrefKeyword, 8308)]
    [InlineData(SyntaxKind.StartXrefKeyword, 8309)]
    [InlineData(SyntaxKind.TrailerKeyword, 8310)]
    [InlineData(SyntaxKind.NumericLiteralToken, 8509)]
    public void SyntaxKindEnum_MustHavePredefinedValues(SyntaxKind kind, ushort intKind)
    {
        // Arrange

        // Act

        // Assert
        Assert.Equal(intKind, (ushort)kind);
    }
}
