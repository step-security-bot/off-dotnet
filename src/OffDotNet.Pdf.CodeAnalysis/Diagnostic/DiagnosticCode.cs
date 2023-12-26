// <copyright file="DiagnosticCode.cs" company="Sunt Programator">
// Copyright (c) Sunt Programator. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace OffDotNet.Pdf.CodeAnalysis.Diagnostic;

[SuppressMessage("ReSharper", "InconsistentNaming", Justification = "The names of the enum members must be the same as the resource strings.")]
public enum DiagnosticCode : ushort
{
    ERR_InvalidPDF = 1,
}
