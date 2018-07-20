﻿using System;
using static System.Console;

class Program
{
    static void PrintBanner(string text)
    {
        var last = ^1;
        if (text?.Length >= 2 && text[0] == '"' && text[last] == '"')
        {
            text = text.Substring(1, text.Length - 1);
        }

        WriteLine(text);
    }

    static void PrintNumbers()
    {
        int[] array = new int[10];
        for (int i = 0; i < array.Length; i++) array[i] = i;
        foreach (var v in array) WriteLine(v);
    }

    static void Main(string[] args)
    {
        PrintBanner('"' + "The Mads and Dustin Show" + '"');
        //PrintNumbers();
    }
}