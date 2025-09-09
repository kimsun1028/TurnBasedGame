using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public static class Field
    {
        public static bool isTaunt
        {
            get { return remainTauntTurn > 0;}
        }
        public static int remainTauntTurn;
        public static int skillPoint = 2;
        public static int maxSkillPoint = 4;
        public static List<Character> allies = new List<Character>();
        public static List<Enemy> enemies = new List<Enemy>();

        public static List<Character> alliesAlive => allies.Where(c => c.IsAlive).ToList();

        public static List<Enemy> enemiesAlive => enemies.Where(c => c.IsAlive).ToList();

       

    }
}
