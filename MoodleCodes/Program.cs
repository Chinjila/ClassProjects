
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StackSample();
        QueueSample();
        BinarySearchSample();
        BubblesortSample();
        MergesortSample();
    }

    private static void QueueSample()
    {
        var demo = new Queue<int>();

        demo.Enqueue(2);
        demo.Enqueue(4);
        var firstInQueue = demo.Peek();
        Console.WriteLine($"First in the queue: {firstInQueue}");

        var firstRemoved = demo.Dequeue();
        Console.WriteLine($"Value Removed: {firstRemoved}");
        var lastInQueue = demo.Peek();
        Console.WriteLine($"Value Remaining: {lastInQueue}");
        Console.ReadLine();
    }

    private static void StackSample()
    {
        var stack = new Stack<int>();

        stack.Push(11);

        stack.Push(13);

        stack.Push(2);

        stack.Peek();

        foreach (var item in stack)

        { Console.Write(item + ","); } //prints 11,13,2,}

        stack.Pop();

        Console.Write("\n");

        foreach (var item in stack)
        {

            Console.Write(item + ",");
        }
    }


    #region BinarySearch
    private static int IterationCount { get; set; }
    public static void BinarySearchSample()
    {
        //Binary search only works on sorted arrays
        int[] data = new int[] { 1, 3, 4, 5, 6 , 7, 9 ,10 , 11 , 12 };
        int searchValue = 6;
        IterationCount = 0;
        bool found = binarySearch(searchValue, data, 0, data.Count());
        var message = "Total iterations to determine the number was not present";
        if (found)
        {
            message = "Total iterations to find the number";
        }

        Console.WriteLine($"{message}: {IterationCount}");
        Console.ReadLine();
    }
    private static bool binarySearch(int v, int[] lst, int low, int high)
    {
        IterationCount += 1;
        if (low > high)
        {
            Console.WriteLine("not found");
            return false;
        }

        int middle = (low + high) / 2;

        if (v == lst[middle])
        {
            Console.WriteLine("Match found! It is at: " + middle);
            return true;
        }
        else if (v < lst[middle])
        {
            return binarySearch(v, lst, low, middle - 1);
        }
        else
        {
            return binarySearch(v, lst, middle + 1, high);
        }

    }
    #endregion

    #region BubbleSort
    internal static void BubblesortSample()
    {

        int[] data = new int[] { 4, 9, 7, 1, 3, 6, 5 };

        bool swapped;
        do
        {
            swapped = false;
            for (int i = 0; i < data.Count() - 1; i++)
            {
                var currentData = data[i];
                var nextData = data[i + 1];
                if (currentData > nextData)
                {
                    int temp = currentData;
                    data[i] = nextData;
                    data[i + 1] = temp;
                    swapped = true;
                }
            }
        } while (swapped);

    }
    #endregion

    #region MergeSorting
    private async static void MergesortSample()
    {
        int[] data = new int[] { 4, 9, 7, 1, 3, 6, 5 };
        await MergeSorting(data, 0, data.Length - 1);
    }
    private static async Task MergeSorting(int[] theData, int startIndex, int endIndex)
    {
        if (endIndex > startIndex)
        {
            int splitIndex = (endIndex + startIndex) / 2;
            await MergeSorting(theData, startIndex, splitIndex);
            await MergeSorting(theData, splitIndex + 1, endIndex);
            await Merge(theData, startIndex, splitIndex + 1, endIndex);
        }
    }

    private static async Task Merge(int[] input, int left, int mid, int right)
    {
        //Merge procedure takes theta(n) time
        int[] temp = new int[input.Length];
        int i, leftEnd, lengthOfInput, tmpPos;
        leftEnd = mid - 1;
        tmpPos = left;
        lengthOfInput = right - left + 1;

        //selecting smaller element from left sorted array or right sorted array and placing them in temp array.
        while ((left <= leftEnd) && (mid <= right))    {
            if (input[left] <= input[mid])         {
                temp[tmpPos++] = input[left++];
            }
         else
            {
                temp[tmpPos++] = input[mid++];
            }
        }
        //placing remaining element in temp from left sorted array
        while (left <= leftEnd)     {
            temp[tmpPos++] = input[left++];
        }

        //placing remaining element in temp from right sorted array
        while (mid <= right)    {
            temp[tmpPos++] = input[mid++];
        }

        //placing temp array to input
        for (i = 0; i < lengthOfInput; i++)    {
            input[right] = temp[right];
            right--;
        }
    }

    #endregion
}