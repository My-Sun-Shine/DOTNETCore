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
### ��̬��Դ
* JS�ļ���CSS�ļ���ͼƬ��
* �����wwwroot�ļ��У�����һ�������ļ���
* ����ע��UseStaticFiles()�м��������ʹ�þ�̬��Դ
### ������
* ��������(���)��NuGet
* ǰ�ˣ�NPM
### ��̬��Դ�ļ�
* 1��ͨ���һ���Ŀ-->���-->�ͻ��˿⣬ѡ��unpkg�������Ҫ�Ŀ�
* 2��������֮����Ŀ�ж��libman.json�����ļ����Լ���wwwroot�¶����Ҫ�Ŀ�
* 3����wwwroot������Զ����
* 4��ͨ���һ���Ŀ-->���-->�½���-->Ӧ�������ļ�������Ϊbundleconfig.json
* 5����bundleconfig.json�����������Ϣ������site.css��bootstrap.css�ϲ�ѹ��Ϊall.min.css����bootstrap.css����ѹ��
```
[
  {
    "outputFileName": "wwwroot/css/all.min.css",
    "inputFiles": [
      "wwwroot/css/site.css",
      "wwwroot/lib/bootstrap/dist/css/bootstrap.css"
    ]
  },

  {
    "outputFileName": "wwwroot/css/bootstrap.css",
    "inputFiles": [
      "wwwroot/lib/bootstrap/dist/css/bootstrap.css"
    ],
    "minify": {
      "enabled": true 
    }
  }
]
```
* 6��ͨ��NuGet���BuildBundlerMinifier
* 7��������Ŀ������wwwroot�оͻ���������ļ�bundleconfig.json�����ļ