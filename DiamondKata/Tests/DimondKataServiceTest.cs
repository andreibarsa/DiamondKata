using System.Text;
using FluentAssertions;
using Xunit;

namespace DiamondKata.Tests
{
    public class DiamondKataServiceTest
    {
        [Theory]
        [InlineData('A')]
        [InlineData('D')]
        [InlineData('X')]
        public void ValidateChar_CheckingUpperLetter_ReturnTrue(char c)
        {
            var sut = new DiamondKataService();

            var result = sut.ValidateLetter(c);

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData('a')]
        [InlineData('2')]
        [InlineData('%')]
        public void ValidateChar_CheckingNonUpperLetter_ReturnFalse(char c)
        {
            var sut = new DiamondKataService();

            var result = sut.ValidateLetter(c);

            result.Should().BeFalse();
        }

        [Fact]
        public void GetIndex_ForCharA_Return1()
        {
            var sut = new DiamondKataService();

            var result = sut.GetIndex('A');

            result.Should().Be(1);
        }

        [Theory]
        [InlineData(1, 'A')]
        [InlineData(3, 'C')]
        [InlineData(2, 'B')]
        public void GetLetter_ForProvidedIndex_ReturnChar(int letterIndex, char expectedChar)
        {
            var sut = new DiamondKataService();

            var result = sut.GetLetter(letterIndex);

            result.Should().Be(expectedChar);
        }

        [Theory]
        [InlineData('A', 5, "  A  ")]
        [InlineData('B', 5, " B B ")]
        [InlineData('C', 5, "C   C")]
        [InlineData('C', 11, "   C   C   ")]
        public void GenerateLine_ForCharInputAndIndex5_ReturnSpecificLine(char c, int i, string expectedResult)
        {
            var sut = new DiamondKataService();

            var result = sut.GenerateLine(c, i);

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void GenerateLine_ForCharBAndIndex1_ThrowException()
        {
            var letter = 'B';
            var lineLength = 1;
            var sut = new DiamondKataService();

            var act = () => sut.GenerateLine(letter, lineLength);
            
            act.Should().Throw<ApplicationException>()
                .WithMessage($"Letter {nameof(letter)} index: 2 is higher the value {lineLength} of the {nameof(lineLength)}");
        }

        [Theory]
        [InlineData('A', 1)]
        [InlineData('B', 3)]
        [InlineData('C', 5)]
        public void GetDiamondDimension_ForSpecifiedChar_ReturnCorrespondingMaxWidth(char c, int expectedWidth)
        {
            var sut = new DiamondKataService();

            var result = sut.GetDiamondDimension(c);

            result.Should().Be(expectedWidth);
        }

        [Fact]
        public void GenerateDiamond_ForCChar_ReturnDiamond()
        {
            var expectedDiamond = new StringBuilder();
            expectedDiamond.AppendLine("  A  ");
            expectedDiamond.AppendLine(" B B ");
            expectedDiamond.AppendLine("C   C");
            expectedDiamond.AppendLine(" B B ");
            expectedDiamond.AppendLine("  A  ");

            var sut = new DiamondKataService();

            var result = sut.GenerateDiamond('C');

            result.Should().Be(expectedDiamond.ToString());
        }

        [Fact]
        public void GenerateDiamond_ForDChar_ReturnDiamond()
        {
            var expectedDiamond = new StringBuilder();
            expectedDiamond.AppendLine("   A   ");
            expectedDiamond.AppendLine("  B B  ");
            expectedDiamond.AppendLine(" C   C ");
            expectedDiamond.AppendLine("D     D");
            expectedDiamond.AppendLine(" C   C ");
            expectedDiamond.AppendLine("  B B  ");
            expectedDiamond.AppendLine("   A   ");

            var sut = new DiamondKataService();

            var result = sut.GenerateDiamond('D');

            result.Should().Be(expectedDiamond.ToString());
        }
    }
}
