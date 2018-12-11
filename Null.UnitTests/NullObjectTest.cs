using FluentAssertions;
using Xunit;

namespace Null.UnitTests
{
    public class DirtyObject : NullObject
    {
        public string Name { get; set; }
    }

    public class NullObjectTest
    {
        [Fact]
        public void Pristine_Equals_Null_Should_Be_True()
        {
            var pristine = new DirtyObject();
            (pristine == null).Should().Be(true);
        }

        [Fact]
        public void Dirty_Equals_Null_Should_Be_False()
        {
            var dirty = new DirtyObject { Name = "some" };
            (dirty == null).Should().Be(false);
        }

        [Fact]
        public void Pristine_Equals_Self_Should_Be_True()
        {
            var pristine = new DirtyObject();
            (pristine == pristine).Should().Be(true);
        }

        [Fact]
        public void Dirty_Equals_Self_Should_Be_True()
        {
            var dirty = new DirtyObject { Name = "some" };
            (dirty == dirty).Should().Be(true);
        }

        [Fact]
        public void Pristine_Not_Equals_Null_Should_Be_False()
        {
            var pristine = new DirtyObject();
            (pristine != null).Should().Be(false);
        }

        [Fact]
        public void Dirty_Not_Equals_Null_Should_Be_True()
        {
            var dirty = new DirtyObject { Name = "some" };
            (dirty != null).Should().Be(true);
        }

        [Fact]
        public void Pristine_Not_Equals_Self_Should_Be_False()
        {
            var pristine = new DirtyObject();
            (pristine != pristine).Should().Be(false);
        }

        [Fact]
        public void Dirty_Not_Equals_Self_Should_Be_False()
        {
            var dirty = new DirtyObject { Name = "some" };
            (dirty != dirty).Should().Be(false);
        }

    }
}
