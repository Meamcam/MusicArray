using System;

namespace music
{
    class Program
    {
           // Defines an enum with at least 5 music genres //
        enum Genre
        {
            Punk,
            HipHop,
            DoomMetal,
            NoisePop,
            BlueGrass
        }

           // Define the Music structure //
        struct Music
        {
            private string _Title;
            private string _Artist;
            private string _Album;
            private double _Length; // Length in minutes //
            private Genre _Genre;

               // Set methods for assigning values //
            public void SetTitle(string title) => _Title = title;
            public void SetArtist(string artist) => _Artist = artist;
            public void SetAlbum(string album) => _Album = album;
            public void SetLength(double length) => _Length = length;
            public void SetGenre(Genre genre) => _Genre = genre;

               // Displays the song information //
            public string Display()
            {
                return $"Title: {_Title}\nArtist: {_Artist}\nAlbum: {_Album}\nLength: {_Length} minutes\nGenre: {_Genre}";
            }
        }

        static void Main(string[] args)
        {
               // Prompt user for the number of songs to enter //
            Console.WriteLine("How many songs would you like to enter?");
            int size = int.Parse(Console.ReadLine());
            Music[] collection = new Music[size];

            try
            {
                   // Loop through the array to collect song details //
                for (int i = 0; i < size; i++)
                {
                    collection[i] = new Music();

                    Console.WriteLine("Please enter the song title:");
                    collection[i].SetTitle(Console.ReadLine());

                    Console.WriteLine("Please enter the artist:");
                    collection[i].SetArtist(Console.ReadLine());

                    Console.WriteLine("Please enter the album:");
                    collection[i].SetAlbum(Console.ReadLine());

                    Console.WriteLine("Please enter the song length (in minutes):");
                    double tempLength;
                    while (!double.TryParse(Console.ReadLine(), out tempLength) || tempLength <= 0)
                    {
                        Console.WriteLine("Invalid input. Enter a valid song length (e.g., 3.5):");
                    }
                    collection[i].SetLength(tempLength);

                    Console.WriteLine("What is the genre?");
                    Console.WriteLine("P - Punk\nH - HipHop\nD - DoomMetal\nN - NoisePop\nB - BlueGrass");

                    Genre tempGenre = Genre.Punk; // Default value
                    string genreInput = Console.ReadLine()?.Trim().ToUpper();
                    if (!string.IsNullOrEmpty(genreInput) && genreInput.Length == 1)
                    {
                        switch (genreInput[0])
                        {
                            case 'P': tempGenre = Genre.Punk; break;
                            case 'H': tempGenre = Genre.HipHop; break;
                            case 'D': tempGenre = Genre.DoomMetal; break;
                            case 'N': tempGenre = Genre.NoisePop; break;
                            case 'B': tempGenre = Genre.BlueGrass; break;
                            default:
                                Console.WriteLine("Invalid input. Defaulting to Punk.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Defaulting to Punk.");
                    }
                    collection[i].SetGenre(tempGenre);
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // Display all entered songs //
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine($"{collection[i].Display()}");
                }
            }
        }
    }
}
