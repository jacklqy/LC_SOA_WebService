using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

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
namespace LC_SOA_WebService.Remote
{
    /// <summary>
    /// MyWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class MyWebService : System.Web.Services.WebService
    {
        //必须定义一个权限验证的属性
        public CustomSoapHeader SoapHeaderProp { get; set; }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [SoapHeader("SoapHeaderProp")]//如果需要权限验证就加此特性
        public int Plus(int x, int y)
        {
            //权限验证
            if (!this.SoapHeaderProp.Validate())
            {
                throw new SoapException("身份验证失败", SoapException.ClientFaultCode);
            }
            return x + y;
        }
        [WebMethod]
        [SoapHeader("SoapHeaderProp")]//如果需要权限验证就加此特性
        public string GetInfo(int id, string name)
        {
            //权限验证
            if (!this.SoapHeaderProp.Validate())
            {
                throw new SoapException("身份验证失败", SoapException.ClientFaultCode);
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Id = id,
                Name = name,
                Remark = $"This is {id} {name}"
            });
        }

        [WebMethod]
        [SoapHeader("SoapHeaderProp")]//如果需要权限验证就加此特性
        public UserInfo GetUser(int id)
        {
            //权限验证
            if (!this.SoapHeaderProp.Validate())
            {
                throw new SoapException("身份验证失败", SoapException.ClientFaultCode);
            }
            return new UserInfo()
            {
                Id = id,
                Name = "楠nan",
                Age = 27
            };
        }
        [WebMethod]
        [SoapHeader("SoapHeaderProp")]//如果需要权限验证就加此特性
        public List<UserInfo> GetUserList()
        {
            //权限验证
            if (!this.SoapHeaderProp.Validate())
            {
                throw new SoapException("身份验证失败", SoapException.ClientFaultCode);
            }
            return new List<UserInfo>()
            {
                new UserInfo()
                {
                    Id = 3,
                    Name = "一路有你",
                    Age = 27
                },
                    new UserInfo()
                {
                    Id = 2,
                    Name = "感谢有梦",
                    Age = 25
                }
            };
        }

    }
}
