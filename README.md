# Sigma Text Analyzer

## Overview
The Sigma Text Analyzer is a simple C# program that analyzes text input by users

## Features
- **Count Words**: Counts the number of words by looking at spaces.
- **Check Mood**: Finds positive/negative words and decides the mood.
- **Text Stats**: Counts letters, digits, and spaces in the text.
- **Top 3 Words**: Shows the 3 longest words and their lengths.
- **Show History**: Lists up to 5 past text inputs.
- **Save Results**: Saves all analysis to a file you name.
- **Exit**: Quits the program.

## How to Use
1. **Run the Program**: Open it in a C# environment (like Visual Studio).
2. **Enter Text**: Type some text when it asks (e.g., "happy great world").
3. **Pick an Option**: Enter a number 1-7 from the menu:
   - 1: Count words
   - 2: Check mood
   - 3: Text stats
   - 4: Top 3 words
   - 5: Show history
   - 6: Save to a file
   - 7: Exit
4. **New Text**: After most options, it asks for new text (press Enter to keep the same).
5. **Save**: For option 6, type a file name (e.g., "output.txt") or press Enter for "results.txt".

## Known Bugs
- **Punctuation Issue**: Words with punctuation (e.g., "happy!") don’t match the mood lists, so they’re ignored.
- **Space-Only Input**: Typing multiple spaces (e.g., "   ") isn’t caught as empty, causing odd word counts.

## Past Bugs (Fixed)
- **Last Word Missed**: Early versions of `TopThreeWords` skipped the last word. Fixed by adding a space to the text end.
- **Case Sensitivity**: Mood check didn’t catch "HAPPY" until I added `ToLower()`.

## Future Ideas
- **Punctuation Handling**: Strip punctuation from words for better mood matching.
- **Bigger History**: Expand history beyond 5 entries with a scrollable list.
- **Mood Expansion**: Add more positive/negative words or let users customize the lists.
- **File Append**: Option to add to a file instead of overwriting it.

## Documentation
See the full code explanation [here](https://gist.github.com/so1icitx/6ca1656c37528ee07a131f70b8d072a4).

## Shameless promo
Tryhackme [here](https://tryhackme.com/p/so1icitx).
My site [here](https://so1icitx.cfd/).
