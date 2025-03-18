using System;
using System.Linq;


string asciiLogo = """""

                   .dP"Y8 88  dP""b8 8b    d8    db        888888 Yb  dP 888888        db    88b 88    db    88         Yb  dP 8888P 888888 88""Yb 
                   `Ybo." 88 dP   `" 88b  d88   dPYb         88    YbdP    88         dPYb   88Yb88   dPYb   88          YbdP    dP  88__   88__dP 
                   o.`Y8b 88 Yb  "88 88YbdP88  dP__Yb        88    dPYb    88        dP__Yb  88 Y88  dP__Yb  88  .o       8P    dP   88""   88"Yb  
                   8bodP' 88  YboodP 88 YY 88 dP""""Yb       88   dP  Yb   88       dP""""Yb 88  Y8 dP""""Yb 88ood8      dP    d8888 888888 88  Yb 

                   """"";

Console.WriteLine(asciiLogo);
Console.WriteLine("[*] Welcome to The Sigma Txt Analyzer");
Console.WriteLine("Enter your text:");
string text = Console.ReadLine();

if (string.IsNullOrWhiteSpace(text))
{
    Console.WriteLine("[!] ERROR: No text provided. Exiting...");
    return;
}

while (true)
{
    Console.WriteLine("\nOptions:");
    Console.WriteLine("1. Word Count");
    Console.WriteLine("2. Mood Check");
    Console.WriteLine("3. Text Stats");
    Console.WriteLine("4. Word Lengths");
    Console.WriteLine("5. Exit");
    Console.Write("Pick an option (1-5): ");

    string pick = Console.ReadLine();

    switch (pick)
    {
        case "1":
            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Word Count: " + words.Length);
            break;

        case "2":
            string[] positiveWords = { "happy", "great", "awesome", "good", "excellent", "wonderful", "amazing", "beautiful", "love", "joy", "fantastic", "perfect", "nice", "lovely", "exciting", "brilliant", "super", "cool", "fun", "glad", "positive", "success", "win", "cheerful", "delight", "pleasure", "hope" };
            string[] negativeWords = { "sad", "bad", "terrible", "awful", "horrible", "depressing", "angry", "hate", "miserable", "poor", "dreadful", "pain", "sucks", "stupid", "ugly", "boring", "annoying", "mad", "furious", "fail", "negative", "stress", "anxiety", "fear", "disappoint", "upset", "hurt" };

            int positiveCount = 0;
            int negativeCount = 0;

            string[] textWords = text.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in textWords)
            {
                foreach (string positive in positiveWords)
                {
                    if (word == positive)
                    {
                        positiveCount++;
                    }
                }

                foreach (string negative in negativeWords)
                {
                    if (word == negative)
                    {
                        negativeCount++;
                    }
                }
            }

            Console.WriteLine("Positive words: " + positiveCount);
            Console.WriteLine("Negative words: " + negativeCount);

            if (positiveCount > negativeCount)
            {
                Console.WriteLine("Overall mood: Positive");
            }
            else if (negativeCount > positiveCount)
            {
                Console.WriteLine("Overall mood: Negative");
            }
            else
            {
                Console.WriteLine("Overall mood: Neutral");
            }
            break;

        case "3":
            int letterCount = 0;
            int digitCount = 0;
            int whitespaceCount = 0;

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    letterCount++;
                }
                else if (char.IsDigit(c))
                {
                    digitCount++;
                }
                else if (char.IsWhiteSpace(c))
                {
                    whitespaceCount++;
                }
            }

            Console.WriteLine("Total Letters: " + letterCount);
            Console.WriteLine("Total Digits: " + digitCount);
            Console.WriteLine("Total Whitespaces: " + whitespaceCount);
            break;

        case "4":
            string[] wordList = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string longestWord = "";
            int maxLength = 0;

            foreach (string word in wordList)
            {
                if (word.Length > maxLength)
                {
                    longestWord = word;
                    maxLength = word.Length;
                }
            }

            Console.WriteLine("Longest word: " + longestWord + " (Length: " + maxLength + ")");
            break;

        case "5":
            Console.WriteLine("Sayonara!");
            return;

        default:
            Console.WriteLine("[!] Invalid option. Try again.");
            break;
    }
}
