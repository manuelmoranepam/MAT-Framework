namespace OrangeHRMTestingSuite.Helpers
{
	public static class RandomDataHelper
	{
		private static Random _random = new Random();

		public static int GetRandomIndex()
		{
			var index = _random.Next();

			return index;
		}

		public static int GetRandomIndex(int exclusiveMax)
		{
			var index = _random.Next(exclusiveMax);

			return index;
		}

		public static int GetRandomIndex(int inclusiveMin, int exclusiveMax)
		{
			int index;

			if (inclusiveMin < exclusiveMax)
			{
				index = _random.Next(inclusiveMin, exclusiveMax);
			}
			else
			{
				index = _random.Next(exclusiveMax, inclusiveMin);
			}

			return index;
		}
	}
}
