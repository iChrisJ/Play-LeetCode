namespace CSharp._0344_Reverse_String
{
	public class Solution
	{
		public void ReverseString(char[] s)
		{
			int i = 0, j = s.Length - 1;
			while (i <= j)
			{
				char temp = s[i];
				s[i] = s[j];
				s[j] = temp;
				i++;
				j--;
			}
		}
	}
}
