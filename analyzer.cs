Console.WriteLine("[*] Welcome to The Sigma Txt Analyzer");
Console.WriteLine("Enter your text:");
string text = Console.ReadLine();

if (text == "")
{
    Console.WriteLine("[!] ERROR: No text provided. Exiting...");
    return;
}

while (true)
{
    ShowMenu();
    string pick = Console.ReadLine();

    if (pick == "5")
    {
        Console.WriteLine("Sayonara!");
        break;
    }
    RunOption(pick);
}

void ShowMenu()
{
    Console.WriteLine("\nOptions:");
    Console.WriteLine("1. Word Count");
    Console.WriteLine("2. Mood Check");
    Console.WriteLine("3. Text Stats");
    Console.WriteLine("4. Word Lengths");
    Console.WriteLine("5. Exit");
    Console.Write("Pick an option (1-5): ");
}
void RunOption(string pick)
{
    switch (pick)
    {
        case "1":
            string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Word Count: " + words.Length);
        case "2":
            break;
        case "3":
            int totalCharacters = text.Length;
                int letterCount = 0;
                int digitCount = 0;
                int whitespaceCount = 0;

                foreach (char c in text)
                {
                    if (char.IsLetter(c))
                        letterCount++;
                    if (char.IsDigit(c))
                        digitCount++;
                    if (char.IsWhiteSpace(c))
                        whitespaceCount++;
                }
                Console.WriteLine("Total Characters: " + totalCharacters);
                Console.WriteLine("Total Letters: " + letterCount);
                Console.WriteLine("Total Digits: " + digitCount);
                Console.WriteLine("Total Whitespaces: " + whitespaceCount);
                break;
        case "4":
            break;
        default:
            Console.WriteLine("[!] Invalid input, pick a number between 1 and 5.");
            break;
    }
}
