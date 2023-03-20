namespace ObjectOrientationDemoLibary
{
    public class Car
    {
        public string Color; // Field / Member / instance variable
        public string LiscensePlate;
        public string Brand;
        private double Speed;

        public Car()
        {
            Color = "Gray";
            LiscensePlate = "AA-AA-AA";
            Brand = "Unknown";
            Speed = 0.0;
        }

        public Car(string color, string liscensePlate)
        {
            Color = color;
            LiscensePlate = liscensePlate;
            Brand = "Unknown";
            Speed = 0.0;
        }

        public Car(string color, string liscensePlate, string brand)
        {
            Color = color;
            LiscensePlate = liscensePlate;
            Brand = brand;
            Speed = 0.0;
        }

        public double GetSpeed() => Speed;
        public void SpeedUp()
        {
            if (Speed > 0 && Speed <= 299)
            {
                Speed++;
            }
        }
        public void Break()
        {
            Speed = 0;
        }
    }
}