using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
// 커밋 확인용 각주
namespace TurnBasedGame
{
    internal class Program
    {
        static bool FirstFloor()
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
                    Console.WriteLine($"(아군) {turn}번째 턴 {i+1}번째 행동 ");
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
                Console.ReadLine();
                Character ActingEnemy1 = Field.enemiesAlive[rnd.Next(Field.enemiesAlive.Count)];
                Console.WriteLine("적이 기본공격을 사용합니다.");
                ActingEnemy1.BasicAttack();
                if (Field.alliesAlive.Count == 0)
                {
                    Console.WriteLine("던전 1층 공략 실패...");
                    return false;
                }
                Console.WriteLine($"(적) {turn}번째 턴 2번째 행동 ");
                Interface.ShowStatus();
                Console.ReadLine();
                Character ActingEnemy2 = Field.enemiesAlive[rnd.Next(Field.enemiesAlive.Count)];
                Console.WriteLine("적이 스킬을 사용합니다.");
                ActingEnemy2.Skill();
                if (Field.alliesAlive.Count == 0)
                {
                    Console.WriteLine("던전 1층 공략 실패...");
                    return false;
                }
            } // 던전 1층 끝!
        }

        static void Main(string[] args)
        {
            Console.WriteLine("게임 시작!");
            Console.WriteLine("아군을 선택하세요!");
            

            int unitIndex = 1;
            foreach (string unit in Setting.Units)
            {
                Console.Write($"{unit} : {unitIndex}");
                if (unitIndex != Setting.Units.Length)
                {
                    Console.Write(" | ");
                }
                unitIndex++;
            }
            Console.WriteLine();










            Knight knight = new Knight();
            Archer archer = new Archer();
            Priest priest = new Priest();
            Console.Clear();
            while(true)
            {
                Console.WriteLine("유닛의 설명을 보시겠습니까? (y/n)");
                string showexplain = Console.ReadLine();
                Console.Clear();
                if (showexplain == "y")
                {
                    bool explaination = true;
                    Console.Clear();
                    while (explaination)
                    {
                        Console.WriteLine("탱커 : 1, 딜러 : 2, 힐러 : 3\n넘어가기 : 0");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.WriteLine("나이트\n공격력 : 20  체력 : 150" +
                                    "\n기본 공격 : 적 한명에게 공격력의 100%만큼 피해를 입히고 스킬포인트를 획득합니다." +
                                    "\n도발(1)   : 적 전체에게 도발을 걸고 최대 채력을 50 증가시킵니다\n" +
                                    "특성 : 기본 공격(강화) : 도발 상태일 때의 기본 공격으로, 잃은 체력에 비례해 피해량이 증가합니다. ");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case "2":
                                Console.WriteLine("아처\n공격력 : 40  체력 : 100" +
                                    "\n기본 공격 : 적 두명에게 공격력의 75%만큼 피해를 입힙니다." +
                                    "\n화살 난사(2)   : 적 전체에게 공격력의 40%의 피해를 10번 나누어 입힙니다\n");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case "3":
                                Console.WriteLine("힐러\n공격력 : 30  체력 : 70" +
                                    "\n기본 공격 : 적 한명에게 공격력의 100%만큼 피해를 입히고 스킬포인트를 획득합니다." +
                                    "\n힐/딜(1)  : 적에게 시전해 공격력의 150%의 피해를 입히거나, 아군에게 시전해 공격력의 200% 만큼 체력을 회복시킵니다.\n");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case "0":
                                explaination = false;
                                break;
                        }
                    }
                }
                Console.WriteLine("던전 1층에 입장하시겠습니까? (y/n)");
                string enterDungeon = Console.ReadLine();
                if (enterDungeon == "y")
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
            Console.Clear();
           // Interface.ShowLoadingDot("던전 1층에 입장합니다");
            
            Field.allies.Insert(0,knight);
            Field.allies.Insert(1, archer);
            Field.allies.Insert(2, priest);

            // Interface.ShowLoadingDot("슬라임의 점액 냄새가 코를 찌릅니다");
            Slime slime1 = new Slime("슬라임1");
            Slime slime2 = new Slime("슬라임2");
            Slime slime3 = new Slime("슬라임3");
            Field.enemies.Insert(0, slime1);
            Field.enemies.Insert(1, slime2);
            Field.enemies.Insert(2, slime3);
           // Interface.ShowLoadingDot("전투를 준비하세요");
           

            // 던전 1층 반복문
            while (true)
            {
                bool isFirstFloorClear = FirstFloor();
                Thread.Sleep(3000);
                Console.Clear();
                if (isFirstFloorClear)
                {
                    while (true)
                    {
                        Console.WriteLine("계속 진행하시겠습니까? (y/n)");
                        string s = Console.ReadLine();
                        if (s == "y")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("게임을 종료하시겠습니까? (y/n)");
                            string poweroff = Console.ReadLine();
                            if (poweroff == "y")
                            {
                                Interface.ShowLoadingDot("게임을 종료합니다",2);
                                return;
                             }
                            else
                            {
                                Console.Clear();
                            }
                         
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("다시 도전하시겠습니까? (y/n)");
                    string s = Console.ReadLine();
                    if (s == "y")
                    {
                        continue;
                    }
                }
            }
            //던전 1층 반복문 종료
            Console.Clear();
            Interface.ShowLoadingDot("던전 2층에 입장합니다");

            Field.allies.Insert(0, knight);
            Field.allies.Insert(1, archer);
            Field.allies.Insert(2, priest);

            Interface.ShowLoadingDot("엄청난 살의가 느껴집니다");
           /* Slime slime1 = new Slime("슬라임1");
            Slime slime2 = new Slime("슬라임2");
            Slime slime3 = new Slime("슬라임3");
            Field.enemies.Insert(0, slime1);
            Field.enemies.Insert(1, slime2);
            Field.enemies.Insert(2, slime3);*/ // 추후 추가
            Interface.ShowLoadingDot("잔혹한 전투를 준비하세요");
            Console.Clear();

        }
    }
}
