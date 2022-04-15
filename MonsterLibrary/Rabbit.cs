using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonLibrary;

namespace MonsterLibrary
{
    public class Rabbit : Monster
    {
        public bool IsFluffy { get; set; }



        public Rabbit(string name, int life, int maxLife, int hitChance, int block, int minDamage,int maxDamage, string description, bool isFluffy) : base(name, life, maxLife, hitChance, block, maxDamage, description, minDamage)
        {
            IsFluffy = isFluffy;
        }

        // CTOR that creates ar abbit object with default values

        public Rabbit()
        {
            MaxLife = 6;
            MaxDamage = 3;
            //The above 2 are set 1st becuase other properties depend on them for their biz rulkes

            Name = "Baby Rabbit";
            Life = 6;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "KIll the bunny!";
            IsFluffy = false;
        }

        //Methods

        public override string ToString()
        {
            return base.ToString() + (IsFluffy ? "Fluffienes: Fluffy" : "Fluffieness : Not Fluffy");
        }

        //Override CalcBlock give a 50% increase if is fluffy

        public override int CalcBlock()
        {
           int calculatedBlock = Block;

            if (IsFluffy == true)
            {
                calculatedBlock += calculatedBlock / 2;
            }

            return calculatedBlock;
        }

    }
}
