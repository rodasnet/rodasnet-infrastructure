using System.Threading.Tasks;
using Xunit;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Rodasnet.Infrastructure.Messaging;

namespace Rodasnet.Infrastructure.UnitTests
{
    public class ImplMicroserviceProcessManager_Tests
    {
        [Fact]
        public void Deserialize_Icommand_Success()
        {
            var factory = new ImplSessionFactory();

            var expected = new ImplCommand
            {
                Id          = Guid.NewGuid(),
                GuidProp    = Guid.NewGuid(),
                StringProp  = "This is a test string.",
                IntListProp = new List<int>() { 1, 2, 3 },
                IntProp     = 42,
                ObjProp     = "Object property",
                FloatProp   = 2.0f
            };

            var handler = new ImplCommandHandler();

            var sut = new ImplMicroserviceProcessManager(factory, handler);

            string json = JsonConvert.SerializeObject(expected);

            var actual = sut.TestDeserializer(json);

            Assert.IsType<ImplCommand>(actual);

            Assert.Equal(expected.Id,          actual.Id);
            Assert.Equal(expected.GuidProp,    actual.GuidProp);
            Assert.Equal(expected.StringProp,  actual.StringProp);
            Assert.Equal(expected.IntListProp, actual.IntListProp);
            Assert.Equal(expected.IntProp,     actual.IntProp);
            Assert.Equal(expected.ObjProp,     actual.ObjProp);
            Assert.Equal(expected.FloatProp,   actual.FloatProp);
        }

        [Fact]
        public void Deserialize_Icommandimpl_2_Success() 
        {
            var factory = new ImplSessionFactory();

            var expected = new ImplCommand_2
            {
                Id = Guid.NewGuid(),
                GuidProp = Guid.NewGuid(),
                StringProp = "This is a test string.",
                IntListProp = new List<int>() { 1, 2, 3 },
                IntProp = 42,
                ObjProp = "Object property",
                FloatProp = 2.0f
            };

            var handler = new ImplCommandHandler();

            var sut = new ImplMicroserviceProcessManager_2(factory, handler);

            string json = JsonConvert.SerializeObject(expected);

            var actual = sut.TestDeserializer2(json);

            Assert.IsType<ImplCommand_2>(actual);

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.GuidProp, actual.GuidProp);
            Assert.Equal(expected.StringProp, actual.StringProp);
            Assert.Equal(expected.IntListProp, actual.IntListProp);
            Assert.Equal(expected.IntProp, actual.IntProp);
            Assert.Equal(expected.ObjProp, actual.ObjProp);
            Assert.Equal(expected.FloatProp, actual.FloatProp);
        }

        public void Deserialize_Icommandimpl_All_Success()
        {
            var factory = new ImplSessionFactory();

            var expected_1 = new ImplCommand
            {
                Id = Guid.NewGuid(),
                GuidProp = Guid.NewGuid(),
                StringProp = "This is a test string implCommand_1.",
                IntListProp = new List<int>() { 1, 2, 3 },
                IntProp = 42,
                ObjProp = "Object implCommand_1 property",
                FloatProp = 2.0f
            };

            var expected_2 = new ImplCommand_2
            {
                Id = Guid.NewGuid(),
                GuidProp = Guid.NewGuid(),
                StringProp = "This is a test string for implCommand_2.",
                IntListProp = new List<int>() { 2, 4, 8 },
                IntProp = 84,
                ObjProp = "Object implCommand_2 property",
                FloatProp = 4.0f
            };

            var handler = new ImplCommandHandler();

            var sut_1 = new ImplMicroserviceProcessManager(factory, handler);
            var sut_2 = new ImplMicroserviceProcessManager_2(factory, handler);

            string json_1 = JsonConvert.SerializeObject(expected_1);
            string json_2 = JsonConvert.SerializeObject(expected_2);

            var actual_1 = sut_1.TestDeserializer(json_1);
            var actual_2 = sut_2.TestDeserializer2(json_2);

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
