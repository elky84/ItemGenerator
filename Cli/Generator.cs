﻿using EnumExtend;
using ItemGenerator.MasterData;
using ItemGenerator.Table;
using ItemGenerator.Util;
using JsonTable;
using Serilog;

namespace Cli
{
    public static class Generator
    {
        private static readonly RandomUtil RandomUtil = new();

        public static void Execute(Options opts)
        {
            MasterTable.Load("ItemGenerator.Table");

            for (var n = 1; n <= opts.Count; ++n)
            {
                var item = Generate(opts);
                if (item != null)
                {
                    Log.Information($"[Generated Item] Item:{item.ItemId}, Grade:{item.Grade.Desc()}, " +
                        $"Type:{item.MasterData!.Type.Desc()}\n" +
                        $"Options:[{String.Join(",", item.Options!)}]");
                }
            }

            Log.Information($"Generate Completed");
        }

        private static ItemGenerator.Model.Item? Generate(Options opts)
        {
            var itemDrop = Drop();
            if (itemDrop == null)
            {
                Log.Error($"ItemDrop is null. Maybe reason is Code or MasterData");
                return null;
            }

            var itemDropGrade = DropGrade();
            if (itemDropGrade == null)
            {
                Log.Error($"ItemDropGrade is null. Maybe reason is Code or MasterData");
                return null;
            }


            var itemMasterData = Pick(opts.Level, itemDrop);
            if (itemMasterData == null)
            {
                Log.Error("Item Pick failed. <Level:{OptsLevel}, Drop:{ItemDrop}>", opts.Level, itemDrop);
                return null;
            }

            var item = new ItemGenerator.Model.Item
            {
                ItemId = itemMasterData.Id,
                MasterData = itemMasterData,
                Grade = itemDropGrade.Grade,
                Options = Enumerable.Range(itemDropGrade.OptionMin, itemDropGrade.OptionMax)
                            .Select(x => PickOption(opts.Level, itemMasterData, itemDropGrade))
                            .Where(x => x != null)
                            .Select(x => x!)
                            .ToList()
            };

            return item;
        }

        private static ItemDrop? Drop()
        {
            double n = RandomUtil.Next(0.0, 100.0), check = 0.0;
            foreach (var itemDrop in MasterTable.From<TableItemDrop>()!)
            {
                check += itemDrop.Probability;
                if (n <= check)
                {
                    return itemDrop;
                }
            }

            return null;
        }

        private static ItemDropGrade? DropGrade()
        {
            double n = RandomUtil.Next(0.0, 100.0), check = 0.0;
            foreach (var itemDropGrade in MasterTable.From<TableItemDropGrade>()!)
            {
                check += itemDropGrade.Probability;
                if (n <= check)
                {
                    return itemDropGrade;
                }
            }

            return null;
        }

        private static Item? Pick(int level, ItemDrop itemDrop)
        {
            var itemByType = MasterTable.From<TableItemByType>()![itemDrop.Type];

            var item = RandomUtil.Pick(itemByType);
            if (item != null) return item;

            Log.Error("Not found ItemMasterData. <Level:{Level}, Drop:{ItemDropType}>", level, itemDrop.Type);
            return null;

        }

        private static ItemGenerator.Model.ItemOption? PickOption(int level, Item item, ItemDropGrade itemDropGrade)
        {
            var itemOptionByGrade = MasterTable.From<TableItemOptionByGrade>()![itemDropGrade.Grade];

            var itemOption = RandomUtil.Pick(itemOptionByGrade);
            if (itemOption != null)
            {
                return new ItemGenerator.Model.ItemOption
                {
                    Type = itemOption.Option,
                    Value = RandomUtil.Next(itemOption.ValueMin, itemOption.ValueMax)
                };
            }

            Log.Error("Not found option. <Level:{Level}, Drop:{Grade}>", level, itemDropGrade.Grade);
            return null;

        }
    }
}
