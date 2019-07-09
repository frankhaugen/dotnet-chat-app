using System;
using System.Collections.Generic;
using ChatApp.Repositories.Tsv;
using FluentAssert;
using System.Threading.Tasks;
using ChatApp.Entities;
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
        public async Task Generate_StateUnderTest_ExpectedBehavior2()
        {
            // Arrange
            var unitUnderTest = this.CreateTsvStringGenerator();
            var enumerable = new List<ChatMessage>()
            {
                new ChatMessage()
                {
                    Id = 1,
                    From = "Frank",
                    Time = DateTime.MinValue,
                    Message = "Hello"
                }
            };
            var expected = $"Id\tTime\tFrom\tMessage\n1\t{DateTime.MinValue}\tFrank\tHello";

            // Act
            var result = await unitUnderTest.Generate(enumerable);

            // Assert
            result.ShouldBeEqualTo(expected);
        }
    }
}
