// <copyright file="SyntaxFacts.cs" company="Sunt Programator">
// Copyright (c) Sunt Programator. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace OffDotNet.Pdf.CodeAnalysis.Syntax;

public static class SyntaxFacts
{
    public static string GetText(SyntaxKind kind)
    {
        return kind switch
        {
            SyntaxKind.LeftParenthesisToken => "(",
            SyntaxKind.RightParenthesisToken => ")",
            SyntaxKind.LessThanToken => "<",
            SyntaxKind.GreaterThanToken => ">",
            SyntaxKind.LeftSquareBracketToken => "[",
            SyntaxKind.RightSquareBracketToken => "]",
            SyntaxKind.LeftCurlyBracketToken => "{",
            SyntaxKind.RightCurlyBracketToken => "}",
            SyntaxKind.SolidusToken => "/",
            SyntaxKind.PercentSignToken => "%",
            SyntaxKind.LessThanLessThanToken => "<<",
            SyntaxKind.GreaterThanGreaterThanToken => ">>",
            SyntaxKind.PlusToken => "+",
            SyntaxKind.MinusToken => "-",
            SyntaxKind.TrueKeyword => "true",
            SyntaxKind.FalseKeyword => "false",
            SyntaxKind.NullKeyword => "null",
            SyntaxKind.StartObjectKeyword => "obj",
            SyntaxKind.EndObjectKeyword => "endobj",
            SyntaxKind.IndirectReferenceKeyword => "R",
            SyntaxKind.StartStreamKeyword => "stream",
            SyntaxKind.EndStreamKeyword => "endstream",
            SyntaxKind.XRefKeyword => "xref",
            SyntaxKind.TrailerKeyword => "trailer",
            SyntaxKind.StartXRefKeyword => "startxref",
            _ => string.Empty,
        };
    }

    public static SyntaxKind GetKeywordKind(string text)
    {
        return text switch
        {
            "true" => SyntaxKind.TrueKeyword,
            "false" => SyntaxKind.FalseKeyword,
            "null" => SyntaxKind.NullKeyword,
            "obj" => SyntaxKind.StartObjectKeyword,
            "endobj" => SyntaxKind.EndObjectKeyword,
            "R" => SyntaxKind.IndirectReferenceKeyword,
            "stream" => SyntaxKind.StartStreamKeyword,
            "endstream" => SyntaxKind.EndStreamKeyword,
            "xref" => SyntaxKind.XRefKeyword,
            "trailer" => SyntaxKind.TrailerKeyword,
            "startxref" => SyntaxKind.StartXRefKeyword,
            _ => SyntaxKind.None,
        };
    }
}
