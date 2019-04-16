using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MusicContext())
            {
                while (true)
                {
                    Console.WriteLine("Что вы хотите сделать?");
                    Console.WriteLine("1)Добавить");
                    Console.WriteLine("2)Просмотреть");
                    Console.WriteLine("3)Выйти");
                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        if (choice == 1)
                        {
                            Add(context);
                        }
                        if (choice == 2)
                        {
                            Show(context);
                        }
                        else if (choice == 3)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод");
                    }
                }
            }
        }

        private static void Add(MusicContext context)
        {
            while (true)
            {
                Console.WriteLine("1)Группу");
                Console.WriteLine("2)Песню");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 1)
                    {
                        MusicalGroup musicalGroup = new MusicalGroup();
                        while (true)
                        {
                            Console.WriteLine("Введите название группы");
                            string songName = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(songName))
                            {
                                musicalGroup.Name = songName;
                                break;
                            }
                        }
                        int amountOfSongs;
                        while (true)
                        {
                            Console.WriteLine("Сколько песен вы хотите добавить?");
                            if (int.TryParse(Console.ReadLine(), out int amount) && amount > 0)
                            {
                                amountOfSongs = amount;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ввод");
                            }
                        }
                        List<Song> songs = new List<Song>();

                        for (int i = 0; i < amountOfSongs; i++)
                        {
                            Song song = new Song();
                            SongDescription songDescrption = new SongDescription();
                            while (true)
                            {
                                Console.WriteLine("Введите название песни");
                                string songName = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(songName))
                                {
                                    song.Name = songName;
                                    break;
                                }
                            }
                            while (true)
                            {
                                Console.WriteLine("Введите текст песни");
                                string songLyrics = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(songLyrics))
                                {
                                    songDescrption.Lyrics = songLyrics;
                                    break;
                                }
                            }
                            while (true)
                            {
                                Console.WriteLine("Введите длительность песни(в секундах)");
                                if (int.TryParse(Console.ReadLine(), out int time))
                                {
                                    songDescrption.Time = time;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный ввод");
                                }
                            }
                            while (true)
                            {
                                Console.WriteLine("Введите рейтинг песни(от 1 до 5)");
                                if (int.TryParse(Console.ReadLine(), out int rating) && rating >= 1 && rating <= 5)
                                {
                                    songDescrption.Rating = rating;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный ввод");
                                }
                            }
                            context.SongDescriptions.Add(songDescrption);
                            song.SongDescription = songDescrption;
                            songs.Add(song);
                            Console.WriteLine("Песня успешно добавлена!");
                            Console.WriteLine("Нажмите enter для продолжения");
                            Console.ReadLine();
                        }
                        musicalGroup.Songs = songs;
                        context.Songs.AddRange(songs);
                        context.MusicalGroups.Add(musicalGroup);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод");
                    }
                }
                else if (choice == 2)
                {
                    Song song = new Song();
                    SongDescription songDescrption = new SongDescription();
                    while (true)
                    {
                        Console.WriteLine("Введите название песни");
                        string songName = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(songName))
                        {
                            song.Name = songName;
                            break;
                        }
                    }
                    while (true)
                    {
                        Console.WriteLine("Введите текст песни");
                        string songLyrics = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(songLyrics))
                        {
                            songDescrption.Lyrics = songLyrics;
                            break;
                        }
                    }
                    while (true)
                    {
                        Console.WriteLine("Введите длительность песни(в секундах)");
                        if (int.TryParse(Console.ReadLine(), out int time))
                        {
                            songDescrption.Time = time;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод");
                        }
                    }
                    while (true)
                    {
                        Console.WriteLine("Введите рейтинг песни(от 1 до 5)");
                        if (int.TryParse(Console.ReadLine(), out int rating) && rating >= 1 && rating <= 5)
                        {
                            songDescrption.Rating = rating;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод");
                        }
                    }
                    song.SongDescription = songDescrption;
                    context.SongDescriptions.Add(songDescrption);
                    context.Songs.Add(song);
                    Console.WriteLine("Песня успешно добавлена!");
                    Console.WriteLine("Нажмите enter для продолжения");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
        }

        private static void Show(MusicContext context)
        {
            while (true)
            {
                Console.WriteLine("1)песни");
                Console.WriteLine("2)группы");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 1)
                    {
                        Console.WriteLine("По возрастанию рейтинга или убыванию?(1 - по возрастанию, 2 - по убыванию)");
                        if (int.TryParse(Console.ReadLine(), out int orderByChoice))
                        {
                            if (orderByChoice == 1)
                            {
                                var songs = from song in context.Songs
                                            where song.SongDescription == (from description in context.SongDescriptions select description)
                                            orderby song
                                            ascending
                                            select song;

                                foreach (var song in songs)
                                {
                                    Console.WriteLine(song.Name);
                                }
                                Console.WriteLine("Нажмите Enter для продолжения");
                                Console.ReadLine();
                                break;
                            }
                            else if (orderByChoice == 2)
                            {
                                var songs = from song in context.Songs
                                            where song.SongDescription == (from description in context.SongDescriptions select description)
                                            orderby song
                                            descending
                                            select song;
                                foreach (var song in songs)
                                {
                                    Console.WriteLine("Название - " + song.Name);
                                    foreach (var description in context.SongDescriptions)
                                    {
                                        Console.WriteLine("Слова - " + description.Lyrics);
                                        Console.WriteLine("Длительность - " + description.Time / 60 + " минуты");
                                        Console.WriteLine("Рейтинг - " + description.Rating);
                                    }
                                    Console.WriteLine();
                                }
                                Console.WriteLine("Нажмите Enter для продолжения");
                                Console.ReadLine();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ввод");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод");
                        }
                    }
                    else if (choice == 2)
                    {
                        var groups = from musicalGroup in context.MusicalGroups
                                     select musicalGroup;

                        foreach (var group in groups)
                        {
                            Console.WriteLine("Название - " + group.Name);
                            Console.WriteLine("Песни: ");
                            foreach (var song in group.Songs)
                            {
                                Console.WriteLine(song.Name);
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("Нажмите Enter для продолжения");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
        }
    }
}