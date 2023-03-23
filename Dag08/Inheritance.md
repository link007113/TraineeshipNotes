## Inleiding

Inheritance is het baseren van een Class op een andere Class.
Hierdoor hoef je properties en functionaliteit van de basis class niet opnieuw te defineren en kan je de class die inherend gebruiken voor extra properties en functionaliteit. 

```c#
 public class Animal
    {
        public Double Weight;

        public Animal(double weight)
        {
            Weight = weight;
        }

        public void Eat(double food)
        {
           Weight += food;
        }
    }

    public class Bird : Animal
    {
        public Bird(double weight) : base(weight)
        {
        }
    }



[TestClass]
    public class BirdTest
    {
        [TestMethod]
        public void Bird_Has_Initial_Weight()
        {
            Animal bird = new Bird(0.2);
            Assert.IsTrue(bird.Weight == 0.2);
        }

        [TestMethod]
        public void Eat_BirdWithWeight02_GainsWeight()
        {
            double weigth = 0.2;
            Bird bird = new(weigth);
            bird.Eat(0.6);

            Assert.IsTrue(bird.Weight == 0.8);

        }
    }

```


### Meer info:
[Inheritance](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/inheritance)