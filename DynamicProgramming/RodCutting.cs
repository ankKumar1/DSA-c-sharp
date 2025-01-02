namespace DynamicProgramming
{
    // find maximum revenue after cutting rod of length n where cost of cutting is given at each length. 
    public class RodCutting
    {
        public void Main()
        {
            // price of rod cutting of length i, i is index;
            int[] costs = [0, 1, 5, 8, 9, 10, 17, 17, 20, 24];
            //rod length
            int length = 5;
            Console.WriteLine($"Maximum Profit Recursive: {MaxRevenue(costs, length)}");
            Console.WriteLine($"Maximum Profit DP: {MaxRevenueDP(costs, length)}");
        }

        //Recursion Method
        public static int MaxRevenue(int[] costs, int n)
        {
            if (n == 0) return 0;

            int profit = int.MinValue;

            for (int i = 1; i <= n; i++)
            {
                profit = Math.Max(profit, costs[i] + MaxRevenue(costs, n - i));
            }
            return profit;
        }

        //DP method - Bottom-up
        public static int MaxRevenueDP(int[] costs, int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = costs[0];

            for (int i = 1; i <= n; i++)
            {
                int profit = int.MinValue;
                for (int j = 1; j <= i; j++)
                {
                    profit = Math.Max(profit, costs[j] + dp[i - j]);
                }
                dp[i] = profit;
            }
            return dp[n];
        }
    }
}
