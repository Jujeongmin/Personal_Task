using System;
using System.Collections.Generic;

namespace C_Personal_Task
{

    internal class Program
    {
        static int chadChoice; // 직업선택
        static int mainChoice; // 마을에서의 선택
        static int save; // 닉네임 저장



        static List<Item> inventory = new List<Item>(); // 아이템 목록
        static int playerGold = 1500;  // 보유 금액
        static string nickName;  //  내 닉네임
        static int baseHP = 100; // 기초체력

        static List<Item> shopItems = new List<Item>  // 아이템 목록
        {
            new Item("수련자 갑옷", "방어", 5, "수련에 도움을 주는 갑옷입니다.", false, 1000),
            new Item("무쇠갑옷", "방어", 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", true, 0), // 구매완료
            new Item("스파르타의 갑옷", "방어", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", false, 3500),
            new Item("낡은 검", "공격", 2, "쉽게 볼 수 있는 낡은 검 입니다.", false, 600),
            new Item("청동 도끼", "공격", 5, "어디선가 사용됐던거 같은 도끼입니다.", false, 1500),
            new Item("스파르타의 창", "공격", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", true, 0), // 구매완료
            new Item("주정민의 가호", "공격", 30, "주정민의 가호로 개사기템입니다.", false, 1500)
        };
        static void Main(string[] args)
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");




            while (true) //이름 설정
            {
                Console.WriteLine("원하시는 이름을 설정해주세요.\n");
                nickName = Console.ReadLine();

                Console.WriteLine();

                Console.WriteLine($"입력하신 이름은 {nickName} 입니다.\n");
                Console.WriteLine("1. 저장\n2. 취소");
                Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");

                if (int.TryParse(Console.ReadLine(), out save))
                {
                    if (save == 1) // 닉네임 저장 했을 시
                    {
                        Console.Clear();
                        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                        Console.WriteLine("원하시는 직업을 선택해주세요.\n");
                        Console.WriteLine("1. 전사\n2. 도적");
                        Console.WriteLine("\n원하시는 행동을 입력해주세요.\n>>");
                        if (int.TryParse(Console.ReadLine(), out chadChoice)) // 직업선택
                            if (chadChoice == 1 || chadChoice == 2)
                            {
                                break;
                            }
                            else // 다른 숫자 입력 시
                            {
                                Console.Clear();
                                Console.WriteLine("잘못된 입력입니다. 처음으로 되돌아갑니다.");
                            }
                        else // 문자 입력 시
                        {
                            Console.Clear();
                            Console.WriteLine("잘못된 입력입니다. 처음으로 되돌아갑니다.");
                        }
                    }
                    else if (save == 2) // 취소 했을 시
                    {
                        Console.WriteLine("\n이름을 다시 설정합니다.");
                    }
                    else // 다른 숫자 입력 시
                    {
                        Console.WriteLine("\n잘못된 입력입니다. 1 또는 2를 입력해주세요. 이름을 다시 설정합니다.");
                    }
                }
                else // 문자 입력 시
                {
                    Console.WriteLine("\n잘못된 입력입니다. 올바른 숫자를 입력해주세요.");
                }
            }





            while (true) // 직업 저장 후 마을 이동
            {
                Console.Clear();
                Console.WriteLine($"스파르타 마을에 오신 {nickName}님 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");

                Console.WriteLine("\n1. 상태 보기\n2. 인벤토리\n3. 상점\n4. 던전입장\n5. 휴식하기");
                Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");

                if (int.TryParse(Console.ReadLine(), out mainChoice))
                {
                    if (mainChoice == 1) // 상태보기
                    {
                        DisplayStatus();
                    }
                    else if (mainChoice == 2) // 인벤토리
                    {
                        ManageInventory();
                    }
                    else if (mainChoice == 3) // 상점
                    {
                        ManageShop();
                    }
                    else if (mainChoice == 4) // 던전입장
                    {
                        Console.WriteLine("죄송합니다. 구현중입니다...");
                        Console.WriteLine("\n마을로 돌아가려면 아무 키나 누르십시오.");
                        Console.ReadKey();
                    }
                    else if (mainChoice == 5) // 휴식하기
                    {
                        BreakTime();
                    }
                    else // 잘못된 숫자 입력 시
                    {
                        Console.Clear();
                        Console.WriteLine("\n잘못된 입력입니다. 1 에서 5의 숫자를 입력해주세요.");
                        Console.WriteLine("\n마을로 돌아가려면 아무 키나 누르십시오.");
                        Console.ReadKey();
                    }
                }
                else // 문자 입력 시
                {
                    Console.Clear();
                    Console.WriteLine("\n잘못된 입력입니다. 숫자를 입력해주세요.");
                    Console.WriteLine("\n마을로 돌아가려면 아무 키나 누르십시오.");
                    Console.ReadKey();
                }
            }
        }


        static void DisplayStatus() // 상태보기
        {
            int baseAttack = 10;
            int baseDefense = 5;
            int attackBonus = 0;
            int defenseBonus = 0;


            foreach (var item in inventory) // 아이템착용 시 스탯
            {
                if (item.IsEquipped)
                {
                    if (item.Type == "공격") attackBonus += item.StatBonus;
                    if (item.Type == "방어") defenseBonus += item.StatBonus;
                }
            }
            while (true)  // 상태보기 창
            {
                Console.Clear();
                Console.WriteLine("상태 보기\n캐릭터의 정보가 표시됩니다.\n");
                Console.WriteLine("Lv. 01");
                if (chadChoice == 1) // 전사 선택
                {
                    Console.WriteLine($"{nickName} ( 전사 )");
                }
                else  // 도적 선택
                {
                    Console.WriteLine($"{nickName} ( 도적 )");
                }
                Console.WriteLine($"공격력 : {baseAttack + attackBonus} (+{attackBonus})");
                Console.WriteLine($"방어력 : {baseDefense + defenseBonus} (+{defenseBonus})");
                Console.WriteLine($"체력 : {baseHP}");
                Console.WriteLine($"Gold : {playerGold} G\n");
                Console.WriteLine("0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");
                if (int.TryParse(Console.ReadLine(), out int statusChoice)) // 상태보기에서 선택
                {
                    if (statusChoice == 0) // 마을로 돌아가기
                    {
                        break; 
                    }
                }
            }
        }

        static void ManageInventory() // 인벤토리
        {
            while (true) // 인벤토리 창
            {
                Console.Clear();
                Console.WriteLine("인벤토리\n보유 중인 아이템을 관리할 수 있습니다.\n");
                Console.WriteLine("[아이템 목록]");

                if (inventory.Count == 0) // 아이템이 없을 때
                {
                    Console.WriteLine("보유 중인 아이템이 없습니다.\n");
                }
                else // 아이템이 있을 때
                {
                    for (int i = 0; i < inventory.Count; i++) // 아이템 표시
                    {
                        var item = inventory[i];
                        Console.WriteLine($"- {(inventory[i].IsEquipped ? "[E]" : "")}{item.Name} | {item.Type} +{item.StatBonus} | {item.Description}");
                    }
                }

                Console.WriteLine("\n1. 장착 관리\n0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");

                if (int.TryParse(Console.ReadLine(), out int invenChoice)) // 인벤토리창에서 선택
                {
                    if (invenChoice == 0) // 마을로 돌아가기
                    {
                        break;
                    }
                    else if (invenChoice == 1) // 인벤토리 - 장착관리로 이동
                    {
                        EquipItems();
                    }
                }
            }
        }
        static void EquipItems() // 인벤토리 - 장착 관리
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("장착 관리\n보유 중인 아이템을 관리할 수 있습니다.\n");
                Console.WriteLine("[아이템 목록]");

                for (int i = 0; i < inventory.Count; i++)
                {
                    var item = inventory[i];
                    Console.WriteLine($"- {i + 1}{(item.IsEquipped ? "[E]" : "")} {item.Name} | {item.Type} +{item.StatBonus} | {item.Description}");
                }

                Console.WriteLine("\n0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");

                // 장착 관리에서 선택
                if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= inventory.Count)
                {
                    inventory[choice - 1].ToggleEquip(); // 아이템 착용 및 해제
                }
                else if (choice == 0) // 인벤토리로 돌아가기
                {
                    break;
                }
            }
        }
        static void ManageShop() // 상점
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
                Console.WriteLine($"[보유 골드]\n{playerGold} G\n");
                Console.WriteLine("[아이템 목록]");

