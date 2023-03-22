using System;
using System.Threading;

namespace Piano
{
    // Оголошення типу даних Note
    class Note
    {
        // Оголошення змінної класу, типу даних Tone, що зберігає частоту звука ноти
        private Tone tone;
        // Оголошення змінної класу, типу даних Duration, що зберігає тривалість звука ноти
        private Duration duration;
        // Оголошення конструктора за замовчуванням
        public Note()
        {
            // Ініціалізація змінної класу tone
            tone = Tone.Pause;
            // Ініціалізація змінної класу duration
            duration = Duration.Whole;
        }
        // Оголошення параметризованого конструктора
        public Note(string t, string d)
        {
            // Ініціалізація tone, в результаті перетворення з строкового типу даних
            Enum.TryParse(t, out tone);
            // Ініціалізація duration, в результаті перетворення з строкового типу даних
            Enum.TryParse(d, out duration);
        }
        // Оголошення методу для програвання ноти
        public void Sound()
        {
            // Реалізація програвання паузи
            if ((int)tone == 0)
                Thread.Sleep((int)duration);
            // Реалізація програвання ноти
            else
                Console.Beep((int)tone, (int)duration);
        }
    }

}
