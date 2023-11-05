using System.Security.Principal;
using task05_11_ado.Models;
using task05_11_ado.Services;

namespace task05_11_ado
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArtistS artistService = new ArtistS();
            MusicS musicService= new MusicS();

            Artist artist = new()
            {
                Id = 1,
                Name = "Suga",
                Surname = "AvgustD",
                Age = 29,
                Gender = "Male"
            };
            Music music = new()
            {
                Name = " Mic Drop",
                Duration = 245,
                ArtistId = 1,
                
            };
            Artist artist2 = new()
            {
                Id = 2,
                Name = "Weekend",
                Surname = ".",
                Age = 33,
                Gender = "Male"
            };
            Music music1 = new()
            {
                Name = " One of the girls",
                Duration = 287,
                ArtistId = 2,

            };
            

            musicService.CreateMusic(music);

            musicService.CreateMusic(music1);

            List<Music> musicc = musicService.GetAllMusic();


            foreach (Music item in musicc )
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.ArtistId+ " " + item.Duration );
            }

            //musicService.DeleteMusic(1);


            artistService.CreateArtist(artist);
            artistService.CreateArtist(artist2);

            List<Artist> artistt = artistService.GetAllArtist();


            foreach (Artist item in artistt)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Surname + " " + item.Age +" "+ item.Gender);
            }

            //artistService.DeleteArtist(1);

        }
    }
}