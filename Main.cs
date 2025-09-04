using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
// Ŀ�� Ȯ�ο� ����
namespace TurnBasedGame
{
    internal class Program
    {
        static bool FirstFloor()
        {
            Random rnd = new Random();
            int turn = 0;

            while (true) //���� 1�� ����!
            {
                
                turn++;
                if (Field.isTaunt)
                {
                    Field.remainTauntTurn--;
                }
                // �Ʊ� �� �ι� ����
                for (int i = 0; i < 2; i++)
                {
                    Console.Clear();
                    Console.WriteLine($"(�Ʊ�) {turn}��° �� {i+1}��° �ൿ ");
                    Interface.ShowStatus();
                    RESELECT_CHARACTER:
                    Console.WriteLine("�ൿ ����");
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

                    // �ൿ�� �⹰ ���� �Ϸ�
                    Character selected = Field.alliesAlive[CharacterIndex];
                    bool allyTurnOver = false;
                    while (!allyTurnOver)
                    {
                        Console.WriteLine($"�⺻ ���� : 1  |  {selected.SkillName} : 2");
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
                                    Console.WriteLine("��ų����Ʈ�� �����մϴ�!");
                                    goto RESELECT_CHARACTER;
                                }
                                break;
                            default:
                                Console.WriteLine("�ùٸ� ���ڸ� �Է����ּ���");
                                break;
                        }
                    }

                    // ���� ���� ���� ���ٸ� (Ŭ���� �ߴٸ�)
                    if (Field.enemiesAlive.Count == 0)
                    {
                        Console.WriteLine("���� 1�� Ŭ����!");
                        return true;
                    }
                }
                //�Ʊ� �� ����

                // ���� �� ����
                Console.Clear();
                Console.WriteLine($"(��) {turn}��° ��  1��° �ൿ ");
                Interface.ShowStatus();
                Console.ReadLine();
                Character ActingEnemy1 = Field.enemiesAlive[rnd.Next(Field.enemiesAlive.Count)];
                Console.WriteLine("���� �⺻������ ����մϴ�.");
                ActingEnemy1.BasicAttack();
                if (Field.alliesAlive.Count == 0)
                {
                    Console.WriteLine("���� 1�� ���� ����...");
                    return false;
                }
                Console.WriteLine($"(��) {turn}��° �� 2��° �ൿ ");
                Interface.ShowStatus();
                Console.ReadLine();
                Character ActingEnemy2 = Field.enemiesAlive[rnd.Next(Field.enemiesAlive.Count)];
                Console.WriteLine("���� ��ų�� ����մϴ�.");
                ActingEnemy2.Skill();
                if (Field.alliesAlive.Count == 0)
                {
                    Console.WriteLine("���� 1�� ���� ����...");
                    return false;
                }
            } // ���� 1�� ��!
        }

        static void Main(string[] args)
        {
            Console.WriteLine("���� ����!");
            Console.WriteLine("�Ʊ��� �����ϼ���!");
            

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
                Console.WriteLine("������ ������ ���ðڽ��ϱ�? (y/n)");
                string showexplain = Console.ReadLine();
                Console.Clear();
                if (showexplain == "y")
                {
                    bool explaination = true;
                    Console.Clear();
                    while (explaination)
                    {
                        Console.WriteLine("��Ŀ : 1, ���� : 2, ���� : 3\n�Ѿ�� : 0");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.WriteLine("����Ʈ\n���ݷ� : 20  ü�� : 150" +
                                    "\n�⺻ ���� : �� �Ѹ��� ���ݷ��� 100%��ŭ ���ظ� ������ ��ų����Ʈ�� ȹ���մϴ�." +
                                    "\n����(1)   : �� ��ü���� ������ �ɰ� �ִ� ä���� 50 ������ŵ�ϴ�\n" +
                                    "Ư�� : �⺻ ����(��ȭ) : ���� ������ ���� �⺻ ��������, ���� ü�¿� ����� ���ط��� �����մϴ�. ");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case "2":
                                Console.WriteLine("��ó\n���ݷ� : 40  ü�� : 100" +
                                    "\n�⺻ ���� : �� �θ��� ���ݷ��� 75%��ŭ ���ظ� �����ϴ�." +
                                    "\nȭ�� ����(2)   : �� ��ü���� ���ݷ��� 40%�� ���ظ� 10�� ������ �����ϴ�\n");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case "3":
                                Console.WriteLine("����\n���ݷ� : 30  ü�� : 70" +
                                    "\n�⺻ ���� : �� �Ѹ��� ���ݷ��� 100%��ŭ ���ظ� ������ ��ų����Ʈ�� ȹ���մϴ�." +
                                    "\n��/��(1)  : ������ ������ ���ݷ��� 150%�� ���ظ� �����ų�, �Ʊ����� ������ ���ݷ��� 200% ��ŭ ü���� ȸ����ŵ�ϴ�.\n");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case "0":
                                explaination = false;
                                break;
                        }
                    }
                }
                Console.WriteLine("���� 1���� �����Ͻðڽ��ϱ�? (y/n)");
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
           // Interface.ShowLoadingDot("���� 1���� �����մϴ�");
            
            Field.allies.Insert(0,knight);
            Field.allies.Insert(1, archer);
            Field.allies.Insert(2, priest);

            // Interface.ShowLoadingDot("�������� ���� ������ �ڸ� ��ϴ�");
            Slime slime1 = new Slime("������1");
            Slime slime2 = new Slime("������2");
            Slime slime3 = new Slime("������3");
            Field.enemies.Insert(0, slime1);
            Field.enemies.Insert(1, slime2);
            Field.enemies.Insert(2, slime3);
           // Interface.ShowLoadingDot("������ �غ��ϼ���");
           

            // ���� 1�� �ݺ���
            while (true)
            {
                bool isFirstFloorClear = FirstFloor();
                Thread.Sleep(3000);
                Console.Clear();
                if (isFirstFloorClear)
                {
                    while (true)
                    {
                        Console.WriteLine("��� �����Ͻðڽ��ϱ�? (y/n)");
                        string s = Console.ReadLine();
                        if (s == "y")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("������ �����Ͻðڽ��ϱ�? (y/n)");
                            string poweroff = Console.ReadLine();
                            if (poweroff == "y")
                            {
                                Interface.ShowLoadingDot("������ �����մϴ�",2);
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
                    Console.WriteLine("�ٽ� �����Ͻðڽ��ϱ�? (y/n)");
                    string s = Console.ReadLine();
                    if (s == "y")
                    {
                        continue;
                    }
                }
            }
            //���� 1�� �ݺ��� ����
            Console.Clear();
            Interface.ShowLoadingDot("���� 2���� �����մϴ�");

            Field.allies.Insert(0, knight);
            Field.allies.Insert(1, archer);
            Field.allies.Insert(2, priest);

            Interface.ShowLoadingDot("��û�� ���ǰ� �������ϴ�");
           /* Slime slime1 = new Slime("������1");
            Slime slime2 = new Slime("������2");
            Slime slime3 = new Slime("������3");
            Field.enemies.Insert(0, slime1);
            Field.enemies.Insert(1, slime2);
            Field.enemies.Insert(2, slime3);*/ // ���� �߰�
            Interface.ShowLoadingDot("��Ȥ�� ������ �غ��ϼ���");
            Console.Clear();

        }
    }
}
