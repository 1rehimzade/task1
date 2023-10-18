using System;
using System.Linq;

public class ListInt
{
    private int[] array;

    public ListInt()
    {
        array = new int[0];
    }

    public int this[int index]
    {
        get
        {
            if (index >= 0 && index < array.Length)
            {
                return array[index];
            }
            else
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
        }
        set
        {
            if (index >= 0 && index < array.Length)
            {
                array[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
        }
    }

    public void Add(int num)
    {
        Array.Resize(ref array, array.Length + 1);
        array[array.Length - 1] = num;
    }

    public void AddRange(params int[] nums)
    {
        int originalLength = array.Length;
        Array.Resize(ref array, array.Length + nums.Length);
        Array.Copy(nums, 0, array, originalLength, nums.Length);
    }

    public bool Contains(int num)
    {
        return Array.IndexOf(array, num) != -1;
    }

    public int Sum()
    {
        return array.Sum();
    }

    public void RemoveRange(params int[] nums)
    {
        int newLength = array.Length;
        foreach (int num in nums)
        {
            newLength -= Array.IndexOf(array, num) != -1 ? 1 : 0;
        }

        int[] newArray = new int[newLength];
        int newIndex = 0;
        foreach (int num in array)
        {
            if (Array.IndexOf(nums, num) == -1)
            {
                newArray[newIndex] = num;
                newIndex++;
            }
        }

        array = newArray;
    }

    public override string ToString()
    {
        return string.Join(", ", array);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ListInt myList = new ListInt();
        myList.Add(1);
        myList.AddRange(2, 3, 4);
        myList.Add(5);
        myList.RemoveRange(3, 5);
        myList[0] = 10;
        int sum = myList.Sum();

        Console.WriteLine(myList.Contains(2));
        Console.WriteLine(myList.Contains(3));
        Console.WriteLine(myList);
    }
}
