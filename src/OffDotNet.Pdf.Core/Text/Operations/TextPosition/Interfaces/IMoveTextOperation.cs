﻿// <copyright file="IMoveTextOperation.cs" company="Sunt Programator">
// Copyright (c) Sunt Programator. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace OffDotNet.Pdf.Core.Text.Operations.TextPosition;

using OffDotNet.Pdf.Core.Common;
using OffDotNet.Pdf.Core.Primitives;

public interface IMoveTextOperation : IPdfOperation
{
    PdfReal X { get; }

    PdfReal Y { get; }
}
