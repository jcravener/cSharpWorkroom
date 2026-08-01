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
