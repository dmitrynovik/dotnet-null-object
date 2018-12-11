using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Null.UnitTests
{
    public class NullSafeTest
    {
        public class TestObject
        {
            public string Name { get; set; }
        }

        [Fact]
        public void Pristine_Equals_Null_Should_Be_True()
        {
            var pristine = new NullSafe<TestObject>();
            using (new AssertionScope())
            {
                (pristine == null).Should().Be(true);
                TestObject to = pristine;
                to.Name.Should().BeNull();
            }
        }

        [Fact]
        public void Dirty_Equals_Null_Should_Be_False()
        {
            var dirty = new NullSafe<TestObject>(new TestObject { Name = "some" });
            using (new AssertionScope())
            {
                (dirty == null).Should().Be(false);
                TestObject to = dirty;
                to.Name.Should().Be("some");
            }
        }

        [Fact]
        public void Pristine_Equals_Self_Should_Be_True()
        {
            var pristine = new NullSafe<TestObject>();
            (pristine == pristine).Should().Be(true);
        }

        [Fact]
        public void Dirty_Equals_Self_Should_Be_True()
        {
            var dirty = new NullSafe<TestObject>(new TestObject() { Name = "some" });
            (dirty == dirty).Should().Be(true);
        }

        [Fact]
        public void Pristine_Not_Equals_Null_Should_Be_False()
        {
            var pristine = new NullSafe<TestObject>();
            (pristine != null).Should().Be(false);
        }

        [Fact]
        public void Dirty_Not_Equals_Null_Should_Be_True()
        {
            var dirty = new NullSafe<TestObject>(new TestObject() { Name = "some" });
            (dirty != null).Should().Be(true);
        }

        [Fact]
        public void Pristine_Not_Equals_Self_Should_Be_False()
        {
            var pristine = new NullSafe<TestObject>();
            (pristine != pristine).Should().Be(false);
        }

        [Fact]
        public void Dirty_Not_Equals_Self_Should_Be_False()
        {
            var dirty = new NullSafe<TestObject>(new TestObject() { Name = "some" });
            (dirty != dirty).Should().Be(false);
        }

    }

}
