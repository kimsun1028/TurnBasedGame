using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
namespace TurnBasedGame
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            Console.WriteLine("���� ����!");

            // �Ʊ� ĳ���� ���� 
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
                        Console.WriteLine("����Ʈ : 1, ��ó : 2, ������Ʈ : 3\n�Ѿ�� : 0");
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
                                Console.WriteLine("������Ʈ\n���ݷ� : 30  ü�� : 70" +
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
            }

            // �Ʊ� ĳ���� ���� ����
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
                Console.WriteLine("\nù��° ĳ���͸� �����ϼ���!");
                int firstjob = int.Parse(Console.ReadLine());
                switch (firstjob)
                {
                    case 1: Console.WriteLine("����Ʈ�� ��Ƽ�� �����մϴ�."); knight = new Knight(); Field.allies.Insert(0, knight); break;
                    case 2: Console.WriteLine("��ó�� ��Ƽ�� �����մϴ�.");  archer = new Archer(); Field.allies.Insert(0, archer); break;
                    case 3: Console.WriteLine("������Ʈ�� ��Ƽ�� �����մϴ�.");  priest = new Priest(); Field.allies.Insert(0, priest); break;
                }
                Console.WriteLine("2��° ĳ���͸� �����ϼ���!");
                int secondjob;
                while (true)
                {
                    secondjob = int.Parse(Console.ReadLine());
                    if (secondjob == firstjob)
                    {
                        Console.WriteLine("�̹� ��Ƽ�� �����߽��ϴ�!");
                    }
                    else
                    {
                        break;
                    }
                }
                switch (secondjob)
                {
                    case 1: Console.WriteLine("����Ʈ�� ��Ƽ�� �����մϴ�."); knight = new Knight(); Field.allies.Insert(1, knight); break;
                    case 2: Console.WriteLine("��ó�� ��Ƽ�� �����մϴ�."); archer = new Archer(); Field.allies.Insert(1, archer); break;
                    case 3: Console.WriteLine("������Ʈ�� ��Ƽ�� �����մϴ�.");  priest = new Priest(); Field.allies.Insert(1, priest); break;
                }
                Console.WriteLine("3��° ĳ���͸� �����ϼ���!");
                int thirdjob;
                while (true)
                {
                    thirdjob = int.Parse(Console.ReadLine());
                    if (thirdjob == firstjob || thirdjob == secondjob)
                    {
                        Console.WriteLine("�̹� ��Ƽ�� �����߽��ϴ�!");
                    }
                    else
                    {
                        break;
                    }
                }
                switch (thirdjob)
                {
                    case 1: Console.WriteLine("����Ʈ�� ��Ƽ�� �����մϴ�."); knight = new Knight(); Field.allies.Insert(2, knight); break;
                    case 2: Console.WriteLine("��ó�� ��Ƽ�� �����մϴ�.");  archer = new Archer(); Field.allies.Insert(2, archer); break;
                    case 3: Console.WriteLine("������Ʈ�� ��Ƽ�� �����մϴ�."); priest = new Priest(); Field.allies.Insert(2, priest); break;
                }
                Console.WriteLine("���͸� ���� ���");
                
                Console.ReadLine();
                Console.Clear();
            }

            while (true)
            {
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
                bool isFirstFloorClear = Dungeon.FirstFloor();
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
