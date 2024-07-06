using System.Text;

namespace Hunting_the_Manticore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int manticore = 10;
            int city = 16;
            int user1Number = ManticoreDistance();
            int user2Number;

            for (int round = 1; ; round++)
            {
                Console.WriteLine("---------------------------------------------------------------------------------");

                city--;
                int cannonDamage = CannonDamage(round);

                Console.WriteLine($"STATUS: Round: {round} City: {city}/15 Manticore: {manticore}/10");
                Console.WriteLine($"The cannon is expected to deal {cannonDamage} damage this round.");
                Console.Write("Enter desired cannon range: ");

                user2Number = Player2Number();
                bool cannonHit = CannonHit(user1Number, user2Number);

                if (cannonHit)
                {
                    manticore -= cannonDamage;
                }

                if (manticore <= 0)
                {
                    Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
                    break;
                }
                else if (city <= 1)
                {
                    Console.WriteLine("Consolas has been destroyed! You failed!");
                    break;
                }
            }

            // Tells Player 2 if the cannon shot hit or not
            bool CannonHit(int user1Number, int user2Number)
            {
                if (user2Number == user1Number)
                {
                    Console.WriteLine("That round was a DIRECT HIT!");
                    return true;
                }
                else if (user2Number < user1Number)
                {
                    Console.WriteLine("That round FELL SHORT of the target.");
                    return false;
                }
                else
                {
                    Console.WriteLine("That round OVERSHOT the target");
                    return false;
                }
            }

            // Calculates how much damage the cannon makes this round
            int CannonDamage(int round)
            {
                int fire = 3;
                int electric = 5;

                if (round % fire == 0 && round % electric == 0)
                {
                    return 10;
                }
                else if (round % electric == 0)
                {
                    return 3;
                }
                else if(round % fire == 0)
                {
                    return 3;
                }
                else
                {
                    return 1;
                }
            }

            // Gets a number between 0 and 100 from Player 1
            int ManticoreDistance()
            {
                Console.Write("Pick a number between 0 and 100: ");
                int number = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                while (number < 0 || number > 100)
                {
                    Console.Write("Pick a number between 0 and 100: ");
                    number = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                }

                return number;
            }

            // Gets a number from Player 2
            int Player2Number()
            {
                int number = Convert.ToInt32(Console.ReadLine());
                return number;
            }
        }
    }
}
