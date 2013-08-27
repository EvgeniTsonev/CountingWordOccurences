//Write a program that reads a list of words from a file words.txt
//and finds how many times each of the words is contained in another
//file test.txt. The result should be written in the file result.txt
//and the words should be sorted by the number of their occurrences
//in descending order. Handle all possible exceptions in your methods.



using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
class Program
{
    //method for extracting the words we are counting
    public static List<string> ReturnDictionary()
    {
        List<string> dictionary = new List<string>();
        using (StreamReader reader = new StreamReader(@"..\..\words.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] words = line.Split(' ');
                foreach (var word in words)
                {
                    dictionary.Add(word);   //saving all words in dictionary
                }
            }
        }
        return dictionary;
    }
    //method for extracting the text
    public static List<string> ReturnText()
    {
        List<string> source = new List<string>();
        using (StreamReader readerTest = new StreamReader(@"..\..\test.txt"))
        {
            string line;
            while ((line = readerTest.ReadLine()) != null)
            {
                string[] items = line.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in items)
                    source.Add(item);
            }
        }
        return source;
    }

    //foreach (var word in dictionary)
    //{
    //    Console.WriteLine(word);  //small test for accuracy
    //}

    static void Main()
    {
        List<string> tempDictionary = ReturnDictionary();   //the words we are counting
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        List<string> source = ReturnText();             //the source from wich we are couting
        StreamWriter write = new StreamWriter(@"..\..\result.txt"); //the file we are writing the result

        foreach (var word in tempDictionary)
        {
            int counter = 0;
            foreach (var item in source)    
                if (word == item)
                {
                    counter++;
                }
            dictionary.Add(word, counter);
        }
        //sorting the dictionary using linq and saving it
        //
        foreach (var item in dictionary.OrderBy(i => i.Value))
        {
            write.WriteLine(item);
        }
        write.Close();
    }
}
//i hate exceptions so.....
