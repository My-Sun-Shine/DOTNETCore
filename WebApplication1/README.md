### 依赖注入
* IoC容器
	* 注册：服务注册
	* 请求实例：请求服务的实例
	* 实例的生命周期：进行设置
* 实例的生命周期
	* Transient：原型模式，这种注册的服务每次被请求都会生成新的实例
	* Scoped：一次web请求产生一个实例，当web请求结束的时候，该实例的生命周期结束
	* Singleton：单例模式，这种注册的服务每次被请求都会使用同一个实例
* 优点：解耦合，不使用具体类接收，使用接口；Controller不需要了解具体的服务类和管理服务类的生命周期
### 不同环境的改变
* 修改Startup.cs中的Configure方法
```
/*
 * 通过变量 ASPNETCORE_ENVIRONMENT 判断是否为开发环境，还是其他环境
 * IsEnvironment(变量值)方法判断自定义的变量值
 */
if (env.IsDevelopment()){
	app.UseDeveloperExceptionPage();
}
```
* 添加Startup.cs中的新Configure()方法
	* 定义ConfigureDevelopment()方法，如果是Development环境，就会走ConfigureDevelopment()方法
	* 如果是Development环境，但是没有定义ConfigureDevelopment()方法，就会走Configure()方法
* Startup.cs中的ConfigureServices()方法名称后面加上环境名称，就如同Configure()方法一样
* Startup类也可以在类名后面加环境名称，例如StartupDevelopment；那么需要修改Program.cs的CreateHostBuilder()方法
```
//先去找对应环境的Startup[环境名称]类，如果没有找到，接着可能会找Startup类，如果还没找到，则会报错
webBuilder.UseStartup(typeof(Program));
```