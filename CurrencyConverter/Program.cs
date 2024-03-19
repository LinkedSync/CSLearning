namespace CurrencyConverter
{
	public class Program
	{
		public static void Main() =>
			AppMenu();

		private static void AppMenu()
		{
			try
			{
				var amountQuantity = GetQuantityFromUser();
				var currentConverter = GetCurrencyOptionFromUser();

				ConvertCurrency(currentConverter, amountQuantity);
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine("[---------------------------------|");
				Console.WriteLine($"[ ***** {ex.Message} *****");
				Console.WriteLine("[---------------------------------|");
			}
		}

		private static byte GetCurrencyOptionFromUser()
		{
			Console.WriteLine("[---------------------------------|");
			Console.WriteLine("[ 1 ] Real To Dolar");

			Console.WriteLine("[ 2 ] Dollar To Real");
			Console.Write("[---------------------------------|\n[ ");
			return Convert.ToByte(Console.ReadLine());
		}

		private static decimal GetQuantityFromUser()
		{
			Console.WriteLine("[---------------------------------|");
			Console.Write("[ Enter Your Quantity: ");

			return Convert.ToDecimal(Console.ReadLine());
		}

		private static void DisplayConversionResult(decimal convertedValue)
		{
			Console.WriteLine("[---------------------------------|");
			Console.WriteLine($"[ Quantity: {convertedValue}");
			Console.WriteLine("[---------------------------------|");
		}

		private static void ConvertCurrency(byte currencyOption, decimal amount)
		{
			decimal convertedTo = 0.0m;

			switch (currencyOption)
			{
				case 1:
					convertedTo = ConverterRealToDollar(amount);
					DisplayConversionResult(convertedTo);
					break;

				case 2:
					convertedTo = ConverterDollarToReal(amount);
					DisplayConversionResult(convertedTo);
					break;

				default:
					throw new ArgumentException($"Invalid Operation {currencyOption}");
			}
		}

		private static decimal ConverterDollarToReal(decimal stateValue) =>
			stateValue * 0.20m;

		private static decimal ConverterRealToDollar(decimal stateValue) =>
			stateValue * 5.03m;
	}
}