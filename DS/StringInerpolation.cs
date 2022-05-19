using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public static class StringInerpolation
    {
        public static void BestUsages()
        {
            // Structure of an interpolated string
            Console.WriteLine($"|{"Left",-7}|{"Right",7}|");

            const int FieldWidthRightAligned = 20;
            Console.WriteLine($"{Math.PI,FieldWidthRightAligned} - default formatting of the pi number");
            Console.WriteLine($"{Math.PI,FieldWidthRightAligned:F3} - display only three decimal digits of the pi number");

            // Use of Special characters
            string name = "Horace";
            int age = 34;
            Console.WriteLine($"He asked, \"Is your name {name}?\", but didn't wait for a reply :-{{");
            Console.WriteLine($"{name} is {age} year{(age == 1 ? "" : "s")} old.");

            // Conversion of interpolation string
            double speedOfLight = 299792.458;
            FormattableString message = $"The speed of light is {speedOfLight:N3} km/s.";

            System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("nl-NL");
            string messageInCurrentCulture = message.ToString();

            var specificCulture = System.Globalization.CultureInfo.GetCultureInfo("en-IN");
            string messageInSpecificCulture = message.ToString(specificCulture);

            string messageInInvariantCulture = FormattableString.Invariant(message);

            Console.WriteLine($"{System.Globalization.CultureInfo.CurrentCulture,-10} {messageInCurrentCulture}");
            Console.WriteLine($"{specificCulture,-10} {messageInSpecificCulture}");
            Console.WriteLine($"{"Invariant",-10} {messageInInvariantCulture}");
        }
    }
}
