using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakthrough
{
    class RandomLocks
    {
        private int _NumberOfLocks;
        private Random _RandomGen;
        private List<Lock> _Locks;
        private Dictionary<int, string> _Kits = new Dictionary<int, string>
        {
            {0, "a" }, // Acute
            {1, "b" }, // Basic
            {2, "c" } // Crude
        };
        private Dictionary<int, string> _Tools = new Dictionary<int, string>
        {
            {0, "P" }, // Pick
            {1, "K" }, // Key
            {2, "F" } // File
        };

        public RandomLocks()
        {
            this._NumberOfLocks = 8;
            this._RandomGen = new Random();
            this._Locks = new List<Lock>();

            for (int i = 0; i < this._NumberOfLocks; i++)
            {
                this._Locks.Add(GenerateLock());
            }
        }

        /// <summary>
        /// Generates a list of conditions
        /// </summary>
        /// <returns>List of conditions</returns>
        public List<string> GenerateCondition()
        {
            List<string> condition = new List<string>();
            string kit;
            string tool;

            kit = this._Kits[this._RandomGen.Next(0, 3)];
            tool = this._Tools[this._RandomGen.Next(0, 3)];

            condition.Add(kit);
            condition.Add(tool);

            return condition;
        }

        public Lock GenerateLock()
        {
            // Each challenge is 1, 2, or 3 conditions
            // Each lock is 1, 2, or 3 challenges
            Lock @lock = new Lock();
            List<List<string>> challenge = new List<List<string>>();
            List<string> condition = new List<string>();
            int numberOfChallenges = this._RandomGen.Next(1, 4);
            int numberOfConditions = this._RandomGen.Next(1, 4);


            for (int i = 0; i < numberOfChallenges; i++)
            {
                for (int j = 0; j < numberOfConditions; j++)
                {
                    condition = GenerateCondition();

                    challenge.Add(condition);
                }

                @lock.AddChallenge(challenge[i]);
            }

            return @lock;
        }
    }
}
