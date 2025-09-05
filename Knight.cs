using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public class Knight : Character
    {
        
        public Knight()
        {
            this.Power = 20;
            this.MaxHP = 150;
            this.CurrentHP = 150;
            this.SkillCost = 1;
            this.Job = "나이트";
            this.SkillName = "도발(1)";
        }

        public override void TakeDamage(int damage)
        {
            Thread.Sleep(400);
            CurrentHP -= damage;
            if (CurrentHP <= 0)
            {
                Field.remainTauntTurn = 0;
                CurrentHP = 0;
                Console.WriteLine($"{Name}이(가) {damage}의 피해를 입고 사망했습니다.");
            }
            else
                Console.WriteLine($"{Name}이(가) {damage}의 피해를 입었습니다. (HP : {CurrentHP}/{MaxHP})");
        }

        public override void Skill()
        {
                Field.remainTauntTurn = 2;
                this.MaxHP = 200;
                this.CurrentHP += 20;
                if (CurrentHP > MaxHP) CurrentHP = MaxHP;
                Field.skillPoint--;
                Console.WriteLine("적 도발 성공");
            Console.ReadLine();
        }

       public override void BasicAttack()
        {
            Console.WriteLine("대상을 입력하세요 : \n");
            int enemyIndex = int.Parse(Console.ReadLine()) - 1;
            Character a = Field.enemiesAlive[enemyIndex]; ;
            if (Field.isTaunt)
            {
                a.TakeDamage(this.Power + (this.MaxHP - this.CurrentHP) / 2);
                Console.WriteLine($"기본공격(강화)으로 {a.Name}에게 {this.Power + (this.MaxHP - this.CurrentHP) / 2}의 피해를 입혔다!");
            }
            else
            {
                a.TakeDamage(this.Power);
                Console.WriteLine($"기본공격으로 {a.Name}에게 {this.Power}의 피해를 입혔다!");
            }
            Field.skillPoint++;
            if(Field.maxSkillPoint < Field.skillPoint)
            {
                Field.skillPoint = Field.maxSkillPoint;
            }
        }

    }
}
