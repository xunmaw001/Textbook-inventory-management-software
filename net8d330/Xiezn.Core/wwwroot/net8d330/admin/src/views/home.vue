<template>
<div class="content" :style='{"minHeight":"100vh","padding":"30px","background":"url(http://codegen.caihongy.cn/20230329/eff4ea96c952463cb46b9c79d043ce56.gif) fixed,#f6f6f6"}'>
	<div class="text" :style='{"margin":"30px auto","fontSize":"32px","color":"#333","textAlign":"center","fontWeight":"bold"}'>欢迎使用 {{this.$project.projectName}}</div>
    <div class="cardView">
        <div class="cards" :style='{"margin":"50px 0","alignItems":"center","justifyContent":"center","display":"flex"}'>
			<div :style='{"border":"1px solid #ddd","boxShadow":"0 0px 0px rgba(0,0,0,.3)","margin":"0 10px","borderRadius":"0px","background":"#fff","display":"flex"}' v-if="isAuth('jiaocairuku','首页总数')">
				<div :style='{"borderColor":"#ddd","borderRadius":"0px","background":"url(http://codegen.caihongy.cn/20230224/7b9ac76e6ed4427d925b003bcf9bf4c5.png) no-repeat center center / 60% auto","borderWidth":"0 1px 0 0","width":"100px","borderStyle":"solid","height":"100px"}'></div>
				<div :style='{"alignItems":"center","borderRadius":"0px","flexDirection":"column","background":"#fff","display":"flex","width":"180px","justifyContent":"center"}'>
					<div :style='{"margin":"5px 0","lineHeight":"24px","fontSize":"24px","color":"#555","fontWeight":"bold","height":"24px"}'>{{jiaocairukuCount}}</div>
					<div :style='{"margin":"5px 0","lineHeight":"24px","fontSize":"16px","color":"#666","height":"24px"}'>教材入库总数</div>
				</div>
			</div>
			<div :style='{"border":"1px solid #ddd","boxShadow":"0 0px 0px rgba(0,0,0,.3)","margin":"0 10px","borderRadius":"0px","background":"#fff","display":"flex"}' v-if="isAuth('jiaocaichuku','首页总数')">
				<div :style='{"borderColor":"#ddd","borderRadius":"0px","background":"url(http://codegen.caihongy.cn/20230224/7b9ac76e6ed4427d925b003bcf9bf4c5.png) no-repeat center center / 60% auto","borderWidth":"0 1px 0 0","width":"100px","borderStyle":"solid","height":"100px"}'></div>
				<div :style='{"alignItems":"center","borderRadius":"0px","flexDirection":"column","background":"#fff","display":"flex","width":"180px","justifyContent":"center"}'>
					<div :style='{"margin":"5px 0","lineHeight":"24px","fontSize":"24px","color":"#555","fontWeight":"bold","height":"24px"}'>{{jiaocaichukuCount}}</div>
					<div :style='{"margin":"5px 0","lineHeight":"24px","fontSize":"16px","color":"#666","height":"24px"}'>教材出库总数</div>
				</div>
			</div>
        </div>
        <div style="display: flex;align-items: center;width: 100%;margin-bottom: 10px;">
            <el-card style="width: 50%;margin: 0 10px;" v-if="isAuth('jiaocairuku','首页统计')">
                <div id="jiaocairukuChart1" style="width:100%;height:400px;"></div>
            </el-card>
            <el-card style="width: 50%;margin: 0 10px;" v-if="isAuth('jiaocaichuku','首页统计')">
                <div id="jiaocaichukuChart1" style="width:100%;height:400px;"></div>
            </el-card>
        </div>
    </div>
