using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public class Slime : Enemy
    {
        public Slime(string Job) : base(Job, 100, 30) 
        {
        this.Job = "슬라임";
        }

        public override void BasicAttack()
        {
            Character target = SelectTarget();
            if (target != null)
            {
                Console.WriteLine($"{Job}이(가) 기본 공격으로 {target.Job}에게 {Power}만큼 피해를 입힙니다!");
                target.TakeDamage(Power);
            }
        }

        public override void Skill()
        {

            if (Field.alliesAlive.Count < 2)
            {
                Character only = SelectTarget();
                if (only != null)
                {
                    Console.WriteLine($"{Job}이(가) 슬라임 난사를 사용했지만 대상이 1명뿐입니다!");
                    only.TakeDamage(Power);
                }
                return;
            }
            else if (Field.isTaunt)
            {
                Character tank = SelectTarget();
                Console.WriteLine($"{Job}이(가) 슬라임 난사를 사용했지만 아군이 도발중입니다!");
                tank.TakeDamage(Power);
                if(!Field.alliesAlive.Contains(tank))
                SelectTarget().TakeDamage(Power);
                else
                    tank.TakeDamage(Power);
            }
            else
            {

                Character target1 = SelectTarget();
                Character target2;
                do
                {
                    target2 = SelectTarget();
                }
                while (target1 == target2);
                Console.WriteLine($"{Job}이(가) 스킬 : 슬라임 난사로 {target1.Job}와(과) {target2.Job}에게 각각{Power}만큼 피해를 입힙니다!");
                target1.TakeDamage(Power);
                target2.TakeDamage(Power);
            }
        }


    }
}
