<template>
<view class="content">
	<view :style='{"minHeight":"100vh","padding":"0px 0 80rpx","borderColor":"#21d5ae","background":"#fff","borderWidth":"0px 0 0","width":"100%","position":"relative","borderStyle":"dashed","height":"auto"}'>
		<form :style='{"width":"100%","padding":"60rpx 40rpx","background":"none","height":"auto"}' class="app-update-pv">
			<view :style='{"padding":"0 20rpx 0px","margin":"0 0 0px","borderColor":"#d9eff0","borderRadius":"0px","flexWrap":"wrap","borderWidth":"0 0 2rpx","background":"#fff","display":"flex","width":"100%","lineHeight":"100rpx","borderStyle":"dashed","height":"auto"}' class="">
				<view :style='{"width":"auto","padding":"0 20rpx 0 0","fontSize":"28rpx","color":"#11999e","textAlign":"right","fontWeight":"600"}' class="title">出库编号</view>
				<view :style='{"padding":"0px 24rpx","margin":"0px","fontSize":"28rpx","color":"#666","flex":"1"}' class="right-input">
					{{ruleForm.chukubianhao}}
				</view>
			</view>
			<view :style='{"padding":"0 20rpx 0px","margin":"0 0 0px","borderColor":"#d9eff0","borderRadius":"0px","flexWrap":"wrap","borderWidth":"0 0 2rpx","background":"#fff","display":"flex","width":"100%","lineHeight":"100rpx","borderStyle":"dashed","height":"auto"}' class="">
				<view :style='{"width":"auto","padding":"0 20rpx 0 0","fontSize":"28rpx","color":"#11999e","textAlign":"right","fontWeight":"600"}' class="title">教材标题</view>
				<input :style='{"border":"0","padding":"0px 20rpx","margin":"0px","color":"#666","borderRadius":"0px","flex":"1","background":"none","fontSize":"28rpx"}' :disabled="ro.jiaocaibiaoti" v-model="ruleForm.jiaocaibiaoti" placeholder="教材标题"></input>
			</view>
			<view :style='{"padding":"0 20rpx 0px","margin":"0 0 0px","borderColor":"#d9eff0","borderRadius":"0px","flexWrap":"wrap","borderWidth":"0 0 2rpx","background":"#fff","display":"flex","width":"100%","lineHeight":"100rpx","borderStyle":"dashed","height":"auto"}' class="">
				<view :style='{"width":"auto","padding":"0 20rpx 0 0","fontSize":"28rpx","color":"#11999e","textAlign":"right","fontWeight":"600"}' class="title">教材分类</view>
				<input :style='{"border":"0","padding":"0px 20rpx","margin":"0px","color":"#666","borderRadius":"0px","flex":"1","background":"none","fontSize":"28rpx"}' :disabled="ro.jiaocaifenlei" v-model="ruleForm.jiaocaifenlei" placeholder="教材分类"></input>
			</view>
			<view :style='{"padding":"0 20rpx 0px","margin":"0 0 0px","borderColor":"#d9eff0","borderRadius":"0px","flexWrap":"wrap","borderWidth":"0 0 2rpx","background":"#fff","display":"flex","width":"100%","lineHeight":"100rpx","borderStyle":"dashed","height":"auto"}' class=" select">
				<view :style='{"width":"auto","padding":"0 20rpx 0 0","fontSize":"28rpx","color":"#11999e","textAlign":"right","fontWeight":"600"}' class="title">出库时间</view>
				<picker :style='{"width":"100%","flex":"1","height":"auto"}' mode="date" :value="ruleForm.chukushijian" @change="chukushijianChange">
					<view :style='{"width":"100%","padding":"0 20rpx","lineHeight":"80rpx","fontSize":"28rpx","color":"#666","background":"none"}' class="uni-input">{{ruleForm.chukushijian?ruleForm.chukushijian:"请选择出库时间"}}</view>
				</picker>
			</view>
			<view :style='{"padding":"0 20rpx 0px","margin":"0 0 0px","borderColor":"#d9eff0","borderRadius":"0px","flexWrap":"wrap","borderWidth":"0 0 2rpx","background":"#fff","display":"flex","width":"100%","lineHeight":"100rpx","borderStyle":"dashed","height":"auto"}' class="" @tap="jiaocaifengmianTap">
				<view :style='{"width":"auto","padding":"0 20rpx 0 0","fontSize":"28rpx","color":"#11999e","textAlign":"right","fontWeight":"600"}' class="title">教材封面</view>
				<image :style='{"width":"72rpx","margin":"12rpx 0","borderRadius":"100%","objectFit":"cover","display":"block","height":"72rpx"}' class="avator" v-if="ruleForm.jiaocaifengmian" :src="baseUrl+ruleForm.jiaocaifengmian.split(',')[0]" mode="aspectFill"></image>
				<image :style='{"width":"72rpx","margin":"12rpx 0","borderRadius":"100%","objectFit":"cover","display":"block","height":"72rpx"}' class="avator" v-else src="../../static/gen/upload.png" mode="aspectFill"></image>
			</view>
			<view :style='{"padding":"0 20rpx 0px","margin":"0 0 0px","borderColor":"#d9eff0","borderRadius":"0px","flexWrap":"wrap","borderWidth":"0 0 2rpx","background":"#fff","display":"flex","width":"100%","lineHeight":"100rpx","borderStyle":"dashed","height":"auto"}' class="">
				<view :style='{"width":"auto","padding":"0 20rpx 0 0","fontSize":"28rpx","color":"#11999e","textAlign":"right","fontWeight":"600"}' class="title">出库数量</view>
				<input :style='{"border":"0","padding":"0px 20rpx","margin":"0px","color":"#666","borderRadius":"0px","flex":"1","background":"none","fontSize":"28rpx"}' :disabled="ro.shuliang" v-model="ruleForm.shuliang" placeholder="出库数量"></input>
			</view>
			<view :style='{"padding":"0 20rpx 0px","margin":"0 0 0px","borderColor":"#d9eff0","borderRadius":"0px","flexWrap":"wrap","borderWidth":"0 0 2rpx","background":"#fff","display":"flex","width":"100%","lineHeight":"100rpx","borderStyle":"dashed","height":"auto"}' class="">
				<view :style='{"width":"auto","padding":"0 20rpx 0 0","fontSize":"28rpx","color":"#11999e","textAlign":"right","fontWeight":"600"}' class="title">规格</view>
				<input :style='{"border":"0","padding":"0px 20rpx","margin":"0px","color":"#666","borderRadius":"0px","flex":"1","background":"none","fontSize":"28rpx"}' :disabled="ro.guige" v-model="ruleForm.guige" placeholder="规格"></input>
			</view>
			<view :style='{"padding":"0 20rpx 0px","margin":"0 0 0px","borderColor":"#d9eff0","borderRadius":"0px","flexWrap":"wrap","borderWidth":"0 0 2rpx","background":"#fff","display":"flex","width":"100%","lineHeight":"100rpx","borderStyle":"dashed","height":"auto"}' class="">
				<view :style='{"width":"auto","padding":"0 20rpx 0 0","fontSize":"28rpx","color":"#11999e","textAlign":"right","fontWeight":"600"}' class="title">用户账号</view>
				<input :style='{"border":"0","padding":"0px 20rpx","margin":"0px","color":"#666","borderRadius":"0px","flex":"1","background":"none","fontSize":"28rpx"}' :disabled="ro.yonghuzhanghao" v-model="ruleForm.yonghuzhanghao" placeholder="用户账号"></input>
			</view>
			<view :style='{"padding":"0 20rpx 0px","margin":"0 0 0px","borderColor":"#d9eff0","borderRadius":"0px","flexWrap":"wrap","borderWidth":"0 0 2rpx","background":"#fff","display":"flex","width":"100%","lineHeight":"100rpx","borderStyle":"dashed","height":"auto"}' class="">
				<view :style='{"width":"auto","padding":"0 20rpx 0 0","fontSize":"28rpx","color":"#11999e","textAlign":"right","fontWeight":"600"}' class="title">用户姓名</view>
				<input :style='{"border":"0","padding":"0px 20rpx","margin":"0px","color":"#666","borderRadius":"0px","flex":"1","background":"none","fontSize":"28rpx"}' :disabled="ro.yonghuxingming" v-model="ruleForm.yonghuxingming" placeholder="用户姓名"></input>
			</view>
			
			<!-- 否 -->
 

			<view :style='{"padding":"0 20rpx 0px","margin":"0 0 0px","borderColor":"#d9eff0","borderRadius":"0px","flexWrap":"wrap","borderWidth":"0 0 2rpx","background":"#fff","display":"flex","width":"100%","lineHeight":"100rpx","borderStyle":"dashed","height":"auto"}' class="">
				<view :style='{"width":"auto","padding":"0 20rpx 0 0","fontSize":"28rpx","color":"#11999e","textAlign":"right","fontWeight":"600"}' class="title">出库详情</view>
				<textarea :style='{"border":"0","minHeight":"240rpx","padding":"40rpx 40rpx","margin":"0px","color":"#666","borderRadius":"8rpx","flex":"1","background":"none","fontSize":"28rpx"}' v-model="ruleForm.chukuxiangqing" placeholder="出库详情"></textarea>
			</view>
			
			
			<view :style='{"padding":"0px","margin":"40rpx 0 0 0","background":"none","display":"flex","width":"100%","justifyContent":"center","height":"auto"}' class="btn" >
				<button :style='{"padding":"0 40rpx","boxShadow":"0px 0px 0px #ccc","margin":"0 40rpx 0 0","borderColor":"#f0bebe","color":"#fff","display":"inline","minWidth":"200rpx","borderRadius":"0px","background":"#11999e","borderWidth":"0px","width":"auto","lineHeight":"72rpx","fontSize":"28rpx","borderStyle":"solid","fontWeight":"500","height":"80rpx"}' @tap="onSubmitTap" class="bg-red">提交</button>
			</view>
		</form>

	</view>
