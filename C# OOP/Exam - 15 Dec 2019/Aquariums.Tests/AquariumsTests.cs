namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        [Test]
        public void FishConstructorTest()
        {
            Fish fish = new Fish("Nemo");
            Assert.That(fish.Name == "Nemo" && fish.Available == true);
        }

        [Test]
        public void AquariumConstructorTest()
        {
            Aquarium aquarium = new Aquarium("New", 10);
            Assert.That(aquarium.Name == "New" && aquarium.Capacity == 10);
        }

        [Test]
        public void AquariumNullOrEmptyNameTest()
        {           
            Assert.Throws<ArgumentNullException>(() => new Aquarium(string.Empty, 10), "Invalid aquarium name!");
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 10), "Invalid aquarium name!");
        }

        [Test]
        public void AquariumInvalidCapacityTest()
        {
            Assert.Throws<ArgumentException>(()=> new Aquarium("Abc", -10), "Invalid aquarium capacity!");
        }


    }
}
