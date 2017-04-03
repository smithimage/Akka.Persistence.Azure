using FluentAssertions;
using Xunit;

namespace Akka.Persistence.AzureTable.Tests
{
    public class TableExtensionsSpec
    {
        [Fact]
        public void ShoulReplaceDisallowedChars_should_replace_slashes()
        {
            "/user/actor1/actor2".ReplaceDisallowedChars().Should().Be("-user-actor1-actor2");
        }
    }
}
