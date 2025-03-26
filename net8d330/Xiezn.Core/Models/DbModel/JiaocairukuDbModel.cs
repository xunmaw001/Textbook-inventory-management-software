using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Xiezn.Core.Models.DbModel
{
    /// <summary>
    ///	Desc: 教材入库
    /// </summary>
    [SugarTable("jiaocairuku")]
	public class JiaocairukuDbModel
	{           
		/// <summary>
		/// Desc: 主键Id
		/// </summary>
		[SugarColumn(IsPrimaryKey = true, ColumnName = "id")]
		public long Id { get; set; }

		/// <summary>
		/// Desc: 入库编号
		/// </summary>
		[SugarColumn(ColumnName = "rukubianhao")]
		public string Rukubianhao { get; set; }

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
		/// Desc: 入库时间
		/// </summary>
        [SugarColumn(ColumnName = "rukushijian")]
		public DateTime Rukushijian { get; set; }

		/// <summary>
		/// Desc: 入库数量
		/// </summary>
        [SugarColumn(ColumnName = "shuliang")]
		public int? Shuliang { get; set; } = 0;

		/// <summary>
		/// Desc: 规格
		/// </summary>
		[SugarColumn(ColumnName = "guige")]
		public string Guige { get; set; }

		/// <summary>
		/// Desc: 入库详情
		/// </summary>
		[SugarColumn(ColumnName = "rukuxiangqing")]
		public string Rukuxiangqing { get; set; }

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
