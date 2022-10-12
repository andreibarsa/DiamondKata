using System.Text;

namespace DiamondKata;

public class DiamondKataService
{
    /// <summary>
    /// Validates that the input char is an upper letter.
    /// </summary>
    /// <param name="letter">The letter.</param>
    /// <returns></returns>
    public bool ValidateLetter(char letter)
    {
        return char.IsUpper(letter);
    }

    /// <summary>
    /// Gets the index of the letter. Letter 'A' has index 1;
    /// </summary>
    /// <param name="letter">The letter.</param>
    /// <returns></returns>
    public int GetIndex(char letter)
    {
        return letter - 'A' + 1;
    }

    /// <summary>
    /// Generates the line base on letter and line length.
    /// </summary>
    /// <param name="letter">The letter.</param>
    /// <param name="lineLength">Length of the line.</param>
    /// <returns></returns>
    /// <exception cref="System.ApplicationException"></exception>
    public string GenerateLine(char letter, int lineLength)
    {
        var line = new StringBuilder(new string(' ', lineLength));
        var letterIndex = GetIndex(letter);

        if (letterIndex > lineLength)
        {
            throw new ApplicationException($"Letter {nameof(letter)} index: {letterIndex} is higher the value {lineLength} of the {nameof(lineLength)}");
        }

        if (letter == 'A')
        {
            //__A__
            line[lineLength / 2] = letter;
        }
        else
        {
            //__C___C__
            line[lineLength / 2 - letterIndex + 1] = letter;
            line[lineLength / 2 + letterIndex - 1] = letter;
        }

        return line.ToString();
    }

    /// <summary>
    /// Generates the diamond.
    /// </summary>
    /// <param name="letter">Last letter to be used.</param>
    /// <returns></returns>
    public string GenerateDiamond(char letter)
    {
        var diamond = new StringBuilder();

        var diamondDim = GetDiamondDimension(letter);
        var middleLine = diamondDim / 2;

        for (var i = 1; i <= diamondDim; i++)
        {
            var letterIndex = i <= middleLine ? i : diamondDim - i + 1;

            var currentLetter = GetLetter(letterIndex);
            diamond.AppendLine(GenerateLine(currentLetter, diamondDim));
        }

        return diamond.ToString();
    }

    /// <summary>
    /// Gets the letter from index.
    /// </summary>
    /// <param name="letterIndex">Length of the diamond.</param>
    /// <returns></returns>
    public char GetLetter(int letterIndex)
    {
        return (char)('A' + letterIndex - 1);
    }

    /// <summary>
    /// Gets the diamond dimension (diamond max width equals height).
    /// </summary>
    /// <param name="letter">Last the letter to be used.</param>
    /// <returns></returns>
    public int GetDiamondDimension(char letter)
    {
        var index = GetIndex(letter);
        return 2 * index - 1;
    }
}