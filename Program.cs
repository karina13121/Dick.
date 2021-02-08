using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using SharpDX;
using System;

namespace zablje_trolovanje
{
    class Program
    {
        static EnsoulSharp.SDK.MenuUI.Menu menu, fountain, chat;
        static void Main(string[] args)
        {
            GameEvent.OnGameLoad += GameEvent_OnGameLoad;
            Game.OnUpdate += Game_OnUpdate;
        }

        private static void Game_OnUpdate(EventArgs args)
        {

            Vector3 redPos = new Vector3();
            redPos.X = 14286;
            redPos.Y = 14270;
            redPos.Z = 171;
            Vector3 bluePos = new Vector3();
            bluePos.X = 410;
            bluePos.Y = 416;
            bluePos.Z = 182;


            if (fountain.GetValue<EnsoulSharp.SDK.MenuUI.MenuBool>("blue").Enabled)
            {
                if (!ObjectManager.Player.IsDead)
                {
                    ObjectManager.Player.IssueOrder(GameObjectOrder.MoveTo, redPos);
                }
            }
            if (fountain.GetValue<EnsoulSharp.SDK.MenuUI.MenuBool>("red").Enabled)
            {
                if (!ObjectManager.Player.IsDead)
                {
                    ObjectManager.Player.IssueOrder(GameObjectOrder.MoveTo, bluePos);
                }
            }
            if (chat.GetValue<MenuBool>("enabled1").Enabled)
            {
                if (chat.GetValue<MenuBool>("toall").Enabled)
                {
                    if (chat.GetValue<MenuList>("list").Index == 0)
                    {
                        Game.Say("EZ", true);
                    }
                    if (chat.GetValue<MenuList>("list").Index == 1)
                    {
                        Game.Say("KYS", true);
                    }
                    if (chat.GetValue<MenuList>("list").Index == 2)
                    {
                        Game.Say("FUCK U RETARDS", true);
                    }
                    if (chat.GetValue<MenuList>("list").Index == 3)
                    {
                        Game.Say("GYPSIES", true);
                    }
                    if (chat.GetValue<MenuList>("list").Index == 4)
                    {
                        Game.Say("FUCK U MUSLIMS", true);
                    }
                    if (chat.GetValue<MenuList>("list").Index == 5)
                    {
                        Game.Say("DIE IRL KYS MOTHERFUCKERS", true);
                    }
                }
                else if (!chat.GetValue<MenuBool>("toall").Enabled)
                {
                    if (chat.GetValue<MenuList>("list").Index == 0)
                    {
                        Game.Say("EZ", false);
                    }
                    if (chat.GetValue<MenuList>("list").Index == 1)
                    {
                        Game.Say("KYS", false);
                    }
                    if (chat.GetValue<MenuList>("list").Index == 2)
                    {
                        Game.Say("FUCK U RETARDS", false);
                    }
                    if (chat.GetValue<MenuList>("list").Index == 3)
                    {
                        Game.Say("GYPSIES", false);
                    }
                    if (chat.GetValue<MenuList>("list").Index == 4)
                    {
                        Game.Say("FUCK U MUSLIMS", false);
                    }
                    if (chat.GetValue<MenuList>("list").Index == 5)
                    {
                        Game.Say("DIE IRL KYS MOTHERFUCKERS", false);
                    }
                }
            }
        }

        private static void GameEvent_OnGameLoad()
        {

            Game.Print("zablje trolovanje za nidzu loudovano");
            Menu();
        }
        private static void Menu()
        {
            menu = new EnsoulSharp.SDK.MenuUI.Menu("menu", "Zablje Trolovanje", true);
            fountain = new EnsoulSharp.SDK.MenuUI.Menu("fountain", "Fontana :D", false);
            chat = new EnsoulSharp.SDK.MenuUI.Menu("chat", "Chat", false);
            var splitter = new EnsoulSharp.SDK.MenuUI.MenuSeparator("sep", "nidzo ako si plavi tim tikuj blue da intas, red obrnuto");
            var mbool = new EnsoulSharp.SDK.MenuUI.MenuBool("blue", "Plavi", false);
            var rbool = new EnsoulSharp.SDK.MenuUI.MenuBool("red", "Crveni", false);
            var toall = new MenuBool("toall", "Sendati /all?", true);
            var enabled = new MenuBool("enabled1", "Ukljuceno?", false);
            var list = new MenuList("list", "Lista", new string[] { "EZ", "KYS", "FUCK U RETARDS", "GYPSIES", "FUCK U MUSLIMS", "DIE IRL KYS MOTHERFUCKERS" }, 0);
            menu.Add(fountain);
            fountain.Add(splitter);
            chat.Add(enabled);
            chat.Add(toall);
            chat.Add(list);
            menu.Add(chat);
            fountain.Add(mbool);
            fountain.Add(rbool);
            menu.Attach();
        }
    }
}
