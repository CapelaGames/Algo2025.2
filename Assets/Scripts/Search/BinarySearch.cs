using UnityEngine;

//https://www.youtube.com/@TooTallProductions/videos
public class BinarySearch : Search
{
    public override int Find(int[] numbers, int target)
    {
        int i = 0;
        int j = numbers.Length - 1;

        while (i <=j)
        {
            int middle = i + (j - i) / 2;

            if (numbers[middle] < target)
            {
                i = middle + 1;
            }
            else if (numbers[middle] > target)
            {
                j = middle - 1;
            }
            else
            {
                return middle;
            }
        }
        return -1;
    }
}
