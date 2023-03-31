namespace Day14.LinqAndFileExcercise
{
    public class Elf
    {
        public List<int> FoodItems { get; }
        public int ID { get; set; }

        public Elf()
        {
            FoodItems = new List<int>();
            ID = 0;
        }

        public static List<Elf> GetAllElves()
        {
            string filePath = @"C:\WORK\BD23\AnthonyEllenbroek\Day14.LinqAndFileExcercise\Elf-Calorie.txt";
            string file = File.ReadAllText(filePath);
            string[] elfFoodItems = file.Split(Environment.NewLine + Environment.NewLine);

            return elfFoodItems.Select(elfFoodItem =>
            {
                Elf elf = new Elf();
                foreach (string calorie in elfFoodItem.Split(Environment.NewLine))
                {
                    if (int.TryParse(calorie, out int calories))
                    {
                        elf.FoodItems.Add(calories);
                    }
                }
                return elf;
            }).ToList();
        }

        public static int GetMaxAmountOfCalories(List<Elf> elves) => elves.Max(e => e.FoodItems.Sum());

        public static int GetMaxAmountOfTop3ElvesCalories(List<Elf> elves)
        {
            var top3Elves = elves.OrderByDescending(e => e.FoodItems.Sum()).Take(3);
            return top3Elves.Sum(e => e.FoodItems.Sum());
        }
    }
}