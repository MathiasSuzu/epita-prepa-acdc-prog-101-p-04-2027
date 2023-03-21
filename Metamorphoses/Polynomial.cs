using System;
using System.Threading;

namespace Metamorphoses;

public class Polynomial
{
    public class Monomial
    {
        public uint Degree { get; set; }

        public int Coefficient { get; set; }

        //Instantiates the zero Monomial
        public Monomial()
        {
            (Degree,Coefficient) = (0, 0);
        }

        //Instantiates a Monomial with set coefficient and degree
        public Monomial(int coefficient, uint degree)
        {
            (Degree,Coefficient) = (degree, coefficient);
        }

        //Returns a string representing a monomial
        public override string ToString()
        {
            string[] singleFactor = { "⁰", "¹", "²", "³", "⁴", "⁵", "⁶", "⁷", "⁸", "⁹" };

            string acc = "";

           if (Coefficient == 0)
                return "0";
            
            else if (Degree == 0)
                return Coefficient + "";
            else
            {
                foreach (char v in Degree + "")
                {
                    acc += singleFactor[v - 48];
                }
            
                if(Coefficient == 1)
                    return "X" + acc;
                else
                    return Coefficient + "X" + acc;
            }
            
                
            
        }

        //Returns true if both Monomials are equals
        public static bool operator ==(Monomial m1, Monomial m2)
        {
            return m1!.Coefficient == m2!.Coefficient && m1.Degree == m2.Degree;
        }

        //Returns false if both Monomials are equals
        public static bool operator !=(Monomial m1, Monomial m2)
        {
            return !(m1 == m2);
        }

        //Sum two Monomials when possible
        public static Monomial operator +(Monomial m1, Monomial m2)
        {
            if (m1.Degree != m2.Degree)
                throw new ArgumentException();
            
            Monomial result = new Monomial(m1.Coefficient + m2.Coefficient, m1.Degree);
            return result;
        }

        //Subtract a Monomial by another when possible
        public static Monomial operator -(Monomial m1, Monomial m2)
        {
            if (m1.Degree != m2.Degree)
                throw new ArgumentException();
            
            Monomial result = new Monomial(m1.Coefficient - m2.Coefficient, m1.Degree);
            return result;
        }

        //Multiply a Monomial by an integer
        public static Monomial operator *(Monomial m1, int n)
        {
            Monomial result = new Monomial(m1.Coefficient * n, m1.Degree);
            return result;
        }

        //Multiply two Monomials
        public static Monomial operator *(Monomial m1, Monomial m2)
        {
            Monomial result = new Monomial(m1.Coefficient * m2.Coefficient, m1.Degree + m2.Degree);
            return result;
        }
    }

    private TList<Monomial> _monomials { get; set; }

    public TList<Monomial> Get_Monomials()
    {
        return _monomials;
    }

    //Instantiates zero Polynomial
    public Polynomial()
    {
        _monomials = new TList<Monomial>();
    }

    //Instantiates a Polynomial from a single Monomial
    public Polynomial(Monomial m)
    { 
        _monomials = new TList<Monomial>(m);
        
    }

    //Returns the Monomial of degree n of a Polynomial
    public Monomial GetMonomial(int degree)
    {
        throw new NotImplementedException();
    }

    //Returns the string representing a Polynomial
    public override string ToString()
    {
        
        string acc = "";
        if (_monomials.Size == 0)
            acc += 0;
        else
        {
            TList<Monomial> recup = new TList<Monomial>();
            Monomial[] g =  new Monomial[_monomials.Size];
            TList<Monomial> temp = _monomials;
            
            int i = 1;
            recup.Add(new Monomial(temp.Head.Data.Coefficient,temp.Head.Data.Degree));
            g[0] = temp.Head.Data;
            temp.Head = temp.Head.Next;
            while (temp.Head != null)
            {
                for (int j = 0; j < i; j++)
                {
                    if (temp.Head.Data.Degree > g[j].Degree)
                    {
                        j += i;
                        for (uint l = _monomials.Size-1; l > j; l--)
                        {
                            g[l] = g[l-1];
                        }

                        g[j] = temp.Head.Data;
                    }
                }
                recup.Add(new Monomial(temp.Head.Data.Coefficient,temp.Head.Data.Degree));
                temp.Head = temp.Head.Next;
                
                i += 1;
            }
            
            acc += g[_monomials.Size-1];
            for (int l = (int)_monomials.Size-2; l >= 0; l--)
            {
                if (g[l].Coefficient < 0)
                {
                    g[l].Coefficient *= -1;
                    acc += " - " + g[l] ;
                }
                else
                    acc += " + " + g[l] ;
            }
            
            _monomials = recup;
        }
        
        
        return acc;
    }

    //Returns true if both Polynomials are equals
    public static bool operator ==(Polynomial p1, Polynomial p2)
    {
        throw new NotImplementedException();
    }

    //Returns false if both Polynomials are equals
    public static bool operator !=(Polynomial p1, Polynomial p2)
    {
        return !(p1 == p2);
    }

    //Add a Monomial m to a Polynomial p
    public static Polynomial operator +(Polynomial p, Monomial m)
    {
        throw new NotImplementedException();
    }

    //Sum two Polynomials
    public static Polynomial operator +(Polynomial p1, Polynomial p2)
    {
        throw new NotImplementedException();
    }

    //Subtract a Monomial m to a Polynomial p
    public static Polynomial operator -(Polynomial p, Monomial m)
    {
        throw new NotImplementedException();
    }

    //Subtract a Polynomial by another
    public static Polynomial operator -(Polynomial p1, Polynomial p2)
    {
        throw new NotImplementedException();
    }

    //Multiply a Polynomial p by a Monomial m
    public static Polynomial operator *(Polynomial p, Monomial m)
    {
        throw new NotImplementedException();
    }

    //Multiply two Polynomials
    public static Polynomial operator *(Polynomial p1, Polynomial p2)
    {
        throw new NotImplementedException();
    }

    //Derives a Polynomial
    public Polynomial Derivative()
    {
        throw new NotImplementedException();
    }

    //Primitives a Polynomial
    public Polynomial Primitive()
    {
        throw new NotImplementedException();
    }

    //Returns the integral of a Polynomial p in [a,b]
    public long Integral(long a, long b)
    {
        throw new NotImplementedException();
    }

    //Compare two Polynomials and return the one with the greater growth rate
    public static Polynomial ComparePolynomials(Polynomial p1, Polynomial p2)
    {
        throw new NotImplementedException();
    }

    //Returns p(n)
    public long PolynomialFunctionLong(long n)
    {
        throw new NotImplementedException();
    }

    //Apply a polynomial function p to all elements of a TMatrix of int m
    public TMatrix<long> ApplyPolynomialToTMatrix(TMatrix<long> m)
    {
        throw new NotImplementedException();
    }

    //Given a polynomial P and a TMatrix of int M, returns P(M)
    public TMatrix<long> PolynomialOfMatrix(TMatrix<long> m)
    {
        throw new NotImplementedException();
    }
}