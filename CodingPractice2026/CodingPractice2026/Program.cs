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

var binsearch = new ExampleBinSearch(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 4);
binsearch.RunProblem();
