// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
await solve1();
async Task solve1()
{
    var input = await File.ReadAllLinesAsync("input");

    var splitCount = 0;

    bool[] currentBeams = new bool[input[0].Length];
    for (int i = 0; i < input.Length; i++)
    {
        var line = input[i];
        for (int j = 0; j < line.Length; j++)
        {
            var c = line[j];
            switch (c)
            {
                case 'S':
                    currentBeams[j] = true;
                    break;
                case '^':
                    if (currentBeams[j])
                    {
                        splitCount++;
                        currentBeams[j] = false;

                        var jRight = j + 1;
                        if (jRight < line.Length)
                        {
                            currentBeams[jRight] = true;
                        }
                        var jLeft = j - 1;
                        if (jLeft >= 0)
                        {
                            currentBeams[jLeft] = true;
                        }
                    }
                    break;

                default:
                    break;
            }
        }
    }
    Console.WriteLine(splitCount);

}


await solve2();
async Task solve2()
{
    var input = await File.ReadAllLinesAsync("input");


    long[] paths = new long[input[0].Length];
    for (int i = 0; i < input.Length; i++)
    {
        int[] beamsToSwitchOff = [];
        var line = input[i];
        for (int j = 0; j < line.Length; j++)
        {
            var c = line[j];
            switch (c)
            {
                case 'S':
                    paths[j]++;
                    break;
                case '^':
                    if (paths[j] > 0)
                    {
                        beamsToSwitchOff = [.. beamsToSwitchOff, j];

                        var jRight = j + 1;
                        if (jRight < line.Length)
                        {
                            paths[jRight] += paths[j];
                        }
                        var jLeft = j - 1;
                        if (jLeft >= 0)
                        {
                            paths[jLeft] += paths[j];
                        }
                    }
                    break;

                default:
                    break;
            }
        }
        foreach (var b in beamsToSwitchOff)
        {
            paths[b] = 0;
        }

        // Console.WriteLine(string.Join(" ", paths.Select(x => x == 0 ? "   " : x.ToString().PadLeft(3))));

    }

    Console.WriteLine(paths.Aggregate((a, c) => a + c));

}