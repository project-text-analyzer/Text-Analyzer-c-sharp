using System;

string asciiLogo = """""

                   .dP"Y8 88  dP""b8 8b    d8    db        888888 Yb  dP 888888        db    88b 88    db    88         Yb  dP 8888P 888888 88""Yb 
                   `Ybo." 88 dP   `" 88b  d88   dPYb         88    YbdP    88         dPYb   88Yb88   dPYb   88          YbdP    dP  88__   88__dP 
                   o.`Y8b 88 Yb  "88 88YbdP88  dP__Yb        88    dPYb    88        dP__Yb  88 Y88  dP__Yb  88  .o       8P    dP   88""   88"Yb  
                   8bodP' 88  YboodP 88 YY 88 dP""""Yb       88   dP  Yb   88       dP""""Yb 88  Y8 dP""""Yb 88ood8      dP    d8888 888888 88  Yb 

                   """"";
Console.WriteLine(asciiLogo);
Console.WriteLine("[*] Welcome to the SIGMA Text Analyzer!!");

Console.Write("[!] Enter your text: ");
string text = Console.ReadLine();

if (text == "")
{
    Console.WriteLine("[!] ERROR no text provided exiting.....");
    return;
}

string[] history = new string[5];
int historyCount = 0;
history[historyCount] = text;
historyCount += 1;

string[] positiveWords = { "happy", "great", "awesome", "good", "excellent", "wonderful", "amazing", "beautiful", "love", "joy", "fantastic", "perfect", "nice", "lovely", "exciting", "brilliant", "super", "cool", "fun", "glad", "positive", "success", "win", "cheerful", "delight", "pleasure", "hope" };
string[] negativeWords = { "sad", "bad", "terrible", "awful", "horrible", "depressing", "angry", "hate", "miserable", "poor", "dreadful", "pain", "sucks", "stupid", "ugly", "boring", "annoying", "mad", "furious", "fail", "negative", "stress", "anxiety", "fear", "disappoint", "upset", "hurt" };

while (true)
{
    Console.WriteLine("");
    Console.WriteLine("=== Menu ===");
    Console.WriteLine("1 - Count Words");
    Console.WriteLine("2 - Mood Check");
    Console.WriteLine("3 - Text Stats");
    Console.WriteLine("4 - Top 3 Longest Words");
    Console.WriteLine("5 - Show History");
    Console.WriteLine("6 - Save Results");
    Console.WriteLine("7 - Exit");
    Console.Write("[!] Pick a choice: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            string wordResult = WordCount(text);
            Console.WriteLine(wordResult);
            break;

        case "2":
            string moodResult = MoodCheck(text, positiveWords, negativeWords);
            Console.WriteLine(moodResult);
            break;

        case "3":
            string statsResult = TextStats(text);
            Console.WriteLine(statsResult);
            break;

        case "4":
            string top3Result = Top3Words(text);
            Console.WriteLine(top3Result);
            break;

        case "5":
            string historyResult = ShowHistory(history, historyCount);
            Console.WriteLine(historyResult);
            break;

        case "6":
            SaveResults(text, positiveWords, negativeWords, history, historyCount);
            break;

        case "7":
            Console.WriteLine("[!] Bye bye!");
            return;

        default:
            Console.WriteLine("[!] ERROR, pick 1 to 7!");
            break;
    }

    if (choice != "6" && choice != "7")
    {
        Console.Write($"[!] New text (or Enter to keep '{text}'): ");
        string newText = Console.ReadLine();

        if (newText != "")
        {
            text = newText;

            if (historyCount < 5)
            {
                history[historyCount] = text;
                historyCount = historyCount + 1;
            }
        }
    }
}

string WordCount(string text)
{
    string[] words = text.Split(' ');
    int count = 0;

    foreach (string word in words)
    {
        if (word != "")
        {
            count = count + 1;
        }
    }

    return $"Word Counter: {count}";
}

string MoodCheck(string text, string[] positiveWords, string[] negativeWords)
{
    int posCount = 0;
    int negCount = 0;
    string lowerText = text.ToLower();
    string[] words = lowerText.Split(' ');

    foreach (string word in words)
    {
        if (word != "")
        {
            foreach (string posWord in positiveWords)
            {
                if (word == posWord)
                {
                    posCount = posCount + 1;
                }
            }

            foreach (string negWord in negativeWords)
            {
                if (word == negWord)
                {
                    negCount = negCount + 1;
                }
            }
        }
    }

    if (posCount > negCount)
    {
        return "The text is Positive!";
    }
    else if (negCount > posCount)
    {
        return "The text is Negative!";
    }
    else
    {
        return "The text is Neutral..";
    }
}

string TextStats(string text)
{
    int spaceCount = 0;
    int letterCount = 0;
    int digitCount = 0;

    foreach (char c in text)
    {
        if (c == ' ')
        {
            spaceCount = spaceCount + 1;
        }
        else if (char.IsLetter(c))
        {
            letterCount = letterCount + 1;
        }
        else if (char.IsDigit(c))
        {
            digitCount = digitCount + 1;
        }
    }

    string result = "";
    result = result + $"Spaces: {spaceCount}\n";
    result = result + $"Letters: {letterCount}\n";
    result = result + $"Digits: {digitCount}";
    return result;
}

string Top3Words(string text)
{
    string[] words = text.Split(' ');
    string[] topWords = new string[3];
    int[] topLengths = new int[3];

    topWords[0] = "";
    topWords[1] = "";
    topWords[2] = "";
    topLengths[0] = 0;
    topLengths[1] = 0;
    topLengths[2] = 0;

    foreach (string word in words)
    {
        if (word != "")
        {
            int len = word.Length;

            if (len > topLengths[0])
            {
                topLengths[2] = topLengths[1];
                topWords[2] = topWords[1];
                topLengths[1] = topLengths[0];
                topWords[1] = topWords[0];
                topLengths[0] = len;
                topWords[0] = word;
            }
            else if (len > topLengths[1])
            {
                topLengths[2] = topLengths[1];
                topWords[2] = topWords[1];
                topLengths[1] = len;
                topWords[1] = word;
            }
            else if (len > topLengths[2])
            {
                topLengths[2] = len;
                topWords[2] = word;
            }
        }
    }

    string result = "";
    if (topWords[0] != "")
    {
        result = result + $"1: {topWords[0]}, length: {topLengths[0]}\n";
    }
    if (topWords[1] != "")
    {
        result = result + $"2: {topWords[1]}, length: {topLengths[1]}\n";
    }
    if (topWords[2] != "")
    {
        result = result + $"3: {topWords[2]}, length: {topLengths[2]}";
    }
    return result;
}

string ShowHistory(string[] history, int historyCount)
{
    string result = "";
    result = result + "[*] History:\n";

    for (int i = 0; i < historyCount; i++)
    {
        if (history[i] != null)
        {
            result = result + $"[*] {i + 1}: '{history[i]}'\n";
        }
    }

    return result;
}

void SaveResults(string text, string[] positiveWords, string[] negativeWords, string[] history, int historyCount)
{
    Console.Write("[!] Enter file name (e.g., 'output.txt'): ");
    string fileName = Console.ReadLine();

    if (fileName == "")
    {
        fileName = "results.txt";
    }

    string results = "";
    results = results + "Analyzer Results\n";
    results = results + $"Text: {text}\n";

    string wordResult = WordCount(text);
    results = results + $"{wordResult}\n";

    string moodResult = MoodCheck(text, positiveWords, negativeWords);
    results = results + $"{moodResult}\n";

    string statsResult = TextStats(text);
    results = results + $"{statsResult}\n";

    string top3Result = Top3Words(text);
    results = results + $"{top3Result}\n";

    string historyResult = ShowHistory(history, historyCount);
    results = results + historyResult;

    System.IO.File.WriteAllText(fileName, results);
    Console.WriteLine($"[!] Saved to '{fileName}'");
}
