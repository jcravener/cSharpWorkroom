using CodingPractice2026.Examples;

Console.WriteLine("Hello, World!");

// Example 1

string config1 = """
        timeout = 30
        enabled = true
        path = /var/log/app
        name = serviceA
        """;

var one = new Example1(config1);
one.RunProblem();

// bin search

var binsearch = new ExampleBinSearch([1, 2, 3, 4, 5, 6, 7, 8, 9], 4);
binsearch.RunProblem();

// linked list traversal

var lltraverse = new ExampleLinkedList([1, 2, 3, 4, 5, 6, 7, 8, 9]);
lltraverse.RunProblem();

// basic linked list search

var llsearch = new ExampleLinkedListSearch([ 1, 2, 3, 4, 5, 6, 7, 8, 9 ], 0);
llsearch.RunProblem();