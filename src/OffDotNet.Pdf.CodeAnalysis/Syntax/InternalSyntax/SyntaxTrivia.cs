// <copyright file="SyntaxTrivia.cs" company="Sunt Programator">
// Copyright (c) Sunt Programator. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using OffDotNet.Pdf.CodeAnalysis.InternalUtilities;

namespace OffDotNet.Pdf.CodeAnalysis.Syntax.InternalSyntax;

internal sealed class SyntaxTrivia : GreenNode
{
    private SyntaxTrivia(SyntaxKind kind, string text)
        : base(kind)
    {
        this.Text = text;
        this.FullWidth = text.Length;
    }

    /// <summary>Gets the lexeme of the trivia.</summary>
    /// <remarks>A lexeme is an actual character sequence forming a specific instance of a token.</remarks>
    /// <example>Whitespaces, end-of-line markers, etc.</example>
    public string Text { get; }

    /// <inheritdoc cref="GreenNode.Width"/>
    public override int Width => this.FullWidth;

    /// <summary>Gets the width of the leading trivia.</summary>
    /// <remarks>As this object represents a trivia, it cannot have any nested <see cref="GreenNode.LeadingTrivia"/>, so the <see cref="LeadingTriviaWidth"/> is always 0.</remarks>
    public override int LeadingTriviaWidth => 0;

    /// <summary>Gets the width of the trailing trivia.</summary>
    /// <remarks>As this object represents a trivia, it cannot have any nested <see cref="GreenNode.TrailingTrivia"/>, so the <see cref="TrailingTriviaWidth"/> is always 0.</remarks>
    public override int TrailingTriviaWidth => 0;

    /// <summary>Gets a value indicating whether the node represents a trivia.</summary>
    /// <remarks>Trivia or minutiae are parts of the source text that are largely insignificant for normal understanding of the PDF Syntax, such as whitespace, comments, etc.</remarks>
    public override bool IsTrivia => true;

    /// <summary>Returns the <see cref="Text"/> value.</summary>
    /// <returns>The <see cref="Text"/> value.</returns>
    public override string ToString()
    {
        return this.Text;
    }

    internal static SyntaxTrivia Create(SyntaxKind kind, string text)
    {
        return new SyntaxTrivia(kind, text);
    }

    /// <inheritdoc cref="GreenNode.GetSlot"/>
    internal override GreenNode GetSlot(int index)
    {
        throw ExceptionUtilities.Unreachable();
    }
}
