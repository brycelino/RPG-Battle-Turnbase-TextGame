using System;
using System.Collections.Generic; 

namespace InheritancePolymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Player p = new Player();
            Enemy e = new Enemy();
            p.opponent = e;
            e.opponent = p;
           
            
            List<Fighter> fighters = new List<Fighter>();
            fighters.Add(p);
            fighters.Add(e);

            while(p.currentHealth > p.death & e.currentHealth > e.death)
            { 
             for (int i = 0; i < fighters.Count; i++)
                {
                    fighters[i].TakingAction();
                }
            }

        }
    }

     public class Fighter
    {
        
        public string name; // string name to hold opponents name
                       
        public int currentHealth; // declare playerHealth as int to hold total amount of health for player
        public int death = 0; // declare death as int that will determine if the player or enemy is dead 
        public Fighter opponent;

        
        public void TakingDamage(int amount) // method that will handle fighters taking damage
        {
            
          currentHealth = currentHealth - amount;
           
            
            DeadFighter();
        }

        public void DeadFighter()
        {
           if (currentHealth <= death)
            {
                Console.WriteLine("Defeated!");
                return;
            }
            
            
        }
        
        public virtual void TakingAction() // a function that will handle action and can be overridden
        {
            Player p = new Player();
            Enemy e = new Enemy();
            p.opponent = e;
            e.opponent = p;
            
            
            Console.WriteLine("==== Player Turn ===");
            Console.WriteLine("Player Health:" + currentHealth);
            Console.WriteLine("Enemy Health:" + opponent.currentHealth);
            Console.WriteLine("What would you like to choose.");
            
            Console.WriteLine("Enter '1' to Attack \nEnter '2' to use Health Potion(" + p.potionStocks + " Remaing)");
                

                int playerChoice = int.Parse(Console.ReadLine());

                if (playerChoice == 1)
                {
                    opponent.TakingDamage(2);
                    Console.WriteLine("The player landed an Attack worth '2' point(s) of damage");
                }


                else
                {

                currentHealth += 5;

                    Console.WriteLine("The Player recovered '5' point(s)" + p.potionStocks);

                }
            

                if (opponent.currentHealth <= 0)
                {
                    Console.WriteLine("The Player has won Congrats!");
                }
        
        }
        
    }

    public class Enemy : Fighter
    {
        
       public Enemy() : base()
        {
            name = "opponent";
            currentHealth = 12;
            death = 0;
        }

        public override void TakingAction()
        {
            Player p = new Player();
            Enemy e = new Enemy();
            p.opponent = e;
            e.opponent = p;
            if (currentHealth > 0)
            {
                Console.WriteLine("=== Opponent turn ===");
                Console.WriteLine("Enemy Health:" + currentHealth);
                Console.WriteLine("Player Health:" + opponent.currentHealth);


                opponent.TakingDamage(3);
                Console.WriteLine("Attacking the Player for '3' points of damage");
                if (opponent.currentHealth <= 0)
                {
                    Console.WriteLine("Enemy Health:" + currentHealth);
                    Console.WriteLine("Player Health:" + opponent.currentHealth);
                    Console.WriteLine("The Enemy has won. GameOver");
                }
            }     
          }
    }

    public class Player : Fighter
    {
        public int potionStocks;
        public Player() : base()
        {
            
            name = "Player";
            currentHealth = 10;
            death = 0;
            potionStocks = 3;
            
        }
        
    }
}
