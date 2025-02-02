﻿// <copyright file="PdfRealTests.cs" company="Sunt Programator">
// Copyright (c) Sunt Programator. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace OffDotNet.Pdf.Core.Tests.Primitives;

using OffDotNet.Pdf.Core.Primitives;

public class PdfRealTests
{
    [Fact(DisplayName = "Ensure that the parameterless constructor will set 0 to the Value property.")]
    public void PdfReal_ParameterlessConstructor_ShouldSetZeroToValueProperty()
    {
        // Arrange
        PdfReal pdfReal1 = new();

        // Act

        // Assert
        Assert.Equal(0, pdfReal1.Value);
    }

    [Theory(DisplayName = "Create an instance using parametrized constructor and check the Value property")]
    [InlineData(34.5)]
    [InlineData(-3.62)]
    [InlineData(+123.6)] // Plus sign is automatically removed by C#.
    [InlineData(4.0)]
    [InlineData(-.002)]
    public void PdfReal_ParameterizedConstructor_CheckValue(float value)
    {
        // Arrange
        PdfReal pdfReal = value; // Use an implicit conversion from float to PdfReal

        // Act
        float expectedValue = pdfReal.Value;

        // Assert
        Assert.Equal(expectedValue, pdfReal.Value);
    }

    [Fact(DisplayName = "Check Equals method if the argument is null")]
    public void PdfReal_Equals_NullArgument_ShouldReturnFalse()
    {
        // Arrange
        PdfReal pdfReal1 = +123.6f; // Use an implicit conversion from float to PdfReal

        // Act
        bool actualResult = pdfReal1.Equals(null);

        // Assert
        Assert.False(actualResult);
    }

    [Theory(DisplayName = "Check Equals method with object type as an argument")]
    [InlineData(34.5, 34.5, true)]
    [InlineData(0.0, -0.000, true)]
    [InlineData(-3.62, 3.62, false)]
    [InlineData(+123.6, 5, false)]
    [InlineData(4.0, 4.000, true)]
    [InlineData(-.002, -0.0002, false)]
    public void PdfReal_Equality_CheckEquals(float value1, float value2, bool expectedResult)
    {
        // Arrange
        PdfReal pdfReal1 = value1; // Use an implicit conversion from float to PdfReal
        PdfReal pdfReal2 = value2; // Use an implicit conversion from float to PdfReal

        // Act
        bool actualResult = pdfReal1.Equals((object)pdfReal2);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory(DisplayName = "Check if Bytes property returns valid data")]
    [InlineData(34.5, new byte[] { 51, 52, 46, 53 })]
    [InlineData(-3.62, new byte[] { 45, 51, 46, 54, 50 })]
    [InlineData(+123.6, new byte[] { 49, 50, 51, 46, 54 })]
    [InlineData(4.0, new byte[] { 52 })]
    [InlineData(-.002, new byte[] { 45, 48, 46, 48, 48, 50 })]
    public void PdfReal_Bytes_CheckValidity(float value1, byte[] expectedBytes)
    {
        // Arrange
        PdfReal pdfReal1 = value1; // Use an implicit conversion from float to PdfReal

        // Act
        ReadOnlyMemory<byte> actualBytes = pdfReal1.Bytes;

        // Assert
        Assert.True(actualBytes.Span.SequenceEqual(expectedBytes));
    }

    [Theory(DisplayName = "Check if GetHashCode method returns valid value")]
    [InlineData(34.5)]
    [InlineData(-3.62)]
    [InlineData(+123.6)] // Plus sign is automatically removed by C#.
    [InlineData(4.0)]
    [InlineData(-.002)]
    public void PdfReal_GetHashCode_CheckValidity(float value1)
    {
        // Arrange
        PdfReal pdfReal1 = value1; // Use an implicit conversion from float to PdfReal
        float expectedHashCode = HashCode.Combine(nameof(PdfReal), value1);

        // Act
        float actualHashCode = pdfReal1.GetHashCode();

        // Assert
        Assert.Equal(expectedHashCode, actualHashCode);
    }

    [Theory(DisplayName = "Compare the hash codes of two real objects.")]
    [InlineData(34.5, 34.5, true)]
    [InlineData(0.0, -0.000, true)]
    [InlineData(-3.62, 3.62, false)]
    [InlineData(+123.6, 5, false)]
    [InlineData(4.0, 4.000, true)]
    [InlineData(-.002, -0.0002, false)]
    public void PdfReal_GetHashCode_CompareHashes(float value1, float value2, bool expectedResult)
    {
        // Arrange
        PdfReal pdfReal1 = value1; // Use an implicit conversion from float to PdfReal
        PdfReal pdfReal2 = value2; // Use an implicit conversion from float to PdfReal

        // Act
        int actualHashCode1 = pdfReal1.GetHashCode();
        int actualHashCode2 = pdfReal2.GetHashCode();
        bool areHashCodeEquals = actualHashCode1 == actualHashCode2;

        // Assert
        Assert.Equal(expectedResult, areHashCodeEquals);
    }

