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
    internal class ArtistS
    {
        private Sql _database = new Sql();

        public void CreateArtist(Artist artist)
        {
            string command = $"insert into Artist values ('{artist.Name}','{artist.Surname}',{artist.Age},'{artist.Gender}')";
            int result = _database.ExecuteCommand(command);
            if (result > 0)
            {
                Console.WriteLine("Artist successfully added");
            }
        }
        public Artist GetByIdArtist(int id)
        {
            Artist artist = new();
            string query = $"select *from Artist where Id={id}";
            var result = _database.ExecuteQuery(query);
            if (result.Rows.Count == 0)
            {
                throw new Exception("Artist Not found");
            }
            artist.Id = (int)result.Rows[0]["Id"];
            artist.Name = result.Rows[0]["Name"].ToString();
            artist.Surname = result.Rows[0]["Surname"].ToString();
            artist.Age = (int)result.Rows[0]["Age"];
            artist.Gender = result.Rows[0]["Gender"].ToString();
            return artist;
        }
        public List<Artist> GetAllArtist()
        {
            List<Artist> artists = new();
            string query = "select *from Artist";
            var table = _database.ExecuteQuery(query);

            foreach (DataRow row in table.Rows)
            {
                Artist artist = new()
                {
                    Id = (int)row["Id"],
                    Name = row["Name"].ToString(),
                    Surname = row["Surname"].ToString(),
                    Age = (int)row["Age"],
                    Gender = row["Gender"].ToString()
                };
                artists.Add(artist);

            }

            return artists;
        }
        public void DeleteArtist(int id)
        {
            string command = $"delete from Artist where Id={id}";
            int result = _database.ExecuteCommand(command);
            if (result > 0)
            {
                Console.WriteLine("Artist successfully deleted");
            }

        }
    }
}
