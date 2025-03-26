<template>
	<div class="main-content" :style='{"minHeight":"100vh","padding":"30px","background":"url(http://codegen.caihongy.cn/20230329/eff4ea96c952463cb46b9c79d043ce56.gif) fixed,#f6f6f6"}'>
		<!-- 列表页 -->
		<template v-if="showFlag">
			<el-form class="center-form-pv" :style='{"margin":"0 0 0px"}' :inline="true" :model="searchForm">
				<el-row :style='{"padding":"0px","margin":"0 auto 20px","borderRadius":"3px","textAlign":"center","background":"none","display":"block"}' >
					<div :style='{"margin":"0 10px 0 0","display":"inline-block"}' class="select" label="所属学院" prop="xueyuan">
						<label :style='{"margin":"0 10px 0 0","color":"#666","display":"inline-block","lineHeight":"50px","fontSize":"16px","fontWeight":"500","height":"50px"}' class="item-label">所属学院</label>
						<el-select  @change="xueyuanChange" clearable v-model="searchForm.xueyuan" placeholder="请选择所属学院">
							<el-option v-for="(item,index) in xueyuanOptions" v-bind:key="index" :label="item" :value="item"></el-option>
						</el-select>
					</div>
					<div :style='{"margin":"0 10px 0 0","display":"inline-block"}' class="select" label="所属专业" prop="zhuanye">
						<label :style='{"margin":"0 10px 0 0","color":"#666","display":"inline-block","lineHeight":"50px","fontSize":"16px","fontWeight":"500","height":"50px"}' class="item-label">所属专业</label>
						<el-select  @change="zhuanyeChange" clearable v-model="searchForm.zhuanye" placeholder="请选择所属专业">
							<el-option v-for="(item,index) in zhuanyeOptions" v-bind:key="index" :label="item" :value="item"></el-option>
						</el-select>
					</div>
					<div :style='{"margin":"0 10px 0 0","display":"inline-block"}' class="select" label="所属年级" prop="nianji">
						<label :style='{"margin":"0 10px 0 0","color":"#666","display":"inline-block","lineHeight":"50px","fontSize":"16px","fontWeight":"500","height":"50px"}' class="item-label">所属年级</label>
						<el-select  @change="nianjiChange" clearable v-model="searchForm.nianji" placeholder="请选择所属年级">
							<el-option v-for="(item,index) in nianjiOptions" v-bind:key="index" :label="item" :value="item"></el-option>
						</el-select>
					</div>
					<div :style='{"margin":"0 10px 0 0","display":"inline-block"}'>
						<label :style='{"margin":"0 10px 0 0","color":"#666","display":"inline-block","lineHeight":"50px","fontSize":"16px","fontWeight":"500","height":"50px"}' class="item-label">教材标题</label>
						<el-input v-model="searchForm.jiaocaibiaoti" placeholder="教材标题" clearable></el-input>
					</div>
					<div :style='{"margin":"0 10px 0 0","display":"inline-block"}' class="select" label="教材分类" prop="jiaocaifenlei">
						<label :style='{"margin":"0 10px 0 0","color":"#666","display":"inline-block","lineHeight":"50px","fontSize":"16px","fontWeight":"500","height":"50px"}' class="item-label">教材分类</label>
						<el-select  @change="jiaocaifenleiChange" clearable v-model="searchForm.jiaocaifenlei" placeholder="请选择教材分类">
							<el-option v-for="(item,index) in jiaocaifenleiOptions" v-bind:key="index" :label="item" :value="item"></el-option>
						</el-select>
					</div>
					<el-button :style='{"border":"0px solid #f2cd41","cursor":"pointer","padding":"0 34px","outline":"none","margin":"0 0px 0 10px","color":"#333","borderRadius":"0px","background":"#FFCC33","width":"auto","fontSize":"16px","minWidth":"100px","height":" 50px"}' type="success" @click="search()">查询</el-button>
				</el-row>

				<el-row :style='{"padding":"16px 12px 10px","margin":"0 0 0px","borderColor":"#e2f0e2","flexWrap":"wrap","background":"#fff","borderWidth":"1px 1px 0 1px","display":"flex","width":"auto","borderStyle":"solid","justifyContent":"flex-end","zIndex":"999"}'>
					<el-button :style='{"border":"0","cursor":"pointer","padding":"0 16px","margin":"0 10px 6px 0","borderColor":"#666","color":"#333","outline":"none","borderRadius":"0px","background":"#f9c535","borderWidth":"0 0 0px","width":"auto","fontSize":"16px","borderStyle":"solid","height":"36px"}' v-if="isAuth('jiaocaixinxi','新增')" type="success" @click="addOrUpdateHandler()">新增</el-button>
					<el-button :style='{"border":"0","cursor":"pointer","padding":"0 16px","margin":"0 10px 6px 0","borderColor":"#666","color":"#333","outline":"none","borderRadius":"0px","background":"#f9c535","borderWidth":"0 0 0px","width":"auto","fontSize":"16px","borderStyle":"solid","height":"36px"}' v-if="isAuth('jiaocaixinxi','删除')" :disabled="dataListSelections.length <= 0" type="danger" @click="deleteHandler()">删除</el-button>




				</el-row>
			</el-form>
			
			<!-- <div> -->
				<el-table class="tables"
					:stripe='true'
					:style='{"padding":"0","borderColor":"#e2f0e2","margin":"0 0 20px","borderRadius":"5px","borderWidth":"1px 0 0 1px","background":"#fff","width":"calc(100% - 0px)","borderStyle":"solid"}' 
					v-if="isAuth('jiaocaixinxi','查看')"
					:data="dataList"
					v-loading="dataListLoading"
				@selection-change="selectionChangeHandler">
					<el-table-column :resizable='true' type="selection" align="center" width="50"></el-table-column>
					<el-table-column :resizable='true' :sortable='true' label="索引" type="index" width="50" />
					<el-table-column :resizable='true' :sortable='true'  
						prop="xueyuan"
					label="所属学院">
						<template slot-scope="scope">
							{{scope.row.xueyuan}}
						</template>
					</el-table-column>
					<el-table-column :resizable='true' :sortable='true'  
						prop="zhuanye"
					label="所属专业">
						<template slot-scope="scope">
							{{scope.row.zhuanye}}
						</template>
					</el-table-column>
					<el-table-column :resizable='true' :sortable='true'  
						prop="nianji"
					label="所属年级">
						<template slot-scope="scope">
							{{scope.row.nianji}}
						</template>
					</el-table-column>
					<el-table-column :resizable='true' :sortable='true'  
						prop="jiaocaibiaoti"
					label="教材标题">
						<template slot-scope="scope">
							{{scope.row.jiaocaibiaoti}}
						</template>
					</el-table-column>
					<el-table-column :resizable='true' :sortable='true'  
						prop="jiaocaifenlei"
					label="教材分类">
						<template slot-scope="scope">
							{{scope.row.jiaocaifenlei}}
						</template>
					</el-table-column>
					<el-table-column :resizable='true' :sortable='true' prop="jiaocaifengmian" width="200" label="教材封面">
						<template slot-scope="scope">
							<div v-if="scope.row.jiaocaifengmian">
								<img v-if="scope.row.jiaocaifengmian.substring(0,4)=='http'" :src="scope.row.jiaocaifengmian.split(',')[0]" width="100" height="100">
								<img v-else :src="$base.url+scope.row.jiaocaifengmian.split(',')[0]" width="100" height="100">
							</div>
							<div v-else>无图片</div>
						</template>
					</el-table-column>
					<el-table-column :resizable='true' :sortable='true'  
						prop="shuliang"
					label="库存">
						<template slot-scope="scope">
							{{scope.row.shuliang}}
						</template>
					</el-table-column>
					<el-table-column :resizable='true' :sortable='true'  
						prop="guige"
					label="规格">
						<template slot-scope="scope">
							{{scope.row.guige}}
						</template>
					</el-table-column>
					<el-table-column width="300" label="操作">
						<template slot-scope="scope">
							<el-button :style='{"border":"0px solid #1e98f5","cursor":"pointer","padding":"0 10px 0 24px","margin":"0 5px 6px","outline":"none","color":"#1e98f5","borderRadius":"0px","background":"url(http://codegen.caihongy.cn/20230329/38553f099fa74a2d86e2206c373a9539.png) no-repeat left center / 20px","width":"auto","fontSize":"15px","height":"32px"}' v-if=" isAuth('jiaocaixinxi','查看')" type="success" size="mini" @click="addOrUpdateHandler(scope.row.id,'info')">详情</el-button>
							<el-button :style='{"border":"0px solid #1e98f5","cursor":"pointer","padding":"0 10px 0 24px","margin":"0 5px 6px","outline":"none","color":"#1e98f5","borderRadius":"0px","background":"url(http://codegen.caihongy.cn/20230329/38553f099fa74a2d86e2206c373a9539.png) no-repeat left center / 20px","width":"auto","fontSize":"15px","height":"32px"}' v-if="isAuth('jiaocaixinxi','教材入库')" type="success" size="mini" @click="jiaocairukuCrossAddOrUpdateHandler(scope.row,'cross','','','')">教材入库</el-button>
							<el-button :style='{"border":"0px solid #1e98f5","cursor":"pointer","padding":"0 10px 0 24px","margin":"0 5px 6px","outline":"none","color":"#1e98f5","borderRadius":"0px","background":"url(http://codegen.caihongy.cn/20230329/38553f099fa74a2d86e2206c373a9539.png) no-repeat left center / 20px","width":"auto","fontSize":"15px","height":"32px"}' v-if="isAuth('jiaocaixinxi','教材出库')" type="success" size="mini" @click="jiaocaichukuCrossAddOrUpdateHandler(scope.row,'cross','','','')">教材出库</el-button>
							<el-button :style='{"border":"0px solid #06d5dd","cursor":"pointer","padding":"0 10px 0 24px","margin":"0 5px 6px","outline":"none","color":"#15a4aa","borderRadius":"0px","background":"url(http://codegen.caihongy.cn/20230329/99f867042acb4c4aae637c8bfcf6714a.png) no-repeat left center","width":"auto","fontSize":"15px","height":"32px"}' v-if=" isAuth('jiaocaixinxi','修改')" type="primary" size="mini" @click="addOrUpdateHandler(scope.row.id)">修改</el-button>





							<el-button :style='{"border":"0px solid #c00","cursor":"pointer","padding":"0 10px 0 24px","margin":"0 5px 6px","outline":"none","color":"#c00","borderRadius":"0px","background":"url(http://codegen.caihongy.cn/20230329/c5ea125f385740a3a3b9aed07f5dfe2c.png) no-repeat left 6px / 20px","width":"auto","fontSize":"14px","height":"32px"}' v-if="isAuth('jiaocaixinxi','删除') " type="danger" size="mini" @click="deleteHandler(scope.row.id)">删除</el-button>
						</template>
					</el-table-column>
				</el-table>
				<el-pagination
					@size-change="sizeChangeHandle"
					@current-change="currentChangeHandle"
					:current-page="pageIndex"
					background
					:page-sizes="[10, 20, 30, 50]"
					:page-size="pageSize"
					:layout="layouts.join()"
					:total="totalPage"
					prev-text="<"
					next-text=">"
					:hide-on-single-page="true"
					:style='{"width":"calc(100% - 370px)","padding":"0","margin":"0 170px 0px 200px","whiteSpace":"nowrap","color":"#333","fontWeight":"500"}'
				></el-pagination>
			<!-- </div> -->
		</template>
		
		<!-- 添加/修改页面  将父组件的search方法传递给子组件-->
		<add-or-update v-if="addOrUpdateFlag" :parent="this" ref="addOrUpdate"></add-or-update>

		<jiaocairuku-cross-add-or-update v-if="jiaocairukuCrossAddOrUpdateFlag" :parent="this" ref="jiaocairukuCrossaddOrUpdate"></jiaocairuku-cross-add-or-update>
		<jiaocaichuku-cross-add-or-update v-if="jiaocaichukuCrossAddOrUpdateFlag" :parent="this" ref="jiaocaichukuCrossaddOrUpdate"></jiaocaichuku-cross-add-or-update>




	</div>
