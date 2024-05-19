namespace ErpStudy.Domain.ValueObjects
{
    public class SKUCode : IEquatable<SKUCode>
    {
        public string Value { get; }

        public SKUCode(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O código SKU não pode estar vazio ou em branco.", nameof(value));
            }

            Value = value.Trim()
                .ToUpper(); // Normaliza o código SKU para maiúsculas e remove espaços em branco desnecessários
        }

        public override string ToString()
        {
            return Value;
        }

        public bool Equals(SKUCode? other)
        {
            if (other is null) return false;
            return ReferenceEquals(this, other) ||
                   string.Equals(Value, other.Value, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((SKUCode)obj);
        }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(Value);
        }
    }
}