using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public abstract class Enemy : Character
    {
        public Enemy(string name, int hp, int power)
        {
            this.MaxHP = hp;
            this.CurrentHP = hp;
            this.Power = power;
        }

       
        // 도발 여부 고려한 타겟 선정 메서드
        public Character SelectTarget()
        {
            List<Character> aliveTargets;

            if(Field.isTaunt)
            {
                aliveTargets = Field.alliesAlive.Where(c => c is Knight).ToList();
            }
            else
            {
                aliveTargets = Field.alliesAlive;
            }

            if (aliveTargets.Count == 0) return null;

            

            Random rnd = new Random();
            return aliveTargets[rnd.Next(aliveTargets.Count)];
        }
    }
}
