# LC_SOA_WebService
    /// <summary>
    /// 1 SOA的思想，分布式服务
    /// 2 WebService声明调用授权，Remoting比较
    /// 3 单元测试服务调用
    /// 
    /// SOA:面向服务架构，是构造分布式系统的方法论，也会提供一些标准、工具。
    /// 
    /// WebService:寄宿在IIS，也就是必须在网站项目
    /// Http协议  SOAP协议
    /// 1 Http传输信道，A服务器到B服务器，数据是什么格式传递的
    /// 2 XML的数据格式---Http传输解析得到的有用数据
    /// 3 SOAP协议---封装格式：在分布式的环境中，描述了如何做数据交换的一个轻量级协议
    /// 4 WSDL：属于webservice的标配，标准化描述服务，方便调用
    /// 5 UDDI：根据描述查找服务的机制
    /// 
    /// 服务端调用WebService添加服务引用，基于svcUtil.exe生成的
    /// 基于wsdl生成的一个代理：屏蔽服务调用的复杂性
    /// 
    /// 单元测试：测试方法---回归测试
    /// 
    /// WebService安全认证：
    /// Form认证  windows认证
    /// 服务方法里面添加账号密码参数
    /// SoapHeader验证
    /// </summary>
    
WebService创建+权限认证+单元测试
![image](https://user-images.githubusercontent.com/26539681/115118130-7208e200-9fd4-11eb-8864-91a5da210afd.png)
![image](https://user-images.githubusercontent.com/26539681/115118135-76cd9600-9fd4-11eb-9d17-11024392e6ef.png)
![image](https://user-images.githubusercontent.com/26539681/115118139-7a611d00-9fd4-11eb-9796-295f0ab329c8.png)

希望为.net开源社区尽绵薄之力，探lu者###一直在探索前进的路上###（QQ:529987528）
