using System;

namespace TextBasedGame 
{
    class Global
    {
        public static int hp;
        public static int xp;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string enemyName;
            string place;
            string race;
            string name;
            string attackName;
            int lvl;

            Console.Title = "Create your own text based rpg!";
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            //world/character creation
            Console.WriteLine("Welcome to create your own text based rpg! \n (press button to start)");
            Console.ReadKey();
            Console.WriteLine("Where do you want your story to take place?");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            place = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Who/what do you want to fight there?");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            enemyName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("What are you?");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            race = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("What is your name?");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("What will you use to attack?");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            attackName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Global.hp = 20;
            lvl = 2;
            Console.WriteLine("Prepare yourself lvl."+lvl+ " " + race + " " + name + "\n (press a button to begin!)");
            Console.ReadKey();

            //Gameplay
            while(Global.hp>0)
            {
                Combat(enemyName, lvl, place, attackName);
                while(Global.xp >= 4 * lvl)
                {
                    Global.xp = Global.xp - 4 *lvl;
                    lvl= lvl + 1;
                    Global.hp = 20 + 1*lvl;
                }
               
                Status(Global.hp, lvl, race);
            }
            
            //The end
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You Died");
            Console.ReadKey();
        }

        static void Combat(string enemyName, int lvl, string place, string attackName)
        {
            //Creating enemy
            Random numberGen = new Random();
            int enemyLevel = numberGen.Next(lvl-1,lvl+1);
            int enemyHealth = enemyLevel * 5;
            int startEnemyhealth = enemyLevel * 5;

            //Combating!
            Console.WriteLine("---------------------------------------------------- \n A lvl "+enemyLevel+ " " + enemyName + " appeared in "+ place +"! Prepare for battle!");
            while (enemyHealth > 0 && Global.hp > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("lvl " + enemyLevel + " " + enemyName + " Health: " + enemyHealth + "/" + startEnemyhealth);
                Console.WriteLine("[¬º-°]¬");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("press to attack");
                Console.ReadKey();
                enemyHealth = attack(enemyHealth, lvl, attackName);
                enemyAttack(enemyName, enemyLevel);

            }
            if (enemyHealth <= 0)
            {
                Global.xp = Global.xp + enemyLevel * 4;
                int xpGained = enemyLevel * 4;
                Console.WriteLine("You gained "+ xpGained + "xp!");
            }
        }
        static int attack(int enemyHealth, int lvl, string attackName)
        {
            int criticalHit = 20;
            int weakHit = 1;
            int rollResult;

            rollResult = roll();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("You rolled: " + rollResult);
                
                if (rollResult==criticalHit){
                    Console.WriteLine("You found an opening!");
                    enemyHealth = enemyHealth - lvl*2;
                }else if (rollResult==weakHit){
                    Console.WriteLine("You missed them...");
                }else{
                    Console.WriteLine("You attack using " + attackName +"!");
                    enemyHealth = enemyHealth - lvl;
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                return enemyHealth;
        }
        static void enemyAttack(string enemyName, int enemyLevel)
        {
            int criticalHit = 20;
            int weakHit = 1;
            int rollResult;

            Console.WriteLine(enemyName + " attacks!");
            rollResult = roll();
            Console.ForegroundColor = ConsoleColor.Red;
            
            if (rollResult==criticalHit){
                Console.WriteLine("they found an opening!");
                Global.hp = Global.hp - enemyLevel*2;
            }else if (rollResult==weakHit){
                Console.WriteLine("they missed you...");
            }else{
                Console.WriteLine("they attack!");
                Global.hp = Global.hp - enemyLevel;
            }
            
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        static int roll()
        {
            Random numberGen = new Random();
            int roll = numberGen.Next(1,20);
            return roll;
        }
        static void Status(int hp,int lvl, string race)
        {
            Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your current stats: ");
            Console.WriteLine(race +" lvl. " + lvl );
            Console.WriteLine("health- " + hp );
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------------");
        }
    }    
}