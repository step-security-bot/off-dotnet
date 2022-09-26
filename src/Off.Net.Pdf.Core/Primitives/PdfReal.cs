using System.Globalization;
using System.Text;
using Off.Net.Pdf.Core.Interfaces;

namespace Off.Net.Pdf.Core.Primitives;

public struct PdfReal : IPdfObject<float>, IEquatable<PdfReal>, IComparable, IComparable<PdfReal>
{
    private const float approximationValue = 1.175e-38f;

    #region Fields
    private readonly int hashCode;
    private string literalValue = string.Empty;
    private byte[]? bytes;
    #endregion

    #region Constructors
    public PdfReal() : this(0f)
    {
    }

    public PdfReal(float value)
    {
        if (value >= -approximationValue && value <= approximationValue)
        {
            value = 0;
        }

        Value = value;
        hashCode = HashCode.Combine(nameof(PdfReal).GetHashCode(), value.GetHashCode());
        bytes = null;
    }
    #endregion

    #region Properties
    public int Length => ToString().Length;

    public float Value { get; }

    public byte[] Bytes => bytes ??= Encoding.ASCII.GetBytes(ToString());
    #endregion

    #region Public Methods
    public override string ToString()
    {
        if (literalValue.Length == 0)
        {
            literalValue = Value.ToString(CultureInfo.InvariantCulture);
        }

        return literalValue;
    }

    public override int GetHashCode()
    {
        return hashCode;
    }

    public bool Equals(PdfReal other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        return (obj is PdfReal integerObject) && Equals(integerObject);
    }

    public int CompareTo(object? obj)
    {
        if (obj is not PdfReal pdfInteger)
        {
            throw new ArgumentException(Resource.Arg_MustBePdfReal);
        }

        return CompareTo(pdfInteger);
    }

    public int CompareTo(PdfReal other)
    {
        if (Value == other.Value)
        {
            return 0;
        }

        return Value > other.Value ? 1 : -1;
    }
    #endregion

    #region Operators
    public static bool operator ==(PdfReal leftOperator, PdfReal rightOperator)
    {
        return leftOperator.CompareTo(rightOperator) == 0;
    }

    public static bool operator !=(PdfReal leftOperator, PdfReal rightOperator)
    {
        return leftOperator.CompareTo(rightOperator) != 0;
    }

    public static bool operator <(PdfReal leftOperator, PdfReal rightOperator)
    {
        return leftOperator.CompareTo(rightOperator) < 0;
    }

    public static bool operator <=(PdfReal leftOperator, PdfReal rightOperator)
    {
        return leftOperator.CompareTo(rightOperator) <= 0;
    }

    public static bool operator >(PdfReal leftOperator, PdfReal rightOperator)
    {
        return leftOperator.CompareTo(rightOperator) > 0;
    }

    public static bool operator >=(PdfReal leftOperator, PdfReal rightOperator)
    {
        return leftOperator.CompareTo(rightOperator) >= 0;
    }

    public static implicit operator float(PdfReal pdfInteger)
    {
        return pdfInteger.Value;
    }

    public static implicit operator PdfReal(float value)
    {
        return new(value);
    }
    #endregion
}
