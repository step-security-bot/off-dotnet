﻿// <copyright file="IPdfIndirect.cs" company="Sunt Programator">
// Copyright (c) Sunt Programator. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace OffDotNet.Pdf.Core.Primitives;

using OffDotNet.Pdf.Core.Common;

public interface IPdfIndirect<T> : IPdfObject
    where T : IPdfObject
{
    int GenerationNumber { get; }

    int ObjectNumber { get; }

    public T? Value { get; set; }
}
