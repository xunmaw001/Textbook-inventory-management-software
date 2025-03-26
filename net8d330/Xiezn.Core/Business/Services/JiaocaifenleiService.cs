using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xiezn.Core.Common.Helpers;
using Xiezn.Core.Models;
using Xiezn.Core.Models.DbModel;


namespace Xiezn.Core.Business.Services
{
    public class JiaocaifenleiService : BaseService<JiaocaifenleiDbModel>
    {
        private readonly long _uid;
        private readonly string _role;

        public JiaocaifenleiService()
        {
            try
            {
                if (CacheHelper.TokenModel != null)
                {
                    _uid = CacheHelper.TokenModel.Uid;
                    _role = CacheHelper.TokenModel.Role;
                }
            }
            catch
            {
                _uid = 0;
                _role = "游客";
            }
        }






        public PageModel<JiaocaifenleiDbModel> GetPageList(int page, int limit, string sort, string order, List<IConditionalModel> conModels)
        {
            PageModel pageModel = new PageModel() { PageIndex = page, PageSize = limit };

            int totalNumber = 0;
            int totalPage = 0;

            string dbColumnName = Db.EntityMaintenance.GetDbColumnName<JiaocaifenleiDbModel>(sort);
            order = order.ToLower() == "asc" ? "ASC" : "DESC";


            List<JiaocaifenleiDbModel> ts = Db.Queryable<JiaocaifenleiDbModel>().Where(conModels).OrderBy(dbColumnName + " " + order).ToPageList(page, limit, ref totalNumber, ref totalPage);


            PageModel<JiaocaifenleiDbModel> t = new PageModel<JiaocaifenleiDbModel>()
            {
                Code = ResponseCodeEnum.Success,
                Data = new Page<JiaocaifenleiDbModel>()
                {
                    Total = totalNumber,
                    PageSize = limit,
                    TotalPage = totalPage,
                    CurrPage = page,
                    List = ts
                }
            };

            return t;
        }








    }
}
