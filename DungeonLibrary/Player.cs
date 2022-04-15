using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //public is an access modifier. It determines where
    //this class can be used in our application. Since
    //we want to make Player objects in our Dungeon 
    //console app project, we need this class to be public.

    //THe sealed keyword indiciates that this class cannot be used as a base class for other classes. 
    //This is the end of the inheritance chain.
    public sealed class Player : Character
    {
        //FIELDS
        //Variables to store information related to this kind of object.
        //Access is ALWAYS private
        //Naming convention: _camelCase;

        //private string _name;
        //private int _hitChance;
        //private int _block;
        //private int _life;
        //private int _maxLife;
        private Race _characterRace;
        private Weapon _equippedWeapon;

        //PROPERTIES
        //Publicly available "gatekeepers" of the information in the fields.
        //Define the "rules" for interacting with the fields & their values.
        //Access is ALWAYS public
        //Naming convention: PascalCase

        //public string Name
        //{
        //    //Getter - Defines the rules for handling when information is requested
        //    get { return _name; }
        //    //Setter - Defines the rules for handling when we attempt to assign a value
        //    set { _name = value; }
        //}

        //public int HitChance
        //{
        //    get { return _hitChance; }
        //    set { _hitChance = value; }
        //}

        //public int Block
        //{
        //    get { return _block; }
        //    set { _block = value; }
        //}

        //public int MaxLife
        //{
        //    get { return _maxLife; }
        //    set { _maxLife = value; }
        //}

        public Race CharacterRace
        {
            get { return _characterRace; }
            set { _characterRace = value; }
        }

        public Weapon EquippedWeapon
        {
            get { return _equippedWeapon; }
            set { _equippedWeapon = value; }
        }


        //Properties & Fields that require custom "business rules"
        //should come after any properties/fields that use the default.

        //public int Life
        //{
        //    get { return _life; }
        //    set
        //    {
        //        //Business rule: Life should not be more than MaxLife
        //        if (value <= MaxLife)
        //        {
        //            //Good to go - set it as normal
        //            _life = value;
        //        }
        //        else
        //        {
        //            //Tried to assign a value to Life that was greater than MaxLife.
        //            //Instead, let's default life to MaxLife (set the player to full)
        //            _life = MaxLife;
        //        }
        //    }
        //}

        //CONSTRUCTORS
        //Special methods used to create objects of this type.
        //Access is ALWAYS public
        //Naming convention: PascalCase, MUST match the name of the class

        //Fully-Qualified Constructor - All properties are accounted for with parameters
        public Player(string name, int hitChance, int block, int life, int maxLife, Race characterRace, Weapon equippedWeapon)
        {
            //ASSIGNMENT
            //Property = parameter;
            //PascalCase = camelCase;

            //Since Life depends on MaxLife, we need to set MaxLife FIRST.
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
        }

        //METHODS
        public override string ToString()
        {
            //return base.ToString();

            string description = "";

            switch (CharacterRace)
            {
                case Race.Orc:
                    description = "Orc";
                    break;
                case Race.Human:
                    description = "Human";
                    break;
                case Race.Elf:
                    description = "Elf";
                    break;
                case Race.Dwarf:
                    description = "Dwarf";
                    break;
                case Race.Gnome:
                    description = "Gnome";
                    break;
                case Race.Halfling:
                    description = "Halfling";
                    break;
                case Race.Tiefling:
                    description = "Tiefling";
                    break;
                case Race.DragonBorn:
                    description = "Dragonborn";
                    break;
            }

            return string.Format("-=-=-= {0} =-=-=-\n" +
                "Life: {1} of {2}\nHit Chance: {3}%\n" +
                "Weapon:\n{4}\nBlock: {5}\nDescription: {6}",
                Name,
                Life,
                MaxLife,
                HitChance,
                EquippedWeapon,
                Block,
                description);

        }

        //Overriding the CalcDamage() in player to use their weapon's properties of MinDamage and MaxDamage
        public override int CalcDamage()
        {
            //return base.CalcDamage();

            //create random obj
            Random rand = new Random();

            //determin damage
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);

            return damage; 
        }

        public override int CalcHitChance()
        {
            //return base.CalcHitChance();
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance; 
        }
    }
}
