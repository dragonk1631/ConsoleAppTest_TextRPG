namespace ConsoleAppTest_TextRPG
{
    // 맵을 관리하는 클래스
    public class Map
    {
        public void ViewMainMenu(Enum currentMenu)
        {
            GameManager.prevMenu = currentMenu;
            // 선택 가능한 메뉴를 딕셔너리에 저장
            Dictionary<int, string> menu = new Dictionary<int, string>();
            switch (currentMenu)
            {
                case MenuViewName.SpartaVillagePlaza:
                    {
                        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n" +
                        "이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
                        menu.Add(1, "상태 보기");
                        menu.Add(2, "인벤토리");
                        menu.Add(3, "상점");
                        // 딕셔너리에 저장되어있는 메뉴를 화면에 출력
                        foreach (KeyValuePair<int, string> pair in menu)
                        {
                            Console.WriteLine($"{pair.Key}. {pair.Value}");
                        }
                        // 선택한 메뉴를 게임매니저에게 넘겨서 입력값 체크
                        int selectMenu = GameManager.CheckselectedMenu(menu);
                        if (selectMenu == 1)
                        {
                            GameManager.ViewCharacterStat();
                        }
                        if (selectMenu == 2)
                        {
                            GameManager.ViewInventory();
                        }
                        if (selectMenu == 3)
                        {
                            this.ViewMainMenu(MenuViewName.SpartaVillageShop);
                        }
                        break;
                    }

                case MenuViewName.SpartaVillageShop:
                    {
                        Console.WriteLine("상점\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
                        // 상점에 진열된 아이템을 세팅
                        
                        // 아이템 정보를 저장한 csv 파일을 통해서 아이템을 받아옴
                        var products = ItemLoader.LoadItems("ItemList.csv");
                        
                        // 아이템들을 화면상에 출력
                        Console.WriteLine("[아이템 목록]");
                        string effectDesc = "";      // 효과설명 문자열
                        int effectValue = 0;
                        foreach (var item in products)
                        {
                            if (item.Type == (int)ItemType.Weapone)
                            {
                                effectDesc = "공격력+";
                                effectValue = item.AttackPlus;
                            }
                            else if (item.Type == (int)ItemType.Armor)
                            {
                                effectDesc = "방어력+";
                                effectValue = item.DefensePlus;
                            }
                            Console.Write($"- {item.Name,-20}\t| {effectDesc} {effectValue}" +
                                    $"\t| {item.Price,5}G | {item.Description}");
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        menu.Add(1, "아이템 구매");
                        menu.Add(0, "나가기");
                        // 딕셔너리에 저장되어있는 메뉴를 화면에 출력
                        foreach (KeyValuePair<int, string> pair in menu)
                        {
                            Console.WriteLine($"{pair.Key}. {pair.Value}");
                        }
                        // 선택한 메뉴를 게임매니저에게 넘겨서 입력값 체크
                        int selectMenu = GameManager.CheckselectedMenu(menu);
                        if (selectMenu == 1)
                        {
                            Console.WriteLine("상점구입화면");
                        }
                        if (selectMenu == 0)
                        {
                            this.ViewMainMenu(MenuViewName.SpartaVillagePlaza);
                        }
                        break;
                    }
                default:
                    Console.WriteLine("태초의 마을에 오신 여러분 환영합니다.");
                    break;
            }
        }
    }
}