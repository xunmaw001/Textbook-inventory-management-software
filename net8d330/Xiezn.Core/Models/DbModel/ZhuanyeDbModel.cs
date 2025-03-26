using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Xiezn.Core.Models.DbModel
{
    /// <summary>
    ///	Desc: 专业
    /// </summary>
    [SugarTable("zhuanye")]
	public class ZhuanyeDbModel
	{           
		/// <summary>
		/// Desc: 主键Id
		/// </summary>
		[SugarColumn(IsPrimaryKey = true, ColumnName = "id")]
		public long Id { get; set; }

		/// <summary>
		/// Desc: 专业
		/// </summary>
		[SugarColumn(ColumnName = "zhuanye")]
		public string Zhuanye { get; set; }

		/// <summary>
		/// Desc: 添加时间
		/// </summary>
		[SugarColumn(ColumnName = "addtime")]
		public DateTime? Addtime { get; set; } = DateTime.Now;

	}
}
