namespace LeetCodeInCS._1013_Partition_Array_Into_Three_Parts_With_Equal_Sum
{
	public class Solution
	{
		public bool CanThreePartsEqualSum(int[] A)
		{
			int sum = 0;
			foreach (int a in A)
				sum += a;

			if (sum % 3 != 0 || A.Length < 3)
				return false;

			int l = 0, r = A.Length - 1, partSum = sum / 3;
			int leftPart = A[0], rightPart = A[A.Length - 1];

			while (l + 1 < r)
			{
				if (leftPart == partSum && rightPart == partSum)
					return true;

				if (leftPart != partSum)
					leftPart += A[++l];

				if (rightPart != partSum)
					rightPart += A[--r];
			}
			return false;
		}
	}
}
