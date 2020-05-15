﻿using Native.Sdk.Cqp.EventArgs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.cbgan.SuiseiBot.Code.database
{
    internal static class DatabaseInit//数据库初始化类
    {
        public static void Init(CQAppEnableEventArgs e)
        {
            string DBPath = System.IO.Directory.GetCurrentDirectory() + "\\data\\" + e.CQApi.GetLoginQQ() + "\\suisei.db";
            SQLiteHelper dbHelper = new SQLiteHelper(DBPath);
            if (!File.Exists(DBPath))//查找数据文件
            {
                dbHelper.CreateNewDBFile();
            }
            dbHelper.OpenDB();//打开数据库连接
            if (!dbHelper.TableExists("suisei")) //彗酱数据库初始化
            {
                ConsoleLog.Warning("数据库初始化", "未找到慧酱数据表 - 创建一个新表");
                dbHelper.CreateTable(SuiseiDBHelper.TableName, SuiseiDBHelper.ColName, SuiseiDBHelper.ColType,SuiseiDBHelper.PrimaryColName);
            }
            if (!dbHelper.TableExists("guild")) //公会数据库初始化
            {
                ConsoleLog.Warning("数据库初始化", "未找到公会表数据表 - 创建一个新表");
                dbHelper.CreateTable(PCRDBHelper.GuildTableName, PCRDBHelper.GColName, PCRDBHelper.GColType, PCRDBHelper.GPrimaryColName);
            }
            if (!dbHelper.TableExists("member")) //公会成员数据库初始化
            {
                ConsoleLog.Warning("数据库初始化", "未找到成员表数据表 - 创建一个新表");
                dbHelper.CreateTable(PCRDBHelper.MemberTableName, PCRDBHelper.MColName, PCRDBHelper.MColType, PCRDBHelper.MPrimaryColName);
            }
            dbHelper.CloseDB();//关闭数据库连接
        }
    }
}
