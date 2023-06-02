using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace VerstaTask.Arrtibutes
{
    public class StreetAttribute : ValidationAttribute
    {
        public StreetAttribute()
        { }

        public override bool IsValid(object? value)
        {
            if (value == null)
                return false;

            var streetName = value as string;

            return !streetName.Any(x => x == ',');
        }
    }
}
