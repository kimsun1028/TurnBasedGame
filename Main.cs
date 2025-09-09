using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
namespace TurnBasedGame
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            Console.WriteLine("게임 시작!");

            // 아군 캐릭터 설명 
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
                        Console.WriteLine("나이트 : 1, 아처 : 2, 프리스트 : 3\n넘어가기 : 0");
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
                                Console.WriteLine("프리스트\n공격력 : 30  체력 : 70" +
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
            }

            // 아군 캐릭터 선택 시작
            Knight knight = null;
            Archer archer = null;
            Priest priest = null;
            {
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
                Console.WriteLine("\n첫번째 캐릭터를 선택하세요!");
                int firstjob = int.Parse(Console.ReadLine());
                switch (firstjob)
                {
                    case 1: Console.WriteLine("나이트가 파티에 참가합니다."); knight = new Knight(); Field.allies.Insert(0, knight); break;
                    case 2: Console.WriteLine("아처가 파티에 참가합니다.");  archer = new Archer(); Field.allies.Insert(0, archer); break;
                    case 3: Console.WriteLine("프리스트가 파티에 참가합니다.");  priest = new Priest(); Field.allies.Insert(0, priest); break;
                }
                Console.WriteLine("2번째 캐릭터를 선택하세요!");
                int secondjob;
                while (true)
                {
                    secondjob = int.Parse(Console.ReadLine());
                    if (secondjob == firstjob)
                    {
                        Console.WriteLine("이미 파티에 참가했습니다!");
                    }
                    else
                    {
                        break;
                    }
                }
                switch (secondjob)
                {
                    case 1: Console.WriteLine("나이트가 파티에 참가합니다."); knight = new Knight(); Field.allies.Insert(1, knight); break;
                    case 2: Console.WriteLine("아처가 파티에 참가합니다."); archer = new Archer(); Field.allies.Insert(1, archer); break;
                    case 3: Console.WriteLine("프리스트가 파티에 참가합니다.");  priest = new Priest(); Field.allies.Insert(1, priest); break;
                }
                Console.WriteLine("3번째 캐릭터를 선택하세요!");
                int thirdjob;
                while (true)
                {
                    thirdjob = int.Parse(Console.ReadLine());
                    if (thirdjob == firstjob || thirdjob == secondjob)
                    {
                        Console.WriteLine("이미 파티에 참가했습니다!");
                    }
                    else
                    {
                        break;
                    }
                }
                switch (thirdjob)
                {
                    case 1: Console.WriteLine("나이트가 파티에 참가합니다."); knight = new Knight(); Field.allies.Insert(2, knight); break;
                    case 2: Console.WriteLine("아처가 파티에 참가합니다.");  archer = new Archer(); Field.allies.Insert(2, archer); break;
                    case 3: Console.WriteLine("프리스트가 파티에 참가합니다."); priest = new Priest(); Field.allies.Insert(2, priest); break;
                }
                Console.WriteLine("엔터를 눌러 계속");
                
                Console.ReadLine();
                Console.Clear();
            }

            while (true)
            {
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
                bool isFirstFloorClear = Dungeon.FirstFloor();
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
