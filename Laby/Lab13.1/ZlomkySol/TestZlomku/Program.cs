using Zlomky;

Zlomek z1 = new(1, 2);
Zlomek z2 = new(3, 4);

Zlomek z3 = z1 + z2;

Console.WriteLine($"{z1} + {z2} = {z3}");

Console.WriteLine($"{z1} - {z2} = {z1-z2}");
Console.WriteLine($"{z1} * {z2} = {z1*z2}");
Console.WriteLine($"{z1} / {z2} = {z1/z2}");

Console.WriteLine(z1 > z2);