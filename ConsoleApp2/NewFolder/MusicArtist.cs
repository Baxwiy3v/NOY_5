using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.NewFolder
{
    internal class MusicArtist
    {
        private Sql _database = new Sql();

        public void Create(Music music)
        {
            string cmd = $"insert into Musics VALUES('{music.Name}',{music.Duration})";

            int result = _database.ExecuteCommand(cmd);

            if (result > 0)
            {
                Console.WriteLine("Command successfully ");
            }
            else
            {
                Console.WriteLine("Error ");
            }
        }
        public List<Music> GetById(int musicId)
        {
            string query = "SELECT Musics.Id FROM Musics";

            DataTable table = _database.ExecuteQuery(query);

            List<Music> musics = new List<Music>();

            foreach (DataRow row in table.Rows)
            {
                Music music = new Music
                {
                    Id = (int)row["id"]

                };
                musics.Add(music);
            }
            return musics;

        }
        public List<Music> GetAll()
        {
            string query = "SELECT * FROM Musics";

            DataTable table = _database.ExecuteQuery(query);

            List<Music> musics = new List<Music>();

            foreach (DataRow row in table.Rows)
            {
                Music music = new Music
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString(),
                    Duration = Convert.ToInt32(row["duration"])
                };
                musics.Add(music);
            }
            return musics;
        }
        public int Delete(int id)
        {
            string cmd = $"DELETE FROM Musics WHERE Id={id}";

            int result = _database.ExecuteCommand(cmd);

            if (result > 0)
            {
                Console.WriteLine("Command successfully complated");
            }
            else
            {
                Console.WriteLine("Error occured");
            }
            return result;
        }
       
    }
}
