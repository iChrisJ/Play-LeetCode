using System;
using System.Collections.Generic;

namespace CSharp._0299_Bulls_and_Cows
{
	public class Solution
	{
		public string GetHint(string secret, string guess)
		{
			if (secret == null || secret.Length == 0)
				throw new Exception("Incorrect parameters!");
			if (guess == null || guess.Length == 0)
				return "0A0B";

			Dictionary<char, int> dict = new Dictionary<char, int>();

			int bull = 0;
			for (int i = 0; i < secret.Length; i++)
			{
				if (secret[i] == guess[i])
					bull++;
				else
				{
					if (dict.ContainsKey(secret[i]))
						dict[secret[i]]++;
					else
						dict.Add(secret[i], 1);
				}
			}

			int cow = 0;
			for (int i = 0; i < guess.Length; i++)
			{
				if (secret[i] != guess[i])
				{
					if (dict.ContainsKey(guess[i]) && dict[guess[i]] > 0)
					{
						cow++;
						dict[guess[i]]--;
					}
				}
			}
			return $"{bull}A{cow}B";
		}
	}
}
