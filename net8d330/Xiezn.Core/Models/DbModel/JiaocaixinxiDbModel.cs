using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Xiezn.Core.Models.DbModel
{
    /// <summary>
    ///	Desc: 教材信息
    /// </summary>
    [SugarTable("jiaocaixinxi")]
	public class JiaocaixinxiDbModel
	{           
		/// <summary>
		/// Desc: 主键Id
		/// </summary>
		[SugarColumn(IsPrimaryKey = true, ColumnName = "id")]
		public long Id { get; set; }

		/// <summary>
		/// Desc: 所属学院
		/// </summary>
		[SugarColumn(ColumnName = "xueyuan")]
		public string Xueyuan { get; set; }

		/// <summary>
		/// Desc: 所属专业
		/// </summary>
		[SugarColumn(ColumnName = "zhuanye")]
		public string Zhuanye { get; set; }

		/// <summary>
		/// Desc: 所属年级
		/// </summary>
		[SugarColumn(ColumnName = "nianji")]
		public string Nianji { get; set; }

		/// <summary>
		/// Desc: 教材标题
		/// </summary>
		[SugarColumn(ColumnName = "jiaocaibiaoti")]
		public string Jiaocaibiaoti { get; set; }

		/// <summary>
		/// Desc: 教材分类
		/// </summary>
		[SugarColumn(ColumnName = "jiaocaifenlei")]
		public string Jiaocaifenlei { get; set; }

		/// <summary>
		/// Desc: 教材封面
		/// </summary>
		[SugarColumn(ColumnName = "jiaocaifengmian")]
		public string Jiaocaifengmian { get; set; }

		/// <summary>
		/// Desc: 库存
		/// </summary>
        [SugarColumn(ColumnName = "shuliang")]
		public int? Shuliang { get; set; } = 0;

		/// <summary>
		/// Desc: 规格
		/// </summary>
		[SugarColumn(ColumnName = "guige")]
		public string Guige { get; set; }

		/// <summary>
		/// Desc: 教材简介
		/// </summary>
		[SugarColumn(ColumnName = "jiaocaijianjie")]
		public string Jiaocaijianjie { get; set; }

		/// <summary>
		/// Desc: 教材详情
		/// </summary>
		[SugarColumn(ColumnName = "jiaocaixiangqing")]
		public string Jiaocaixiangqing { get; set; }

		/// <summary>
		/// Desc: 添加时间
		/// </summary>
		[SugarColumn(ColumnName = "addtime")]
		public DateTime? Addtime { get; set; } = DateTime.Now;

	}
}
