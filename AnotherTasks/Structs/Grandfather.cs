using AnotherTasks.Enums;

namespace AnotherTasks.Structs
{
    struct Grandfather
    {
        public string Name; // поле, содержащее имя деда
        public int AmountOfFingals = 0; // поле, содержащее количество фингалов
        public Grouchiness Grouchiness; // enum с уровнем ворчливости
        public string[] Phrases; // фразы деда

        public Grandfather(string name, Grouchiness grouchiness, params string[] phrases)
        {
            Name = name;
            AmountOfFingals = 0;
            Grouchiness = grouchiness;
            Phrases = phrases;
        }

        public static int CalculateAmountOfFingals(ref Grandfather grandfather, params string[] swearPhrases)
        {

            for (int i = 0; i < grandfather.Phrases.Length; i++)
            {
                grandfather.Phrases[i] = grandfather.Phrases[i].ToLower();
            }

            foreach (var phrase in swearPhrases)
            {
                if (grandfather.Phrases.Contains(phrase.ToLower()))
                {
                    Console.WriteLine($"Дед {grandfather.Name} получил фингал");
                    grandfather.AmountOfFingals++; // увеличиваем кол-во фингалов у переданного деда
                }
            }

            return grandfather.AmountOfFingals;
        }
    }
}
