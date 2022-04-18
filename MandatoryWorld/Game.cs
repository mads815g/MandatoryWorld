using System;
using System.Collections.Generic;
using System.Linq;
using MandatoryWorld.Factory;
using static MandatoryWorld.GameChecks;

namespace MandatoryWorld
{
    /// <summary>
    /// This is the game class. If you call Game.Run(); you start the game.
    /// </summary>
    public class Game
    {
        public int NumberOfTrolls { get; set; }
        public int NumberOfGoblins { get; set; }
        public int NumberOfChests { get; set; }
        private readonly List<Creature> _monster;
        private readonly List<Chest> _chests;
        private readonly MonsterFactory _monsterFactory = new MonsterFactory();
        private readonly GoblinFactory _goblinFactory = new GoblinFactory();
        readonly ChestFactoryAbstract _chestFactory = new ChestFactory();
        private readonly Hero _hero;

        /// <summary>
        /// This is the constructor for the game class.
        /// </summary>
        /// <param name="maxY">This is the height of the game</param>
        /// <param name="maxX">this is the width of the world</param>
        /// <param name="numberOfTrolls">The amount of trolls in the world</param>
        /// <param name="numberOfGoblins">The amount of goblins in the world</param>
        /// <param name="numberOfChests">The amount of chests in the world</param>
        /// <param name="heroName">Your hero name</param>
        /// <param name="heroHp">Your start hp</param>
        /// <param name="heroAttackPower">Your start attack power</param>
        public Game(int maxY, int maxX, int numberOfTrolls, int numberOfGoblins, int numberOfChests, string heroName, int heroHp,
            int heroAttackPower)
        {
            _hero = new Hero(heroName, heroHp, heroAttackPower);
            World.MaxX = maxX;
            World.MaxY = maxY;
            NumberOfTrolls = numberOfTrolls;
            NumberOfGoblins = numberOfGoblins;
            NumberOfChests = numberOfChests;
            _monster = new List<Creature>();
            _chests = new List<Chest>();

            for (int i = 0; i < numberOfTrolls; i++)
            {
                Spawn(_monster, _monsterFactory.CreateCreature());
            }
            for (int i = 0; i < numberOfGoblins; i++)
            {
                Spawn(_monster, _goblinFactory.CreateCreature());
            }
            for (int i = 0; i < numberOfChests; i++)
            {
                Spawn(_chests, _chestFactory.CreateChest());
            }
        }

        /// <summary>
        /// This method starts the game
        /// </summary>
        public void Run()
        {
            MonsterFactoryAbstract world = new MonsterFactory();
            bool gameWon = false;
            Console.WriteLine("press one of the wasd keys to move");

            while (_hero.IsDead == false && gameWon == false)
            {
                Console.WriteLine($"you are at {_hero.PositionX}, {_hero.PositionY}");
                _hero.move();
                MonsterCheck(_hero, _monster);
                ChestCheck(_hero, _chests);
                gameWon = GameWon(_monster);
            }

            _hero.GameOver();
        }
    }
}
