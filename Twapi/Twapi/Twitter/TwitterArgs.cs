﻿using Twapi.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Twapi.Database.SQLite;
using System.IO;

namespace Twapi.Twitter
{
    [AttributeUsage(AttributeTargets.Property)]
    class EndpointParamAttribute : Attribute
    {
        public EndpointParamAttribute(string key)
        {
            this.Key = key;
        }
        public string Key { get; set; }
    }
    public class TwitterArgs : TwapiBase
    {
        #region 引数リスト
        /// <summary>
        /// 引数リスト
        /// </summary>
        public static Dictionary<string, string> Args { get; set; } = new Dictionary<string, string>();
        #endregion

        #region コマンドオプション
        /// <summary>
        /// コマンドオプション
        /// </summary>
        public static TwitterCommandOptions CommandOptions { get; set; } = new TwitterCommandOptions();
        #endregion

        #region コマンドライン引数を分解して値を設定する
        /// <summary>
        /// コマンドライン引数を分解して値を設定する
        /// </summary>
        /// <param name="key">コマンド</param>
        /// <param name="value">セットする値</param>
        public static void SetCommandParameter(string key, string value)
        {
            // Get instance of the attribute.
            EndpointParamAttribute myAttribute =
                (EndpointParamAttribute)Attribute.GetCustomAttribute(typeof(TwitterCommandOptions), typeof(EndpointParamAttribute));

            //プロパティ一覧を取得
            var properties = CommandOptions.GetType().GetProperties();

            foreach (var prop in properties)
            {
                // プロパティに付いている属性を取得する
                var endpoint = (Attribute.GetCustomAttributes(
                            typeof(TwitterCommandOptions).GetProperty(prop.Name),
                            typeof(EndpointParamAttribute)) as EndpointParamAttribute[]).FirstOrDefault();

                // 取得内容の確認
                if (endpoint != null)
                {
                    if (endpoint.Key.Equals(key))
                    {
                        prop.SetValue(CommandOptions, (string)value);
                        break;
                    }
                }
            }
        }
        #endregion

        #region コマンドを分解してセットする
        /// <summary>
        /// コマンドを分解してセットする
        /// </summary>
        /// <param name="args">コマンドライン引数</param>
        public static void SetCommand(string[] args)
        {
            // 引数分ループする
            for (int i = 0; i < args.Length; i++)
            {
                var check = (from x in TwitterActions.Actions
                             where x.ActionName.Equals(args[i].ToLower())
                             select x).FirstOrDefault();

                // nullチェック
                if (check != null)
                {
                    // アクションキーが既に登録されていないことを確認する
                    if (!Args.ContainsKey("action"))
                    {
                        // キーの登録
                        Args.Add("action", args.Length > i ? args[i] : string.Empty);
                    }
                }
                else
                {
                    string key = args[i++];
                    string value = args.Length > i ? args[i] : string.Empty;

                    // 同じキーが既に登録されていないことを確認する
                    if (!Args.ContainsKey(key))
                    {
                        Args.Add(key, value);
                    }
                }
            }

            // コマンド + オプションリストにセットする
            foreach (var param in TwitterArgs.Args)
            {
                // エンドポイントコマンドに使用するパラメータのセット
                SetCommandParameter(param.Key, param.Value);
            }

            #region SQLiteファイルパス設定
            // SQLiteファイルが指定されている場合、指定されたファイルを優先する
            if (!string.IsNullOrEmpty(TwitterArgs.CommandOptions.Sql))
            {
                SQLiteDataContext.db_file_path = TwitterArgs.CommandOptions.Sql;
            }
            #endregion

            #region キーファイルパス指定
            // オプションにキーファイルパスが指定されている場合は指定されたファイルを優先する
            if (!string.IsNullOrEmpty(TwitterArgs.CommandOptions.KeysFile))
            {
                // キーファイル情報のセット
                ConfigManager.KeysFile = TwitterArgs.CommandOptions.KeysFile;

            }
            // キーファイルの存在確認
            if (File.Exists(ConfigManager.KeysFile))
            {
                // キーの読み込み
                TwitterAPI.TwitterKeys = XMLUtil.Deserialize<TwitterKeys>(ConfigManager.KeysFile);
            }
            #endregion

            #region 各種キー設定
            /* デフォルトファイル → キーファイル → キーコマンドの順で上書きする
             * 何も指定しなければデフォルトのファイルが使用され
             * -keysfileが指定されていればそのファイルパスのキーが使用される
             * 更に-ck -cs -at -asオプションが指定されていればオプションを優先する
             */
            // コンシューマーキーが指定されている場合
            if (!string.IsNullOrEmpty(TwitterArgs.CommandOptions.ConsumerKey))
            {
                TwitterAPI.TwitterKeys.ConsumerKey = TwitterArgs.CommandOptions.ConsumerKey;
            }
            // コンシューマーシークレットキーが指定されている場合
            if (!string.IsNullOrEmpty(TwitterArgs.CommandOptions.ConsumerSecret))
            {
                TwitterAPI.TwitterKeys.ConsumerSecretKey = TwitterArgs.CommandOptions.ConsumerSecret;
            }
            // アクセストークンが指定されている場合
            if (!string.IsNullOrEmpty(TwitterArgs.CommandOptions.AccessToken))
            {
                TwitterAPI.TwitterKeys.AccessToken = TwitterArgs.CommandOptions.AccessToken;
            }
            // アクセスシークレットが指定されている場合
            if (!string.IsNullOrEmpty(TwitterArgs.CommandOptions.AccessSecret))
            {
                TwitterAPI.TwitterKeys.AccessSecret = TwitterArgs.CommandOptions.AccessSecret;
            }
            #endregion
        }
        #endregion

    }
}
