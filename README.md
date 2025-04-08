
# Sigma Text Analyzer

## Overview
The Sigma Text Analyzer is a simple C# program that analyzes text input by users.

## Features
- **Count Words**: Counts the number of words by splitting text at spaces, ignoring empty segments.
- **Check Mood**: Compares words to positive/negative lists and decides the mood (Positive, Negative, or Neutral).
- **Text Stats**: Counts spaces, letters, and digits in the text.
- **Top 3 Words**: Lists the 3 longest words and their lengths.
- **Show History**: Displays up to 5 past text inputs.
- **Save Results**: Saves all analysis to a file you name.
- **Exit**: Quits the program with a friendly "Bye bye!".

## How to Use
1. **Run the Program**: Open it in a C# environment (like Visual Studio).
2. **Enter Text**: Type some text when prompted (e.g., "happy great world") after the logo and welcome message.
3. **Pick an Option**: Enter a number 1-7 from the menu:
   - 1: Count words
   - 2: Check mood
   - 3: Text stats
   - 4: Top 3 longest words
   - 5: Show history
   - 6: Save to a file
   - 7: Exit
4. **New Text**: After most options (except 6 and 7), it asks for new text (press Enter to keep the same).
5. **Save**: For option 6, type a file name (e.g., "output.txt") or press Enter for "results.txt".

## Known Bugs
- **Punctuation Issue**: Words with punctuation (e.g., "happy!") don’t match the mood lists because they’re not stripped, so they’re ignored.
- **Multiple Spaces in Top 3**: If text has extra spaces (e.g., "happy   great"), `Top3Words` might process empty strings but won’t show them, but i dont like stuff like that but malware anaylsis awaits me.

## Past Bugs (Fixed)
- **Last Word Missed**: Early versions of `Top3Words` skipped the last word. Fixed by improving the logic to handle word boundaries better (no need for extra space anymore).
- **Case Sensitivity**: Mood check didn’t catch "HAPPY" until `ToLower()` was added.
- **Space-Only Input**: Typing multiple spaces (e.g., "   ") used to slip through as valid input, messing up counts. Fixed by checking `text == ""`, which catches all empty or whitespace-only inputs now.

## Future Ideas
- **Punctuation Handling**: Remove punctuation from words (e.g., "happy!" becomes "happy") for better mood matching.
- **Bigger History**: Increase history beyond 5 entries, maybe with a way to scroll or view more.
- **Mood Expansion**: Add more words to the positive/negative lists or let users add their own.
- **File Append**: Add an option to append results to a file instead of overwriting it.

## Documentation
See the full code explanation [here](https://gist.github.com/so1icitx/6ca1656c37528ee07a131f70b8d072a4).  

## Presentation
Download the presentation [here](https://www.mediafire.com/file/8it9skvwc6la2sx/3CvkSsvqBJOV5jEKAGYBu7.pptx/file).  

## Shameless Promo
TryHackMe [here](https://tryhackme.com/p/so1icitx).  
My site [here](https://so1icitx.cfd/).

---
