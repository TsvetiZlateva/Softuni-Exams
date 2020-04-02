namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class PresentsTests
    {
        private Present present;
        private Bag bag;

        [SetUp]
        public void SetUp()
        {
            present = new Present("First", 1.0);
            bag = new Bag();
        }

        [Test]
        public void PresentConstructorTest()
        {
            present = new Present("Second", 2.0);
            Assert.That(present != null && present.Name != null && present.Magic != 0);
        }

        [Test]
        public void BagConstructorTest()
        {
            bag = new Bag();
            Assert.That(bag != null);
        }

        [Test]
        public void BagCreateTest()
        {
            var result = bag.Create(present);
            Assert.That(result == $"Successfully added present { present.Name}.");
        }

        [Test]
        public void BagCreateNullTest()
        {
            Present present2 = null;            
            Assert.Throws<ArgumentNullException>(() => bag.Create(present2), "Present is null");
        }

        [Test]
        public void BagCreateExistingPresentTest()
        {
            bag.Create(present);
            Present present2 = present; 
            Assert.Throws<InvalidOperationException>(() => bag.Create(present2), "This present already exists!");
        }

        [Test]
        public void BagRemoveTest()
        {
            bag.Create(present);
            var result = bag.Remove(present);
            Assert.That(result);
        }

        [Test]
        public void BagGetPresentWithLeastMagicTest()
        {
            var present2 = new Present("Second", 2.0);
            bag.Create(present);
            bag.Create(present2);
            var result = bag.GetPresentWithLeastMagic();
            Assert.AreSame(result, present);
        }

        [Test]
        public void BagGetPresentTest()
        {
            bag.Create(present);
            var result = bag.GetPresent("First");
            Assert.AreSame(result, present);
        }

        [Test]
        public void BagGetPresentsTest()
        {
            List<Present> presents = new List<Present>();
            presents.Add(present);
            bag.Create(present);
            var result = bag.GetPresents();
            Assert.AreEqual(result, presents.AsReadOnly());
        }

    }
}
