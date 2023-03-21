using System;
using Metamorphoses;

Polynomial g = new Polynomial(new Polynomial.Monomial(2,1));

g.Get_Monomials().Add(new Polynomial.Monomial(-7,2));
g.Get_Monomials().Add(new Polynomial.Monomial(1,333));
Console.WriteLine(g.Get_Monomials());
Console.WriteLine(g);
Console.WriteLine(g.Get_Monomials());
Console.WriteLine();

TList<int> a = new TList<int>(-1);
a.Add(-2);
a.Add(-3);
Console.WriteLine(a);
//Console.WriteLine(g.Get_Monomials());
