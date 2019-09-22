namespace CSharp._0058_Length_of_Last_Word
{
	public class Solution
	{
		public int LengthOfLastWord(string s)
		{
			int lastWordLength = 0;

			for (int i = s.Length - 1; i >= 0; i--)
			{
				if (s[i] != ' ')
				{
					lastWordLength++;
					if (i - 1 < 0 || s[i - 1] == ' ')
						return lastWordLength;
				}
			}
			return lastWordLength;
		}
	}
}
