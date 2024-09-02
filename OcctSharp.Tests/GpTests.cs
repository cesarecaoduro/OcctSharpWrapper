using FluentAssertions;
using Occt;

namespace OcctSharp.Tests
{
    public class GpTests
    {
        [Fact]
        public void It_Creates_A_Point()
        {
            GpPnt gpPnt = new(10, 0, 0);
            gpPnt.Should().NotBeNull();
            gpPnt.X.Should().Be(10);
        }
    }
}