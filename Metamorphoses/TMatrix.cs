namespace Metamorphoses;

using System.Numerics;
using System;

public class TMatrix<T> where T : INumber<T>
{
    public uint Height { get; set; }

    public uint Width { get; set; }

    public T[,] Elements { get; set; }

    public T this[uint h, uint w]
    {
        get => Elements[h, w];
        set => Elements[h, w] = value;
    }

    public class DimensionsMismatchException : Exception
    {
    }

    public class UnsupportedValueException : Exception
    {
    }

    //Instantiates a TMatrix of size width*height
    public TMatrix(uint width, uint height)
    {
        Width = width;
        Height = height;
        Elements = new T[height, width];
    }

    //Instantiates a TMatrix of size width*height filled with element
    public TMatrix(uint width, uint height, T element)
    {
        Width = width;
        Height = height;
        Elements = new T[height, width];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Elements[i, j] = element;
            }
        }
    }

    //Instantiates a TMatrix from an array of two dimensions
    public TMatrix(T[,] elements)
    {
        Height = (uint) elements.GetLength(0);
        Width = (uint) elements.GetLength(1);

        Elements = elements;
    }

    //Returns the string representing the TMatrix graphically 
    public override string ToString()
    {
        if (Height == 0 || Width == 0)
            return "{ }";
        string acc = "{ { ";

        for (int i = 0; i < Height; i++)
        {
            int j = 0;
            for (; j < Width-1; j++)
            {
                acc += Elements[i, j];
                acc += ", ";
            }
            acc += Elements[i, j];
            acc += " ";
            
            if (i < Height-1)
                acc += "}   \n  { ";
        }

        return acc + "} }";
    }

    //Returns true if both matrices are equals
    public static bool operator ==(TMatrix<T> m1, TMatrix<T> m2)
    {
        if (m1.Width != m2.Width || m1.Width != m2.Width)
            return false;

        for (int i = 0; i < m1.Height; i++)
        {
            for (int j = 0; j < m1.Width; j++)
            {
                if (!Equals(m1.Elements[i, j], m2.Elements[i, j]))
                {
                    return false;
                }
            }
            
        }


        return true;
    }

    //Returns false if both matrices are equals, we hightly suggest to use the == operator
    public static bool operator !=(TMatrix<T> m1, TMatrix<T> m2)
    {
        return !(m1 == m2);
    }

    //Returns the sum of two matrices of numbers. Tt must not modify the parameters
    public static TMatrix<T> operator +(TMatrix<T> m1, TMatrix<T> m2)
    {
        if (m1.Width != m2.Width || m1.Height != m2.Height)
            throw new DimensionsMismatchException();

        TMatrix<T> result = new TMatrix<T>(m1.Width, m1.Height);
        for (int i = 0; i < m1.Height; i++)
        {
            for (int j = 0; j < m1.Width; j++)
            {
                result.Elements[i, j] = m1.Elements[i, j] + m2.Elements[i, j];
            }
        }

        return result;
    }

    //Returns the subtraction of two matrices of numbers. It must not modify the parameters
    public static TMatrix<T> operator -(TMatrix<T> m1, TMatrix<T> m2)
    {
        if (m1.Width != m2.Width || m1.Height != m2.Height)
            throw new DimensionsMismatchException();

        TMatrix<T> result = new TMatrix<T>(m1.Width, m1.Height);
        for (int i = 0; i < m1.Height; i++)
        {
            for (int j = 0; j < m1.Width; j++)
            {
                result.Elements[i, j] = m1.Elements[i, j] - m2.Elements[i, j];
            }
        }

        return result;
    }

    //Returns the result of the multiplication of a TMatrix of numbers and an integer n
    public static TMatrix<T> operator *(TMatrix<T> m, T n)
    {
        TMatrix<T> result = new TMatrix<T>(m.Width, m.Height);
        for (int i = 0; i < m.Height; i++)
        {
            for (int j = 0; j < m.Width; j++)
            {
                result.Elements[i, j] = m.Elements[i, j] * n;
            }
        }

        return result;
    }

    //Multiplies two matrices of numbers and returns the result
    public static TMatrix<T> operator *(TMatrix<T> m1, TMatrix<T> m2)
    {
        if (m1.Width != m2.Height)
            throw new DimensionsMismatchException();

        TMatrix<T> result = new TMatrix<T>(m2.Width, m1.Height);
        
        for (int i = 0; i < result.Height; i++)
        {
            for (int j = 0; j < result.Width; j++)
            {
                for (int k = 0; k < m1.Width; k++)
                {
                    result.Elements[i, j] += m1.Elements[i, k] * m2.Elements[k, j];
                }
            }
        }
        
        return result;
    }

    //Returns a new TMatrix of numbers that is the TMatrix m1 at power n
    public static TMatrix<T> operator ^(TMatrix<T> m1, uint n)
    {
        if (n < 1)
            throw new UnsupportedValueException();
        
        TMatrix<T> result = new TMatrix<T>(m1.Width, m1.Height);
        
        for (int i = 0; i < m1.Height; i++)
        {
            for (int j = 0; j < m1.Width; j++)
            {
                result.Elements[i, j] = m1.Elements[i,j];
            }
        }

        for (int k = 0; k < n-1; k++)
        {
            result *= m1;
        }
        
        return result;
    }

    //Transform the TMatrix into its transpose
    public void Transpose()
    {
        T[,] Transposed = new T[Width, Height];

        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                Transposed[j, i] = Elements[i, j];
            }
        }

        (Height, Width) = (Width, Height);
        Elements = Transposed;
    }
}