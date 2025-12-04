// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

char[][] diagram = [];

await foreach (var line in File.ReadLinesAsync("input"))
{
    diagram = [.. diagram, line.ToCharArray()];
}

solvePart2();

void solvePart1()
{
    int total = 0;
    for (int i = 0; i < diagram.Length; i++)
    {
        for (int j = 0; j < diagram[i].Length; j++)
        {
            if (diagram[i][j] == '@')
            {
                var neighbours = countNeighbours(diagram, i, j);
                Console.WriteLine($"{i} {j} -> {neighbours}");
                if (neighbours < 4)
                {
                    total++;
                }
            }
        }

    }
    Console.WriteLine($"Total: {total}");
}

void solvePart2()
{
    int total = 0;

    while (true)
    {
        int removedThisIteration = 0;
        for (int i = 0; i < diagram.Length; i++)
        {
            for (int j = 0; j < diagram[i].Length; j++)
            {
                if (diagram[i][j] == '@')
                {
                    var neighbours = countNeighbours(diagram, i, j);
                    Console.WriteLine($"{i} {j} -> {neighbours}");
                    if (neighbours < 4)
                    {
                        diagram[i][j] = 'x';
                        removedThisIteration++;
                        total++;
                    }
                }
            }
        }
        if (removedThisIteration == 0)
        {
            break;
        }
    }
    Console.WriteLine($"Total: {total}");
}

static int countNeighbours(char[][] diagram, int x, int y)
{
    int neighbourCount = 0;
    for (int dx = -1; dx <= 1; dx++)
    {
        for (int dy = -1; dy <= 1; dy++)
        {
            if (dx == 0 && dy == 0)
            {
                // Console.WriteLine("skipping 0 0");
                continue;
            }

            int checkX = x + dx;
            int checkY = y + dy;
            // Console.WriteLine($"checking {checkX} {checkY}");
            if (checkX < 0 || checkY < 0)
            {
                // Console.WriteLine("too low, out of bounds");
                continue;
            }

            if (checkX >= diagram.Length || checkY >= diagram[checkX].Length)
            {
                // Console.WriteLine("too high, out of bounds");
                continue;
            }

            if (diagram[checkX][checkY] == '@')
            {
                neighbourCount++;
            }
        }
    }
    return neighbourCount;
}


static void print(char[][] diagram)
{
    for (int i = 0; i < diagram.Length; i++)
    {
        for (int j = 0; j < diagram[i].Length; j++)
        {
            Console.Write(diagram[i][j]);
        }
        Console.Write("\n");
    }
}