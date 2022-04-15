using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //fields 
        private int _minDamage;

        //Properties
        public int MaxDamage { get; set; }
        public string Description { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //cant be more than MaxDamage and cannot be less than 1
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1; 
                }
            }
        }

        //CTORS
        public Monster()
        {

        }

        public Monster(string name, int life, int maxLife, int hitChance, int block, int maxDamage, string description, int minDamage)
        {
            //No FQCTOR in the parent so all assignments must be done here
            //Set MaxLife and MaxDamage first because other properties depend on them having a value
            MaxLife = maxLife;
            MaxDamage = maxDamage;
            Name = name;
            Life = life;
            HitChance = hitChance;
            Block = block;
            MinDamage = minDamage;
            Description = description; 
        }

        //Methods
        public override string ToString()
        {
            return string.Format("\n******* MONSTER ********\n{0}\nLife: {1} of {2}\nDamage: {3} to {4}\n" +
                "Block: {5}\nDescription:\n{6}\n", Name, Life, MaxLife, MinDamage, MaxDamage, Block, Description);
        }

        public override int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1); 
        }

    }
}
