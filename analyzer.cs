using System;

string asciiLogo = """""

                   .dP"Y8 88  dP""b8 8b    d8    db        888888 Yb  dP 888888        db    88b 88    db    88         Yb  dP 8888P 888888 88""Yb 
                   `Ybo." 88 dP   `" 88b  d88   dPYb         88    YbdP    88         dPYb   88Yb88   dPYb   88          YbdP    dP  88__   88__dP 
                   o.`Y8b 88 Yb  "88 88YbdP88  dP__Yb        88    dPYb    88        dP__Yb  88 Y88  dP__Yb  88  .o       8P    dP   88""   88"Yb  
                   8bodP' 88  YboodP 88 YY 88 dP""""Yb       88   dP  Yb   88       dP""""Yb 88  Y8 dP""""Yb 88ood8      dP    d8888 888888 88  Yb 

                   """"";
Console.WriteLine(asciiLogo);
Console.WriteLine("[!] Welcome to the Sigma Text Analyzer");
Console.Write("[!] Enter your text: ");
string text = Console.ReadLine();

if (text.Length == 0 || text == " ")
{
    Console.WriteLine("[!] [ERROR]: No text! Bye!");
    return;
}

string[] history = new string[5]; 
int historyCount = 0;
history[historyCount++] = text;


string[] positiveWords = { "happy", "great", "awesome", "good", "excellent", "wonderful", "amazing", "beautiful", "love", "joy", "fantastic", "perfect", "nice", "lovely", "exciting", "brilliant", "super", "cool", "fun", "glad", "positive", "success", "win", "cheerful", "delight", "pleasure", "hope" };
string[] negativeWords = { "sad", "bad", "terrible", "awful", "horrible", "depressing", "angry", "hate", "miserable", "poor", "dreadful", "pain", "sucks", "stupid", "ugly", "boring", "annoying", "mad", "furious", "fail", "negative", "stress", "anxiety", "fear", "disappoint", "upset", "hurt" };


void CountWords(out int count)
{
    count = 1;
    for (int i = 0; i < text.Length; i++)
        if (text[i] == ' ') count++;
    if (text[0] == ' ' || text[text.Length - 1] == ' ') count--;
    Console.WriteLine("[*] Words: " + count);
}

void CheckMood(out int pos, out int neg, out string mood)
{
    pos = 0; neg = 0;
    string word = "";
    string lowerText = text.ToLower(); 
    for (int i = 0; i < lowerText.Length; i++)
    {
        if (lowerText[i] != ' ') word += lowerText[i];
        if (lowerText[i] == ' ' || i == lowerText.Length - 1)
        {
            for (int j = 0; j < positiveWords.Length; j++)
                if (word == positiveWords[j]) pos++;
            for (int j = 0; j < negativeWords.Length; j++)
                if (word == negativeWords[j]) neg++;
            word = "";
        }
    }
    mood = pos > neg ? "Positive" : neg > pos ? "Negative" : "Neutral";
    Console.WriteLine("[*] Positive: " + pos + ", Negative: " + neg + ", Mood: " + mood);
}

void TextStats(out int letters, out int digits, out int spaces)
{
    letters = 0; digits = 0; spaces = 0;
    for (int i = 0; i < text.Length; i++)
    {
        char c = text[i];
        if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')) letters++;
        else if (c >= '0' && c <= '9') digits++;
        else if (c == ' ') spaces++;
    }
    Console.WriteLine("[*] Letters: " + letters + ", Digits: " + digits + ", Spaces: " + spaces);
}

void TopThreeWords(out string[] words, out int[] lengths)
{
    words = new string[] { "", "", "" };
    lengths = new int[] { 0, 0, 0 };
    string word = "", textEnd = text + " ";
    for (int i = 0; i < textEnd.Length; i++)
    {
        if (textEnd[i] != ' ') word += textEnd[i];
        else if (word != "")
        {
            int len = word.Length;
            if (len > lengths[0])
            {
                lengths[2] = lengths[1]; words[2] = words[1];
                lengths[1] = lengths[0]; words[1] = words[0];
                lengths[0] = len; words[0] = word;
            }
            else if (len > lengths[1])
            {
                lengths[2] = lengths[1]; words[2] = words[1];
                lengths[1] = len; words[1] = word;
            }
            else if (len > lengths[2])
            {
                lengths[2] = len; words[2] = word;
            }
            word = "";
        }
    }
    Console.WriteLine("[*] Top 3 Words:");
    for (int i = 0; i < 3; i++)
        if (words[i] != "") Console.WriteLine("[*] " + (i + 1) + ": '" + words[i] + "' (" + lengths[i] + ")");
}

void ShowHistory()
{
    Console.WriteLine("[*] History:");
    for (int i = 0; i < historyCount; i++)
        if (history[i] != null) Console.WriteLine("[*] " + (i + 1) + ": '" + history[i] + "'");
}

void SaveResults()
{
    Console.Write("[!] Enter file name (e.g., 'output.txt'): ");
    string fileName = Console.ReadLine();
    if (fileName == "") fileName = "results.txt";

    string results = "Analyzer Results\nText: " + text + "\n";
    
    int count; CountWords(out count);
    results += "Words: " + count + "\n";

    int pos, neg; string mood;
    CheckMood(out pos, out neg, out mood);
    results += "Positive: " + pos + ", Negative: " + neg + ", Mood: " + mood + "\n";

    int letters, digits, spaces;
    TextStats(out letters, out digits, out spaces);
    results += "Letters: " + letters + ", Digits: " + digits + ", Spaces: " + spaces + "\n";

    string[] words; int[] lengths;
    TopThreeWords(out words, out lengths);
    results += "Top 3 Words:\n";
    for (int i = 0; i < 3; i++)
        if (words[i] != "") results += (i + 1) + ": '" + words[i] + "' (" + lengths[i] + ")\n";

    results += "History:\n";
    for (int i = 0; i < historyCount; i++)
        if (history[i] != null) results += (i + 1) + ": '" + history[i] + "'\n";

    System.IO.File.WriteAllText(fileName, results);
    Console.WriteLine("[!] Saved to '" + fileName + "'");
}

while (true)
{
    Console.WriteLine("\n=== Menu ===");
    Console.WriteLine("1 - Count Words");
    Console.WriteLine("2 - Check Mood");
    Console.WriteLine("3 - Text Stats");
    Console.WriteLine("4 - Top 3 Words");
    Console.WriteLine("5 - Show History");
    Console.WriteLine("6 - Save Results");
    Console.WriteLine("7 - Exit");
    Console.Write("[!] Pick (1-7): ");

    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1": int c; CountWords(out c); 
            break;
        case "2": int p, n; string m; CheckMood(out p, out n, out m);
            break;
        case "3": int l, d, s; TextStats(out l, out d, out s); 
            break;
        case "4": string[] w; int[] len; TopThreeWords(out w, out len); 
            break;
        case "5": ShowHistory(); 
            break;
        case "6": SaveResults(); 
            break;
        case "7": Console.WriteLine("[!] Sayonara!"); 
            return;
        default: Console.WriteLine("[!] [ERROR]: Pick 1-7!"); 
            break;
    }

    if (choice != "6" && choice != "7")
    {
        Console.Write("[!] New text (or Enter to keep '" + text + "'): ");
        string newText = Console.ReadLine();
        if (newText != "")
        {
            text = newText;
            if (historyCount < 5) history[historyCount++] = text;
        }
    }
}
