using ChatApp.Repositories.Tsv;
using FluentAssert;
using System.Threading.Tasks;
using Xunit;

namespace ChatApp.Tests.Repositories.Tsv
{
    public class TsvStringGeneratorTests
    {
        private TsvStringGenerator CreateTsvStringGenerator()
        {
            return new TsvStringGenerator();
        }

        [Fact]
        public async Task Generate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateTsvStringGenerator();
            var enumerable = new string[] {"MyString", "MyOtherString"};
            var expected = "String\nMyString\nMyOtherString";

            // Act
            var result = await unitUnderTest.Generate(enumerable);

            // Assert
            result.ShouldBeEqualTo(expected);
        }
    }
}
