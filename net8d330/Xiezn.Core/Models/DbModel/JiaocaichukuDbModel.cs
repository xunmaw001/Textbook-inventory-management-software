using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Xiezn.Core.Models.DbModel
{
    /// <summary>
    ///	Desc: 教材出库
    /// </summary>
    [SugarTable("jiaocaichuku")]
	public class JiaocaichukuDbModel
	{           
		/// <summary>
		/// Desc: 主键Id
		/// </summary>
		[SugarColumn(IsPrimaryKey = true, ColumnName = "id")]
		public long Id { get; set; }

		/// <summary>
		/// Desc: 出库编号
		/// </summary>
		[SugarColumn(ColumnName = "chukubianhao")]
		public string Chukubianhao { get; set; }

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
		/// Desc: 出库时间
		/// </summary>
        [SugarColumn(ColumnName = "chukushijian")]
		public DateTime Chukushijian { get; set; }

		/// <summary>
		/// Desc: 教材封面
		/// </summary>
		[SugarColumn(ColumnName = "jiaocaifengmian")]
		public string Jiaocaifengmian { get; set; }

		/// <summary>
		/// Desc: 出库数量
		/// </summary>
        [SugarColumn(ColumnName = "shuliang")]
		public int? Shuliang { get; set; } = 0;

		/// <summary>
		/// Desc: 规格
		/// </summary>
		[SugarColumn(ColumnName = "guige")]
		public string Guige { get; set; }

		/// <summary>
		/// Desc: 出库详情
		/// </summary>
		[SugarColumn(ColumnName = "chukuxiangqing")]
		public string Chukuxiangqing { get; set; }

		/// <summary>
		/// Desc: 用户账号
		/// </summary>
		[SugarColumn(ColumnName = "yonghuzhanghao")]
		public string Yonghuzhanghao { get; set; }

		/// <summary>
		/// Desc: 用户姓名
		/// </summary>
		[SugarColumn(ColumnName = "yonghuxingming")]
		public string Yonghuxingming { get; set; }

		/// <summary>
		/// Desc: 添加时间
		/// </summary>
		[SugarColumn(ColumnName = "addtime")]
		public DateTime? Addtime { get; set; } = DateTime.Now;

	}
}
