using Rodasnet.Infrastructure.Messaging.Handling;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Rodasnet.Infrastructure.UnitTests
{
    public class ImplCommandHandler_Tests
    {
        [Fact]
        public void HandleAsync_Success()
        {
            var expected = new ImplCommand
            {
                Id = Guid.NewGuid(),
                GuidProp = Guid.NewGuid(),
                StringProp = "This is a test string.",
                IntListProp = new List<int>() { 1, 2, 3 },
                IntProp = 42,
                ObjProp = "Object property",
                FloatProp = 2.0f
            };

            var sut = new ImplCommandHandler();

            var actual = sut.HandleAsyncTest(expected);

            Assert.IsType<ImplCommand>(actual);

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.GuidProp, actual.GuidProp);
            Assert.Equal(expected.StringProp, actual.StringProp);
            Assert.Equal(expected.IntListProp, actual.IntListProp);
            Assert.Equal(expected.IntProp, actual.IntProp);
            Assert.Equal(expected.ObjProp, actual.ObjProp);
            Assert.Equal(expected.FloatProp, actual.FloatProp);
        }
        
        [Fact]
        public void HandleAsync_All_Events_Success()
        {
            var expected_1 = new ImplCommand
            {
                Id = Guid.NewGuid(),
                GuidProp = Guid.NewGuid(),
                StringProp = "This is a test string.",
                IntListProp = new List<int>() { 1, 2, 3 },
                IntProp = 42,
                ObjProp = "Object property",
                FloatProp = 2.0f
            };

            var expected_2 = new ImplCommand_2
            {
                Id = Guid.NewGuid(),
                GuidProp = Guid.NewGuid(),
                StringProp = "This is a test string.",
                IntListProp = new List<int>() { 1, 2, 3 },
                IntProp = 42,
                ObjProp = "Object property",
                FloatProp = 2.0f
            };

            var sut = new ImplCommandHandler();

            var actual_1 = sut.HandleAsyncTest(expected_1);
            var actual_2 = sut.HandleAsyncTest2(expected_2);

            Assert.IsType<ImplCommand>(actual_1);
            Assert.IsType<ImplCommand_2>(actual_2);

            Assert.Equal(expected_1.Id, actual_1.Id);
            Assert.Equal(expected_1.GuidProp, actual_1.GuidProp);
            Assert.Equal(expected_1.StringProp, actual_1.StringProp);
            Assert.Equal(expected_1.IntListProp, actual_1.IntListProp);
            Assert.Equal(expected_1.IntProp, actual_1.IntProp);
            Assert.Equal(expected_1.ObjProp, actual_1.ObjProp);
            Assert.Equal(expected_1.FloatProp, actual_1.FloatProp);

            Assert.Equal(expected_2.Id, actual_2.Id);
            Assert.Equal(expected_2.GuidProp, actual_2.GuidProp);
            Assert.Equal(expected_2.StringProp, actual_2.StringProp);
            Assert.Equal(expected_2.IntListProp, actual_2.IntListProp);
            Assert.Equal(expected_2.IntProp, actual_2.IntProp);
            Assert.Equal(expected_2.ObjProp, actual_2.ObjProp);
            Assert.Equal(expected_2.FloatProp, actual_2.FloatProp);
        }
    }   
}

