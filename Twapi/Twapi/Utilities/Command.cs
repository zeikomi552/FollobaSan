﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twapi.Utilities
{
    public class Command
    {
        public enum CommandTypeEnum
        {
            /// <summary>
            /// アクション：コマンドの動作を決定する
            /// 例：ヘルプ、キーファイルの保存、ツイッター系のAPIエンドポイント
            /// </summary>
            Action,
            /// <summary>
            /// オプション：ツイッターAPI外の指定条件
            /// 例：出力先ディレクトリ指定
            /// </summary>
            Option,
            /// <summary>
            /// キー：アクセスシークレットやトークン等
            /// </summary>
            Keys
        }

        #region キー
        /// <summary>
        /// キー
        /// </summary>
        public string Key { get; set; }
        #endregion

        #region 説明
        /// <summary>
        /// 説明
        /// </summary>
        public string Description { get; set; }
        #endregion

        #region コマンドタイプ
        /// <summary>
        /// コマンドタイプ
        /// </summary>
        public CommandTypeEnum CommandType { get; set; }
        #endregion

        #region 有効（実装済）/無効(未実装)
        /// <summary>
        /// 有効（実装済）/無効(未実装)
        /// </summary>
        public bool IsEnable { get; set; }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="description">説明</param>
        /// <param name="command_type">タイプ</param>
        /// <param name="is_enable">true:実装済 false:未実装</param>
        public Command(string key, string description, CommandTypeEnum command_type, bool is_enable = false)
        {
            this.Key = key;
            this.Description = description;
            this.CommandType = command_type;
            this.IsEnable = is_enable;
        }
        #endregion
    }
}
