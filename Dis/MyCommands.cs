using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using HtmlAgilityPack;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Dis
{
    class MyCommands
    {
        
        [Command("a")]
        public async Task Ava(CommandContext ctx, DiscordMember me = null)
        {
            if (me == null)
            {
                string g = ctx.User.AvatarUrl;
                await ctx.RespondAsync(g);
            }
            else
            {
                string g = me.AvatarUrl;
                await ctx.RespondAsync(g);
            }
        }

        [Command("notify")]
        public async Task notify(CommandContext ctx)
        {
            var etr = ctx.Guild.Members.GetEnumerator();
            while (etr.MoveNext())
            {
                var et = etr.Current.Roles.GetEnumerator();
                while (et.MoveNext())
                {
                    if (et.Current.Id == 717019183384363091)
                    {
                        try
                        {
                            int rand;
                            var rnd = new Random();
                            rand = rnd.Next(0, 9);
                            if (rand == 0)
                                await etr.Current.SendMessageAsync("А ну быстро голосовать! Прям щам же нажал на ссылку ниже и проголосовал! Я проверю https://excalibur-craft.ru/index.php?do=clans&go=profile&id=4620");
                            else if (rand == 1)
                                await etr.Current.SendMessageAsync("Антоха закапывает тех, кто не голосует https://excalibur-craft.ru/index.php?do=clans&go=profile&id=4620");
                            else if (rand == 2)
                                await etr.Current.SendMessageAsync("Голосуй или кик!) https://excalibur-craft.ru/index.php?do=clans&go=profile&id=4620");
                            else if (rand == 3)
                                await etr.Current.SendMessageAsync("Твой голос очень важен для нас! https://excalibur-craft.ru/index.php?do=clans&go=profile&id=4620");
                            else if (rand == 4)
                                await etr.Current.SendMessageAsync("Вырвемся в топ! https://excalibur-craft.ru/index.php?do=clans&go=profile&id=4620");
                            else if (rand == 5)
                                await etr.Current.SendMessageAsync("Кто если не ты? https://excalibur-craft.ru/index.php?do=clans&go=profile&id=4620");
                            else if (rand == 6)
                                await etr.Current.SendMessageAsync("Доброе утро! Проголосуй: https://excalibur-craft.ru/index.php?do=clans&go=profile&id=4620");
                            else if (rand == 7)
                                await etr.Current.SendMessageAsync("А голос свой вложить? https://excalibur-craft.ru/index.php?do=clans&go=profile&id=4620");
                            else if (rand == 8)
                                await etr.Current.SendMessageAsync("А ты уже голосовал сегодня? https://excalibur-craft.ru/index.php?do=clans&go=profile&id=4620");
                            else if (rand == 9)
                                await etr.Current.SendMessageAsync("Обгонем Авалон! https://excalibur-craft.ru/index.php?do=clans&go=profile&id=4620");
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }

        [Command("list")]
        public async Task ListRank(CommandContext ctx)
        {
            string kio = "";

            string path = @"C:\Users\stepa\source\repos\Dis\Dis\bin\Debug\netcoreapp3.0\hta.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        string[] lineKio = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        string hui = "";
                        if (lineKio[2] == "0")
                            hui = "Рядовой Копатель";
                        else if (lineKio[2] == "1")
                            hui = "Офицер III ранга";
                        else if (lineKio[2] == "2")
                            hui = "Офицер II ранга";
                        else if (lineKio[2] == "3")
                            hui = "Офицер I ранга";
                        else if (lineKio[2] == "4")
                            hui = "Глава клана";
                        kio += "<@!" + lineKio[0] + ">" + " имеет " + lineKio[1] + " баллов. Текущее звание: " + hui + "\n";
                    }
                    await ctx.RespondAsync(kio);
                }
            }
            catch
            {

            }
        }
        [Command("up")]
        public async Task up(CommandContext ctx, DiscordMember mem, int numRank)
        {
            bool prov = false;
            var gu = ctx.Member.Roles.GetEnumerator();
            while (gu.MoveNext())
            {
                if (gu.Current.Id == 734694384771268698 || gu.Current.Id == 717018450828066836)
                {
                    DiscordRole RoleKop = new DiscordRole();
                    DiscordRole RoleOf1 = new DiscordRole();
                    DiscordRole RoleOf2 = new DiscordRole();
                    DiscordRole RoleOf3 = new DiscordRole();
                    var etr = ctx.Guild.Roles.GetEnumerator();
                    while (etr.MoveNext())
                    {
                        if (etr.Current.Id == 717019183384363091)
                        {
                            RoleKop = etr.Current;
                        }

                        else if (etr.Current.Id == 734694384771268698)
                        {
                            RoleOf1 = etr.Current;
                        }
                        else if (etr.Current.Id == 734694447903801354)
                        {
                            RoleOf2 = etr.Current;
                        }
                        else if (etr.Current.Id == 734694618339213383)
                        {
                            RoleOf3 = etr.Current;
                        }


                    }
                    string kio = "";
                    string path = @"C:\Users\stepa\source\repos\Dis\Dis\bin\Debug\netcoreapp3.0\hta.txt";
                    try
                    {
                        using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                        {
                            string line;
                            while ((line = await sr.ReadLineAsync()) != null)
                            {
                                string[] lineKio = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                if (lineKio[0] == mem.Id.ToString())
                                {
                                    lineKio[1] = Convert.ToString(Convert.ToInt32(lineKio[1]) + numRank);
                                    if (Convert.ToInt32(lineKio[1]) >= 10000)
                                    {
                                        lineKio[2] = "4";
                                        await mem.RevokeRoleAsync(RoleOf1);
                                        await mem.RevokeRoleAsync(RoleOf2);
                                        await mem.RevokeRoleAsync(RoleOf3);
                                        await mem.RevokeRoleAsync(RoleKop);
                                    }
                                    else if (Convert.ToInt32(lineKio[1]) >= 31)
                                    {
                                        lineKio[2] = "3";
                                        await mem.GrantRoleAsync(RoleOf1);
                                        await mem.RevokeRoleAsync(RoleOf2);
                                        await mem.RevokeRoleAsync(RoleOf3);
                                        await mem.RevokeRoleAsync(RoleKop);
                                    }
                                    else if (Convert.ToInt32(lineKio[1]) >= 21)
                                    {
                                        lineKio[2] = "2";
                                        await mem.GrantRoleAsync(RoleOf2);
                                        await mem.RevokeRoleAsync(RoleOf3);
                                        await mem.RevokeRoleAsync(RoleKop);
                                    }
                                    else if (Convert.ToInt32(lineKio[1]) >= 11)
                                    {
                                        lineKio[2] = "1";
                                        await mem.GrantRoleAsync(RoleOf3);
                                        await mem.RevokeRoleAsync(RoleKop);
                                    }
                                    else if(Convert.ToInt32(lineKio[1]) < 11)
                                    {
                                        lineKio[2] = "0";
                                        await mem.GrantRoleAsync(RoleKop);
                                    }

                                    kio += lineKio[0] + " " + lineKio[1] + " " + lineKio[2] + "\n";
                                }
                                else
                                    kio += lineKio[0] + " " + lineKio[1] + " " + lineKio[2] + "\n";
                            }
                        }

                        using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                        {
                            kio = kio.TrimEnd('\n');
                            sw.WriteLine(kio);

                        }

                    }
                    catch
                    {

                    }
                    if (numRank > 0)
                        await ctx.RespondAsync("Игрок повышен");
                    else if (numRank < 0)
                        await ctx.RespondAsync("Игрок понижен");
                    prov = true;
                    break;
                }
            }
            if (!prov)
                await ctx.RespondAsync("Вы не имеете доступа к этой команде");
        }
        [Command("del")]
        public async Task del(CommandContext ctx, DiscordMember mem)
        {
            bool prov = false;
            var gu = ctx.Member.Roles.GetEnumerator();
            while (gu.MoveNext())
            {
                if (gu.Current.Id == 734694384771268698 || gu.Current.Id == 717018450828066836)
                {
                    DiscordRole RoleKop = new DiscordRole();
                    DiscordRole RoleOf1 = new DiscordRole();
                    DiscordRole RoleOf2 = new DiscordRole();
                    DiscordRole RoleOf3 = new DiscordRole();
                    var etr = ctx.Guild.Roles.GetEnumerator();
                    while (etr.MoveNext())
                    {
                        if (etr.Current.Id == 717019183384363091)
                        {
                            RoleKop = etr.Current;
                        }

                        else if (etr.Current.Id == 734694384771268698)
                        {
                            RoleOf1 = etr.Current;
                        }
                        else if (etr.Current.Id == 734694447903801354)
                        {
                            RoleOf2 = etr.Current;
                        }
                        else if (etr.Current.Id == 734694618339213383)
                        {
                            RoleOf3 = etr.Current;
                        }


                    }
                    string kio = "";
                    string path = @"C:\Users\stepa\source\repos\Dis\Dis\bin\Debug\netcoreapp3.0\hta.txt";
                    try
                    {
                        using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                        {
                            string line;
                            while ((line = await sr.ReadLineAsync()) != null)
                            {
                                string[] lineKio = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                if (lineKio[0] == mem.Id.ToString())
                                {
                                    await mem.RevokeRoleAsync(RoleKop);
                                    await mem.RevokeRoleAsync(RoleOf1);
                                    await mem.RevokeRoleAsync(RoleOf2);
                                    await mem.RevokeRoleAsync(RoleOf3);
                                }
                                else
                                    kio += lineKio[0] + " " + lineKio[1] + " " + lineKio[2] + "\n";
                            }
                        }

                        using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                        {
                            kio = kio.TrimEnd('\n');
                            sw.WriteLine(kio);

                        }

                    }
                    catch
                    {

                    }
                    await ctx.RespondAsync("Игрок удален");
                    prov = true;
                    break;
                }
            }
            if (!prov)
                await ctx.RespondAsync("Вы не имеете доступа к этой команде");
        }
        
        [Command("new")]
        public async Task newMem(CommandContext ctx, DiscordMember mem)
        {
            bool prov = false;
            var gu = ctx.Member.Roles.GetEnumerator();
            while (gu.MoveNext())
            {
                if (gu.Current.Id == 734694384771268698 || gu.Current.Id == 717018450828066836)
                {
                    DiscordRole RoleKop = new DiscordRole();
                    var etr = ctx.Guild.Roles.GetEnumerator();
                    while (etr.MoveNext())
                    {
                        if (etr.Current.Id == 717019183384363091)
                        {
                            RoleKop = etr.Current;
                        }


                    }
                    await mem.GrantRoleAsync(RoleKop);
                    string writePath = @"C:\Users\stepa\source\repos\Dis\Dis\bin\Debug\netcoreapp3.0\hta.txt";

                    string text = mem.Id.ToString();
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                        {
                            await sw.WriteLineAsync(text + " " + 0 + " 0");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    await ctx.RespondAsync("Роль выдана");
                    prov = true;
                    break;
                }
            }
            if (!prov)
                await ctx.RespondAsync("Вы не имеете доступа к этой команде");
        }
        [Command("tr")]
        public async Task Tr(CommandContext ctx, string InputL, string OutL)
        {
            string Massag = ctx.Message.Content;
            string Text = Massag.Substring(10);
            Trans tr = new Trans();
            await ctx.RespondAsync(tr.BTranslator(Text, tr.GetLangPair(InputL, OutL)));
        }


    }
}
