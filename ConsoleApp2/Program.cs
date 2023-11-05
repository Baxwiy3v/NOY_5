using ConsoleApp2.NewFolder;
using System.Data;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicArtist musicArtist = new MusicArtist();

          
            Music newMusic = new Music
            {
                Name = "Unutma..",
                Duration = 120 
            };
            musicArtist.Create(newMusic);

            List<Music> allMusics = musicArtist.GetAll();
            foreach (var music in allMusics)
            {
                Console.WriteLine($"Music ID: {music.Id}, Name: {music.Name}, Duration: {music.Duration} second");
            }

           
            int musicId = 1; 
            List<Music> musicById = musicArtist.GetById(musicId);
            foreach (var music in musicById)
            {
                Console.WriteLine($"Music ID: {music.Id}");
            }

           
            int deleteMusicId = 2; 
            int deletedRows = musicArtist.Delete(deleteMusicId);
            if (deletedRows > 0)
            {
                Console.WriteLine($"Deleted {deletedRows} row(s) successfully.");
            }
            else
            {
                Console.WriteLine("No rows were deleted.");
            }

        }
    }
}