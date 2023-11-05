using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task05_11_ado.Data;
using task05_11_ado.Models;

namespace task05_11_ado.Services
{
    internal class MusicS
    {
        Sql _database = new();
        ArtistS _artistService = new();

        public void CreateMusic(Music music)
        {
            string command = $"insert into Music values('{music.Name}',{music.Duration},{music.ArtistId})";
            int result = _database.ExecuteCommand(command);
            if (result > 0)
            {
                Console.WriteLine("Music successfully added");
            }
        }
        public Music GetByIdMusic(int id)
        {
            Music music = new();
            string query = $"select *from Music where Id={id}";
            var table = _database.ExecuteQuery(query);
            if (table.Rows.Count == 0)
            {
                throw new Exception("Music Not found");
            }
            music.Id = (int)table.Rows[0]["Id"];
            music.Name = table.Rows[0]["Name"].ToString();
            music.Duration = (int)table.Rows[0]["Duration"];
            music.ArtistId = (int)table.Rows[0]["ArtistId"];
            music.Artist = _artistService.GetByIdArtist((int)table.Rows[0]["ArtistId"]);

            return music;
        }
        public List<Music> GetAllMusic()
        {
            List<Music> musics = new();
            string query = "select *from Music";
            var table = _database.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                Music music = new()
                {
                    Name = row["Name"].ToString(),
                    ArtistId = (int)row["ArtistId"],
                    Artist = _artistService.GetByIdArtist((int)row["ArtistId"]),
                    Duration = (int)row["Duration"]
                };
                musics.Add(music);
            }
            return musics;
        }
        public void DeleteMusic(int id)
        {
            string command = $"delete from Music where Id={id}";
            int result = _database.ExecuteCommand(command);
            if (result > 0)
            {
                Console.WriteLine("Music successfully deleted");
            }
        }
    }
}
