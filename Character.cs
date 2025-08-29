namespace TurnBasedGame
{
    public abstract class Character
    {
       
        public int Power;
        public int MaxHP;
        public int CurrentHP;
        public int SkillCost;
        public string Job;
        public string Name;
        public string SkillName;
        public bool IsAlive => CurrentHP > 0;

        public Character()
        {
        }

        public virtual void Act(List<Character> allies, List<Character> enemies)
        {
            // 자식 클래스에서 오버라이드
        }

        public virtual void BasicAttack()
        {
            Console.WriteLine("대상을 입력하세요 : ");
            int enemyIndex = int.Parse(Console.ReadLine()) - 1;
            Character a = Field.enemiesAlive[enemyIndex]; ;
            a.TakeDamage(this.Power);
            Field.skillPoint++;
            if (Field.maxSkillPoint < Field.skillPoint)
            {
                Field.skillPoint = Field.maxSkillPoint;
            }
            Console.ReadLine();
        }
        public abstract void Skill();

        public virtual void TakeDamage(int damage)
        {
            Thread.Sleep(400);
            CurrentHP -= damage;
            if (CurrentHP <= 0)
            {
                CurrentHP = 0;
                Console.WriteLine($"{Job}이(가) {damage}의 피해를 입고 사망했습니다.");
            }
            else
                Console.WriteLine($"{Job}이(가) {damage}의 피해를 입었습니다. (HP : {CurrentHP}/{MaxHP})");
        }

        public void Heal(int amount)
        {
            Thread.Sleep(1000);
            int healAmount;
            if((CurrentHP + amount) >= MaxHP)
            {
                healAmount = MaxHP - CurrentHP;
            }
            else
            {
                healAmount = amount;
            }
                CurrentHP += healAmount;
            Console.WriteLine($"{Job}이(가) {healAmount}만큼 체력을 회복했습니다! (HP : {CurrentHP}/{MaxHP})");
        }

        public bool CanUseSkill()
        {
            return Field.skillPoint >= this.SkillCost;
        }
    }
}
