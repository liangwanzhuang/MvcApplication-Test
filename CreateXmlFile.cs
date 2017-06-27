using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace MvcApplication_Test
{
    public class CreateXmlFile
    {
        public void CreateXml()
        {
            XmlDocument xmlDoc = new XmlDocument();
            //创建类型声明节点  
            XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
            xmlDoc.AppendChild(node);
            //创建根节点  
            XmlNode root = xmlDoc.CreateElement("Users");
            xmlDoc.AppendChild(root);

            XmlNode node1 = xmlDoc.CreateNode(XmlNodeType.Element, "User", null);
            CreateNode(xmlDoc, node1, "Email", "");
            CreateNode(xmlDoc, node1, "Password", "");
            CreateNode(xmlDoc, node1, "User", "");
            root.AppendChild(node1);

            //XmlNode node2 = xmlDoc.CreateNode(XmlNodeType.Element, "User", null);
            //CreateNode(xmlDoc, node2, "name", "xiaolai");
            //CreateNode(xmlDoc, node2, "sex", "female");
            //CreateNode(xmlDoc, node2, "age", "23");
            //root.AppendChild(node2);

            try
            {
                string url = AppDomain.CurrentDomain.BaseDirectory + "xml\\UserData.xml";
                xmlDoc.Save(url);
            }
            catch (Exception e)
            {
                //显示错误信息  
                Console.WriteLine(e.Message);
            }
            //Console.ReadLine();  

        }
        /// 创建节点    
        /// </summary>    
        /// <param name="xmldoc"></param>  xml文档  
        /// <param name="parentnode"></param>父节点    
        /// <param name="name"></param>  节点名  
        /// <param name="value"></param>  节点值  
        ///   
        public void CreateNode(XmlDocument xmlDoc, XmlNode parentNode, string name, string value)
        {
            XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, name, null);
            node.InnerText = value;
            parentNode.AppendChild(node);
        }

        public void LoadXml()
        {
            try
            {
                string url = AppDomain.CurrentDomain.BaseDirectory + "xml\\UserData.xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(url);
                XmlNodeList topM = doc.DocumentElement.ChildNodes;

               
                foreach (XmlElement element in topM)
                {

                    XmlNodeList nodelist = element.ChildNodes;
                    string id = element.GetElementsByTagName("Email")[0].InnerText;
                    string domainName = element.GetElementsByTagName("Password")[0].InnerText;
                }

            }
            catch (Exception e)
            {
                CreateXml();
            }
           
        }


    }
   
}