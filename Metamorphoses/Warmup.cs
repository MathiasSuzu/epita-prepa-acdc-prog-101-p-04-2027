using System;

namespace Metamorphoses;

public class Warmup
{
    //Returns the maximum of two integers
    public static int Max(int x, int y)
    {
        if (x > y)
            return x;
        
        return y;
    }

    //Returns the maximum of two strings representing numbers
    public static string Max(string x, string y)
    {

        (string,string) Bigger(string a, string b)
        {
            int i = 0;
            if (a[0] == '-')
                i++;
            for (; i < a.Length; i++)
            {
                if (a[i] > b[i])
                {
                    return (a, b);
                }

                if (b[i] > a[i])
                {
                    return (b, a);
                }
            }
            
            return (a,b);
        } 
        
        if (x[0] == '-' && y[0] != '-') 
            return y;
        if (x[0] != '-' && y[0] == '-')
            return x;

        (int xLen, int yLen) = (x.Length, y.Length);

        if (x[0] == '-' && y[0] == '-')
        {

            if (xLen > yLen)
                return y;
            else if (yLen > xLen)
                return x;
            else
            {
                return Bigger(x, y).Item2;
            }
        }
        else
        {
            if (xLen > yLen)
                return x;
            else if (yLen > xLen)
                return y;
            else
            {
                return Bigger(x, y).Item1;
            }
        }
    }

    //Returns the sum of all the elements of an array of integers
    public static int SumArray(int[] tab)
    {
        int acc = 0;

        foreach (int current in tab)
        {
            acc += current;
        }
        
        return acc;
    }

    //Returns the concatenation of all the elements of an array of strings
    public static string SumArray(string[] tab)
    {
        string acc = "";

        foreach (string current in tab)
        {
            acc += current;
        }
        
        return acc;
    }
}