﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twapi.Database.SQLite.Base
{
	/// <summary>
	/// フォロバリスト
	/// FollowBackListテーブルをベースに作成しています
	/// 作成日：2021/12/31 作成者gohya
	/// </summary>
	[Table("FollowBackList")]
	public class FollowBackListBase : INotifyPropertyChanged
	{
		#region パラメータ
		#region ユーザーID[UserId]プロパティ
		/// <summary>
		/// ユーザーID[UserId]プロパティ用変数
		/// </summary>
		long _UserId = 0;
		/// <summary>
		/// ユーザーID[UserId]プロパティ
		/// </summary>
		[Key]
		[Column("UserId")]
		public long UserId
		{
			get
			{
				return _UserId;
			}
			set
			{
				if (!_UserId.Equals(value))
				{
					_UserId = value;
					NotifyPropertyChanged("UserId");
				}
			}
		}
		#endregion

		#region データ追加日時[InsertAt]プロパティ
		/// <summary>
		/// データ追加日時[InsertAt]プロパティ用変数
		/// </summary>
		DateTime _InsertAt = DateTime.MinValue;
		/// <summary>
		/// データ追加日時[InsertAt]プロパティ
		/// </summary>
		[Column("InsertAt")]
		public DateTime InsertAt
		{
			get
			{
				return _InsertAt;
			}
			set
			{
				if (!_InsertAt.Equals(value))
				{
					_InsertAt = value;
					NotifyPropertyChanged("InsertAt");
				}
			}
		}
		#endregion

		#region データ更新日時[UpdateAt]プロパティ
		/// <summary>
		/// データ更新日時[UpdateAt]プロパティ用変数
		/// </summary>
		DateTime _UpdateAt = DateTime.MinValue;
		/// <summary>
		/// データ更新日時[UpdateAt]プロパティ
		/// </summary>
		[Column("UpdateAt")]
		public DateTime UpdateAt
		{
			get
			{
				return _UpdateAt;
			}
			set
			{
				if (!_UpdateAt.Equals(value))
				{
					_UpdateAt = value;
					NotifyPropertyChanged("UpdateAt");
				}
			}
		}
		#endregion

		#region スクリーン名[ScreenName]プロパティ
		/// <summary>
		/// スクリーン名[ScreenName]プロパティ用変数
		/// </summary>
		String _ScreenName = string.Empty;
		/// <summary>
		/// スクリーン名[ScreenName]プロパティ
		/// </summary>
		[Column("ScreenName")]
		public String ScreenName
		{
			get
			{
				return _ScreenName;
			}
			set
			{
				if (!_ScreenName.Equals(value))
				{
					_ScreenName = value;
					NotifyPropertyChanged("ScreenName");
				}
			}
		}
		#endregion

		#region 詳細[Description]プロパティ
		/// <summary>
		/// 詳細[Description]プロパティ用変数
		/// </summary>
		String _Description = string.Empty;
		/// <summary>
		/// 詳細[Description]プロパティ
		/// </summary>
		[Column("Description")]
		public String Description
		{
			get
			{
				return _Description;
			}
			set
			{
				if (!_Description.Equals(value))
				{
					_Description = value;
					NotifyPropertyChanged("Description");
				}
			}
		}
		#endregion

		#region 作成日時[CreateAt]プロパティ
		/// <summary>
		/// 作成日時[CreateAt]プロパティ用変数
		/// </summary>
		DateTime _CreateAt = DateTime.MinValue;
		/// <summary>
		/// 作成日時[CreateAt]プロパティ
		/// </summary>
		[Column("CreateAt")]
		public DateTime CreateAt
		{
			get
			{
				return _CreateAt;
			}
			set
			{
				if (!_CreateAt.Equals(value))
				{
					_CreateAt = value;
					NotifyPropertyChanged("CreateAt");
				}
			}
		}
		#endregion

		#region フォロー数[FriendsCount]プロパティ
		/// <summary>
		/// フォロー数[FriendsCount]プロパティ用変数
		/// </summary>
		Int32 _FriendsCount = 0;
		/// <summary>
		/// フォロー数[FriendsCount]プロパティ
		/// </summary>
		[Column("FriendsCount")]
		public Int32 FriendsCount
		{
			get
			{
				return _FriendsCount;
			}
			set
			{
				if (!_FriendsCount.Equals(value))
				{
					_FriendsCount = value;
					NotifyPropertyChanged("FriendsCount");
				}
			}
		}
		#endregion

		#region フォロワー数[FollowersCount]プロパティ
		/// <summary>
		/// フォロワー数[FollowersCount]プロパティ用変数
		/// </summary>
		Int32 _FollowersCount = 0;
		/// <summary>
		/// フォロワー数[FollowersCount]プロパティ
		/// </summary>
		[Column("FollowersCount")]
		public Int32 FollowersCount
		{
			get
			{
				return _FollowersCount;
			}
			set
			{
				if (!_FollowersCount.Equals(value))
				{
					_FollowersCount = value;
					NotifyPropertyChanged("FollowersCount");
				}
			}
		}
		#endregion

		#region お気に入り数[FavouritesCount]プロパティ
		/// <summary>
		/// お気に入り数[FavouritesCount]プロパティ用変数
		/// </summary>
		Int32? _FavouritesCount = 0;
		/// <summary>
		/// お気に入り数[FavouritesCount]プロパティ
		/// </summary>
		[Column("FavouritesCount")]
		public Int32? FavouritesCount
		{
			get
			{
				return _FavouritesCount;
			}
			set
			{
				if (!_FavouritesCount.Equals(value))
				{
					_FavouritesCount = value;
					NotifyPropertyChanged("FavouritesCount");
				}
			}
		}
		#endregion

		#region ツイート数[TweetCount]プロパティ
		/// <summary>
		/// ツイート数[TweetCount]プロパティ用変数
		/// </summary>
		Int32? _TweetCount = 0;
		/// <summary>
		/// ツイート数[TweetCount]プロパティ
		/// </summary>
		[Column("TweetCount")]
		public Int32? TweetCount
		{
			get
			{
				return _TweetCount;
			}
			set
			{
				if (!_TweetCount.Equals(value))
				{
					_TweetCount = value;
					NotifyPropertyChanged("TweetCount");
				}
			}
		}
		#endregion

		#region 最終ツイート日[LastTweetAt]プロパティ
		/// <summary>
		/// 最終ツイート日[LastTweetAt]プロパティ用変数
		/// </summary>
		DateTime? _LastTweetAt = null;
		/// <summary>
		/// 最終ツイート日[LastTweetAt]プロパティ
		/// </summary>
		[Column("LastTweetAt")]
		public DateTime? LastTweetAt
		{
			get
			{
				return _LastTweetAt;
			}
			set
			{
				if (!_LastTweetAt.Equals(value))
				{
					_LastTweetAt = value;
					NotifyPropertyChanged("LastTweetAt");
				}
			}
		}
		#endregion

		#region 最終ツイート内容[LastTweet]プロパティ
		/// <summary>
		/// 最終ツイート内容[LastTweet]プロパティ用変数
		/// </summary>
		String _LastTweet = string.Empty;
		/// <summary>
		/// 最終ツイート内容[LastTweet]プロパティ
		/// </summary>
		[Column("LastTweet")]
		public String LastTweet
		{
			get
			{
				return _LastTweet;
			}
			set
			{
				if (!_LastTweet.Equals(value))
				{
					_LastTweet = value;
					NotifyPropertyChanged("LastTweet");
				}
			}
		}
		#endregion

		#region プライベートアカウントかどうか[IsProtected]プロパティ
		/// <summary>
		/// プライベートアカウントかどうか[IsProtected]プロパティ用変数
		/// </summary>
		bool _IsProtected = false;
		/// <summary>
		/// プライベートアカウントかどうか[IsProtected]プロパティ
		/// </summary>
		[Column("IsProtected")]
		public bool IsProtected
		{
			get
			{
				return _IsProtected;
			}
			set
			{
				if (!_IsProtected.Equals(value))
				{
					_IsProtected = value;
					NotifyPropertyChanged("IsProtected");
				}
			}
		}
		#endregion

		#region Twitterからロックされているかどうか[IsSuspended]プロパティ
		/// <summary>
		/// Twitterからロックされているかどうか[IsSuspended]プロパティ用変数
		/// </summary>
		bool? _IsSuspended = false;
		/// <summary>
		/// Twitterからロックされているかどうか[IsSuspended]プロパティ
		/// </summary>
		[Column("IsSuspended")]
		public bool? IsSuspended
		{
			get
			{
				return _IsSuspended;
			}
			set
			{
				if (!_IsSuspended.Equals(value))
				{
					_IsSuspended = value;
					NotifyPropertyChanged("IsSuspended");
				}
			}
		}
		#endregion


		#endregion

		#region 関数
		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public FollowBackListBase()
		{

		}
		#endregion

		#region コピーコンストラクタ
		/// <summary>
		/// コピーコンストラクタ
		/// </summary>
		/// <param name="item">コピー内容</param>
		public FollowBackListBase(FollowBackListBase item)
		{
			// 要素のコピー
			Copy(item);
		}
		#endregion

		#region コピー
		/// <summary>
		/// コピー
		/// </summary>
		/// <param name="item">コピー内容</param>
		public void Copy(FollowBackListBase item)
		{
			this.UserId = item.UserId;

			this.InsertAt = item.InsertAt;

			this.UpdateAt = item.UpdateAt;

			this.ScreenName = item.ScreenName;

			this.Description = item.Description;

			this.CreateAt = item.CreateAt;

			this.FriendsCount = item.FriendsCount;

			this.FollowersCount = item.FollowersCount;

			this.FavouritesCount = item.FavouritesCount;

			this.TweetCount = item.TweetCount;

			this.LastTweetAt = item.LastTweetAt;

			this.LastTweet = item.LastTweet;

			this.IsProtected = item.IsProtected;

			this.IsSuspended = item.IsSuspended;


		}
		#endregion

		#region Insert処理
		/// <summary>
		/// Insert処理
		/// </summary>
		/// <param name="item">Insertする要素</param>
		public static void Insert(FollowBackListBase item)
		{
			using (var db = new SQLiteDataContext())
			{
				Insert(db, item);
				db.SaveChanges();
			}
		}
		#endregion

		#region Insert処理
		/// <summary>
		/// Insert処理
		/// </summary>
		/// <param name="db">SQLiteDataContext</param>
		/// <param name="item">Insertする要素</param>
		public static void Insert(SQLiteDataContext db, FollowBackListBase item)
		{
			// Insert
			db.Add<FollowBackListBase>(item);
		}
		#endregion

		#region Update処理
		/// <summary>
		/// Update処理
		/// </summary>
		/// <param name="pk_item">更新する主キー（主キーの値のみ入っていれば良い）</param>
		/// <param name="update_item">テーブル更新後の状態</param>
		public static void Update(FollowBackListBase pk_item, FollowBackListBase update_item)
		{
			using (var db = new SQLiteDataContext())
			{
				Update(db, pk_item, update_item);
				db.SaveChanges();
			}
		}
		#endregion

		#region Update処理
		/// <summary>
		/// Update処理
		/// </summary>
		/// <param name="db">SQLiteDataContext</param>
		/// <param name="pk_item">更新する主キー（主キーの値のみ入っていれば良い）</param>
		/// <param name="update_item">テーブル更新後の状態</param>
		public static void Update(SQLiteDataContext db, FollowBackListBase pk_item, FollowBackListBase update_item)
		{
			var item = db.DbSet_FollowBackList.SingleOrDefault(x => x.UserId.Equals(pk_item.UserId));

			if (item != null)
			{
				item.Copy(update_item);
			}
		}
		#endregion

		#region Delete処理
		/// <summary>
		/// Delete処理
		/// </summary>
		/// <param name="pk_item">削除する主キー（主キーの値のみ入っていれば良い）</param>
		public static void Delete(FollowBackListBase pk_item)
		{
			using (var db = new SQLiteDataContext())
			{
				Delete(db, pk_item);
				db.SaveChanges();
			}
		}
		#endregion

		#region Delete処理
		/// <summary>
		/// Delete処理
		/// </summary>
		/// <param name="db">SQLiteDataContext</param>
		/// <param name="pk_item">削除する主キー（主キーの値のみ入っていれば良い）</param>
		public static void Delete(SQLiteDataContext db, FollowBackListBase pk_item)
		{
			var item = db.DbSet_FollowBackList.SingleOrDefault(x => x.UserId.Equals(pk_item.UserId));
			if (item != null)
			{
				db.DbSet_FollowBackList.Remove(item);
			}
		}
		#endregion

		#region Select処理
		/// <summary>
		/// Select処理
		/// </summary>
		/// <returns>全件取得</returns>
		public static List<FollowBackListBase> Select()
		{
			using (var db = new SQLiteDataContext())
			{
				return Select(db);
			}
		}
		#endregion

		#region Select処理
		/// <summary>
		/// Select処理
		/// </summary>
		/// <param name="db">SQLiteDataContext</param>
		/// <returns>全件取得</returns>
		public static List<FollowBackListBase> Select(SQLiteDataContext db)
		{
			return db.DbSet_FollowBackList.ToList<FollowBackListBase>();
		}
		#endregion
		#endregion

		#region INotifyPropertyChanged 
		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}
		#endregion
	}
}
