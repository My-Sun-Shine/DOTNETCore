### ����ע��
* IoC����
	* ע�᣺����ע��
	* ����ʵ������������ʵ��
	* ʵ�����������ڣ���������
* ʵ������������
	* Transient��ԭ��ģʽ������ע��ķ���ÿ�α����󶼻������µ�ʵ��
	* Scoped��һ��web�������һ��ʵ������web���������ʱ�򣬸�ʵ�����������ڽ���
	* Singleton������ģʽ������ע��ķ���ÿ�α����󶼻�ʹ��ͬһ��ʵ��
* �ŵ㣺����ϣ���ʹ�þ�������գ�ʹ�ýӿڣ�Controller����Ҫ�˽����ķ�����͹�����������������
### ��ͬ�����ĸı�
* �޸�Startup.cs�е�Configure����
```
/*
 * ͨ������ ASPNETCORE_ENVIRONMENT �ж��Ƿ�Ϊ����������������������
 * IsEnvironment(����ֵ)�����ж��Զ���ı���ֵ
 */
if (env.IsDevelopment()){
	app.UseDeveloperExceptionPage();
}
```
* ���Startup.cs�е���Configure()����
	* ����ConfigureDevelopment()�����������Development�������ͻ���ConfigureDevelopment()����
	* �����Development����������û�ж���ConfigureDevelopment()�������ͻ���Configure()����
* Startup.cs�е�ConfigureServices()�������ƺ�����ϻ������ƣ�����ͬConfigure()����һ��
* Startup��Ҳ��������������ӻ������ƣ�����StartupDevelopment����ô��Ҫ�޸�Program.cs��CreateHostBuilder()����
```
//��ȥ�Ҷ�Ӧ������Startup[��������]�࣬���û���ҵ������ſ��ܻ���Startup�࣬�����û�ҵ�����ᱨ��
webBuilder.UseStartup(typeof(Program));
```