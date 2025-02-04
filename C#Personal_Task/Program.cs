using System;
using System.Collections.Generic;

namespace C_Personal_Task
{

    internal class Program
    {
        static List<Item> inventory = new List<Item>();
        static int playerGold = 1500;
        static string nickName;

        static List<Item> shopItems = new List<Item>
        {
            new Item("수련자 갑옷", "방어", 5, "수련에 도움을 주는 갑옷입니다.", false, 1000),
            new Item("무쇠갑옷", "방어", 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", true, 0), // 구매완료
            new Item("스파르타의 갑옷", "방어", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", false, 3500),
            new Item("낡은 검", "공격", 2, "쉽게 볼 수 있는 낡은 검 입니다.", false, 600),
            new Item("청동 도끼", "공격", 5, "어디선가 사용됐던거 같은 도끼입니다.", true, 1500),
            new Item("스파르타의 창", "공격", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", false, 0) // 구매완료
        };
        static void Main(string[] args)
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");

            int save;

            while (true) //이름 설정
            {
                Console.WriteLine("원하시는 이름을 설정해주세요.\n");
                nickName = Console.ReadLine();

                Console.WriteLine();

                Console.WriteLine($"입력하신 이름은 {nickName} 입니다.\n");
                Console.WriteLine("1. 저장\n2. 취소");

                if (int.TryParse(Console.ReadLine(), out save))
                {
                    if (save == 1) // 저장 했을 시
                    {
                        Console.WriteLine($"\n스파르타 마을에 오신 {nickName}님 환영합니다.");
                        Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                        break;
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
                    Console.WriteLine("\n잘못된 입력입니다. 숫자를 입력해주세요.");
                }
            }

            int choice;



            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. 상태 보기\n2. 인벤토리\n3. 상점\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice == 1) // 상태보기
                    {
                        DisplayStatus();
                    }
                    else if (choice == 2) // 인벤토리
                    {
                        ManageInventory();
                    }
                    else if (choice == 3) // 상점
                    {
                        ManageShop();
                    }
                    else // 잘못된 숫자 입력 시
                    {
                        Console.WriteLine("\n잘못된 입력입니다. 1 에서 3의 숫자를 입력해주세요.");
                    }
                }
                else // 문자 입력 시
                {
                    Console.WriteLine("\n잘못된 입력입니다. 숫자를 입력해주세요.");
                }
            }
        }


        static void DisplayStatus() // 상태보기
        {
            int baseAttack = 10;
            int baseDefense = 5;
            int attackBonus = 0;
            int defenseBonus = 0;
            int baseHP = 100;

            foreach (var item in inventory) // 아이템착용 시 스탯
            {
                if (item.IsEquipped)
                {
                    if (item.Type == "공격") attackBonus += item.StatBonus;
                    if (item.Type == "방어") defenseBonus += item.StatBonus;
                }
            }
            Console.Clear();
            Console.WriteLine("상태 보기\n캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine("Lv. 01");
            Console.WriteLine($"Chad ( {nickName} )");
            Console.WriteLine($"공격력 : {baseAttack + attackBonus} (+{attackBonus})");
            Console.WriteLine($"방어력 : {baseDefense + defenseBonus} (+{defenseBonus})");
            Console.WriteLine($"체력 : {baseHP}");
            Console.WriteLine($"Gold : {playerGold} G\n");
            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");
            if (int.TryParse(Console.ReadLine(), out int choice2))
            {
                if (choice2 == 0)
                {

                }
                else
                {
                    Console.WriteLine("올바른 숫자를 입력해주세요.");
                }
            }
        }

        static void ManageInventory()
        {
            Console.Clear();
            Console.WriteLine("인벤토리\n보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]");

            if (inventory.Count == 0)
            {
                Console.WriteLine("보유 중인 아이템이 없습니다.\n");
            }
            else
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    var item = inventory[i];
                    Console.WriteLine($"{(inventory[i].IsEquipped ? "[E]" : "")}{item.Name} | {item.Type} +{item.StatBonus} | {item.Description}");
                }
            }

            Console.WriteLine("\n1. 장착 관리\n0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");

            if (int.TryParse(Console.ReadLine(), out int choice) && choice == 1)
            {
                EquipItems();
            }
        }
        static void EquipItems()
        {
            Console.Clear();
            Console.WriteLine("장착 관리\n보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < inventory.Count; i++)
            {
                var item = inventory[i];
                Console.WriteLine($"- {i + 1} {(item.IsEquipped ? "[E]" : "")} {item.Name} | {item.Type} +{item.StatBonus} | {item.Description}");
            }

            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");

            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= inventory.Count)
            {
                inventory[choice - 1].ToggleEquip();
            }
        }
        static void ManageShop()
        {
            Console.Clear();
            Console.WriteLine("상점\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine($"[보유 골드]\n{playerGold} G\n");
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < shopItems.Count; i++)
            {
                string priceText = shopItems[i].IsPurchased ? "구매 완료" : $"{shopItems[i].Price} G";
                Console.WriteLine($"- {shopItems[i].Name} | {shopItems[i].Type} + {shopItems[i].StatBonus} | {shopItems[i].Description} | {priceText} ");
            }

            Console.WriteLine("\n1. 아이템 구매\n0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 0)
                {
                    return;
                }
                else if (choice == 1)
                {
                    Console.Clear();
                    Console.WriteLine("상점 - 아이템 구매\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
                    Console.WriteLine($"[보유 골드]\n{playerGold} G\n");
                    Console.WriteLine("[아이템 목록]");


                    for (int i = 0; i < shopItems.Count; i++)
                    {
                        string priceText = shopItems[i].IsPurchased ? "구매 완료" : $"{shopItems[i].Price} G";
                        Console.WriteLine($"{i + 1}. {shopItems[i].Name} | {shopItems[i].Type} + {shopItems[i].StatBonus} | {shopItems[i].Description} | {priceText} ");
                    }



                    Console.WriteLine("\n0. 나가기\n");
                    Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");

                    if (int.TryParse(Console.ReadLine(), out int itemChoice) && itemChoice > 0 && itemChoice <= shopItems.Count)
                    {
                        var selectedItem = shopItems[itemChoice - 1];

                        if (!selectedItem.IsPurchased && playerGold >= selectedItem.Price)
                        {
                            playerGold -= selectedItem.Price;
                            inventory.Add(new Item(selectedItem.Name, selectedItem.Type, selectedItem.StatBonus, selectedItem.Description, false, 0)); // 구매한 아이템을 인벤토리에 추가
                            selectedItem.IsPurchased = true;
                            Console.WriteLine("구매를 완료했습니다.");
                        }
                        else if (selectedItem.IsPurchased)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                        }
                        else
                        {
                            Console.WriteLine("Gold 가 부족합니다.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 선택입니다.");
                    }
                }
            }

        }
        class Item
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

            public void ToggleEquip()
            {
                IsEquipped = !IsEquipped;
            }
        }
    }
}