                for (int i = 0; i < shopItems.Count; i++)
                {
                    string priceText = shopItems[i].IsPurchased ? "구매완료" : $"{shopItems[i].Price} G";
                    Console.WriteLine($"- {shopItems[i].Name} | {shopItems[i].Type} + {shopItems[i].StatBonus} | {shopItems[i].Description} | {priceText} ");
                }

                Console.WriteLine("\n1. 아이템 구매\n2. 아이템 판매\n0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 0) // 마을로 돌아가기
                    {
                        break;
                    }
                    else if (choice == 1) // 상점 - 아이템구매로 이동
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("상점 - 아이템 구매\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
                            Console.WriteLine($"[보유 골드]\n{playerGold} G\n");
                            Console.WriteLine("[아이템 목록]");


                            for (int i = 0; i < shopItems.Count; i++) // 아이템 목록
                            {
                                string priceText = shopItems[i].IsPurchased ? "구매 완료" : $"{shopItems[i].Price} G";
                                Console.WriteLine($"{i + 1}. {shopItems[i].Name} | {shopItems[i].Type} + {shopItems[i].StatBonus} | {shopItems[i].Description} | {priceText} ");
                            }


                            Console.WriteLine("\n0. 나가기\n");
                            Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");

                            if (int.TryParse(Console.ReadLine(), out int itemChoice)) // 상점- 구매하기에서 선택
                            {
                                if (itemChoice == 0) // 상점으로 돌아가기
                                {
                                    break ;
                                }
                                else if (itemChoice > 0 && itemChoice <= shopItems.Count)  // 아이템을 구매한다면
                                {
                                    var selectedItem = shopItems[itemChoice - 1];

                                    if (!selectedItem.IsPurchased && playerGold >= selectedItem.Price) // 구매하기
                                    {
                                        playerGold -= selectedItem.Price;
                                        inventory.Add(new Item(selectedItem.Name, selectedItem.Type, selectedItem.StatBonus, selectedItem.Description, false, 0)); // 구매한 아이템을 인벤토리에 추가
                                        selectedItem.IsPurchased = true;
                                        Console.WriteLine("구매를 완료했습니다.");
                                    }
                                    else if (selectedItem.IsPurchased) // 이미 구매한 아이템이라면
                                    {
                                        Console.WriteLine("이미 구매한 아이템입니다.");
                                    }
                                    else // 골드가 부족하다면
                                    {
                                        Console.WriteLine("Gold 가 부족합니다.");
                                    }
                                    Console.WriteLine("\n계속하려면 아무키나 누르십시오.");
                                    Console.ReadKey();
                                }
                            }
                        }
                    }
                    else if (choice == 2) // 상점 - 아이템 판매
                    {
                        while (true)
                        {
                            
                            Console.Clear();
                            Console.WriteLine("상점 - 아이템 판매\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
                            Console.WriteLine($"[보유 골드]\n{playerGold} G\n");
                            Console.WriteLine("[아이템 목록]");
                            /*
                            if (inventory.Count == 0)
                            {
                                Console.WriteLine("보유 중인 아이템이 없습니다.\n");
                            }
                            else
                            {
                                for (int i = 0; i < inventory.Count; i++)
                                {
                                    var item = inventory[i];
                                    Console.WriteLine($"- {(inventory[i].IsEquipped ? "[E]" : "")}{item.Name} | {item.Type} +{item.StatBonus} | {item.Description}");
                                }
                            }
                            */
                            Console.WriteLine("\n죄송합니다 구현중입니다....\n\n\n");
                            Console.WriteLine("\n0. 나가기\n");
                            Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");

                            if (int.TryParse(Console.ReadLine(), out int sellChoice)) // 상점 - 판매하기에서 선택
                            {
                                if (sellChoice == 0) // 상점으로 돌아가기
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        static void BreakTime() // 휴식하기
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("휴식하기");
                Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {playerGold})");
                Console.WriteLine("\n1. 휴식하기\n0. 나가기");
                Console.WriteLine("\n원하시는 행동을 입력해주세요.\n>>");
                if (int.TryParse(Console.ReadLine(), out int breakChoice)) // 휴식하기에서 선택
                {
                    if (breakChoice == 1) // 휴식을 한다면
                    {
                        if (playerGold >= 500) // 플레이어가 500골드 이상 있다면
                        {
                            if (baseHP < 100) // 체력이 100미만이라면
                            {
                                playerGold -= 500;
                                baseHP = Math.Min(baseHP + 100, 100);
                                Console.WriteLine("휴식을 완료했습니다.");
                            }
                            else // 체력이 100미만이 아니라면
                            {
                                Console.WriteLine("체력이 이미 최대입니다.");
                            }
                            Console.WriteLine("\n계속하려면 아무키나 누르십시오.");
                            Console.ReadKey();
                        }
                        else // 플레이어가 보유골드가 500골드 미만이라면
                        {
                            Console.WriteLine("Gold 가 부족합니다.");
                            Console.WriteLine("\n계속하려면 아무키나 누르십시오.");
                            Console.ReadKey();
                        }
                        break;  // 마을로 이동
                    }
                    else if (breakChoice == 0) // 마을로 이동
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("올바른 숫자를 입력해주세요.");
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 올바른 숫자를 입력해주세요.");
                }
            }
        }


        class Item // 아이템 변수들
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public int StatBonus { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
            public bool IsEquipped { get; set; }
            public bool IsPurchased { get; set; }


            public Item(string name, string type, int statBonus, string description, bool isPurchased, int price)
            {
                Name = name;
                Type = type;
                StatBonus = statBonus;
                Description = description;
                Price = price;
                IsPurchased = isPurchased;
                IsEquipped = false;
            }

            public void ToggleEquip() // 아이템 장착
            {
                IsEquipped = !IsEquipped; // 장착된 아이템이면 해제, 장착되지 않은 아이템이라면 장착
            }
        }
    }
}
