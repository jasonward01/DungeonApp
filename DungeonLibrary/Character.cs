using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //The abstract modifier indicates that the thing being modified 
    //has an incomplete implementation. The abstract modifier 
    //can be used with classes, methods, and properties. Use the abstract 
    //modifier in a class declaration to indicate that the
    //class is intended to only be a base(parent) class of other classes.
    public abstract class Character
    {
        //fields
        private string _name;
        private int _hitChance;
        private int _block;
        private int _life;
        private int _maxLife;

        //properties
        public string Name
        {
            //Getter - Defines the rules for handling when information is requested
            get { return _name; }
            //Setter - Defines the rules for handling when we attempt to assign a value
            set { _name = value; }
        }

        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }

        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }

        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }

        public int Life
        {
            get { return _life; }
            set
            {
                //Business rule: Life should not be more than MaxLife
                if (value <= MaxLife)
                {
                    //Good to go - set it as normal
                    _life = value;
                }
                else
                {
                    //Tried to assign a value to Life that was greater than MaxLife.
                    //Instead, let's default life to MaxLife (set the player to full)
                    _life = MaxLife;
                }
            }
        }

        //ctors
        //Since you do NOT inherit ctors and we already did a lot of work defining the player FQCTOR, we will
        //not create any here. 

        //methods 
        //No need to override the ToString() here because we will never create an object of type Character.

        //Below are methods we want to be inherited by player and monster, so we are creating default vresions
        //of each here. The child classes can use these default versions or override them. 
        public virtual int CalcBlock()
        {
            //To be able to override this in a child class it must be VIRTUAL

            //Basic version: will just return the value stored in Block
            return Block; 
        }

        public virtual int CalcHitChance()
        {
            return HitChance; 
        }

        public virtual int CalcDamage()
        {
            return 0; 
        }
    }
}
