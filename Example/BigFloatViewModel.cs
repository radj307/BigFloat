using radj307;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Example
{
    internal class BigFloatViewModel : INotifyPropertyChanged
    {
        public BigFloatViewModel() => _value = new();

        private BigFloat? _value;
        public BigFloat? Value
        {
            get => _value;
            set
            {
                _value = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(String));
            }
        }
        public string? String
        {
            get => Value?.ToString();
            set
            {
                if (value is null)
                {
                    Value = null;
                    NotifyPropertyChanged();
                    return;
                }
                _ = BigFloat.TryParse(value, out _value);
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(Value));
            }
        }

        public string ToString(int precision, bool trailingZeros = false) => Value?.ToString(precision, trailingZeros) ?? string.Empty;
        public override string ToString() => this.ToString(10, false);

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new(propertyName));
    }
}
