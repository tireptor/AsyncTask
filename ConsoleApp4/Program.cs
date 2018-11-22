using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Mode asynchrone
namespace ConsoleApp4
{
    class Program
    {
        public static bool estPremier(int nb)
        {
            if (nb < 2)
            {
                return false;
            }
            if (nb == 2)
            {
                return true;
            }
            if (nb % 2 == 0)
            {
                return false;
            }
            int i;
            i = 3;
            while ((i * i <= nb))
            {
                if (nb % i == 0)
                {
                    return false;

                }
                else
                {
                    i = i + 1;
                }
            }
            return true;
        }
        static async Task traitement (int maxi)
        {
            int resultat;
            resultat = await comptePremier(maxi);
            Console.WriteLine(resultat);
            Console.WriteLine("*********");
        }
        public static async Task<int> comptePremier(int maxi)
        {
            int resultat;
            resultat = await Task.Run<int>(() =>
             {
                 int i;
                 int nb;
                 nb = 0;
                 for (i = 0; i <= maxi; i++)
                 {
                     if (estPremier(i))
                     {
                         nb = nb + 1;
                     }
                 }
                 return nb;
             });
            return resultat;
        }
        static void Main(string[] args)
        {
            Console.Write("Saisir la valeur maximale pour le calcul :");
            string maxi = Console.ReadLine();
            int mx = int.Parse(maxi);
            traitement(mx);
            Console.WriteLine("appuyer sur une touche quelquonque pour arrêter l'application");
            Console.ReadKey();
        }
    }
}
