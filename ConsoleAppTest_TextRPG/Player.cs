namespace ConsoleAppTest_TextRPG
{
    // 캐릭터클래스를 상속한 플레이어 클래스
    public class Player : Character
    {
        #region Fields
        private Dictionary<StatusType, object> currentStat;
        private Item playerItems;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Chad
        {
            get { return chad; }
            set { chad = value; }
        }
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public int AttackPoint
        {
            get { return attackPoint; }
            set { attackPoint = value; }
        }
        public int DefensePoint
        {
            get { return defensePoint; }
            set { defensePoint = value; }
        }
        public int HitPoit
        {
            get { return hitPoit; }
            set { hitPoit = value; }
        }
        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }
        public int Exp
        {
            get { return exp; }
            set { exp = value; }
        }
        #endregion

        // 플레이어의 현재 스탯의 상태를 딕셔너리에저장
        public void SetCurrentStat()
        {
            currentStat = new Dictionary<StatusType, object>();
            currentStat.Add(StatusType.Name, (string)Name);
            currentStat.Add(StatusType.Chad, (string)Chad);
            currentStat.Add(StatusType.Level, (int)Level);
            currentStat.Add(StatusType.AttackPoint, (int)AttackPoint);
            currentStat.Add(StatusType.DefensePoint, (int)DefensePoint);
            currentStat.Add(StatusType.HitPoit, (int)HitPoit);
            currentStat.Add(StatusType.Gold, (int)Gold);
            currentStat.Add(StatusType.Exp, (int)Exp);
        }

        // 캐릭터의 스테이터스 화면을 출력
        public void ViewStatus()
        {
            // 캐릭터의 스탯을 화면에 출력
            Console.Write("상태 보기\n캐릭터의 정보가 표시됩니다.\n\n");
            Console.WriteLine($"레벨. {currentStat[StatusType.Level].ToString()}");
            Console.WriteLine($"Chad ( {currentStat[StatusType.Chad].ToString()} )");
            Console.WriteLine($"공격력: {currentStat[StatusType.AttackPoint].ToString()}");
            Console.WriteLine($"방어력: {currentStat[StatusType.DefensePoint].ToString()}");
            Console.WriteLine($"체력: {currentStat[StatusType.HitPoit].ToString()}");
            Console.WriteLine($"Gold: {currentStat[StatusType.Gold].ToString()} G");
            Console.WriteLine();

            // 현재 화면에서 선택할 수 있는 메뉴를 표시
            Dictionary<int, string> menu = new Dictionary<int, string>();
            menu.Add(0, "나가기");
            foreach (KeyValuePair<int, string> pair in menu)
            {
                Console.WriteLine($"{pair.Key}. {pair.Value}");
            }
            // 입력값을 케임매니저가 체크
            int selectMenu = GameManager.CheckselectedMenu(menu);
            if (selectMenu == 0)
            {
                Map map = new Map();
                map.ViewMainMenu(GameManager.prevMenu);
            }
        }

        // 캐릭터의 인벤토리화면을 출력
        public void ViewInventory()
        {
            Console.Write("인벤토리\n보유 중인 아이템을 관리할 수 있습니다.\n\n");
            // 현재 화면에서 선택할 수 있는 메뉴를 표시
            Dictionary<int, string> menu = new Dictionary<int, string>();
            menu.Add(1, "장착관리");
            menu.Add(0, "나가기");
            foreach (KeyValuePair<int, string> pair in menu)
            {
                Console.WriteLine($"{pair.Key}. {pair.Value}");
            }
            // 입력값을 케임매니저가 체크
            int selectMenu = GameManager.CheckselectedMenu(menu);
            if (selectMenu == 1)
            {
                Console.WriteLine("장착관리로 전이");
            }
            if (selectMenu == 0)
            {
                Console.WriteLine();
                Map map = new Map();
                map.ViewMainMenu(GameManager.prevMenu);
            }
        }
    }
}
