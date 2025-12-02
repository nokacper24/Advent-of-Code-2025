
using System.Text;

string content = await File.ReadAllTextAsync("input");
var ranges = content.Split(',');


long total = 0;
foreach (var range in ranges)
{
    var vals = range.Split('-');
    var min = long.Parse(vals[0]);
    var max = long.Parse(vals[1]);
    for (long i = min; i <= max; i++)
    {
        if (isInvalid2(i.ToString()))
        {
            Console.WriteLine(i);
            total += i;
        }
    }

}

Console.WriteLine(total);


bool isInvalid(string digits)
{
    if (digits.Length % 2 != 0)
    {
        return false;
    }
    var half1 = digits.Substring(0, digits.Length / 2);
    var half2 = digits.Substring(digits.Length / 2, digits.Length / 2);
    return half1 == half2;
}

bool isInvalid2(string digits)
{
    StringBuilder bld = new();
    string pattern = "";
    for (int i = 0; i < digits.Length / 2; i++)
    {
        bld.Append(digits[i]);
        pattern = bld.ToString();

        if (digits.Length % pattern.Length == 0)
        {
            List<string> substrings = [];
            for (int j = 0; j < digits.Length; j += pattern.Length)
            {
                substrings.Add(digits.Substring(j, pattern.Length));
            }
            if (substrings.All(x => x == pattern))
            {
                return true;
            }

        }
    }
    return false;
}