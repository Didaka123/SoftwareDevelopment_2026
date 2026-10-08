namespace StudentRegistration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1zad

            Console.Write("въведете име:");
            string name = Console.ReadLine();


            //2zad

            Console.Write("Въведете възраст:");


            if (int.TryParse(Console.ReadLine(), out int age) && age >= 6 && age <= 30)
            {
                Console.WriteLine($"Вие сте на: {age} години");
            }
            else
            {
                Console.WriteLine("Невалидна възраст.");
            }

            //3zad

            Console.Write("Въведете клас на ученика:");


            if (byte.TryParse(Console.ReadLine(), out byte grade))
            {
                if (grade <= 12)
                {
                    Console.WriteLine($"Клас: {grade}");
                }
                else
                {
                    Console.WriteLine("Няма такъв клас.");
                }


            }

            //zad 4 

            Console.Write("Въведете среден успех:");

            if (double.TryParse(Console.ReadLine(), out double uspeh))
            {
                if (uspeh >= 2 && uspeh <= 6)
                {
                    Console.WriteLine($"Среден успех : {uspeh}");
                }
                else
                {
                    Console.WriteLine("Няма такъв успех");
                }

            }
            else
            {
                Console.WriteLine("Error");
            }

            //zad 5

            Console.Write("Въведете парична стойност:");

            if (decimal.TryParse(Console.ReadLine(), out decimal money))
            {
                Console.WriteLine($"Паричната стойност е: {money}");
            }
            else
            {
                Console.WriteLine("Паричната стойност е невалидна!");
            }

            //zad 6




        }
    }
}
