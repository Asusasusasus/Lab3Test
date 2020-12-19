using System;
using NUnit.Framework;
using IIG.BinaryFlag;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void MultipleBinaryFlagExceptionTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(99999999999));
        }
        [Test]
        public void MultipleBinaryFlagMinMaxTest()
        {
            Assert.IsNotNull(new MultipleBinaryFlag(2));
            Assert.IsNotNull(new MultipleBinaryFlag(17179868704));
            Assert.IsNotNull(new MultipleBinaryFlag(3)); // we also pick another length beetween min add max
        }
        [Test]
        public void MultipleBinaryFlagWithSecondParameterTest()
        {
            Assert.IsNotNull(new MultipleBinaryFlag(3, true));
            Assert.IsNotNull(new MultipleBinaryFlag(1000, false));
        }
        [Test]
        public void FlagGetingTest()
        {
            MultipleBinaryFlag flag = new MultipleBinaryFlag(5, true);
            Assert.IsTrue(flag.GetFlag());
        }
        [Test]
        public void FlagResetingTest()
        {
            MultipleBinaryFlag flag = new MultipleBinaryFlag(5, true);
            flag.ResetFlag(2);
            Assert.IsFalse(flag.GetFlag());
        }
        [Test]
        public void RightFlagSetingTest()
        {
            MultipleBinaryFlag flag = new MultipleBinaryFlag(5, false);
            flag.SetFlag(2);
            Assert.IsFalse(flag.GetFlag());
        }
        [Test]
        public void WrongFlagSetingTest() 
        {
            MultipleBinaryFlag flag = new MultipleBinaryFlag(5, false);
            Assert.Throws<ArgumentOutOfRangeException>(() => flag.SetFlag(6));
        }
        [Test]
        public void WrongFlagResetingTest() 
        {
            MultipleBinaryFlag flag = new MultipleBinaryFlag(5, true);
            Assert.Throws<ArgumentOutOfRangeException>(() => flag.ResetFlag(6));
        }
        [Test]
        public void ToStringAndTypeTest()
        {
            MultipleBinaryFlag flag = new MultipleBinaryFlag(5);
            Assert.AreEqual(flag.GetType().ToString(), "IIG.BinaryFlag.MultipleBinaryFlag");
        }
        [Test]
        public void ToStringTest() //lets do some loop coverage
        {
            MultipleBinaryFlag flag = new MultipleBinaryFlag(5, true);
            Assert.AreEqual(flag.ToString(), "TTTTT");
            for (ulong i = 0; i<5; i++)
            {
                flag.ResetFlag(i);
            }
            Assert.AreEqual(flag.ToString(), "FFFFF");
        }
        [Test]
        public void DisposeTest()
        {
            MultipleBinaryFlag flag = new MultipleBinaryFlag(5, true);
            flag.Dispose();
            Assert.IsNotNull(flag);
        }
    }
}