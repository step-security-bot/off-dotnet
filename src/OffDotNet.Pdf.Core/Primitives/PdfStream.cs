// <copyright file="PdfStream.cs" company="Sunt Programator">
// Copyright (c) Sunt Programator. All rights reserved.
// Licensed under the GPL-3.0 license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Text;
using OffDotNet.Pdf.Core.Interfaces;

namespace OffDotNet.Pdf.Core.Primitives;

public sealed class PdfStream : IPdfObject<ReadOnlyMemory<char>>, IEquatable<PdfStream?>
{
    private static readonly PdfName LengthKey = "Length";
    private static readonly PdfName FilterKey = "Filter";
    private static readonly PdfName DecodeParametersKey = "DecodeParms";
    private static readonly PdfName FileFilterKey = "FFilter";
    private static readonly PdfName FileDecodeParametersKey = "FDecodeParms";
    private static readonly PdfName FileSpecificationKey = "F";

    private readonly PdfStreamExtentOptions pdfStreamExtentOptions = new();
    private readonly int hashCode;
    private string literalValue = string.Empty;
    private byte[]? bytes;
    private PdfDictionary<IPdfObject>? streamExtentDictionary;

    public PdfStream(ReadOnlyMemory<char> value, Action<PdfStreamExtentOptions>? options = null)
    {
        this.hashCode = HashCode.Combine(nameof(PdfStream), value);
        this.bytes = null;
        this.Value = value;
        options?.Invoke(this.pdfStreamExtentOptions);
    }

    public ReadOnlyMemory<char> Value { get; }

    public ReadOnlyMemory<byte> Bytes => this.bytes ??= Encoding.ASCII.GetBytes(this.Content);

    public string Content => this.GenerateContent();

    public PdfDictionary<IPdfObject> StreamExtent => this.GenerateStreamExtendDictionary();

    public override int GetHashCode()
    {
        return this.hashCode;
    }

    public override bool Equals(object? obj)
    {
        return this.Equals(obj as PdfStream);
    }

    public bool Equals(PdfStream? other)
    {
        return other is not null && this.Value.Equals(other.Value);
    }

    private string GenerateContent()
    {
        if (this.literalValue.Length != 0)
        {
            return this.literalValue;
        }

        StringBuilder stringBuilder = new StringBuilder()
            .Insert(0, "\nstream\n")
            .Append(this.Value);

        if (stringBuilder[^1] != '\n')
        {
            stringBuilder.Append('\n');
        }

        stringBuilder.Append("endstream");

        this.literalValue = stringBuilder
            .Insert(0, this.StreamExtent.Content)
            .ToString();

        return this.literalValue;
    }

    private PdfDictionary<IPdfObject> GenerateStreamExtendDictionary()
    {
        if (this.streamExtentDictionary != null)
        {
            return this.streamExtentDictionary;
        }

        int length = this.Value.Length;

        this.streamExtentDictionary = new Dictionary<PdfName, IPdfObject>(6)
            .WithKeyValue(FilterKey, this.pdfStreamExtentOptions.Filter?.PdfObject)
            .WithKeyValue(DecodeParametersKey, this.pdfStreamExtentOptions.DecodeParameters?.PdfObject)
            .WithKeyValue(FileSpecificationKey, this.pdfStreamExtentOptions.FileSpecification)
            .WithKeyValue(FileFilterKey, this.pdfStreamExtentOptions.FileFilter?.PdfObject)
            .WithKeyValue(FileDecodeParametersKey, this.pdfStreamExtentOptions.FileDecodeParameters?.PdfObject)
            .WithKeyValue(LengthKey, (PdfInteger)length)
            .ToPdfDictionary();

        return this.streamExtentDictionary;
    }
}
