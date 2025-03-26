const base = {
    get() {
        return {
            url : "http://localhost:8080/net8d330/",
            name: "net8d330",
            // 退出到首页链接
            indexUrl: 'http://localhost:8080/net8d330/front/h5/index.html'
        };
    },
    getProjectName(){
        return {
            projectName: "基于C#的教材库存管理软件设计与实现"
        } 
    }
}
export default base
