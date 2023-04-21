namespace DZ11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OtusDictionary NewDict = new OtusDictionary();

            NewDict.Add(11, "AAA");
            NewDict.Add(12, "BBB");
            NewDict.Add(7, "CCC");
            NewDict.Add(36, "DDD");
            NewDict.Add(34, "TTT");
            NewDict.Add(34, "TTT");
            NewDict.Add(34, null);
            NewDict.Add(64, null);

            Console.WriteLine();
            Console.WriteLine(NewDict.Get(11));
            Console.WriteLine(NewDict.Get(12));
            Console.WriteLine(NewDict.Get(7));
            Console.WriteLine(NewDict.Get(36));
            Console.WriteLine(NewDict.Get(34));
            Console.WriteLine(NewDict.Get(64)); 
            Console.WriteLine(NewDict.Get(94));


            Console.ReadKey();
        }
    }

    internal class OtusDictionary
    {
        public int Key { get; set; }
        public string Value { get; set; }
        public static int size = 32;
        int HasKey;


        public OtusDictionary[] dictionary = new OtusDictionary[size];

        public OtusDictionary()
        {
            //size = 32;
        }

        public void Add(int Key, string Value)

        {
            if (Value != null)
            {
                HasKey = Key % size;
                if (dictionary[HasKey]?.Key == Key) { Console.WriteLine("Дублирование ключа"); return; }
                while (dictionary[HasKey]?.Value != null)
                {
                    size *= 2;
                    Array.Resize(ref dictionary, size);
                    for (int i = 0; i < size; i++)
                    {
                        if (dictionary[i] != null)
                            dictionary[dictionary[i].Key % size].Value = dictionary[i].Value;
                    }
                    HasKey = Key % size;
                }
                OtusDictionary Dict = new OtusDictionary();
                Dict.Key = Key;
                Dict.Value = Value;
                dictionary[HasKey] = Dict;
            }
        }


        public string Get(int Key)
        {
            HasKey = Key % size;
            if (dictionary[HasKey]?.Value != null) return dictionary[HasKey].Value;

            return "Ключ не найден";

        }

    }
}