</template>

<script>
//$graphType1
//$buttonName1
//$subNameList1
import axios from 'axios'
import AddOrUpdate from "./add-or-update";
import jiaocairukuCrossAddOrUpdate from "../jiaocairuku/add-or-update";
import jiaocaichukuCrossAddOrUpdate from "../jiaocaichuku/add-or-update";
export default {
  data() {
    return {
      xueyuanOptions: [],
      zhuanyeOptions: [],
      nianjiOptions: [],
      jiaocaifenleiOptions: [],
      searchForm: {
        key: ""
      },
      form:{},
      dataList: [],
      pageIndex: 1,
      pageSize: 10,
      totalPage: 0,
      dataListLoading: false,
      dataListSelections: [],
      showFlag: true,
      sfshVisiable: false,
      shForm: {},
      chartVisiable: false,
      chartVisiable1: false,
      chartVisiable2: false,
      chartVisiable3: false,
      chartVisiable4: false,
      chartVisiable5: false,
      addOrUpdateFlag:false,
      jiaocairukuCrossAddOrUpdateFlag: false,
      jiaocaichukuCrossAddOrUpdateFlag: false,
      layouts: ["total","prev","pager","next","sizes","jumper"],

    };
  },
  created() {
    this.init();
    this.getDataList();
    this.contentStyleChange()
  },
  mounted() {
  },
  filters: {
    htmlfilter: function (val) {
      return val.replace(/<[^>]*>/g).replace(/undefined/g,'');
    }
  },
  components: {
    AddOrUpdate,
    jiaocairukuCrossAddOrUpdate,
    jiaocaichukuCrossAddOrUpdate,
  },
  methods: {

    contentStyleChange() {
      this.contentPageStyleChange()
    },
    // 分页
    contentPageStyleChange(){
      let arr = []

      // if(this.contents.pageTotal) arr.push('total')
      // if(this.contents.pageSizes) arr.push('sizes')
      // if(this.contents.pagePrevNext){
      //   arr.push('prev')
      //   if(this.contents.pagePager) arr.push('pager')
      //   arr.push('next')
      // }
      // if(this.contents.pageJumper) arr.push('jumper')
      // this.layouts = arr.join()
      // this.contents.pageEachNum = 10
    },

    jiaocairukuCrossAddOrUpdateHandler(row,type,crossOptAudit,statusColumnName,tips,statusColumnValue){
      this.showFlag = false;
      this.addOrUpdateFlag = false;
      this.jiaocairukuCrossAddOrUpdateFlag = true;
      this.$storage.set('crossObj',row);
      this.$storage.set('crossTable','jiaocaixinxi');
      this.$storage.set('statusColumnName',statusColumnName);
      this.$storage.set('statusColumnValue',statusColumnValue);
      this.$storage.set('tips',tips);
	if(statusColumnName!=''&&!statusColumnName.startsWith("[")) {
		var obj = this.$storage.getObj('crossObj');
		for (var o in obj){
		  if(o==statusColumnName && obj[o]==statusColumnValue){
		    this.$message({
		      message: tips,
		      type: "success",
		      duration: 1500,
		      onClose: () => {
			this.getDataList();
		      }
		    });
		      this.showFlag = true;
		      this.jiaocairukuCrossAddOrUpdateFlag = false;
			return;
		  }
		}
	}
      this.$nextTick(() => {
      this.$refs.jiaocairukuCrossaddOrUpdate.init(row.id,type);
      });
    },
    jiaocaichukuCrossAddOrUpdateHandler(row,type,crossOptAudit,statusColumnName,tips,statusColumnValue){
      this.showFlag = false;
      this.addOrUpdateFlag = false;
      this.jiaocaichukuCrossAddOrUpdateFlag = true;
      this.$storage.set('crossObj',row);
      this.$storage.set('crossTable','jiaocaixinxi');
      this.$storage.set('statusColumnName',statusColumnName);
      this.$storage.set('statusColumnValue',statusColumnValue);
      this.$storage.set('tips',tips);
	if(statusColumnName!=''&&!statusColumnName.startsWith("[")) {
		var obj = this.$storage.getObj('crossObj');
		for (var o in obj){
		  if(o==statusColumnName && obj[o]==statusColumnValue){
		    this.$message({
		      message: tips,
		      type: "success",
		      duration: 1500,
		      onClose: () => {
			this.getDataList();
		      }
		    });
		      this.showFlag = true;
		      this.jiaocaichukuCrossAddOrUpdateFlag = false;
			return;
		  }
		}
	}
      this.$nextTick(() => {
      this.$refs.jiaocaichukuCrossaddOrUpdate.init(row.id,type);
      });
    },







    init () {
          this.$http({
            url: `option/xueyuan/xueyuan`,
            method: "get"
          }).then(({ data }) => {
            if (data && data.code === 0) {
              this.xueyuanOptions = data.data;
            } else {
              this.$message.error(data.msg);
            }
          });
          this.$http({
            url: `option/zhuanye/zhuanye`,
            method: "get"
          }).then(({ data }) => {
            if (data && data.code === 0) {
              this.zhuanyeOptions = data.data;
            } else {
              this.$message.error(data.msg);
            }
          });
          this.$http({
            url: `option/nianji/nianji`,
            method: "get"
          }).then(({ data }) => {
            if (data && data.code === 0) {
              this.nianjiOptions = data.data;
            } else {
              this.$message.error(data.msg);
            }
          });
          this.$http({
            url: `option/jiaocaifenlei/jiaocaifenlei`,
            method: "get"
          }).then(({ data }) => {
            if (data && data.code === 0) {
              this.jiaocaifenleiOptions = data.data;
            } else {
              this.$message.error(data.msg);
            }
          });
    },
    search() {
      this.pageIndex = 1;
      this.getDataList();
    },

    // 获取数据列表
    getDataList() {
      this.dataListLoading = true;
      let params = {
        page: this.pageIndex,
        limit: this.pageSize,
        sort: 'id',
        order: 'desc',
      }
           if(this.searchForm.xueyuan!='' && this.searchForm.xueyuan!=undefined){
            params['xueyuan'] = this.searchForm.xueyuan
          }
           if(this.searchForm.zhuanye!='' && this.searchForm.zhuanye!=undefined){
            params['zhuanye'] = this.searchForm.zhuanye
          }
           if(this.searchForm.nianji!='' && this.searchForm.nianji!=undefined){
            params['nianji'] = this.searchForm.nianji
          }
           if(this.searchForm.jiaocaibiaoti!='' && this.searchForm.jiaocaibiaoti!=undefined){
            params['jiaocaibiaoti'] = '%' + this.searchForm.jiaocaibiaoti + '%'
          }
           if(this.searchForm.jiaocaifenlei!='' && this.searchForm.jiaocaifenlei!=undefined){
            params['jiaocaifenlei'] = this.searchForm.jiaocaifenlei
          }
      this.$http({
        url: "jiaocaixinxi/page",
        method: "get",
        params: params
      }).then(({ data }) => {
        if (data && data.code === 0) {
          this.dataList = data.data.list;
          this.totalPage = data.data.total;
        } else {
          this.dataList = [];
          this.totalPage = 0;
        }
        this.dataListLoading = false;
      });
    },
    // 每页数
    sizeChangeHandle(val) {
      this.pageSize = val;
      this.pageIndex = 1;
      this.getDataList();
    },
    // 当前页
    currentChangeHandle(val) {
      this.pageIndex = val;
      this.getDataList();
    },
    // 多选
    selectionChangeHandler(val) {
      this.dataListSelections = val;
    },
    // 添加/修改
    addOrUpdateHandler(id,type) {
      this.showFlag = false;
      this.addOrUpdateFlag = true;
      this.crossAddOrUpdateFlag = false;
      if(type!='info'){
        type = 'else';
      }
      this.$nextTick(() => {
        this.$refs.addOrUpdate.init(id,type);
      });
    },
    // 下载
    download(file){
      window.open(`${file}`)
    },
    // 删除
    deleteHandler(id) {
      var ids = id
        ? [Number(id)]
        : this.dataListSelections.map(item => {
            return Number(item.id);
          });
      this.$confirm(`确定进行[${id ? "删除" : "批量删除"}]操作?`, "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning"
      }).then(() => {
        this.$http({
          url: "jiaocaixinxi/delete",
          method: "post",
          data: ids
        }).then(({ data }) => {
          if (data && data.code === 0) {
            this.$message({
              message: "操作成功",
              type: "success",
              duration: 1500,
              onClose: () => {
                this.search();
              }
            });
          } else {
            this.$message.error(data.msg);
          }
        });
      });
    },


  }

};
</script>
<style lang="scss" scoped>
	
	.center-form-pv {
	  .el-date-editor.el-input {
	    width: auto;
	  }
	}
	
	.el-input {
	  width: auto;
	}
	
	// form
	.center-form-pv .el-input /deep/ .el-input__inner {
				border: 1px solid #eee;
				border-radius: 0px;
				padding: 0 12px;
				box-shadow: 0 0px 0px #ccc;
				outline: none;
				color: #999;
				width: 170px;
				font-size: 16px;
				height: 50px;
			}
	
	.center-form-pv .el-select /deep/ .el-input__inner {
				border: 1px solid #eee;
				border-radius: 0px;
				padding: 0 10px;
				box-shadow: 0 0px 0px #ccc;
				outline: none;
				color: #999;
				width: 170px;
				font-size: 16px;
				line-height: 30px;
				height: 50px;
			}
	
	.center-form-pv .el-date-editor /deep/ .el-input__inner {
				border: 1px solid #eee;
				border-radius: 0px;
				padding: 0 10px 0 30px;
				box-shadow: 0 0px 0px #ccc;
				outline: none;
				color: #999;
				width: 170px;
				font-size: 16px;
				height: 50px;
			}
	
	// table
	.el-table /deep/ .el-table__header-wrapper thead {
				color: #999;
				font-weight: 500;
				width: 100%;
			}
	
	.el-table /deep/ .el-table__header-wrapper thead tr {
				background: #fff;
			}
	
	.el-table /deep/ .el-table__header-wrapper thead tr th {
				padding: 10px;
				color: #000;
				background: #e4f9e4;
				border-color: #e2f0e2;
				border-width: 0 1px 1px 0;
				border-style: solid;
				text-align: left;
			}

	.el-table /deep/ .el-table__header-wrapper thead tr th .cell {
				padding: 0 10px;
				word-wrap: normal;
				word-break: break-all;
				white-space: normal;
				font-weight: bold;
				display: inline-block;
				vertical-align: middle;
				width: 100%;
				line-height: 24px;
				position: relative;
				text-overflow: ellipsis;
			}

	
	.el-table /deep/ .el-table__body-wrapper tbody {
				width: 100%;
			}

	.el-table /deep/ .el-table__body-wrapper tbody tr {
				background: none;
			}
	
	.el-table /deep/ .el-table__body-wrapper tbody tr td {
				padding: 2px 10px;
				color: #666;
				background: none;
				border-color: #e2f0e2;
				border-width: 0 1px 1px 0;
				border-style: solid;
				text-align: left;
			}
	
		.el-table /deep/ .el-table__body-wrapper tbody tr.el-table__row--striped td {
		background: rgba(246,254,246,.5);
	}
		
	.el-table /deep/ .el-table__body-wrapper tbody tr:hover td {
				padding: 2px 10px;
				color: #999;
				background: rgba(228,249,228,.6);
				border-color: #e2f0e2;
				border-width: 0 1px 1px 0;
				border-style: solid;
				text-align: left;
			}
	
	.el-table /deep/ .el-table__body-wrapper tbody tr td {
				padding: 2px 10px;
				color: #666;
				background: none;
				border-color: #e2f0e2;
				border-width: 0 1px 1px 0;
				border-style: solid;
				text-align: left;
			}

	.el-table /deep/ .el-table__body-wrapper tbody tr td .cell {
				padding: 0 10px;
				overflow: hidden;
				word-break: break-all;
				white-space: normal;
				line-height: 24px;
				text-overflow: ellipsis;
			}
	
	// pagination
	.main-content .el-pagination /deep/ .el-pagination__total {
				margin: 0 10px 0 0;
				color: #666;
				font-weight: 400;
				display: inline-block;
				vertical-align: top;
				font-size: 16px;
				line-height: 28px;
				height: 28px;
			}
	
	.main-content .el-pagination /deep/ .btn-prev {
				border: none;
				border-radius: 30px;
				padding: 0;
				margin: 0 5px;
				color: #666;
				background: #f4f4f5;
				display: inline-block;
				vertical-align: top;
				font-size: 16px;
				line-height: 28px;
				min-width: 35px;
				height: 28px;
			}
	
	.main-content .el-pagination /deep/ .btn-next {
				border: none;
				border-radius: 30px;
				padding: 0;
				margin: 0 5px;
				color: #666;
				background: #f4f4f5;
				display: inline-block;
				vertical-align: top;
				font-size: 16px;
				line-height: 28px;
				min-width: 35px;
				height: 28px;
			}
	
	.main-content .el-pagination /deep/ .btn-prev:disabled {
				border: none;
				cursor: not-allowed;
				border-radius: 30px;
				padding: 0;
				margin: 0 5px;
				color: #C0C4CC;
				background: #f4f4f5;
				display: inline-block;
				vertical-align: top;
				font-size: 16px;
				line-height: 28px;
				height: 28px;
			}
	
	.main-content .el-pagination /deep/ .btn-next:disabled {
				border: none;
				cursor: not-allowed;
				border-radius: 30px;
				padding: 0;
				margin: 0 5px;
				color: #C0C4CC;
				background: #f4f4f5;
				display: inline-block;
				vertical-align: top;
				font-size: 16px;
				line-height: 28px;
				height: 28px;
			}

	.main-content .el-pagination /deep/ .el-pager {
				padding: 0;
				margin: 0;
				display: inline-block;
				vertical-align: top;
			}

	.main-content .el-pagination /deep/ .el-pager .number {
				cursor: pointer;
				padding: 0 4px;
				margin: 0 5px;
				color: #666;
				display: inline-block;
				vertical-align: top;
				font-size: 16px;
				line-height: 28px;
				border-radius: 30px;
				background: #f4f4f5;
				text-align: center;
				min-width: 30px;
				height: 28px;
			}
	
	.main-content .el-pagination /deep/ .el-pager .number:hover {
				cursor: pointer;
				padding: 0 4px;
				margin: 0 5px;
				color: #333;
				display: inline-block;
				vertical-align: top;
				font-size: 16px;
				line-height: 28px;
				border-radius: 30px;
				background: #e8e6d4;
				text-align: center;
				min-width: 30px;
				height: 28px;
			}
	
	.main-content .el-pagination /deep/ .el-pager .number.active {
				cursor: default;
				padding: 0 4px;
				margin: 0 5px;
				color: #333;
				display: inline-block;
				vertical-align: top;
				font-size: 16px;
				line-height: 28px;
				border-radius: 30px;
				background: #e8e6d4;
				text-align: center;
				min-width: 30px;
				height: 28px;
			}
	
	.main-content .el-pagination /deep/ .el-pagination__sizes {
				display: inline-block;
				vertical-align: top;
				font-size: 16px;
				line-height: 28px;
				height: 28px;
			}
	
	.main-content .el-pagination /deep/ .el-pagination__sizes .el-input {
				margin: 0 5px;
				width: 100px;
				position: relative;
			}
	
	.main-content .el-pagination /deep/ .el-pagination__sizes .el-input .el-input__inner {
				border: 1px solid #DCDFE6;
				cursor: pointer;
				padding: 0 25px 0 8px;
				color: #606266;
				display: inline-block;
				font-size: 16px;
				line-height: 28px;
				border-radius: 30px;
				outline: 0;
				background: #FFF;
				width: 100%;
				text-align: center;
				height: 28px;
			}
	
	.main-content .el-pagination /deep/ .el-pagination__sizes .el-input span.el-input__suffix {
				top: 0;
				position: absolute;
				right: 0;
				height: 100%;
			}
	
	.main-content .el-pagination /deep/ .el-pagination__sizes .el-input .el-input__suffix .el-select__caret {
				cursor: pointer;
				color: #C0C4CC;
				width: 25px;
				font-size: 14px;
				line-height: 28px;
				text-align: center;
			}
	
	.main-content .el-pagination /deep/ .el-pagination__jump {
				margin: 0 0 0 24px;
				color: #606266;
				display: inline-block;
				vertical-align: top;
				font-size: 16px;
				line-height: 28px;
				height: 28px;
			}
	
	.main-content .el-pagination /deep/ .el-pagination__jump .el-input {
				border-radius: 3px;
				padding: 0 2px;
				margin: 0 2px;
				display: inline-block;
				width: 50px;
				font-size: 16px;
				line-height: 18px;
				position: relative;
				text-align: center;
				height: 28px;
			}
	
	.main-content .el-pagination /deep/ .el-pagination__jump .el-input .el-input__inner {
				border: 1px solid #DCDFE6;
				cursor: pointer;
				padding: 0 3px;
				color: #606266;
				display: inline-block;
				font-size: 16px;
				line-height: 28px;
				border-radius: 30px;
				outline: 0;
				background: #FFF;
				width: 100%;
				text-align: center;
				height: 28px;
			}
</style>
