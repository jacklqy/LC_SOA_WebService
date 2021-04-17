using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SOA.WebService.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private static string _ConnectionString = null;
        static UnitTest1()
        {
            Console.WriteLine("初始化操作，比如可以提前从数据库或配置文件读取一些值...");
            _ConnectionString = "";//可以从配置文件读取或数据库获取
        }
        public UnitTest1()
        {
            Console.WriteLine("实例化对象的时候初始化赋值操作...");
        }
        [TestMethod]
        public void TestMethod1()
        {
            //用完需要释放
            using (MyWebServiceTest.MyWebServiceSoapClient client = new MyWebServiceTest.MyWebServiceSoapClient())
            {
                MyWebServiceTest.CustomSoapHeader header = new MyWebServiceTest.CustomSoapHeader();
                header.UserName = "jack";
                header.PassWord = "123456";
                //断言
                Assert.AreEqual(client.Plus(header, 1, 2), 3);
                Assert.AreEqual(client.Plus(header, 2, 2), 4);
                Assert.AreEqual(client.Plus(header, 3, 2), 5);
                Assert.AreEqual(client.Plus(header, 4, 2), 3);//这里会断言失败
            }
        }
    }
}
