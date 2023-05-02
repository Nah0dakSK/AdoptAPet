namespace AdoptAPet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Pet> availablePets = new List<Pet>()
            {
                new Pet("Ďuro", "škrečok", 1),
                new Pet("Lilien", "mačka", 2),
                new Pet("Godži", "papagáj", 2),
                new Pet("Fido", "pes", 3),
                new Pet("Fabián", "morča", 5),
                new Pet("Martin", "korytnačka", 4),
                new Pet("Škrček", "had", 4),
                new Pet("Janči", "kôň", 3),
                new Pet("Ben", "somár", 2)
            };

            List<Pet> adoptedPets = new List<Pet>();

            Console.WriteLine("------------------------------");
            Console.WriteLine("| VITAJTE V ADOPČNOM CENTRE! |");
            Console.WriteLine("------------------------------");

            while (true)
            {
                Console.WriteLine("\nVOĽNÉ ZVIERATÁ:");

                for (int i = 0; i < availablePets.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {availablePets[i]}");
                }

                Console.WriteLine("\nVÝBER:");
                Console.WriteLine("--------------------------");
                Console.WriteLine("| 1. ADOPTUJ SI ZVIERA   |");
                Console.WriteLine("| 2. ADOPTOVANÉ ZVIERATÁ |");
                Console.WriteLine("| 3. VYHOTOVENIE         |");
                Console.WriteLine("| 4. ODÍSŤ               |");
                Console.WriteLine("--------------------------");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AdoptPet(availablePets, adoptedPets);
                            break;
                        case 2:
                            ViewAdoptedPets(adoptedPets);
                            break;
                        case 3:
                            Console.WriteLine("VYHOTOVILI:");
                            Console.WriteLine("---------------------");
                            Console.WriteLine("| Barbora Dujčíková |");
                            Console.WriteLine("| Patrik Fatura     |");
                            Console.WriteLine("---------------------");
                            break;
                        case 4:
                            Console.WriteLine("ĎAKUJEME ZA POUŽITIE NAŠEJ APPKY!");
                            return;
                        default:
                            Console.WriteLine("NEPLATNÁ VOĽBA!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("NEPLATNÁ VOĽBA!");
                }
            }
        }
        static void AdoptPet(List<Pet> availablePets, List<Pet> adoptedPets)
        {
            Console.WriteLine("\nZADAJ ČÍSLO ZVIERAŤA:");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int index) && index >= 1 && index <= availablePets.Count)
            {
                Pet pet = availablePets[index - 1];
                adoptedPets.Add(pet);
                availablePets.RemoveAt(index - 1);
                Console.WriteLine($"\nVÝBORNE, ADOPTOVALI STE SI {pet.Name}, DRUH: {pet.Type}!");
            }
            else
            {
                Console.WriteLine("NEPLATNÁ VOĽBA!");
            }
        }
        static void ViewAdoptedPets(List<Pet> adoptedPets)
        {
            if (adoptedPets.Count == 0)
            {
                Console.WriteLine("\nNEMÁŠ ADOPTOVANÉ ZVIERATÁ");
            }
            else
            {
                Console.WriteLine("\nTVOJE ADOPTOVANÉ ZVIERATÁ:");
                foreach (Pet pet in adoptedPets)
                {
                    Console.WriteLine(pet);
                }
            }
        }
    }
}