</div>
</template>
<script>
//2
import router from '@/router/router-static'
import * as echarts from 'echarts'
export default {
	data() {
		return {
            jiaocairukuCount: 0,
            jiaocaichukuCount: 0,
		};
	},
  mounted(){
    this.init();
    this.getjiaocairukuCount();
    this.jiaocairukuChat1();
    this.getjiaocaichukuCount();
    this.jiaocaichukuChat1();
  },
  methods:{
    init(){
        if(this.$storage.get('Token')){
        this.$http({
            url: `${this.$storage.get('sessionTable')}/session`,
            method: "get"
        }).then(({ data }) => {
            if (data && data.code != 0) {
            router.push({ name: 'login' })
            }
        });
        }else{
            router.push({ name: 'login' })
        }
    },
    getjiaocairukuCount() {
        this.$http({
            url: `jiaocairuku/count`,
            method: "get"
        }).then(({
            data
        }) => {
            if (data && data.code == 0) {
                this.jiaocairukuCount = data.data
            }
        })
    },

    jiaocairukuChat1() {
      this.$nextTick(()=>{

        var jiaocairukuChart1 = echarts.init(document.getElementById("jiaocairukuChart1"),'azul');
        this.$http({
            url: `jiaocairuku/value/jiaocaibiaoti/shuliang`,
            method: "get",
        }).then(({ data }) => {
            if (data && data.code === 0) {
                let res = data.data;
                let xAxis = [];
                let yAxis = [];
                let pArray = []
                for(let i=0;i<res.length;i++){
                    xAxis.push(res[i].jiaocaibiaoti);
                    yAxis.push(parseFloat((res[i].total)));
                    pArray.push({
                        value: parseFloat((res[i].total)),
                        name: res[i].jiaocaibiaoti
                    })
                }
                var option = {};
                option = {
                    title: {
                        text: '入库统计',
                        left: 'center'
                    },
                    tooltip: {
                      trigger: 'item',
                      formatter: '{b} : {c}'
                    },
                    xAxis: {
                        type: 'category',
                        data: xAxis
                    },
                    yAxis: {
                        type: 'value'
                    },
                    series: [{
                        data: yAxis,
                        type: 'bar'
                    }]
                };
                // 使用刚指定的配置项和数据显示图表。
                jiaocairukuChart1.setOption(option);
                  //根据窗口的大小变动图表
                window.onresize = function() {
                    jiaocairukuChart1.resize();
                };
            }
        });
      })
    },






    getjiaocaichukuCount() {
        this.$http({
            url: `jiaocaichuku/count`,
            method: "get"
        }).then(({
            data
        }) => {
            if (data && data.code == 0) {
                this.jiaocaichukuCount = data.data
            }
        })
    },

    jiaocaichukuChat1() {
      this.$nextTick(()=>{

        var jiaocaichukuChart1 = echarts.init(document.getElementById("jiaocaichukuChart1"),'macarons');
        this.$http({
            url: `jiaocaichuku/value/jiaocaibiaoti/shuliang`,
            method: "get",
        }).then(({ data }) => {
            if (data && data.code === 0) {
                let res = data.data;
                let xAxis = [];
                let yAxis = [];
                let pArray = []
                for(let i=0;i<res.length;i++){
                    xAxis.push(res[i].jiaocaibiaoti);
                    yAxis.push(parseFloat((res[i].total)));
                    pArray.push({
                        value: parseFloat((res[i].total)),
                        name: res[i].jiaocaibiaoti
                    })
                }
                var option = {};
                option = {
                    title: {
                        text: '出库统计',
                        left: 'center'
                    },
                    tooltip: {
                      trigger: 'item',
                      formatter: '{b} : {c}'
                    },
                    xAxis: {
                        type: 'category',
                        data: xAxis
                    },
                    yAxis: {
                        type: 'value'
                    },
                    series: [{
                        data: yAxis,
                        type: 'bar'
                    }]
                };
                // 使用刚指定的配置项和数据显示图表。
                jiaocaichukuChart1.setOption(option);
                  //根据窗口的大小变动图表
                window.onresize = function() {
                    jiaocaichukuChart1.resize();
                };
            }
        });
      })
    },






  }
};
</script>
<style lang="scss" scoped>
    .cardView {
        display: flex;
        flex-wrap: wrap;
        width: 100%;

        .cards {
            display: flex;
            align-items: center;
            width: 100%;
            margin-bottom: 10px;
            justify-content: center;
            .card {
                width: calc(25% - 20px);
                margin: 0 10px;
                /deep/.el-card__body{
                    padding: 0;
                }
            }
        }
    }
</style>
