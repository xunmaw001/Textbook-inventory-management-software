<template>
	<view class="content">
		<view class="box" :style='{"minHeight":"100vh","width":"100%","padding":"560rpx 40rpx 80rpx","background":"url(http://codegen.caihongy.cn/20230410/0af9f56813d94407abfaf8d41e7a6ba6.jpg) no-repeat center top / 100% auto,#fff","height":"100%"}' v-if="type==1">
			<view :style='{"minHeight":"500rpx","padding":"40rpx 80rpx","boxShadow":"0px 0px 0px #aaa","borderColor":"#e9be70","borderRadius":"40rpx","background":"none","borderWidth":"0px","display":"block","width":"100%","borderStyle":"solid","height":"auto"}'>
				<view class="forget-input" :style='{"width":"100%","margin":"0 0 40rpx 0","height":"auto"}'>
					<input v-model="username" :style='{"border":"0px solid rgb(255, 170, 51)","padding":"0px 24rpx","boxShadow":"0px 0px 0px #2c77cb","margin":"0px","borderColor":"#d9f4f5","color":"#333","borderRadius":"40rpx","background":"#ecfafb","borderWidth":"2rpx","width":"100%","fontSize":"28rpx","borderStyle":"solid","height":"80rpx"}' type="text" placeholder="请输入您的账号" />
				</view>
				<picker :style='{"boxShadow":"0px 0px 0px #2c77cb","margin":"0 0 60rpx 0","borderColor":"#d9f4f5","borderRadius":"40rpx","borderWidth":"2rpx","background":"#ecfafb","width":"100%","borderStyle":"solid","height":"auto"}' @change="optionsChange" :value="index" :range="options">
					<view class="uni-input" :style='{"width":"100%","padding":"0 24rpx","lineHeight":"80rpx","fontSize":"28rpx","color":"#666"}'>{{options[index]}}</view>
				</picker>
				<button class="landing" :style='{"padding":"0 40rpx","boxShadow":"0px 0px 0px #ccc","margin":"0 auto 24rpx","borderColor":"rgba(255,208,125,1)","color":"#fff","display":"block","borderRadius":"40rpx","background":"#11999E","borderWidth":"0px","width":"100%","lineHeight":"80rpx","fontSize":"28rpx","borderStyle":"solid","height":"80rpx"}' @tap="nextClick" type="primary">下一步</button>
			</view>
		</view>
        <view class="box" :style='{"minHeight":"100vh","width":"100%","padding":"560rpx 40rpx 80rpx","background":"url(http://codegen.caihongy.cn/20230410/0af9f56813d94407abfaf8d41e7a6ba6.jpg) no-repeat center top / 100% auto,#fff","height":"100%"}' v-if="type==2">
            <view :style='{"minHeight":"500rpx","padding":"40rpx 80rpx","boxShadow":"0px 0px 0px #aaa","borderColor":"#e9be70","borderRadius":"40rpx","background":"none","borderWidth":"0px","display":"block","width":"100%","borderStyle":"solid","height":"auto"}'>
                <view class="forget-input" :style='{"width":"100%","margin":"0 0 40rpx 0","height":"auto"}'>
                    <input v-model="userForm.pquestion"  :style='{"border":"0px solid rgb(255, 170, 51)","padding":"0px 24rpx","boxShadow":"0px 0px 0px #2c77cb","margin":"0px","borderColor":"#d9f4f5","color":"#333","borderRadius":"40rpx","background":"#ecfafb","borderWidth":"2rpx","width":"100%","fontSize":"28rpx","borderStyle":"solid","height":"80rpx"}' type="text" placeholder="密保问题" disabled="disabled"/>
                </view>
                <view class="forget-input" :style='{"width":"100%","margin":"0 0 40rpx 0","height":"auto"}'>
                    <input v-model="panswer1" :style='{"border":"0px solid rgb(255, 170, 51)","padding":"0px 24rpx","boxShadow":"0px 0px 0px #2c77cb","margin":"0px","borderColor":"#d9f4f5","color":"#333","borderRadius":"40rpx","background":"#ecfafb","borderWidth":"2rpx","width":"100%","fontSize":"28rpx","borderStyle":"solid","height":"80rpx"}' type="text" placeholder="密保答案" />
                </view>
                <button class="landing" :style='{"padding":"0 40rpx","boxShadow":"0px 0px 0px #ccc","margin":"0 auto 24rpx","borderColor":"rgba(255,208,125,1)","color":"#fff","display":"block","borderRadius":"40rpx","background":"#11999E","borderWidth":"0px","width":"100%","lineHeight":"80rpx","fontSize":"28rpx","borderStyle":"solid","height":"80rpx"}' @tap="confirmClick" type="primary">确定</button>
            </view>
        </view>
        <view class="box" :style='{"minHeight":"100vh","width":"100%","padding":"560rpx 40rpx 80rpx","background":"url(http://codegen.caihongy.cn/20230410/0af9f56813d94407abfaf8d41e7a6ba6.jpg) no-repeat center top / 100% auto,#fff","height":"100%"}' v-if="type==3">
            <view :style='{"minHeight":"500rpx","padding":"40rpx 80rpx","boxShadow":"0px 0px 0px #aaa","borderColor":"#e9be70","borderRadius":"40rpx","background":"none","borderWidth":"0px","display":"block","width":"100%","borderStyle":"solid","height":"auto"}'>
                <view class="forget-input" :style='{"width":"100%","margin":"0 0 40rpx 0","height":"auto"}'>
                    <input v-model="password" :style='{"border":"0px solid rgb(255, 170, 51)","padding":"0px 24rpx","boxShadow":"0px 0px 0px #2c77cb","margin":"0px","borderColor":"#d9f4f5","color":"#333","borderRadius":"40rpx","background":"#ecfafb","borderWidth":"2rpx","width":"100%","fontSize":"28rpx","borderStyle":"solid","height":"80rpx"}' type="password" placeholder="密码" />
                </view>
                <view class="forget-input" :style='{"width":"100%","margin":"0 0 40rpx 0","height":"auto"}'>
                    <input v-model="repassword" :style='{"border":"0px solid rgb(255, 170, 51)","padding":"0px 24rpx","boxShadow":"0px 0px 0px #2c77cb","margin":"0px","borderColor":"#d9f4f5","color":"#333","borderRadius":"40rpx","background":"#ecfafb","borderWidth":"2rpx","width":"100%","fontSize":"28rpx","borderStyle":"solid","height":"80rpx"}' type="password" placeholder="确认密码" />
                </view>
                <button class="landing" :style='{"padding":"0 40rpx","boxShadow":"0px 0px 0px #ccc","margin":"0 auto 24rpx","borderColor":"rgba(255,208,125,1)","color":"#fff","display":"block","borderRadius":"40rpx","background":"#11999E","borderWidth":"0px","width":"100%","lineHeight":"80rpx","fontSize":"28rpx","borderStyle":"solid","height":"80rpx"}' @tap="updateClick" type="primary">修改密码</button>
            </view>
        </view>
	</view>
