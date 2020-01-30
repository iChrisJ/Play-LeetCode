namespace LeetCodeInCS._0779_K_th_Symbol_in_Grammar
{
	public class Solution
	{
		public int KthGrammar(int N, int K)
		{
			if (N == 1)
				return 0;
			int ans = KthGrammar(N - 1, (K + 1) / 2);
			return K % 2 == 1 ? ans : 1 - ans;
			// return (~K & 1) ^ KthGrammar(N - 1, (K + 1) / 2);
			// ~K & 1 equals 1, that means the K is even, equals 0 means the K is odd;
			// if K is even, then the currnt value is the opposite of the parent. Otherwise, it's same as the parent. 
		}
	}
}
