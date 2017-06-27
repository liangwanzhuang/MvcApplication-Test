using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace MvcApplication_Test
{
    public class CreateXmlFile
    {
        /// <summary>
        ///创建xml文件
        /// </summary>
        public void CreateXml()
        {
            XmlDocument xmlDoc = new XmlDocument();//创建类型声明节点  
            XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
            xmlDoc.AppendChild(node); //创建根节点  
            XmlNode root = xmlDoc.CreateElement("Users");
            xmlDoc.AppendChild(root);

            XmlElement person = xmlDoc.CreateElement("Person");
            person.SetAttribute("id", "1");//  创建节点为Person，id=1
            person.AppendChild(CreateNode(xmlDoc, person, "name", "张三"));
            person.AppendChild(CreateNode(xmlDoc, person,"Age", "24"));
            root.AppendChild(person);

            //XmlNode node2 = xmlDoc.CreateNode(XmlNodeType.Element, "Person", null);
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
        public XmlNode CreateNode(XmlDocument xmlDoc, XmlNode parentNode, string name, string value)
        {
            XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, name, null);
            node.InnerText = value;
            //parentNode.AppendChild(node);
            return node;
        }
        /// <summary>
        /// 加载解析xml文件
        /// </summary>
        public void ReadXml()
        {
            try
            {
                XmlDocument xmlDoc = LoadXml();
                XmlNodeList topM = xmlDoc.DocumentElement.ChildNodes;
                XmlElement root = xmlDoc.DocumentElement;//获取根节点
                XmlNodeList user = root.GetElementsByTagName("Person");//获取user子节点集合

                foreach (XmlElement node in topM)
                {
                    string id = ((XmlElement)node).GetAttribute("id");   //获取Name属性值 
                    string name = ((XmlElement)node).GetElementsByTagName("Name")[0].InnerText;  //获取Age子XmlElement集合 
                    string age = ((XmlElement)node).GetElementsByTagName("Age")[0].InnerText;
                }

            }
            catch (Exception e)
            {
                CreateXml();
            }
           
        }
        public void EditXml()
        {
            try
            {
                string url = AppDomain.CurrentDomain.BaseDirectory + "xml\\UserData.xml";
                XmlDocument xmlDoc = LoadXml();
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList personNodes = root.GetElementsByTagName("Person");
                foreach (XmlNode node in personNodes)
                {
                    XmlElement ele = (XmlElement)node;
                    if (ele.GetAttribute("id") == "1")
                    {
                        XmlElement nameEle = (XmlElement)ele.GetElementsByTagName("name")[0];
                        nameEle.InnerText = nameEle.InnerText + "修改";
                    }
                }
                xmlDoc.Save(url);
            }
            catch (Exception e)
            {                
            }
        }
        /// <summary>
        ///  删除独立的节点
        /// </summary>
        public void DelectXmlnode()
        {
            try
            {
                string url = AppDomain.CurrentDomain.BaseDirectory + "xml\\UserData.xml";
                XmlDocument xmlDoc = LoadXml();
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList personNodes = root.GetElementsByTagName("Person"); //获取Person子节点集合  
                XmlNode selectNode = root.SelectSingleNode(("/Users/Person[@id='3']"));
                if (selectNode != null)
                {
                    root.RemoveChild(selectNode);
                    xmlDoc.Save(url);
                }
              
            }
            catch (Exception e)
            {
            }
        }
        private XmlDocument LoadXml()
        {
            string url = AppDomain.CurrentDomain.BaseDirectory + "xml\\UserData.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            return doc;
        }
        /// <summary>
        ///  //根节点的添加独立子节点 
        /// </summary>
        public void AddNode()
        {
            string url = AppDomain.CurrentDomain.BaseDirectory + "xml\\UserData.xml";
            XmlDocument xmlDoc = LoadXml();
            XmlElement root = xmlDoc.DocumentElement;
            XmlElement person = xmlDoc.CreateElement("Person");
            person.SetAttribute("id", "3");
            person.AppendChild(CreateNode(xmlDoc,person ,"name", "Elephant"));
            person.AppendChild(CreateNode(xmlDoc,person, "Age", "23"));
            xmlDoc.DocumentElement.AppendChild(person);//xml有且只能有一个根节点 把doc.AppendChild(Element);改成doc.DocumentElement.AppendChild(Element)
            //xmlDoc.AppendChild(person);
            xmlDoc.Save(url);
        }
   }
}