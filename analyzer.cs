using System.Linq;

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
    while (pick != "1" && pick != "2" && pick != "3" && pick != "4" && pick != "5")
            {
                Console.WriteLine("[!] Invalid input, please pick a number between 1 and 5.");
                Console.WriteLine("Try again? (y/n): ");
                string tryAgain = Console.ReadLine().ToLower();
                if (tryAgain != "y")
                {
                    Console.WriteLine("Sayonara!");
                    return; 
                }
                ShowMenu();
                pick = Console.ReadLine();
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
            break;
        case "2":
            string[] textWords = text.ToLower().Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    // Positive words list
                    string[] positiveWords = new string[] {
                        "happy", "great", "awesome", "good", "excellent", "wonderful", "amazing",
                        "beautiful", "love", "joy", "fantastic", "perfect", "nice", "lovely",
                        "exciting", "brilliant", "super", "cool", "fun", "glad", "positive",
                        "success", "win", "cheerful", "delight", "pleasure", "hope"
                    };

                    // Negative words list
                    string[] negativeWords = new string[] {
                        "sad", "bad", "terrible", "awful", "horrible", "depressing", "angry",
                        "hate", "miserable", "poor", "dreadful", "pain", "sucks", "stupid",
                        "ugly", "boring", "annoying", "mad", "furious", "fail", "negative",
                        "stress", "anxiety", "fear", "disappoint", "upset", "hurt"
                    };

                    int positiveCount = 0;
                    int negativeCount = 0;

                    foreach (string word in textWords)
                    {
                        if (positiveWords.Contains(word))
                            positiveCount++;
                        if (negativeWords.Contains(word))
                            negativeCount++;
                    }

                    Console.WriteLine("Mood Analysis:");
                    Console.WriteLine($"Positive words found: {positiveCount}");
                    Console.WriteLine($"Negative words found: {negativeCount}");
                    
                    if (positiveCount > negativeCount)
                        Console.WriteLine("Overall mood: Positive");
                    else if (negativeCount > positiveCount)
                        Console.WriteLine("Overall mood: Negative");
                    else
                        Console.WriteLine("Overall mood: Neutral");
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
            bstring[] wordArray = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    string[] topWords = new string[5];
                    int[] topLengths = new int[5];
                    
                    for (int i = 0; i < 5; i++)
                    {
                        topWords[i] = "";
                        topLengths[i] = 0;
                    }

                    foreach (string word in wordArray)
                    {
                        int wordLength = word.Length;
                        
                        for (int i = 0; i < 5; i++)
                        {
                            if (wordLength > topLengths[i])
                            {
                                for (int j = 4; j > i; j--)
                                {
                                    topWords[j] = topWords[j - 1];
                                    topLengths[j] = topLengths[j - 1];
                                }
                                topWords[i] = word;
                                topLengths[i] = wordLength;
                                break;
                            }
                        }
                    }

                    Console.WriteLine("Top 5 Longest Words:");
                    bool hasWords = false;
                    for (int i = 0; i < 5; i++)
                    {
                        if (topLengths[i] > 0)
                        {
                            Console.WriteLine($"{i + 1}. {topWords[i]} (Length: {topLengths[i]})");
                            hasWords = true;
                        }
                    }
                    if (!hasWords)
                    {
                        Console.WriteLine("No words found!");
                    }
                    break;
        default:
            Console.WriteLine("[!] Invalid input, pick a number between 1 and 5.");
            break;
    }
}
