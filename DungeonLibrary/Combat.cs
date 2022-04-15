using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //This is not a data type class so no props fields ctors or methods
        //Just methods related to combat

        public static void DoAttack(Character attacker, Character defender)
        {
            //Get random num form 1-100 this is going to be like a dice roll
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(30);
            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                int damageDealt = attacker.CalcDamage();

                //assign the damage
                defender.Life -= damageDealt;

                //Write out result to scree
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} hit {1} for {2} damage!", attacker.Name, defender.Name, damageDealt);
                Console.ResetColor();

            }
            else
            {
                Console.WriteLine("{0} missed !", attacker.Name);
            }

        }

        public static void DoBattle (Player player, Monster monster)

            //possible customization : check monter property player race or any peice of info to give opp an atvantage
        {
            DoAttack(player, monster);
            //Monster only attacks 2nd if alive
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }
        }
    }
}