    [Theory(DisplayName = "Check if comparison operators works properly")]
    [InlineData(34.5, 34.5, true, false, true, false, true, false)]
    [InlineData(0.0, -0.000, true, false, true, false, true, false)]
    [InlineData(-3.62, 3.62, false, true, false, false, true, true)]
    [InlineData(+123.6, 5, false, true, true, true, false, false)]
    [InlineData(4.0, 4.000, true, false, true, false, true, false)]
    [InlineData(-.002, -0.0002, false, true, false, false, true, true)]
    public void PdfReal_Operators_CheckValidity(float value1, float value2, bool expectedEq, bool expectedNe, bool expectedGe, bool expectedGt, bool expectedLe, bool expectedLt)
    {
        // Arrange
        PdfReal pdfReal1 = value1; // Use an implicit conversion from float to PdfReal
        PdfReal pdfReal2 = value2; // Use an implicit conversion from float to PdfReal

        // Act
        bool actualEqual = pdfReal1 == pdfReal2;
        bool actualNotEqual = pdfReal1 != pdfReal2;
        bool actualGreaterOrEqualThan = pdfReal1 >= pdfReal2;
        bool actualGreaterThan = pdfReal1 > pdfReal2;
        bool actualLessOrEqualThan = pdfReal1 <= pdfReal2;
        bool actualLessThan = pdfReal1 < pdfReal2;

        // Assert
        Assert.Equal(actualEqual, expectedEq);
        Assert.Equal(actualNotEqual, expectedNe);
        Assert.Equal(actualGreaterOrEqualThan, expectedGe);
        Assert.Equal(actualGreaterThan, expectedGt);
        Assert.Equal(actualLessOrEqualThan, expectedLe);
        Assert.Equal(actualLessThan, expectedLt);
    }

    [Theory(DisplayName = "Check if implicit operator works")]
    [InlineData(34.5)]
    [InlineData(-3.62)]
    [InlineData(+123.6)] // Plus sign is automatically removed by C#.
    [InlineData(4.0)]
    [InlineData(-.002)]
    public void PdfReal_CheckImplicitOperator(float value1)
    {
        // Arrange
        PdfReal pdfReal1 = new(value1);

        // Act
        float actualValue = pdfReal1; // Use an implicit conversion from PdfReal to float
        float expectedValue = pdfReal1.Value;

        // Assert
        Assert.Equal(expectedValue, actualValue);
    }

    [Theory(DisplayName = "Check CompareTo method")]
    [InlineData(34.5, 34.5, 0)]
    [InlineData(0.0, -0.000, 0)]
    [InlineData(-3.62, 3.62, -1)]
    [InlineData(+123.6, 5, 1)]
    [InlineData(4.0, 4.000, 0)]
    [InlineData(-.002, -0.0002, -1)]
    public void PdfReal_CompareTo_CheckValidity(float value1, float value2, float expectedValue)
    {
        // Arrange
        PdfReal pdfReal1 = new(value1);
        object pdfReal2 = new PdfReal(value2);

        // Act
        float actualValue = pdfReal1.CompareTo(pdfReal2);

        // Assert
        Assert.Equal(expectedValue, actualValue);
    }

    [Fact(DisplayName = "Check CompareTo method should throw an exception")]
    public void PdfReal_CompareTo_ThrowsException()
    {
        // Arrange
        PdfReal pdfReal1 = new();
        object pdfReal2 = 5;

        // Act
        // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
        Action actualValueDelegate = () => pdfReal1.CompareTo(pdfReal2);

        // Assert
        Assert.Throws<ArgumentException>(actualValueDelegate);
    }

    [Theory(DisplayName = "Check Content property for equality")]
    [InlineData(34.5, "34.5")]
    [InlineData(-3.62, "-3.62")]
    [InlineData(+123.6, "123.6")] // Plus sign is automatically removed by C#.
    [InlineData(4.0, "4")]
    [InlineData(-.002, "-0.002")]
    public void PdfReal_Content_CheckEquality(float value1, string expectedPdfRealStringValue)
    {
        // Arrange
        PdfReal pdfReal1 = value1; // Use an implicit conversion from float to PdfReal

        // Act
        string actualPdfRealStringValue = pdfReal1.Content;

        // Assert
        Assert.Equal(expectedPdfRealStringValue, actualPdfRealStringValue);
    }

    [Theory(DisplayName = "Check if the too small value is approximated to zero")]
    [InlineData(1.175e-38f)]
    [InlineData(-1.175e-38f)]
    [InlineData(-1.175e-38f + 1e-38f)]
    [InlineData(1.175e-38f - 1e-38f)]
    public void PdfReal_Constructor_CheckApproximation(float value1)
    {
        // Arrange
        PdfReal pdfReal1 = new(value1);

        // Act
        float actualValue = pdfReal1.Value;

        // Assert
        Assert.Equal(0f, actualValue);
    }
}
