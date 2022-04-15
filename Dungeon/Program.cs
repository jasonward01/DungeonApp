using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using MonsterLibrary;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "DUNGEON OF DOOM!";

            Console.WriteLine("your journey begins....\n");

            //1. Create a Player & a Weapon
            Weapon sword = new Weapon(1, 8, "Longsword", 10, false);

            Player player = new Player("Leeroy Jenkins", 70, 5, 40, 40, Race.Human, sword);

            int score = 0;


            //2. Create a loop for the game

            bool exit = false;

            do
            {
                //3. Create a Room - making a method to generate a room description
                Console.WriteLine("You have now entered a room....\n");
                Console.WriteLine(GetRoom());

                // 4. Create a Monster
                Rabbit r1 = new Rabbit(); // This is the one that uses default values
                Rabbit r2 = new Rabbit("White Rabbit", 25, 25, 50, 20, 2, 8, "Thats no regular rabbit look at the bones!", true);

                //Since all of our monsters are the same type, we will create and array with a few instances of each rabbit abouve.

                Monster[] monsters = { r1, r1, r2, r1, r2 };

                Random rand = new Random();
                int randomNbr = rand.Next(monsters.Length);

                Monster monster = monsters[randomNbr];

                Console.WriteLine("\nIn this room : " + monster.Name);

                //5. Create a Loop for the Menu
                bool reload = false;
                do
                {
                    //6. Provide the user with a menu of options
                    Console.WriteLine("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");

                    //7. Catch the user's choice 
                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    Console.Clear();

                    //8. Build out a switch to handle the user's choice
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            // 9. Handle the combat logic & what happens if the player wins
                            Combat.DoBattle(player, monster);

                            if (monster.Life <= 0 )
                            {
                                //DEAD
                                //COULD GET STASH
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n You Killed {0}! \n", monster.Name);
                                Console.ResetColor();

                                //get new room and monster
                                reload = true; //break out of interior look
                                score++;
                            }
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("Run Away!!!");
                            // 10. Handle the user running away and the monster getting a free attack
                            Console.WriteLine($"{monster.Name} attacks as you flee");
                            Combat.DoAttack(monster, player);
                            Console.WriteLine();
                            reload = true;
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Player Info");
                            //11. Print out Player Info
                            Console.WriteLine(player);
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("Monster Info");
                            // 12. Print out Monster Info

                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.X:
                        case ConsoleKey.E:
                            Console.WriteLine("Nobody likes a quitter...boo!");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Thou hast chosen an improper option. Triest thou again.");
                            break; 
                    }

                    //13. Check the player's life
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Dude you died");
                        exit = true;
                    }


                } while (!exit && !reload); //while exit is false and reload is false, keep running

            } while (!exit);//while exit is false, keep running

            // 14. State the players score (how many monsters were killed)
            Console.WriteLine("YOU DEFEATED {0} MONSTER {1}", score, ((score == 1) ? "." : "s."));
        }


        private static string GetRoom()
        {
            string[] rooms =
{
                "The room is dark and musty with the smell of lost souls.",
                "You enter a pretty pink powder room and instantly get glitter on you.",
                "You arrive in a room filled with chairs and a ticket stub machine...DMV",
                "You enter a quiet library... silence... nothing but silence....",
                "As you enter the room, you realize you are standing on a platform surrounded by sharks",
                "Oh my.... what is that smell? You appear to be standing in a compost pile",
                "You enter a dark room and all you can hear is hair band music blaring.... This is going to be bad!",
                "Oh no.... the worst of them all... Oprah's bedroom....",
                "The room looks just like the room you are sitting in right now... or does it?",
            };

            Random rand = new Random();
            int indexNbr = rand.Next(rooms.Length);
            string room = rooms[indexNbr];
            return room; 
        }
    }
}
