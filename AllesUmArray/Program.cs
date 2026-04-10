namespace DojoCSAufgaben
{
    internal class Program
    {

        /// <summary>
        /// Einübung in die Vererbung zur Wiederholdung
        /// </summary>
        public class Student : PersonBase{
            public Student(string FullName) : base(FullName)
            {
            }

            public Student(string FirstName, string LastName) : base($"{FirstName} {LastName}")
            {
            }

            public int SchoolYear{ get; set; }

            public override void Write()
            {
                base.Write();
                Console.WriteLine($"Diese Person ist ein Schueler im {SchoolYear}. Jahr");
            }
        }

        public class Teacher : PersonBase
        {
            public Teacher(string FullName) : base(FullName)
            {
            }

            public string Subject { get; set; }

            public override void Write()
            {
                base.Write();
            }
        }


        public class PersonBase
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }

            public PersonBase(string FullName)
            {
                var NameSplit = FullName.Split(' ');
                FirstName = NameSplit[0];
                LastName = NameSplit[1];
            }

            public PersonBase(string FirstName, string LastName)
            {
                this.FirstName = FirstName;
                this.LastName = LastName;
                    }

      
            public virtual void Write()
            {
                Console.WriteLine($"{FirstName} {LastName} wohnt hier: {Address}");
            }
        }

        /// SUMMARY ENDE



        /// <summary>
        /// AUFGABE ENTSCHEIDUNGEN || 
        /// If Statement Temperatur Zustand vom Wasser
        /// </summary>
        public class Temperatur
        {
            public static string MesseZustand(int temperatur)
            {
                if (temperatur <= 0)
                {
                    return "Gefroren";
                }
                else if (temperatur >= 100)
                {
                    return "Dampf";
                }
                else
                {
                    return "Flüssig";
                }

                return "";
            }

            public static void Run()
            {
                Console.WriteLine($"Verdampft: {MesseZustand(100)}");
                Console.WriteLine($"Gefroren {MesseZustand(0)}");
                Console.WriteLine($"Fluessig: {MesseZustand(20)}");
                Console.WriteLine($"{MesseZustand(10000)}");
                Console.WriteLine($"{MesseZustand(-12)}");

            }
        }


        /// <summary>
        /// AUFGABE SCHLEIFEN |||
        /// Aufgabe ist es, alle Zahlen zwischen der Anfangszahl und der Endzahl zu addieren.
        ///
        ///     Beispiel:
        /// Bei 5 und 10: 6+7+8+9
        /// Die Funktion liefert 30.
        /// </summary>
        public class Calculator
        {
            public static int CalcSum(int begin, int end)
            {
                int result = 0;
                for (int i = begin; i < end; i++)
                {
                    if (i == begin)
                        continue;

                    result += i;
                    //Console.WriteLine(i);

                }

                return result;
            }

            public static void Run()
            {
                Console.WriteLine(CalcSum(5,10));
            }


        }



        /// <summary>
        /// AUFGABE ARRAYS - DIE LÖSUNG DIE AM ENDE FUNKTIONIERT HAT
        /// </summary>
        public class NumbersCORRECT
        {
            public static double? FindLargestNumberOLD(double[] numbers)
            {

                if (numbers == null)
                {
                    return null;
                }

                double largestNumber = numbers[0];

                for (int i = 1; i < numbers.Length; i++)
                {
                    if (numbers[i] > largestNumber)
                    {
                        largestNumber = numbers[i];
                    }
                }

                return largestNumber;
            }


            public static double FindLargestNumber(double[] numbers)
            {
                if (numbers == null)
                {
                    return 0;
                }

                if (numbers.Length == 0)
                {
                    return 0;
                }

                double largestNumber = numbers[0];

                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] > largestNumber)
                    {
                        largestNumber = numbers[i];
                    }
                }

                return largestNumber;
            }


            public static void Run()
            {
                Console.WriteLine(FindLargestNumber(new double[15] { 67.980, 15.60, 1.10, 2, 45.14, 67.67, 505, 12.15, 22.70, 31.98, 2.200, 20, 203.20, 800.201, 0}));
            }
        }


        /// <summary>
        /// AUFGABE ARRAYS
        /// </summary>
        public class Numbers
        {
            public static double FindLargestNumber(double[] numbers)
            {
                if (numbers.Length == 0)
                    return 0;

                for (int i = 0; i < numbers.Length; i++)
                {
                    for (int j = 1; j < numbers.Length; j++)
                    {
                        if (numbers[j - 1] > numbers[i])
                        {
                            //Falls die vorherige Nummer größer ist als die Nummer danach dann soll gewechselt werden.
                            double temp = numbers[i];
                            numbers[i] = numbers[j - 1];
                            numbers[j - 1] = temp;
                            continue;                        
                        }
                        Console.WriteLine($"LINE j-1: {numbers[j - 1]} | LINE i: {numbers[i]}");
                    }           
                }

                return numbers[numbers.Length-1];
            }

            public static void Run()
            {
                Console.WriteLine(FindLargestNumber(new double[10] { 10.20, 15.60, 1.10, 150000, 45.14, 67.67, 17.13, 12.15, 22.70, 31.98 }));
            }
        }


        /// <summary>
        /// AUFGABE COLLECTIONS
        /// </summary>
        public static class DojoManager
        {
            public static string SearchStudent(System.Collections.Generic.Dictionary<string, string[]> studentsInClasses, string student)
            {
                if (studentsInClasses == null)
                {
                    return null;
                }

                foreach (var entry in studentsInClasses)
                {

                    foreach (var name in entry.Value)
                    {
                        if(name == student)
                        {
                            return entry.Key;
                        }
                    }
                }
                return null;
            }

            public static void Run()
            {
                var dojo = new Dictionary<string, string[]>();
                dojo.Add("Halle 1", new string[] { "Alice", "Bob" });
                dojo.Add("Halle 2", new string[] { "Charlie", "David", "Eve" });

                string name = "Alice";
                string raum = DojoManager.SearchStudent(dojo, name);

                Console.WriteLine(raum);
            }
        }
        
        /// <summary>
        /// AUFGABE KLASSENSTRUKTUR
        /// </summary>
        public class Klassenstruktur{
            public static void Run()
            {
                Fisch fisch = new Fisch("Goldie", "Goldfisch");
                Teich teich = new Teich();

                Console.WriteLine(teich.AddFisch(fisch));
            }

            public class Fisch
            {
                public string name { get; set; }
                public string rasse { get; set; }

                public Fisch(string name, string rasse)
                {
                    this.name = name;
                    this.rasse = rasse;
                }


            }




            public class Teich
            {
                public string AddFisch(Fisch fisch)
                {
                    return $"Der {fisch.rasse} namens {fisch.name} wurde hinzugefügt";
                }
            }

        }

        
        /// <summary>
        /// Aufgabe ENUMERATION
        /// </summary>
        public class Enumeration
        {

            enum Level
            {
                Beginner,
                Advanced,
                Master
            }

            class Person
            {
                Level level;
                string lastName;

                public Person(string lastName, Level level) 
                {
                    this.level = level;
                    this.lastName = lastName;
                }

                public int CurrLevel() 
                {
                    switch (this.level)
                    {
                        case Level.Beginner: return 3;
                            break;
                        case Level.Advanced: return 2;
                            break;
                        case Level.Master: return 1;
                            break;
                        default: return 0;
                    }                
                }
            }
        }


        /// <summary>
        /// AUFGABE DATUM UND ZEIT
        /// </summary>
        class Birthday
        {
            public static int OnWeekdayCount(DateTime birthday, DayOfWeek dayOfWeek)
            {
                
                int dateYear = DateTime.Now.Year - birthday.Year;
                DateTime date = birthday;
                int count = 0;

                for (int i = 0; i <= dateYear; i++)
                {
                    //Console.WriteLine($"Datum: {date} Day of the Week: {date.DayOfWeek} | Birthday: {birthday} Day of the Week: {birthday.DayOfWeek}");
                    if (date.DayOfWeek.Equals(dayOfWeek))
                    {
                        count++;
                    }

                    date = date.AddYears(1);
                }
                return count;
                
            }


            public static void Run()
            {

                DateTime birthday = new DateTime(year:1945, month:5, day: 16);
                OnWeekdayCount(birthday, DayOfWeek.Monday);
            }
        }


        /// <summary>
        /// AUFGABE VERERBUNG
        /// </summary>
        class Vererbung
        {
            public class Material
            {
                public string name;
                public string id;

                public Material(string name, string id)
                { 
                    this.name = name;
                    this.id = id;
                }

                public virtual string GetID() 
                {
                    return this.id;
                }
            }


            public class RawMaterial : Material
            {
                public string seller;

                public RawMaterial(string name, string id, string seller) : base(name, id) 
                {
                    this.seller = seller;
                }

                public override string GetID() 
                {
                    return $"{base.GetID()}-{this.seller}";
                }
            }


            public static void Run()
            {
                Material material = new Material("Granit", "T22");
                RawMaterial rawMat = new RawMaterial("Raw Material", "T25", "Mobi");
                Console.WriteLine($"Material: {material.GetID()}");
                Console.WriteLine($"Raw Material: {rawMat.GetID()}");

            }

        }

        static void Main(string[] args)
        {
            // Aufgabe Entscheidungen
            //Temperatur.Run();

            //Aufgabe Schleifen
            //Calculator.Run();

            //Aufgabe Arrays
            //NumbersCORRECT.Run();

            //Aufgabe Collections
            //DojoManager.Run();

            //Augabe Klassenstruktur
            //Klassenstruktur.Run();

            //Aufgabe Datum - Zeit
            //Birthday.Run();

            //Aufgabe Vererbung
            //Vererbung.Run();

        }
    }
}
