using System;
using System.Collections.Generic;
using System.Linq;
using MandatoryWorld.Factory;

namespace MandatoryWorld
{
    public class Game
    {
        public int NumberOfMonsters { get; set; }
        public int NumberOfChests { get; set; }
        private readonly List<Monster> _monster;
        private readonly List<Chest> _chests;
        readonly MonsterFactoryAbstract _monsterFactory = new MonsterFactory();
        readonly ChestFactoryAbstract _chestFactory = new ChestFactory();
        private readonly Hero _hero;

        public Game(int maxY, int maxX, int numberOfMonsters, int numberOfChests, string heroName, int heroHp, int heroAttackPower)
        {
            _hero = new Hero(heroName, heroHp, heroAttackPower);
            World.MaxX = maxX;
            World.MaxY = maxY;
            NumberOfMonsters = numberOfMonsters;
            NumberOfChests = numberOfChests;
            _monster = new List<Monster>();
            _chests = new List<Chest>();
            for (int i = 0; i < numberOfMonsters; i++)
            {
                _monster.Add(_monsterFactory.CreateTrolls());
                _monster.Add(_monsterFactory.CreateGoblins());
            }
            for (int i = 0; i < numberOfChests; i++)
            {
                _chests.Add(_chestFactory.CreateChest());
            }

        }
        public void Run()
        {
            MonsterFactoryAbstract world = new MonsterFactory();
            bool gameWon = false;
            Console.WriteLine("press one of the wasd keys to move");

            while (_hero.IsDead == false && gameWon == false)
            {
                Console.WriteLine($"you are at {_hero.PositionX}, {_hero.PositionY}");
                _hero.move();
                foreach (var monster in _monster.Where(a => a.PositionY == _hero.PositionY && a.PositionX == _hero.PositionX))
                {
                    if (monster.IsDead == true)
                    {
                        Console.WriteLine($"Dead {monster.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"you have encountered {monster.Name}, fight commenced");
                    }

                    while (_hero.IsDead == false && monster.IsDead == false)
                    {
                        monster.RecieveHit(_hero.hit());
                        _hero.RecieveHit(monster.hit());
                    }
                }

                foreach (var chest in _chests)
                {
                    if (_hero.PositionX == chest.PositionY && _hero.PositionY == chest.PositionY)
                    {
                        Console.WriteLine($"you have encountered {chest.Name}, looting commenced");
                        _hero.Loot(chest.ContainedLoot());
                        Console.WriteLine($"You now have {_hero.AttackPower} attack and {_hero.Defense} defence");
                    }
                }
                int monstersAlive = _monster.Count;
                foreach (var monster in _monster)
                {
                    if (monster.IsDead == true)
                    {
                        monstersAlive--;
                    }
                }

                if (monstersAlive == 0)
                {
                    Console.WriteLine("There are no more monster you have won the game");
                    gameWon = true;
                    Console.ReadKey();
                }

            }

            if (_hero.IsDead == true)
            {
                Console.WriteLine("You have died, Game Over");
                Console.ReadKey();
            }
        }
    }
}
