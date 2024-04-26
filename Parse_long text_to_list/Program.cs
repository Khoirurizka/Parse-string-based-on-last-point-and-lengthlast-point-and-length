using Microsoft.VisualBasic;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Contracts;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string longText = "A cut-set in a graph is a set of edges whose removal breaks the graph into two or more connected components.Given a graph " +
            "G = (V, E) with n vertices, the minimum cut – or min-cut – problem is to ind a minimum cardinality cut-set in G.Minimum cut problems arise in many contexts, including the study of network reliability.In the " +
            "case where nodes correspond to machines in the network and edges correspond to connections between machines, the min-cut is the smallest number of edges that can fail " +
            "before some pair of machines cannot communicate.Minimum cuts also arise in clustering problems.For example, if nodes represent Web pages(or any documents in a " +
            "hypertext - based system) and two nodes have an edge between them if the corresponding nodes have a hyperlink between them, then small cuts divide the graph into clusters " +
            "of documents with few links between clusters.Documents in different clusters are likely to be unrelated. We shall proceed by making use of the deinitions and techniques presented so far " +
            "in order to analyze a simple randomized algorithm for the min-cut problem.The main operation in the algorithm is edge contraction. In contracting an edge(u, v) we merge the two vertices u and v into one vertex, eliminate all edges connecting u and v, and " +
            "retain all other edges in the graph.The new graph may have parallel edges but no self - loops.Examples appear in Figure 1.1, where in each step the dark edge is being contracted. " +
            "The algorithm consists of n − 2 iterations.In each iteration, the algorithm picks an edge from the existing edges in the graph and contracts that edge.There are many possible " +
            "ways one could choose the edge at each step.Our randomized algorithm chooses " +
            "the edge uniformly at random from the remaining edges. Each iteration reduces the number of vertices in the graph by one.After n − 2 iterations, " +
            "the graph consists of two vertices.The algorithm outputs the set of edges connecting the two remaining vertices.";

        int maxChars = 500; // Maximum characters per part

        List<string> splitText = SplitTextByMaxChars(longText, maxChars);

        // Print each part of the split text
        int ix = 0;
        foreach (var part in splitText)
        {
            ix++;
            Console.WriteLine(ix + ") " + part);
        }
    }

    static List<string> SplitTextByMaxChars(string longText, int maxChars)
    {
        // string ongoing_str = longText;
        List<string> textList = new List<string>();
        if (maxChars < longText.Length)
        {
            int rest_index = longText.Length;

            while (rest_index > maxChars)
            {
                // Determine the maximum length of the substring from the current index
                int count = Math.Min(maxChars, rest_index);

                //Console.WriteLine(last_index);
                // Console.WriteLine(longText);
                // Console.WriteLine(longText.Length);
                // Console.WriteLine(rest_index);

                //  Console.WriteLine(count);

                int lastPeriod = longText.LastIndexOf('.', count, count) + 1;
                // Console.WriteLine(lastPeriod);
                //  Console.WriteLine(longText.Length);

                string x = longText.Substring(0, lastPeriod).Trim();
                textList.Add(longText.Substring(0, lastPeriod).Trim());

                //  Console.WriteLine(x);

                longText = longText.Substring((lastPeriod), (longText.Length - lastPeriod)).Trim();
                //  Console.WriteLine(longText);
                //  Console.WriteLine("\n");

                rest_index -= lastPeriod;
            }
        }
        textList.Add(longText);

        return textList;
    }
}