</template>

<script>
	export default {
		data() {
			return {
				options: [
                    '请选择登录用户类型',
                ],
                optionsValues: [
					'',
				],
				index: 0,
                tableName: '',
                type: 1,
                repassword: '',
                password: '',
                panswer1: '',
                userForm: {
                }
			}
		},
		onLoad() {
			this.styleChange()
		},
		methods: {
			async nextClick() {
				if(this.username==undefined) {
					this.$utils.msg('请输入账号')
					return;
                                }
				if(this.optionsValues[this.index]=="") {
					this.$utils.msg('请选择角色')
                    return;
				}
                this.tableName = this.optionsValues[this.index];
                let res = await this.$api.security(this.tableName,{
                    username: this.username
                })
                if(!res.data) {
                    this.$utils.msg('用户不存在')
                }
                if (res.code == 0) {
                    this.userForm = res.data
                    this.type = 2
                }
			},
			optionsChange(e) {
				this.index = e.target.value
			},
			styleChange() {
				this.$nextTick(()=>{
					// document.querySelectorAll('.forget-input .uni-input-input').forEach(el=>{
					//   el.style.backgroundColor = this.restPwFrom.content.input.backgroundColor
					// })
				})
			},
            confirmClick() {
                if (this.userForm.panswer !== this.panswer1) {
                    this.$utils.msg('密保答案不正确')
                    return false
                }
                this.$utils.msg('验证成功')
                this.password = ''
                setTimeout(() => {
                    this.type = 3
                }, 1000)
            },
            async updateClick() {
                if(!this.password) {
                    this.$utils.msg('密码不能为空')
                    return false
                }
                if (this.password != this.repassword) {
                    this.$utils.msg('两次密码输入不一致')
                    return false
                }
                if(this.userForm.mima) {
                    this.userForm.mima=this.password;
                } else {
                    this.userForm.password=this.password;
                }
                await this.$api.update(this.tableName, this.userForm)
                this.$utils.msg('密码修改成功')
                setTimeout(() => {
                    uni.navigateBack({
            
                    })
                }, 1000)
            },
		}
	}
</script>

<style lang="scss" scoped>
	.content {
		min-height: calc(100vh - 44px);
		box-sizing: border-box;
	}
</style>
