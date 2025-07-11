namespace ConsoleAppTest_TextRPG
{
    // 게임진행상황을 관리하는 게임매니저클래스
    public static class GameManager
    {
        static Player player;               // 플레이어를 관리
        public static Enum prevMenu;        // 이전메뉴를 기억
        public static void GameStart()
        {
            // 플레이어 초기세팅
            player = new Player();
            player.Name = "르탄이";
            player.Level = 1;
            player.Chad = "전사";
            player.AttackPoint = 10;
            player.DefensePoint = 5;
            player.HitPoit = 100;
            player.Gold = 1500;
            player.SetCurrentStat();

            // 맵 초기세팅
            Map map = new Map();
            prevMenu = MenuViewName.SpartaVillagePlaza;
            map.ViewMainMenu(prevMenu);
        }
        // 선택된 메뉴번호에 해당 메뉴가 있는지를 체크해서 되돌려주는 함수
        public static int CheckselectedMenu(Dictionary<int, string> menu)
        {
            int selectMenu = 0;
            Console.Write("\n원하시는 행동을 입력해 주세요.\n>> ");
            string? inputMenue = Console.ReadLine();
            while (!int.TryParse(inputMenue, out selectMenu) || !menu.ContainsKey(selectMenu))
            {
                Console.Write("잘못된 입력입니다.\n>> ");
                inputMenue = Console.ReadLine();
            }
            Console.Clear();        // 화면을 지워준다
            return selectMenu;
        }
        // 캐릭터의 스테이터스를 보여주는 함수
        public static void ViewCharacterStat()
        {
            player.ViewStatus();
        }
        // 캐릭터의 인벤토리를 보여주는 함수
        public static void ViewInventory()
        {
            player.ViewInventory();
        }
    }
}