</view>
</template>

<script>
	import wPicker from "@/components/w-picker/w-picker.vue";
    import xiaEditor from '@/components/xia-editor/xia-editor';
	export default {
		data() {
			return {
				cross:'',
				ruleForm: {
				chukubianhao: this.getUUID(),
				jiaocaibiaoti: '',
				jiaocaifenlei: '',
				chukushijian: '',
				jiaocaifengmian: '',
				shuliang: '',
				guige: '',
				chukuxiangqing: '',
				yonghuzhanghao: '',
				yonghuxingming: '',
				},
				// 登录用户信息
				user: {},
                ro:{
                   chukubianhao : false,
                   jiaocaibiaoti : false,
                   jiaocaifenlei : false,
                   chukushijian : false,
                   jiaocaifengmian : false,
                   shuliang : false,
                   guige : false,
                   chukuxiangqing : false,
                   yonghuzhanghao : false,
                   yonghuxingming : false,
                },
			}
		},
		components: {
			wPicker,
            xiaEditor
		},
		computed: {
			baseUrl() {
				return this.$base.url;
			},



		},
		async onLoad(options) {
            this.ruleForm.chukushijian = this.$utils.getCurDate();
			let table = uni.getStorageSync("nowTable");
			// 获取用户信息
			let res = await this.$api.session(table);
			this.user = res.data;
			
			// ss读取
			this.ruleForm.yonghuzhanghao = this.user.yonghuzhanghao
			this.ro.yonghuzhanghao = true;
			this.ruleForm.yonghuxingming = this.user.yonghuxingming
			this.ro.yonghuxingming = true;



			// 如果有登录，获取登录后保存的userid
			this.ruleForm.userid = uni.getStorageSync("userid")
			if (options.refid) {
				// 如果上一级页面传递了refid，获取改refid数据信息
				this.ruleForm.refid = options.refid;
				this.ruleForm.nickname = uni.getStorageSync("nickname");
			}
			// 如果是更新操作
			if (options.id) {
				this.ruleForm.id = options.id;
				// 获取信息
				res = await this.$api.info(`jiaocaichuku`, this.ruleForm.id);
				this.ruleForm = res.data;
			}
			// 跨表
			this.cross = options.cross;
			if(options.cross){
				var obj = uni.getStorageSync('crossObj');
				for (var o in obj){
					if(o=='chukubianhao'){
					this.ruleForm.chukubianhao = obj[o];
					this.ro.chukubianhao = true;
					continue;
					}
					if(o=='jiaocaibiaoti'){
					this.ruleForm.jiaocaibiaoti = obj[o];
					this.ro.jiaocaibiaoti = true;
					continue;
					}
					if(o=='jiaocaifenlei'){
					this.ruleForm.jiaocaifenlei = obj[o];
					this.ro.jiaocaifenlei = true;
					continue;
					}
					if(o=='chukushijian'){
					this.ruleForm.chukushijian = obj[o];
					this.ro.chukushijian = true;
					continue;
					}
					if(o=='jiaocaifengmian'){
					this.ruleForm.jiaocaifengmian = obj[o].split(",")[0];
					this.ro.jiaocaifengmian = true;
					continue;
					}
					if(o=='shuliang'){
					this.ruleForm.shuliang = obj[o];
					this.ro.shuliang = true;
					continue;
					}
					if(o=='guige'){
					this.ruleForm.guige = obj[o];
					this.ro.guige = true;
					continue;
					}
					if(o=='chukuxiangqing'){
					this.ruleForm.chukuxiangqing = obj[o];
					this.ro.chukuxiangqing = true;
					continue;
					}
					if(o=='yonghuzhanghao'){
					this.ruleForm.yonghuzhanghao = obj[o];
					this.ro.yonghuzhanghao = true;
					continue;
					}
					if(o=='yonghuxingming'){
					this.ruleForm.yonghuxingming = obj[o];
					this.ro.yonghuxingming = true;
					continue;
					}
				}
            this.ruleForm.shuliang = 0;
            this.ro.shuliang = false;
			}
			this.styleChange()
		},
		methods: {
			styleChange() {
				this.$nextTick(()=>{
					// document.querySelectorAll('.app-update-pv . .uni-input-input').forEach(el=>{
					//   el.style.backgroundColor = this.addUpdateForm.input.content.backgroundColor
					// })
				})
			},

			// 多级联动参数

			chukushijianChange(e) {
				this.ruleForm.chukushijian = e.target.value;
				this.$forceUpdate();
			},



			jiaocaifengmianTap() {
				let _this = this;
				this.$api.upload(function(res) {
					_this.ruleForm.jiaocaifengmian = 'upload/' + res.file;
					_this.$forceUpdate();
					_this.$nextTick(()=>{
						_this.styleChange()
					})
				});
			},

			getUUID () {
				return new Date().getTime();
			},
			async onSubmitTap() {





















//跨表计算判断
				var obj;
				obj = uni.getStorageSync('crossObj');
				var table = uni.getStorageSync('crossTable');
				//obj.shuliang = obj.shuliang - this.ruleForm.shuliang
                if((parseFloat(obj.shuliang) - parseFloat(this.ruleForm.shuliang))<0){
					this.$utils.msg("出库数量不足");
					return
				}
				if(this.ruleForm.shuliang&&(!this.$validate.isIntNumer(this.ruleForm.shuliang))){
					this.$utils.msg(`出库数量应输入整数`);
					return
				}
				//更新跨表属性
			       var crossuserid;
			       var crossrefid;
			       var crossoptnum;
				if(this.cross){
					var statusColumnName = uni.getStorageSync('statusColumnName');
					var statusColumnValue = uni.getStorageSync('statusColumnValue');
					if(statusColumnName!='') {
                        if(!obj) {
						    obj = uni.getStorageSync('crossObj');
                        }
						if(!statusColumnName.startsWith("[")) {
							for (var o in obj){
								if(o==statusColumnName){
									obj[o] = statusColumnValue;
								}

							}
							var table = uni.getStorageSync('crossTable');
							await this.$api.update(`${table}`, obj);
						} else {
						       crossuserid=Number(uni.getStorageSync('userid'));
						       crossrefid=obj['id'];
						       crossoptnum=uni.getStorageSync('statusColumnName');
						       crossoptnum=crossoptnum.replace(/\[/,"").replace(/\]/,"");
						}
					}
				}
				if(crossrefid && crossuserid) {
					this.ruleForm.crossuserid=crossuserid;
					this.ruleForm.crossrefid=crossrefid;
					let params = {
						page: 1,
						limit:10,
						crossuserid:crossuserid,
						crossrefid:crossrefid,
					}
					let res = await this.$api.list(`jiaocaichuku`, params);
					if (res.data.total >= crossoptnum) {
						this.$utils.msg(uni.getStorageSync('tips'));
						return false;
					} else {
                //跨表计算
                        if(!obj) {
                            obj = uni.getStorageSync('crossObj');
                        }
                        var table = uni.getStorageSync('crossTable');
                        obj.shuliang = parseFloat(obj.shuliang) - parseFloat(this.ruleForm.shuliang)
                        await this.$api.update(`${table}`, obj);
						if(this.ruleForm.id){
							await this.$api.update(`jiaocaichuku`, this.ruleForm);
						}else{
							await this.$api.add(`jiaocaichuku`, this.ruleForm);
						}
						this.$utils.msgBack('提交成功');
					}
				} else {
                //跨表计算
                    if(!obj) {
                        obj = uni.getStorageSync('crossObj');
                    }
                    var table = uni.getStorageSync('crossTable');
                    obj.shuliang = obj.shuliang - this.ruleForm.shuliang
                    await this.$api.update(`${table}`, obj);
					if(this.ruleForm.id){
						await this.$api.update(`jiaocaichuku`, this.ruleForm);
					}else{
						await this.$api.add(`jiaocaichuku`, this.ruleForm);
					}
					this.$utils.msgBack('提交成功');
				}
			},
			optionsChange(e) {
				this.index = e.target.value
			},
			bindDateChange(e) {
				this.date = e.target.value
			},
			getDate(type) {
				const date = new Date();
				let year = date.getFullYear();
				let month = date.getMonth() + 1;
				let day = date.getDate();
				if (type === 'start') {
					year = year - 60;
				} else if (type === 'end') {
					year = year + 2;
				}
				month = month > 9 ? month : '0' + month;;
				day = day > 9 ? day : '0' + day;
				return `${year}-${month}-${day}`;
			},
			toggleTab(str) {
				this.$refs[str].show();
			}
		}
	}
</script>

<style lang="scss" scoped>
	.content {
		min-height: calc(100vh - 44px);
		box-sizing: border-box;
	}
</style>
