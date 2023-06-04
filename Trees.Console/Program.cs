﻿// See https://aka.ms/new-console-template for more information
using TreeBase;

var root = new BinaryNode<string>("Root");
var a = new BinaryNode<string>("A");
var b = new BinaryNode<string>("B");
var c = new BinaryNode<string>("C");
var d = new BinaryNode<string>("D");
var e = new BinaryNode<string>("E");
var f = new BinaryNode<string>("F");

root.AddLeft(a);
root.AddRight(b);
a.AddLeft(c);
a.AddRight(d);
b.AddRight(e);
e.AddLeft(f);

Console.WriteLine(root);
//Console.WriteLine(a);
//Console.WriteLine(b);
//Console.WriteLine(c);
//Console.WriteLine(d);
//Console.WriteLine(e);
//Console.WriteLine(f);

Console.WriteLine("----------------------------");

var nRoot = new NaryNode<string>("Root");
var A = new NaryNode<string>("A");
var B = new NaryNode<string>("B");
var C = new NaryNode<string>("C");
var D = new NaryNode<string>("D");
var E = new NaryNode<string>("E");
var F = new NaryNode<string>("F");
var G = new NaryNode<string>("G");
var H = new NaryNode<string>("H");
var I = new NaryNode<string>("I");

nRoot.AddChild(A);
nRoot.AddChild(B);
nRoot.AddChild(C);

A.AddChild(D);
A.AddChild(E);

C.AddChild(F);
D.AddChild(G);
F.AddChild(H);
F.AddChild(I);

Console.WriteLine(nRoot);
//Console.WriteLine(A);
//Console.WriteLine(B);
//Console.WriteLine(C);
//Console.WriteLine(D);
//Console.WriteLine(E);
//Console.WriteLine(F);
//Console.WriteLine(G);
//Console.WriteLine(H);
//Console.WriteLine(I);