using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using MandatoryWorld.Factory;
using MandatoryWorld.Observers;
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
        private readonly List<Monster> _monster;
        private readonly List<Chest> _chests;
        private readonly MonsterFactoryAbstract _goblinFactory = new GoblinFactory();
        private readonly AbstractHeroFactory _heroFactory = new HeroFactory();
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
        public Game(int maxY, int maxX, int numberOfGoblins, int numberOfChests, string heroName, int heroHp,
            int heroAttackPower)
        {
            _hero = _heroFactory.CreateHero("MadsHero", 10, 100);
            World.MaxX = maxX;
            World.MaxY = maxY;
            NumberOfGoblins = numberOfGoblins;
            NumberOfChests = numberOfChests;
            _monster = new List<Monster>();
            _chests = new List<Chest>();


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
            ReadConfiguration();
            bool gameWon = false;
            var observer = new ObserverA();
            var monsterObserver = new ObserverB();
            foreach (var creature in _monster)
            {
                creature.Attach(monsterObserver);
            }
            _hero.Attach(observer);

            GameStart();

            while (_hero.IsDead == false && gameWon == false)
            {
                _hero.move();
                MonsterCheck(_hero, _monster);
                ChestCheck(_hero, _chests);
                gameWon = GameWon(_monster);
            }

            _hero.GameOver();
        }

        public void ReadConfiguration()
        {
            XmlDocument configDoc = new XmlDocument();
            configDoc.Load("Config.xml");

            XmlNode nameNode = configDoc.DocumentElement.SelectSingleNode("Name");
            if (nameNode != null)
            {
                string str = nameNode.InnerText.Trim();
                _hero.Name = str;
            }

            XmlNode hpNode = configDoc.DocumentElement.SelectSingleNode("HitPoints");
            if (hpNode != null)
            {
                String str = hpNode.InnerText.Trim();
                int hp = Convert.ToInt32(str);
                _hero.HitPoints = hp;
                _hero.CurrentHitPoints = hp;
            }

            XmlNode attackPowerNode = configDoc.DocumentElement.SelectSingleNode("AttackPower");
            if (attackPowerNode != null)
            {
                String str = attackPowerNode.InnerText.Trim();
                int attackPower = Convert.ToInt32(str);
                _hero.AttackPower = attackPower;
            }
        }
    }
}
