using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAlgotithm.OOP
{

    abstract class Animal
    {
        protected bool isMammal;
        protected bool isCarnivorous;

        public Animal(bool isMammal, bool isCarnivorous)
        {
            this.isMammal = isMammal;
            this.isCarnivorous = isCarnivorous;
        }

        public bool getIsMammal()
        {
            return this.isMammal;
        }

        public bool getIsCarnivorous()
        {
            return this.isCarnivorous;
        }

        abstract public string getGreeting();

        public void printAnimal(string name)
        {
            Console.WriteLine("A {0} says '{1}', is{2} carnivorous, and is{3} a mammal.",
            name,
            this.getGreeting(),
            this.getIsCarnivorous() ? "" : " not",
            this.getIsMammal() ? "" : " not");
        }
    }

    class Dog : Animal
    {
        public Dog() : base(true, true)
        {

        }
        public Dog(bool isMammal, bool isCarnivorous) : base(isMammal, isCarnivorous)
        {

        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string getGreeting()
        {
            return "ruff";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    class Cow : Animal
    {
        public Cow() : base(true, false)
        {

        }
        public Cow(bool isMammal, bool isCarnivorous) : base(isMammal, isCarnivorous)
        {
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string getGreeting()
        {
            return "moo";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    class Duck : Animal
    {
        public Duck() : base(false, false)
        {

        }
        public Duck(bool isMammal, bool isCarnivorous) : base(isMammal, isCarnivorous)
        {
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string getGreeting()
        {
            return "quack";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
