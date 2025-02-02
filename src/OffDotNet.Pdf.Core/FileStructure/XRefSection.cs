﻿// <copyright file="XRefSection.cs" company="Sunt Programator">
// Copyright (c) Sunt Programator. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace OffDotNet.Pdf.Core.FileStructure;

using System.Text;
using Common;
using Extensions;
using Properties;

public sealed class XRefSection : PdfObject, IXRefSection
{
    private readonly Lazy<string> literalValue;
    private readonly Lazy<byte[]> bytes;

    public XRefSection(ICollection<IXRefSubSection> xRefSubSections)
    {
        this.Value = xRefSubSections.CheckConstraints(subSections => subSections.Count > 0, Resource.XRefSection_MustHaveNonEmptyEntriesCollection);
        this.literalValue = new Lazy<string>(this.GenerateContent);
        this.bytes = new Lazy<byte[]>(() => Encoding.ASCII.GetBytes(this.Content));
    }

    /// <inheritdoc/>
    public override ReadOnlyMemory<byte> Bytes => this.bytes.Value;

    /// <inheritdoc/>
    public ICollection<IXRefSubSection> Value { get; }

    /// <inheritdoc/>
    public override string Content => this.literalValue.Value;

    /// <inheritdoc/>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        return this.Value;
    }

    private string GenerateContent()
    {
        var stringBuilder = new StringBuilder()
            .Append("xref")
            .Append('\n');

        foreach (var subSection in this.Value)
        {
            stringBuilder.Append(subSection.Content);
        }

        return stringBuilder.ToString();
    }
}
