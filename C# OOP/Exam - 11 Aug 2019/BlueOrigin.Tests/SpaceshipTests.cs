namespace BlueOrigin.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Astronaut astronaut;
        private Spaceship spaceship;
        private List<Astronaut> astronauts;

        [SetUp]
        public void SetUp()
        {
            astronaut = new Astronaut("Pesho", 50);
            spaceship = new Spaceship("Moon", 2);
            astronauts = new List<Astronaut>();
        }

        [Test]
        public void AstronautConstructor()
        {
            Astronaut astronaut = new Astronaut("Ivan", 10);
            Assert.That(astronaut.Name == "Ivan" && astronaut.OxygenInPercentage == 10);
        }

        [Test]
        public void SpaceshipConstructor()
        {
            Spaceship spaceship = new Spaceship("Solar", 2);
            Assert.That(spaceship.Name == "Solar" && spaceship.Capacity == 2 && spaceship.Count == 0);
        }

        [Test]
        public void NullSpaceshiptName()
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(string.Empty, 1), "Invalid spaceship name!");

            Assert.Throws<ArgumentNullException>(() => new Spaceship(null, 1), "Invalid spaceship name!");
        }

        [Test]
        public void InvalidCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Spaceship("Boo", -1), "Invalid capacity!");

        }

        [Test]
        public void AddAstronautToSpaceship()
        {
            this.spaceship.Add(astronaut);
            Assert.That(spaceship.Count == 1);
        }

        [Test]
        public void FullSpaceshipAdd()
        {
            Astronaut astronaut1 = new Astronaut("Name", 1);
            spaceship = new Spaceship("Moon", 1);
            spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut1), "Spaceship is full!");
        }

        [Test]
        public void ExistingAstronaut()
        {
            Astronaut astronaut1 = new Astronaut("Pesho", 1);
            spaceship = new Spaceship("Moon", 2);
            spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut1), $"Astronaut {astronaut1.Name} is already in!");
        }

        [Test]
        public void RemoveAstronautFromSpaceship()
        {
            this.spaceship.Add(astronaut);
            this.spaceship.Remove(astronaut.Name);
            Assert.That(spaceship.Count == 0);
        }


    }
}