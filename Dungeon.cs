using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    public class Dungeon
    {
        public static bool FirstFloor()
        {
            Random rnd = new Random();
            int turn = 0;

            while (true) //던전 1층 시작!
            {

                turn++;
                if (Field.isTaunt)
                {
                    Field.remainTauntTurn--;
                }
                // 아군 턴 두번 시작
                for (int i = 0; i < 2; i++)
                {
                    Console.Clear();
                    Console.WriteLine($"(아군) {turn}번째 턴 {i + 1}번째 행동 ");
                    Interface.ShowStatus();

                     RESELECT_CHARACTER:

                    Console.WriteLine("행동 선택");
                    int index = 1;
                    /* foreach (Character a in Field.alliesAlive)
                     {
                         Console.Write($"{a.Name}({a.Job}) : {index}");
                         if (index != Field.alliesAlive.Count)
                         {
                             Console.Write(" | ");
                         }
                         index++;
                     }*/
                    int CharacterIndex = int.Parse(Console.ReadLine()) - 1;

                    // 행동할 기물 선택 완료
                    Character selected = Field.alliesAlive[CharacterIndex];
                    bool allyTurnOver = false;
                    while (!allyTurnOver)
                    {
                        Console.WriteLine($"기본 공격 : 1  |  {selected.SkillName} : 2");
                        int action = int.Parse(Console.ReadLine());
                        switch (action)
                        {
                            case 1:
                                selected.BasicAttack();
                                allyTurnOver = true;
                                break;
                            case 2:
                                if (selected.CanUseSkill())
                                {
                                    selected.Skill();
                                    allyTurnOver = true;
                                }
                                else
                                {
                                    Console.WriteLine("스킬포인트가 부족합니다!");
                                    goto RESELECT_CHARACTER;
                                }
                                break;
                            default:
                                Console.WriteLine("올바른 숫자를 입력해주세요");
                                break;
                        }
                       

                    }
                    Console.ReadLine();

                    // 만약 남은 적이 없다면 (클리어 했다면)
                    if (Field.enemiesAlive.Count == 0)
                    {
                        Console.WriteLine("던전 1층 클리어!");
                        return true;
                    }
                }
                //아군 턴 종료

                // 적군 턴 시작
                Console.Clear();
                Console.WriteLine($"(적) {turn}번째 턴  1번째 행동 ");
                Interface.ShowStatus();
                Enemy ActingEnemy1 = Field.enemiesAlive[rnd.Next(Field.enemiesAlive.Count)];
                Console.WriteLine("적이 기본공격을 사용합니다 :");
                Console.ReadLine();
                ActingEnemy1.BasicAttack();
                Console.ReadLine();
                if (Field.alliesAlive.Count == 0)
                {
                    Console.WriteLine("던전 1층 공략 실패...");
                    return false;
                }
                Console.Clear();
                Console.WriteLine($"(적) {turn}번째 턴 2번째 행동 ");
                Interface.ShowStatus();
                Character ActingEnemy2 = Field.enemiesAlive[rnd.Next(Field.enemiesAlive.Count)];
                Console.WriteLine("적이 스킬을 사용합니다.");
                Console.ReadLine();
                ActingEnemy2.Skill();
                Console.ReadLine();
                if (Field.alliesAlive.Count == 0)
                {
                    Console.WriteLine("던전 1층 공략 실패...");
                    return false;
                }
               
            } // 던전 1층 끝!
        }

    }
}
