using System.Text.RegularExpressions;

namespace Day03;

internal static class Day03
{
    public static void Main(string[] args)
    {
        const string inputFile = "input.txt";

        Console.WriteLine("Day03!");

        List<string> lines = [];

        try
        {
            StreamReader sr = new(inputFile);
            string? line = sr.ReadLine();
            while (line != null)
            {
                lines.Add(line);
                line = sr.ReadLine();
            }

            sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }

        if (args.Length != 1)
        {
            Console.WriteLine("Usage: Day01 <part 1/2>");
            return;
        }

        string input = args[0];
        int day = int.Parse(input);
        switch (day)
        {
            case 1:
                Part1(lines);
                break;
            case 2:
                Part2(lines);
                break;
            default:
                Console.WriteLine("Usage: Day01 <part 1/2");
                break;
        }
    }

    private static void Part1(List<string> lines)
    {
        Console.WriteLine("Part 1");

        Regex mulOpen = new Regex(@"mul\([0-9]*$");
        Regex mulFirstNum = new Regex(@"mul\([0-9]*,$");
        Regex mulSecondNum = new Regex(@"mul\([0-9]*,[0-9]*$");
        Regex mulSolution = new Regex(@"mul\(([0-9]*),([0-9]*)\)");


        int sum = 0;

        foreach (string line in lines)
        {
            string currentToken = "";
            foreach (char characte in line)
            {
                string character = characte.ToString();

                if (currentToken == "")
                {
                    if (character == "m")
                    {
                        currentToken += character;
                    }

                    continue;
                }
                else if (currentToken == "m")
                {
                    if (character == "u")
                    {
                        currentToken += character;
                    }
                    else
                    {
                        currentToken = "";
                    }

                    continue;
                }
                else if (currentToken == "mu")
                {
                    if (character == "l")
                    {
                        currentToken += character;
                    }
                    else
                    {
                        currentToken = "";
                    }

                    continue;
                }
                else if (currentToken == "mul")
                {
                    if (character == "(")
                    {
                        currentToken += character;
                    }
                    else
                    {
                        currentToken = "";
                    }

                    continue;
                }
                else if (currentToken == "mul(")
                {
                    if (int.TryParse(character, out int num))
                    {
                        currentToken += num;
                    }
                    else
                    {
                        currentToken = "";
                    }

                    continue;
                }
                else if (mulOpen.Match(currentToken).Success)
                {
                    if (character == ",")
                    {
                        currentToken += character;
                    }
                    else if (int.TryParse(character, out int num))
                    {
                        currentToken += num;
                    }
                    else
                    {
                        currentToken = "";
                    }

                    continue;
                }
                else if (mulFirstNum.Match(currentToken).Success)
                {
                    if (int.TryParse(character, out int num))
                    {
                        currentToken += num;
                    }
                    else
                    {
                        currentToken = "";
                    }

                    continue;
                }
                else if (mulSecondNum.Match(currentToken).Success)
                {
                    if (character == ")")
                    {
                        currentToken += character;
                        Match match = mulSolution.Match(currentToken);
                        sum += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
                        currentToken = "";
                    }
                    else if (int.TryParse(character, out int num))
                    {
                        currentToken += num;
                    }
                    else
                    {
                        currentToken = "";
                    }

                    continue;
                }
                else
                {
                    throw new Exception("Unexpected currentToken: " + currentToken);
                }
            }
        }

        Console.WriteLine(sum);
    }

    private static void Part2(List<string> lines)
    {
        Console.WriteLine("Part 2");

        Regex mulOpen = new Regex(@"mul\([0-9]*$");
        Regex mulFirstNum = new Regex(@"mul\([0-9]*,$");
        Regex mulSecondNum = new Regex(@"mul\([0-9]*,[0-9]*$");
        Regex mulSolution = new Regex(@"mul\(([0-9]*),([0-9]*)\)");

        int sum = 0;

        string line = "";
        lines.ForEach((lineValue) => { line += lineValue; });

        bool first = true;
        string[] dontSegments = line.Split("don't()");
        foreach (string seg in dontSegments)
        {
            List<string> list;
            if (first)
            {
                // first line segment is always do
                first = false;
                list = [seg];
            }
            else
            {
                string[] doSeg = seg.Split("do()");
                list = doSeg.ToList();
                list.RemoveAt(0);
            }

            foreach (var thing in list)
            {
                string currentToken = "";
                foreach (char characte in thing)
                {
                    string character = characte.ToString();

                    if (currentToken == "")
                    {
                        if (character == "m")
                        {
                            currentToken += character;
                        }

                        continue;
                    }
                    else if (currentToken == "m")
                    {
                        if (character == "u")
                        {
                            currentToken += character;
                        }
                        else
                        {
                            currentToken = "";
                        }

                        continue;
                    }
                    else if (currentToken == "mu")
                    {
                        if (character == "l")
                        {
                            currentToken += character;
                        }
                        else
                        {
                            currentToken = "";
                        }

                        continue;
                    }
                    else if (currentToken == "mul")
                    {
                        if (character == "(")
                        {
                            currentToken += character;
                        }
                        else
                        {
                            currentToken = "";
                        }

                        continue;
                    }
                    else if (currentToken == "mul(")
                    {
                        if (int.TryParse(character, out int num))
                        {
                            currentToken += num;
                        }
                        else
                        {
                            currentToken = "";
                        }

                        continue;
                    }
                    else if (mulOpen.Match(currentToken).Success)
                    {
                        if (character == ",")
                        {
                            currentToken += character;
                        }
                        else if (int.TryParse(character, out int num))
                        {
                            currentToken += num;
                        }
                        else
                        {
                            currentToken = "";
                        }

                        continue;
                    }
                    else if (mulFirstNum.Match(currentToken).Success)
                    {
                        if (int.TryParse(character, out int num))
                        {
                            currentToken += num;
                        }
                        else
                        {
                            currentToken = "";
                        }

                        continue;
                    }
                    else if (mulSecondNum.Match(currentToken).Success)
                    {
                        if (character == ")")
                        {
                            currentToken += character;
                            Match match = mulSolution.Match(currentToken);
                            sum += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
                            currentToken = "";
                        }
                        else if (int.TryParse(character, out int num))
                        {
                            currentToken += num;
                        }
                        else
                        {
                            currentToken = "";
                        }

                        continue;
                    }
                    else
                    {
                        throw new Exception("Unexpected currentToken: " + currentToken);
                    }
                }
            }
        }

        Console.WriteLine(sum);
    }
}