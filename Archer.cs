using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public class Archer : Character
    {

        
        public Archer()
        {
            this.Power = 40;
            this.MaxHP = 100;
            this.CurrentHP = 100;
            this.SkillCost = 2;
            this.Job = "아처";
            this.SkillName = "난사(2)";
        }

        public override void BasicAttack() // 총 딜 : 3/2 Power 
        {
            int damage = (int)(this.Power * 0.75);
            if (Field.enemiesAlive.Count == 1)
            {
                Console.WriteLine("남은 적이 한명입니다!");
                Character only = Field.enemiesAlive[0];
                only.TakeDamage(damage);
                only.TakeDamage(damage);
                return;
            }
            else
            {
                Console.WriteLine("대상 두명을 차례로 입력하세요 : ");
                int enemyIndex;
                while (true)
                {
                    enemyIndex = int.Parse(Console.ReadLine()) - 1;
                    if (enemyIndex >= Field.enemiesAlive.Count)
                    {
                        Console.WriteLine("번호에 해당하는 적이 없습니다! 다시 입력하세요 : ");
                    }
                    else
                    {
                        break;
                    }
                }
                int enemyIndex2;
                while (true)
                {
                    enemyIndex2 = int.Parse(Console.ReadLine()) - 1;
                    if (enemyIndex2 >= Field.enemiesAlive.Count)
                    {
                        Console.WriteLine("번호에 해당하는 적이 없습니다! 다시 입력하세요 : ");
                    }
                    else
                    {
                        break;
                    }
                }

                Character a = Field.enemiesAlive[enemyIndex];
                Character b = Field.enemiesAlive[enemyIndex2]; ;

                a.TakeDamage(damage);
                b.TakeDamage(damage);
            }
        }

        public override void Skill()
        {
            Field.skillPoint -= 2;
            Console.WriteLine($"아처가 바운스 공격을 시전합니다!");

            int totalHits = 10;
            int damagePerHit = (int)(this.Power* 0.4);
            Random rnd = new Random();

            for (int i = 0; i < totalHits; i++)
            {
                if (Field.enemiesAlive.Count == 0)
                {
                    Console.WriteLine("모든 적이 쓰러졌습니다! 바운스 공격 종료.");
                    break;
                }

                Character target = Field.enemiesAlive[rnd.Next(Field.enemiesAlive.Count)];
                Console.WriteLine($"→ {target.Job}이(가) 바운스 타격을 맞습니다! ({damagePerHit} 피해)");
                target.TakeDamage(damagePerHit);
                Thread.Sleep(400);
            }
        }
     



    }
}
