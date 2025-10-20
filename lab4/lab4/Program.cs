using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            // 5. Створюємо колекцію програм
            List<Software> programs = new List<Software>
            {
                new Software("Visual Studio Code", "1.94", 320, true),
                new Software("Google Chrome", "129.0", 480, true),
                new Software("Notepad++", "8.6", 25, true),
                new Software("Blender", "4.2", 950, false),
                new Software("Steam", "2.10", 600, true),
                new Software("Spotify", "1.3", 180, false),
                new Software("Discord", "0.9", 210, true)
            };

            Console.WriteLine("===== Усі програми =====");
            PrintList(programs);

            // 6. 3 методи вибірки даних
            var installed = programs.Where(p => p.IsInstalled);                       // Where
            var smallSize = programs.Where(p => p.SizeMB < 300);                      // Where
            var namesOnly = programs.Select(p => p.Name);                             // Select

            Console.WriteLine("\n===== Встановлені програми =====");
            PrintList(installed);
            Console.WriteLine("\n===== Програми розміром < 300MB =====");
            PrintList(smallSize);
            Console.WriteLine("\n===== Назви всіх програм =====");
            foreach (var name in namesOnly) Console.WriteLine(name);

            // 7. 3 методи зміни порядку даних
            var orderedByName = programs.OrderBy(p => p.Name);
            var orderedBySizeDesc = programs.OrderByDescending(p => p.SizeMB);
            var thenOrdered = programs.OrderBy(p => p.IsInstalled).ThenBy(p => p.SizeMB);

            Console.WriteLine("\n===== Сортування за назвою (OrderBy) =====");
            PrintList(orderedByName);
            Console.WriteLine("\n===== Сортування за розміром (спадання) =====");
            PrintList(orderedBySizeDesc);
            Console.WriteLine("\n===== Спочатку невстановлені, потім за розміром =====");
            PrintList(thenOrdered);

            // 8. 2 методи вибірки даних
            var first3 = programs.Take(3);          // перші 3
            var skip2 = programs.Skip(2);           // пропускаємо 2

            Console.WriteLine("\n===== Перші 3 програми =====");
            PrintList(first3);
            Console.WriteLine("\n===== Пропускаємо перші 2 =====");
            PrintList(skip2);

            // 9. 1 метод управління запитами
            var uniqueSizes = programs.Select(p => p.SizeMB).Distinct(); // Distinct
            Console.WriteLine("\n===== Унікальні розміри програм =====");
            Console.WriteLine(string.Join(", ", uniqueSizes));

            Console.WriteLine("\nРоботу завершено. Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }

        static void PrintList(IEnumerable<Software> list)
        {
            foreach (var p in list)
                Console.WriteLine($"{p.Name,-20} | Версія: {p.Version,-6} | {p.SizeMB,4} MB | Встановлено: {p.IsInstalled}");
        }
    }

    class Software
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public int SizeMB { get; set; }
        public bool IsInstalled { get; set; }

        public Software(string name, string version, int sizeMB, bool isInstalled)
        {
            Name = name;
            Version = version;
            SizeMB = sizeMB;
            IsInstalled = isInstalled;
        }
    }
}
