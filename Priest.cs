using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public class Priest : Character
    {
       
        public Priest()
        {
            this.Power = 30;
            this.MaxHP = 70;
            this.CurrentHP = 70;
            this.SkillCost = 1;
            this.Job = "ÇÁ¸®½ºÆ®";
            this.SkillName = "Èú/µô(1)";
        }

       

        public override void Skill()
        {
            Field.skillPoint--;   
            Console.WriteLine("½ºÅ³ À¯ÇüÀ» ¼±ÅÃÇÏ¼¼¿ä : Èú(1) / µô(2)");
            int n = int.Parse(Console.ReadLine());
            switch(n)
            {
                case 1:
                    int Index = int.Parse(Console.ReadLine()) - 1;
                    Character a = Field.alliesAlive[Index]; ;
                    a.Heal(2 * this.Power);
                    break;
                case 2:
                    int enemyIndex = int.Parse(Console.ReadLine()) - 1;
                    Character b = Field.enemiesAlive[enemyIndex];
                    b.TakeDamage((int)(1.5 * this.Power));
                    break;
            }
            Console.ReadLine();
        }
       



    }
}
