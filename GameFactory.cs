using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace GameLibrary
{
    public class GameFactory
    {
        StreamWriter sw;
        XmlSerializer serial;
        List<Game> gameList;
        public String FilePath = @"..\..\games.xml";

        public void CreateGameList()
        {
            gameList = new List<Game>();
            Game G = new Game("Hornets", "Bulldogs", 50, 75);
            gameList.Add(G);
            G = new Game("Heat", "Mavericks", 125, 65);
            gameList.Add(G);
            G = new Game("Echo Fox", "PG", 3, 2);
            gameList.Add(G);
            G = new Game("USA", "China", 45, 22);
            gameList.Add(G);
            G = new Game("Mike Tyson", "Muhammad Ali", 93, 97);
            gameList.Add(G);
            G = new Game("JDCR", "Saint", 3, 2);
            gameList.Add(G);
        }

        public Boolean SerializeGameList()
        {
            serial = new XmlSerializer(gameList.GetType());
            sw = new StreamWriter(FilePath);
            serial.Serialize(sw, gameList);
            sw.Close();

            return true;
        }

        public List<Game> DeserializeGameList()
        {
            gameList = new List<Game>();
            StreamReader sr = new StreamReader(FilePath);
            serial = new XmlSerializer(gameList.GetType());
            gameList = (List<Game>) serial.Deserialize(sr);
            sr.Close();
            return gameList;
        }

    }
}
