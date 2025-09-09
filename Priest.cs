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
            this.Job = "프리스트";
            this.SkillName = "힐/딜(1)";
        }

       

        public override void Skill()
        {
            Field.skillPoint--;   
            Console.WriteLine("스킬유형을 입력하세요 힐(1)/딜(2)");
            int n = int.Parse(Console.ReadLine());
            switch(n)
            {
                case 1:
                    Console.WriteLine("아군 대상을 입력하세요!");
                    int Index = int.Parse(Console.ReadLine()) - 1;
                    Character a = Field.alliesAlive[Index]; ;
                    a.Heal(2 * this.Power);
                    break;
                case 2:
                    Console.WriteLine("적 대상을 입력하세요!");
                    int enemyIndex = int.Parse(Console.ReadLine()) - 1;
                    Character b = Field.enemiesAlive[enemyIndex];
                    b.TakeDamage((int)(1.5 * this.Power));
                    break;
            }
        }
       



    }
}
