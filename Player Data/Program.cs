using System;
using System.Collections.Generic;

namespace Player_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAdd = "1";
            const string CommandDelite = "2";
            const string CommandBan = "3";
            const string CommandUnBan = "4";
            const string CommandExit = "5";

            bool isWorking = true;
            PlayersData playerData = new PlayersData();

            while (isWorking)    
            {
                playerData.ShowPlayers();

                Console.WriteLine($"{CommandAdd} - добавить игрока\n{CommandDelite} - удалить игрока\n{CommandBan} - забанить игрока\n{CommandUnBan} - разбанить игрока\n{CommandExit} - выход");
               
                string userInput = Console.ReadLine();

                switch (userInput)
                {

                    case CommandAdd:
                        playerData.AddPlayer();
                        break;

                    case CommandDelite:
                        playerData.DelitePlayer();
                        break;

                    case CommandBan:
                        playerData.BanPlayer();
                        break;

                    case CommandUnBan:
                        playerData.UnBanPlayer();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;

                    default:
                        Console.WriteLine("неверный ввод");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Player
    {
        private static int _id = 0;

        public Player(string name)
        {
            ID = _id++;
            Name = name;
            Level = 1;
            IsBanned = false;
        }

        public int ID { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool IsBanned { get; private set; }

        public void Ban()
        {
            IsBanned = true;
        }

        public void UnBan()
        {
            IsBanned = false;
        }
    }

    class PlayersData
    {
        private readonly List<Player> _players = new List<Player>();

        public void ShowPlayers()
        {
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("список игроков:");
            Console.SetCursorPosition(0, 11);

            foreach (Player player in _players)
                Console.WriteLine($"|игрок - {player.Name}| ID: {player.ID}| уровень - {player.Level}| статус блокировки - {player.IsBanned}|");

            Console.SetCursorPosition(0, 0);
        }

        public void AddPlayer()
        {
            Console.WriteLine("введите имя:");
            string name = Console.ReadLine();

            Player player = new Player(name);
            _players.Add(player);
        }

        public void DelitePlayer()
        {
            if (FindPlayer(out Player player))
                _players.Remove(player);
            else
                Console.WriteLine("игрок не найден");
        }

        public void BanPlayer()
        {
            if (FindPlayer(out Player player))
                player.Ban();
            else
                Console.WriteLine("игрок не найден");
        }

        public void UnBanPlayer()
        {
            if (FindPlayer(out Player player))
                player.UnBan();
            else
                Console.WriteLine("игрок не найден");
        }

        public int ConvertToNumber()
        {
            Console.Write("введите ID игрока:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int index) == true);
            return index;
        }

        private bool FindPlayer(out Player playerFind)
        {
            int playerId = ConvertToNumber();

            foreach (Player player in _players)
            {
                if (player.ID == playerId)
                {
                    playerFind = player;
                    return true;
                }
            }

            playerFind = null;
            return false;
        }
    }
}
