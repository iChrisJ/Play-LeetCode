namespace CSharp._0345_Reverse_Vowels_of_a_String
{
	public class Solution
	{
		public string ReverseVowels(string s)
		{
			char[] charArr = s.ToCharArray();
			int i = 0, j = charArr.Length - 1;

			while (i <= j)
			{
				while (i < charArr.Length && !IsVowel(charArr[i]))
					i++;
				while (j > 0 && !IsVowel(charArr[j]))
					j--;
				if (i <= j)
				{
					char temp = charArr[i];
					charArr[i] = charArr[j];
					charArr[j] = temp;
					i++;
					j--;
				}
				else
					return new string(charArr);
			}
			return new string(charArr);

		}

		public bool IsVowel(char c)
		{
			char ch = char.ToLower(c);
			if (ch == 'a' || ch == 'e' || ch == 'o' || ch == 'i' || ch == 'u')
				return true;
			return false;
		}
	}
}
