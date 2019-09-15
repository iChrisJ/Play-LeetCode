using System;

namespace CSharp.Dynamic_Programming
{
	/// <summary>
	/// 给定两个字符串str1和str2, 再给定三个整数ic, dc和rc, 分别代表插入,删除和替换一个字符的代价.
	/// 返回将str1编辑成str2的最小代价比如, str1="abc", str2="adc", ic=5, dc=3, rc=2.
	/// 从"abc"编辑成"adc", 把'b'替换成'd'是代价最小的, 所以返回2.
	/// 再比如, str1="abc", str2="adc", ic=5, dc=3, rc=100.
	/// 从"abc"编辑成"adc", 先删除'b', 然后插入'd'是代价最小的, 所以返回8
	/// </summary>
	class MinCost_Solution
	{
		public int FindMinCost(string str1, string str2, int ic, int dc, int rc)
		{
			/// 假设str1的长度为M, str2的长度为N. 首先生成大小为(M+1)＊(N+1)的矩阵dp,
			/// dp[i][j]的值代表str1[0..i-1]编辑成str2[0..j-1]的最小代价.
			/// 比如, str1="ab12cd3", str2="abcdf", ic=5, dc=3, rc=2
			/// dp如下:
			///			''	'a'	'b'	'c'	'd'	'f'
			///		''	0	5	10	15	20	25
			///		'a'	3	0	5	10	15	20
			///		'b'	6	3	0	5	10	15
			///		'1'	9	6	3	2	7	12
			///		'2'	12	9	6	5	4	9
			///		'c'	15	12	9	6	7	6
			///		'd'	18	15	12	9	6	9
			///		'3'	21	18	15	12	9	8
			///
			/// 下面具体说明dp矩阵每个位置的值是如何计算的:
			/// 1. dp[0][0]设置为0,表示str1空的子串编辑成str2空的子串,故代价为0
			/// 2. 矩阵dp第一列即dp[0..M][0], dp[i][0]表示str1[0..i-1]编辑成空串的最小代价, 即把str1[0..i-1]所有字符都删掉的代价, 故dp[i][0]=dc＊i
			/// 3. 矩阵dp第一行即dp[0][0..N], dp[0][j]表示空串编辑成str2[0..j-1]的最小代价, 即在空串里插入str2[0..j-1]的所有字符的代价, 故dp[0][j]=ic＊j
			/// 4. 其他位置按照先从左到右, 再从上到下来计算, d[i][j]的值只可能来自以下四种情况:
			///		1). str1[0..i-1]可以先编辑成str1[0..i-2], 也就是删除字符str1[i-1], 然后由str1[0..i-2]编辑成str2[0..j-1], dp[i-1][j]就表示str1[0..i-2]编辑成str2[0..j-1]的最小代价, 那么dp[i][j]可能等于dc+dp[i-1][j].
			///		2). str1[0..i-1]可以先编辑成str2[0..j-2], 然后将str2[0..j-2]插入字符str2[j-1], 编辑成str2[0..j-1]. dp[i][j-1]表示str1[0..i-1]编辑成str2[0..j-2]的最小代价, 那么dp[i][j]可能等于dp[i][j-1]+ic.
			///		3). 如果str1[i-1] != str2[j-1]. 先把str1[0..i-1]中str1[0..i-2]的部分变成str2[0..j-2], 然后把字符str1[i-1]替换成str2[j-1],这样str1[0..i-1]就编辑成str2[0..j-1]了.
			///			dp[i-1][j-1]就表示str1[0..i-2]编辑成str2[0..j-2]的最小代价, 那么dp[i][j]可能等于dp[i-1][j-1]+rc.
			///		4). 如果str1[i-1] == str2[j-1],先把str1[0..i-1]中str1[0..i-2]的部分变成str2[0..j-2], 因为此时字符str1[i-1]等于str2[j-i], 所以str1[0..i-1]已经编辑成str2[0..j-1],
			///			dp[i-1][j-1]就表示str1[0..i-2]编辑成str2[0..j-2]的最小代价, 那么dp[i][j]可能等于dp[i-1][j-1].
			///	  以上四种可能的值中,选最小值作为dp[i][j]的值
			///	5. 最终结果返回dp最右下角的值
			if (str1 == null || str2 == null)
				return 0;

			int[,] dp = new int[str1.Length + 1, str2.Length + 1];

			dp[0, 0] = 0;
			for (int i = 1; i <= str1.Length; i++)
				dp[i, 0] = dc * i;

			for (int i = 1; i <= str2.Length; i++)
				dp[0, i] = ic * i;

			for (int i = 1; i <= str1.Length; i++)
			{
				for (int j = 1; j <= str2.Length; j++)
				{
					int dcCost = dp[i - 1, j] + dc;
					int icCost = dp[i, j - 1] + ic;
					int rcCost = str1[i - 1] == str2[j - 1] ? dp[i - 1, j - 1] : dp[i - 1, j - 1] + rc;
					dp[i, j] = Math.Min(Math.Min(dcCost, icCost), rcCost);
				}
			}
			return dp[str1.Length, str2.Length];
		}
	}
}
