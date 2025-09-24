using UnityEngine;

public abstract class Search
{
    public abstract int Find(int[] numbers, int target);
}

public class BruteForceSearch : Search
{
    public override int Find(int[] numbers, int target)
    {
        for (int x = 0; x < numbers.Length; x++)
        {
            if (numbers[x] == target)
            {
                return x;
            }
        }

        return -1;
    }
}