<template>
<view class="content">
	<view :style='{"minHeight":"100vh","padding":"0px 0 80rpx","borderColor":"#21d5ae","background":"#fff","borderWidth":"0px 0 0","width":"100%","position":"relative","borderStyle":"dashed","height":"auto"}'>
		<form :style='{"width":"100%","padding":"60rpx 40rpx","background":"none","height":"auto"}' class="app-update-pv">
			<view :style='{"padding":"0 20rpx 0px","margin":"0 0 0px","borderColor":"#d9eff0","borderRadius":"0px","flexWrap":"wrap","borderWidth":"0 0 2rpx","background":"#fff","display":"flex","width":"100%","lineHeight":"100rpx","borderStyle":"dashed","height":"auto"}' class="">
				<view :style='{"width":"auto","padding":"0 20rpx 0 0","fontSize":"28rpx","color":"#11999e","textAlign":"right","fontWeight":"600"}' class="title">用户账号</view>
				<input :style='{"border":"0","padding":"0px 20rpx","margin":"0px","color":"#666","borderRadius":"0px","flex":"1","background":"none","fontSize":"28rpx"}' :disabled="ro.yonghuzhanghao" v-model="ruleForm.yonghuzhanghao" placeholder="用户账号"></input>
			</view>
			<view :style='{"padding":"0 20rpx 0px","margin":"0 0 0px","borderColor":"#d9eff0","borderRadius":"0px","flexWrap":"wrap","borderWidth":"0 0 2rpx","background":"#fff","display":"flex","width":"100%","lineHeight":"100rpx","borderStyle":"dashed","height":"auto"}' class="">
				<view :style='{"width":"auto","padding":"0 20rpx 0 0","fontSize":"28rpx","color":"#11999e","textAlign":"right","fontWeight":"600"}' class="title">密码</view>
				<input :style='{"border":"0","padding":"0px 20rpx","margin":"0px","color":"#666","borderRadius":"0px","flex":"1","background":"none","fontSize":"28rpx"}' :disabled="ro.mima" v-model="ruleForm.mima" placeholder="密码"></input>
			</view>
			<view :style='{"padding":"0 20rpx 0px","margin":"0 0 0px","borderColor":"#d9eff0","borderRadius":"0px","flexWrap":"wrap","borderWidth":"0 0 2rpx","background":"#fff","display":"flex","width":"100%","lineHeight":"100rpx","borderStyle":"dashed","height":"auto"}' class="">
				<view :style='{"width":"auto","padding":"0 20rpx 0 0","fontSize":"28rpx","color":"#11999e","textAlign":"right","fontWeight":"600"}' class="title">用户姓名</view>
				<input :style='{"border":"0","padding":"0px 20rpx","margin":"0px","color":"#666","borderRadius":"0px","flex":"1","background":"none","fontSize":"28rpx"}' :disabled="ro.yonghuxingming" v-model="ruleForm.yonghuxingming" placeholder="用户姓名"></input>
			</view>
			<view :style='{"padding":"0 20rpx 0px","margin":"0 0 0px","borderColor":"#d9eff0","borderRadius":"0px","flexWrap":"wrap","borderWidth":"0 0 2rpx","background":"#fff","display":"flex","width":"100%","lineHeight":"100rpx","borderStyle":"dashed","height":"auto"}' class=" select">
				<view :style='{"width":"auto","padding":"0 20rpx 0 0","fontSize":"28rpx","color":"#11999e","textAlign":"right","fontWeight":"600"}' class="title">性别</view>
				<picker :style='{"width":"100%","flex":"1","height":"auto"}' @change="xingbieChange" :value="xingbieIndex"  :range="xingbieOptions">
					<view :style='{"width":"100%","padding":"0 20rpx","lineHeight":"80rpx","fontSize":"28rpx","color":"#666","background":"none"}' class="uni-input">{{ruleForm.xingbie?ruleForm.xingbie:"请选择性别"}}</view>
				</picker>
			</view>
			<view :style='{"padding":"0 20rpx 0px","margin":"0 0 0px","borderColor":"#d9eff0","borderRadius":"0px","flexWrap":"wrap","borderWidth":"0 0 2rpx","background":"#fff","display":"flex","width":"100%","lineHeight":"100rpx","borderStyle":"dashed","height":"auto"}' class="">
				<view :style='{"width":"auto","padding":"0 20rpx 0 0","fontSize":"28rpx","color":"#11999e","textAlign":"right","fontWeight":"600"}' class="title">用户电话</view>
				<input :style='{"border":"0","padding":"0px 20rpx","margin":"0px","color":"#666","borderRadius":"0px","flex":"1","background":"none","fontSize":"28rpx"}' :disabled="ro.yonghudianhua" v-model="ruleForm.yonghudianhua" placeholder="用户电话"></input>
			</view>
			<view :style='{"padding":"0 20rpx 0px","margin":"0 0 0px","borderColor":"#d9eff0","borderRadius":"0px","flexWrap":"wrap","borderWidth":"0 0 2rpx","background":"#fff","display":"flex","width":"100%","lineHeight":"100rpx","borderStyle":"dashed","height":"auto"}' class="" @tap="touxiangTap">
				<view :style='{"width":"auto","padding":"0 20rpx 0 0","fontSize":"28rpx","color":"#11999e","textAlign":"right","fontWeight":"600"}' class="title">头像</view>
				<image :style='{"width":"72rpx","margin":"12rpx 0","borderRadius":"100%","objectFit":"cover","display":"block","height":"72rpx"}' class="avator" v-if="ruleForm.touxiang" :src="baseUrl+ruleForm.touxiang.split(',')[0]" mode="aspectFill"></image>
				<image :style='{"width":"72rpx","margin":"12rpx 0","borderRadius":"100%","objectFit":"cover","display":"block","height":"72rpx"}' class="avator" v-else src="../../static/gen/upload.png" mode="aspectFill"></image>
			</view>
			
			<!-- 否 -->
 

			
			
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
				yonghuzhanghao: '',
				mima: '',
				yonghuxingming: '',
				xingbie: '',
				yonghudianhua: '',
				touxiang: '',
				},
				xingbieOptions: [],
				xingbieIndex: 0,
				// 登录用户信息
				user: {},
                ro:{
                   yonghuzhanghao : false,
                   mima : false,
                   yonghuxingming : false,
                   xingbie : false,
                   yonghudianhua : false,
                   touxiang : false,
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
			let table = uni.getStorageSync("nowTable");
			// 获取用户信息
			let res = await this.$api.session(table);
			this.user = res.data;
			
			// ss读取


			// 自定义下拉框值
			this.xingbieOptions = "男,女".split(',')

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
				res = await this.$api.info(`yonghu`, this.ruleForm.id);
				this.ruleForm = res.data;
			}
			// 跨表
			this.cross = options.cross;
			if(options.cross){
				var obj = uni.getStorageSync('crossObj');
				for (var o in obj){
					if(o=='yonghuzhanghao'){
					this.ruleForm.yonghuzhanghao = obj[o];
					this.ro.yonghuzhanghao = true;
					continue;
					}
					if(o=='mima'){
					this.ruleForm.mima = obj[o];
					this.ro.mima = true;
					continue;
					}
					if(o=='yonghuxingming'){
					this.ruleForm.yonghuxingming = obj[o];
					this.ro.yonghuxingming = true;
					continue;
					}
					if(o=='xingbie'){
					this.ruleForm.xingbie = obj[o];
					this.ro.xingbie = true;
					continue;
					}
					if(o=='yonghudianhua'){
					this.ruleForm.yonghudianhua = obj[o];
					this.ro.yonghudianhua = true;
					continue;
					}
					if(o=='touxiang'){
					this.ruleForm.touxiang = obj[o].split(",")[0];
					this.ro.touxiang = true;
					continue;
					}
				}
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



			// 下拉变化
			xingbieChange(e) {
				this.xingbieIndex = e.target.value
				this.ruleForm.xingbie = this.xingbieOptions[this.xingbieIndex]
			},

			touxiangTap() {
				let _this = this;
				this.$api.upload(function(res) {
					_this.ruleForm.touxiang = 'upload/' + res.file;
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
				if((!this.ruleForm.yonghuzhanghao)){
					this.$utils.msg(`用户账号不能为空`);
					return
				}
				if((!this.ruleForm.mima)){
					this.$utils.msg(`密码不能为空`);
					return
				}
				if((!this.ruleForm.yonghuxingming)){
					this.$utils.msg(`用户姓名不能为空`);
					return
				}
				if(this.ruleForm.yonghudianhua&&(!this.$validate.isMobile(this.ruleForm.yonghudianhua))){
					this.$utils.msg(`用户电话应输入手机格式`);
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
					let res = await this.$api.list(`yonghu`, params);
					if (res.data.total >= crossoptnum) {
						this.$utils.msg(uni.getStorageSync('tips'));
						return false;
					} else {
                //跨表计算
						if(this.ruleForm.id){
							await this.$api.update(`yonghu`, this.ruleForm);
						}else{
							await this.$api.add(`yonghu`, this.ruleForm);
						}
						this.$utils.msgBack('提交成功');
					}
				} else {
                //跨表计算
					if(this.ruleForm.id){
						await this.$api.update(`yonghu`, this.ruleForm);
					}else{
						await this.$api.add(`yonghu`, this.ruleForm);
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
