using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    class Interface
    {
        public static void ShowStatus()
        {
            Console.WriteLine();
           
            int endex = 0;
            foreach (Character e in Field.enemiesAlive)
            {
                Console.Write($"{e.Job} : hp {e.CurrentHP}/{e.MaxHP}");
                if (endex + 1 != Field.enemiesAlive.Count)
                {
                    Console.Write(" | ");
                }
                endex++;
            }
           
            Console.WriteLine();
            Console.WriteLine();
            int index = 0;
           
           
            foreach (Character a in Field.alliesAlive)
            {
                Console.Write($"{a.Job}({index + 1}) : pw {a.Power}  hp {a.CurrentHP}/{a.MaxHP}");
                if (index + 1 != Field.alliesAlive.Count)
                {
                    Console.Write(" | ");
                }
                index++;
            }
            Console.WriteLine();

            Console.Write($"[아군 상태]   스킬포인트 : {Field.skillPoint}/{Field.maxSkillPoint}");
            if (Field.isTaunt)
            {
                Console.WriteLine($"  남은 도발 턴 : {Field.remainTauntTurn}");
            }
            Console.WriteLine();
        }

        public static void ShowLoadingDot(string message, int repeat = 3, int delay = 400)
        {
            for (int i = 0; i < repeat * 4; i++)
            {
                int dotCount = i % 4;
                string dots = new string('.', dotCount);
                string padding = new string(' ', 3 - dotCount);
                Console.Write($"\r{message}{dots}{padding}");
                Thread.Sleep(delay);
            }
            Console.WriteLine(); // 줄바꿈
        }
    }
}
