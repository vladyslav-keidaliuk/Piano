using System.Collections;

namespace Piano
{
     // Оголосити делегат PlayNotes без вхідних та вихідних параметрів
     delegate void PlayNotes();
     // Оголошення типу даних Melody
     class Melody
     {

    // Оголосити змінну notes, масив типу даних Note
    private Note[] notes;
    // Оголосити змінну playNotes, масив типу даних PlayNotes
    private PlayNotes[] playNotes;
    
    // Оголошення конструктора за замовчуванням
    public Melody()
    {
        // Ініціалізувати змінну notes
        notes = new Note[0];
        // Ініціалізувати змінну playNotes
        playNotes = new PlayNotes[0];
    }
    
    
    // Оголошення події з аксесорами
    public event PlayNotes playMelody
    {
        // Оголошення аксесора додавання
        add
        {
            PlayNotes[] tmp = new PlayNotes[playNotes.Length+1];
            // Реалізувати додавання обробника події в масив делегатів playNotes
            for (int i = 0; i < playNotes.Length; i++)
            {
                tmp[i] = playNotes[i];
            }
            tmp[tmp.Length - 1] = value;
            playNotes = tmp;
        }
        // Оголошення аксесора видалення
        remove
        {
            // Реалізувати видалення обробника події з масиву делегатів playNotes
            PlayNotes[] tmp = new PlayNotes[playNotes.Length-1];
            // Реалізувати додавання обробника події в масив делегатів playNotes
            int k = 0;
            for (int i = 0; i < playNotes.Length; i++)
            {
                
                if (value != playNotes[i])
                {
                    tmp[k] = playNotes[i];
                    k++;
                }
                
            }
            playNotes = tmp;
        }
    }
    // Оголошення методу, що запускає подію playMelody
    public void OnPlayMelody()
    {
        for (int i = 0; i < playNotes.Length; i++)
        {
            playNotes[i]();
        }
        // Реалізувати циклічне звернення до елементів масиву делегатів playNotes для 
        // виклику по черзі кожного обробника події
    }
    // Оголошення методу, що виконує додавання ноти в мелодію
    public void AddNote(string t, string d)
    {
        Note note = new Note(t,d);
        playMelody += note.Sound;
        
        Note[] tmp = new Note[notes.Length+1];
        for (int i = 0; i < notes.Length; i++)
        {
            tmp[i] = notes[i];
        }
        tmp[tmp.Length - 1] = note;
        notes = tmp;

        // Оголосити змінну note, типу даних Note, ініціалізувати параметрами t та d
        // Реалізувати додавання в подію playMelody методу Sound для note
        // Реалізувати додавання note до масиву нот notes
    }
    // Оголошення методу, що виконує видалення ноти з мелодії
    public void RemoveNote(int idx)
    {
        Note note = notes[idx];
        playMelody -= note.Sound;

        Note[] tmp = new Note[notes.Length - 1];
        int k = 0;
        for (int i = 0; i < notes.Length; i++)
        {
            if (note != notes[i])
            {
                tmp[k] = notes[i];
                k++;
            }

            
        }
        notes = tmp;

        // Оголосити змінну note, типу даних Note, обрану з масиву нот за idx
        // Реалізувати видалення з події playMelody методу Sound для note
        // Реалізувати видалення note з масиву нот notes
    }
    }

}