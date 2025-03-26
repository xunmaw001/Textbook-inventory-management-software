using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Xiezn.Core.Models.DbModel
{
    /// <summary>
    ///	Desc: 公告资讯
    /// </summary>
    [SugarTable("news")]
	public class NewsDbModel
	{           
		/// <summary>
		/// Desc: 主键Id
		/// </summary>
		[SugarColumn(IsPrimaryKey = true, ColumnName = "id")]
		public long Id { get; set; }

		/// <summary>
		/// Desc: 标题
		/// </summary>
		[SugarColumn(ColumnName = "title")]
		public string Title { get; set; }

		/// <summary>
		/// Desc: 简介
		/// </summary>
		[SugarColumn(ColumnName = "introduction")]
		public string Introduction { get; set; }

		/// <summary>
		/// Desc: 图片
		/// </summary>
		[SugarColumn(ColumnName = "picture")]
		public string Picture { get; set; }

		/// <summary>
		/// Desc: 内容
		/// </summary>
		[SugarColumn(ColumnName = "content")]
		public string Content { get; set; }

		/// <summary>
		/// Desc: 添加时间
		/// </summary>
		[SugarColumn(ColumnName = "addtime")]
		public DateTime? Addtime { get; set; } = DateTime.Now;

	}
}
