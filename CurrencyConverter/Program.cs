namespace CurrencyConverter
{
	public class Program
	{
		public static void Main() =>
			AppMenu();

		private static void AppMenu()
		{
			while (true)
			{
				try
				{
					var amountQuantity = GetQuantityFromUser();
					var currentConverter = GetCurrencyOptionFromUser();

					if (HandleExitOption(currentConverter)) break;
					ConvertCurrency(currentConverter, amountQuantity);
				}
				catch (ArgumentException ex)
				{
					Console.WriteLine("[---------------------------------|");
					Console.WriteLine($"[ ***** {ex.Message} *****");
					Console.WriteLine("[---------------------------------|");
				}
				catch (FormatException)
				{
					Console.WriteLine("[---------------------------------|");
					Console.WriteLine($"[ ***** Just Number *****");
					Console.WriteLine("[---------------------------------|");
				}
			}
		}

		private static byte GetCurrencyOptionFromUser()
		{
			Console.WriteLine("[---------------------------------|");
			Console.WriteLine("[ 0 ] Exit");
			Console.WriteLine("[ 1 ] Real To Euro");
			Console.WriteLine("[ 2 ] Real To Dollar");
			Console.WriteLine("[ 3 ] Dollar To Real");
			Console.WriteLine("[ 4 ] Dollar To Euro");
			Console.WriteLine("[ 5 ] Euro To Dollar");
			Console.WriteLine("[ 6 ] Euro To Real");
			Console.Write("[---------------------------------|\n[ ");

			return Convert.ToByte(Console.ReadLine());
		}

		private static decimal GetQuantityFromUser()
		{
			Console.WriteLine("[---------------------------------|");
			Console.Write("[ Enter Your Quantity: ");

			return Convert.ToDecimal(Console.ReadLine());
		}

		private static void ConvertCurrency(byte currencyOption, decimal amount)
		{
			decimal convertedTo;

			switch (currencyOption)
			{
				case 1:
					convertedTo = ConverterRealToEuro(amount);
					DisplayConversionResult(convertedTo);
					break;

				case 2:
					convertedTo = ConverterRealToDollar(amount);
					DisplayConversionResult(convertedTo);
					break;

				case 3:
					convertedTo = ConverterDollarToReal(amount);
					DisplayConversionResult(convertedTo);
					break;

				case 4:
					convertedTo = ConverterDollarToEuro(amount);
					DisplayConversionResult(convertedTo);
					break;

				case 5:
					convertedTo = ConverterEuroToDollar(amount);
					DisplayConversionResult(convertedTo);
					break;

				case 6:
					convertedTo = ConverterEuroToReal(amount);
					DisplayConversionResult(convertedTo);
					break;

				default:
					throw new ArgumentException($"Invalid Operation {currencyOption}");
			}
		}

		private static void DisplayConversionResult(decimal convertedValue)
		{
			Console.WriteLine("[---------------------------------|");
			Console.WriteLine($"[ Quantity: {convertedValue}");
			Console.WriteLine("[---------------------------------|");
		}

		private static bool HandleExitOption(byte currencyOption)
		{
			if (currencyOption == 0)
			{
				Environment.Exit(0);
				return true;
			}

			return false;
		}

		private static decimal ConverterDollarToReal(decimal stateValue) =>
			stateValue * 0.20m;

		private static decimal ConverterDollarToEuro(decimal stateValue) =>
			stateValue * 1.01m;

		private static decimal ConverterRealToDollar(decimal stateValue) =>
			stateValue * 5.03m;

		private static decimal ConverterRealToEuro(decimal stateValue) =>
			stateValue * 5.47m;

		private static decimal ConverterEuroToReal(decimal stateValue) =>
			stateValue * 0.18m;

		private static decimal ConverterEuroToDollar(decimal stateValue) =>
			stateValue * 0.92m;
	}
}