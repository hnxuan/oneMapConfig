using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Web;
using System.Net;
using System.Configuration;

namespace 生成服务目录树
{
    public partial class Form1 : Form
    {
        public class mulu
        {
            public string id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string parent { get; set; }
            public bool @checked { get; set; }
            public bool isleaf { get; set; }
        }

        public class server
        {
            public string id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string parent { get; set; }
            public bool @checked { get; set; }
            public bool isleaf { get; set; }
            public string type { get; set; }
            public string createDate { get; set; }
            public string origin { get; set; }
            public bool showLegend { get; set; }
            public bool isShow { get; set; }
            public bool isEnable { get; set; }
            public string url { get; set; }
        }

        public class operationallayer
        {
            public string label { get; set; }
            public string url { get; set; }
            public string type { get; set; }
            public string icon { get; set; }
            public bool visible { get; set; }
            public bool isOperationalLayer { get; set; }
        }

        public class information
        {
            public string parentId { get; set; }
            public string name { get; set; }
            public string id { get; set; }
            public string type { get; set; }
            public string url { get; set; }
            public int index { get; set; }
            public string classLabel { get; set; }
        }

        private List<mulu> muluList = new List<mulu>();
        private List<server> serverList = new List<server>();
        private List<operationallayer> operationallayerList = new List<operationallayer>();
        private List<parent.User> informations = new List<parent.User>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string parent = "";
            string lastParent = "";
            string writeString = "";
            string zhengxuString = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            string[] zhengxuArry = { "" };
            List<operationallayer> operationallayer_result = new List<operationallayer>();

            //处理正序目录
            if (!string.IsNullOrEmpty(zhengxu.Text))
            {
                if (zhengxu.Text.Contains(","))
                {
                    zhengxuArry = zhengxu.Text.Split(',');
                }
                else
                {
                    zhengxuArry[0] = zhengxu.Text;
                }

            }

            mulu zhuMul = new mulu();
            zhuMul.id = "所有数据";
            zhuMul.name = "所有数据";
            zhuMul.description = "";
            zhuMul.parent = "数据";
            zhuMul.@checked = true;
            zhuMul.isleaf = false;

            richTextBox2.AppendText(ConvertJsonString(JsonConvert.SerializeObject(zhuMul)) + ",\r\n");

            for (var i = 0; i < richTextBox1.Lines.Length; i++)
            {
                string operaString = "";
                var now_ClassNum = richTextBox1.Lines[i].LastIndexOf("#");
                //#符号多于上一行时
                if (now_ClassNum != 0)
                {
                    for (int z = i - 1; z > -1; z--)
                    {
                        if (richTextBox1.Lines[z].LastIndexOf("#") >= now_ClassNum)
                        {
                            continue;
                        }
                        else
                        {
                            if (richTextBox1.Lines[z].Contains(','))
                            {
                                MessageBox.Show("服务节点不能作为目录,请检查第" + (z + 1) + "行");
                                richTextBox2.Text = "";
                                richTextBox3.Text = "";
                                return;
                            }
                            //包含id信息
                            if (richTextBox1.Lines[z].Contains('~'))
                            {
                                if (richTextBox1.Lines[z].Contains('@'))
                                {
                                    parent = getString(richTextBox1.Lines[z], "~", "@");
                                }
                                else
                                {
                                    parent = richTextBox1.Lines[z].Substring(richTextBox1.Lines[z].LastIndexOf("~") + 1);
                                }
                            }
                            else
                            {
                                parent = richTextBox1.Lines[z].Substring(richTextBox1.Lines[z].LastIndexOf("#") + 1);
                            }
                            break;
                        }
                    }
                }
                else if (now_ClassNum == 0)
                {
                    parent = "所有数据";
                }
                //地图服务
                if (richTextBox1.Lines[i].Contains(','))
                {
                    var name = richTextBox1.Lines[i].Split(',')[0];
                    server ser = new server();
                    if (!name.Contains('@'))
                    {
                        //包含id信息
                        if (name.Contains('~'))
                        {
                            ser.id = name.Substring(name.IndexOf('~') + 1);
                            ser.name = getString(name, "#", "~");
                        }
                        else
                        {
                            var layerId = HttpUtility.UrlDecode(richTextBox1.Lines[i].Split(',')[1].Split('/')[(richTextBox1.Lines[i].Split(',')[1].Split('/').Length - 2)], System.Text.Encoding.UTF8);
                            ser.id = layerId;
                            ser.name = name.Substring(name.LastIndexOf("#") + 1);
                        }
                        if (serverIdOne.Checked)
                        {
                            ser.id = richTextBox1.Lines[i].Split(',')[1].Split('.')[2] + "_" + richTextBox1.Lines[i].Split(',')[1].Split('.')[3].Substring(0, 2) + "_" + HttpUtility.UrlDecode(richTextBox1.Lines[i].Split(',')[1].Split('/')[(richTextBox1.Lines[i].Split(',')[1].Split('/').Length - 3)], System.Text.Encoding.UTF8) + "_" + HttpUtility.UrlDecode(richTextBox1.Lines[i].Split(',')[1].Split('/')[(richTextBox1.Lines[i].Split(',')[1].Split('/').Length - 2)], System.Text.Encoding.UTF8);
                        }

                        ser.description = "";
                        ser.@checked = false;
                        ser.isleaf = true;
                        ser.type = "server";
                        ser.createDate = "";
                        ser.origin = "";
                        //影像不显示图例
                        if (richTextBox1.Lines[i].Split(',')[0].Contains("影像"))
                        {
                            ser.showLegend = false;
                        }
                        else
                        {
                            ser.showLegend = true;
                        }
                        ser.isShow = true;
                        ser.isEnable = true;
                        ser.url = richTextBox1.Lines[i].Split(',')[1];
                    }
                    //包含@模式
                    else
                    {
                        ser.id = getString(name, "~", "@");
                        ser.name = getString(name, "#", "~");

                        int index = Convert.ToInt32(name.Substring(name.IndexOf('@') + 1));
                        ser.description = serverList[index].description;
                        ser.@checked = serverList[index].@checked;
                        ser.isleaf = serverList[index].isleaf;
                        ser.type = serverList[index].type;
                        ser.createDate = serverList[index].createDate;
                        ser.origin = serverList[index].origin;
                        ser.showLegend = serverList[index].showLegend;
                        ser.isShow = serverList[index].isShow;
                        ser.isEnable = serverList[index].isEnable;
                        ser.url = richTextBox1.Lines[i].Split(',')[1];
                    }

                    ser.parent = parent;
                    writeString = ConvertJsonString(JsonConvert.SerializeObject(ser));

                    //生成operationallayer部分
                    operationallayer opera = new operationallayer();
                    opera.label = ser.id;
                    opera.url = richTextBox1.Lines[i].Split(',')[1];
                    opera.icon = "";
                    opera.visible = false;
                    opera.isOperationalLayer = false;

                    //在operationallayerList查找到以前的配置
                    int operationallayerListIndex = operationallayerList.FindIndex(a => a.label == ser.id);
                    if (operationallayerListIndex != -1)
                    {
                        opera.type = Convert.ToString(operationallayerList[operationallayerListIndex].type);
                        opera.icon = Convert.ToString(operationallayerList[operationallayerListIndex].icon);
                        opera.visible = Convert.ToBoolean(operationallayerList[operationallayerListIndex].visible);
                        opera.isOperationalLayer = Convert.ToBoolean(operationallayerList[operationallayerListIndex].isOperationalLayer);
                    }
                    var layersObject = JObject.Parse(HttpApi(richTextBox1.Lines[i].Split(',')[1] + "?f=pjson"+getToken(richTextBox1.Lines[i].Split(',')[1])));
                    if (layersObject["singleFusedMapCache"] == null)
                    {
                        MessageBox.Show("请检查exe.config中token信息是否填写正确");
                    }
                    else
                    {
                        bool isdynamic = Convert.ToBoolean(layersObject["singleFusedMapCache"]);
                        if (isdynamic)
                        {
                            opera.type = "tiled";
                        }
                        else
                        {
                            opera.type = "dynamic";
                        }
                    }

                    if (operationallayer_result.FindIndex(a=>a.label==opera.label&&a.url==opera.url)==-1)
                    {
                        operationallayer_result.Add(opera);
                        operaString = ConvertJsonString(JsonConvert.SerializeObject(opera));
                    }
                }
                //目录
                else
                {
                    var name = richTextBox1.Lines[i];
                    mulu mul = new mulu();
                    //包含id信息
                    if (!name.Contains('@'))
                    {
                        if (name.Contains('~'))
                        {
                            mul.id = name.Substring(name.IndexOf("~") + 1);
                            mul.name = getString(name, "#", "~");
                        }
                        else
                        {
                            mul.id = name.Substring(name.LastIndexOf("#") + 1);
                            mul.name = name.Substring(name.LastIndexOf("#") + 1);
                        }

                        mul.description = "";
                        mul.@checked = false;
                        mul.isleaf = false;
                    }
                    //包含@模式
                    else
                    {
                        if (name.Contains('~'))
                        {
                            mul.id = getString(name, "~", "@");
                            mul.name = getString(name, "#", "~");
                        }
                        else
                        {
                            mul.id = getString(name, "#", "@");
                            mul.name = name.Substring(name.LastIndexOf("#") + 1);
                        }
                        int index = Convert.ToInt32(name.Substring(name.IndexOf('@') + 1));
                        mul.description = muluList[index].description;
                        mul.@checked = muluList[index].@checked;
                        mul.isleaf = muluList[index].isleaf;
                    }
                    mul.parent = parent;

                    writeString = ConvertJsonString(JsonConvert.SerializeObject(mul));
                }

                //填充内容部分
                if (i == (richTextBox1.Lines.Length - 1))
                {
                    richTextBox2.AppendText(writeString);
                    if (!string.IsNullOrEmpty(operaString))
                    {
                        if (!string.IsNullOrEmpty(zhengxuString))
                        {
                            if (lastParent == parent)
                            {
                                zhengxuString += ",\r\n" + operaString;
                                richTextBox3.Text = richTextBox3.Text.Insert(0, zhengxuString.Substring(3));
                                zhengxuString = "";
                            }
                            else
                            {
                                richTextBox3.Text = richTextBox3.Text.Insert(0, zhengxuString);
                                zhengxuString = "";
                                richTextBox3.Text = richTextBox3.Text.Insert(0, operaString);
                            }
                        }
                        else
                        {
                            richTextBox3.Text = richTextBox3.Text.Insert(0, operaString);
                        }
                    }
                }
                //非最后一个
                else
                {
                    richTextBox2.AppendText(writeString + ",\r\n");
                    if (!string.IsNullOrEmpty(operaString))
                    {
                        if (!string.IsNullOrEmpty(zhengxu.Text))
                        {
                            if (zhengxuArry.Contains(parent))
                            {
                                if (lastParent == parent)
                                {
                                    zhengxuString += ",\r\n" + operaString;
                                }
                                else if (zhengxuString == "")
                                {
                                    zhengxuString += ",\r\n" + operaString;
                                }
                                else
                                {
                                    richTextBox3.Text = richTextBox3.Text.Insert(0, zhengxuString);
                                    zhengxuString = "";
                                }
                            }
                            else
                            {
                                richTextBox3.Text = richTextBox3.Text.Insert(0, ",\r\n" + operaString);
                            }

                        }
                        else
                        {
                            richTextBox3.Text = richTextBox3.Text.Insert(0, ",\r\n" + operaString);
                        }
                    }
                }

                lastParent = parent;
            }
            if(richTextBox3.Text.IndexOf(',')== 0){
                richTextBox3.Text=richTextBox3.Text.Substring(2);
            }
        }

        private string ConvertJsonString(string str)
        {
            //格式化json字符串
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(str);
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            else
            {
                return str;
            }
        }

        private string getString(string str, string a, string b)
        {
            int i = str.LastIndexOf(a);//找a的位置  
            int j = str.IndexOf(b);//找b的位置  
            str = (str.Substring(i + 1)).Substring(0, j - i - 1);//找出a和b之间的字符串
            return str;
        }

        private void idCheck(string type)
        {
            List<string> wordList = new List<string>();


            for (var i = 0; i < richTextBox1.Lines.Length; i++)
            {
                string word = null;
                if (type == "mulu")
                {
                    if (!richTextBox1.Lines[i].Contains(','))
                    {
                        if (richTextBox1.Lines[i].Contains('~'))
                        {
                            if (richTextBox1.Lines[i].Contains('@'))
                            {
                                word = getString(richTextBox1.Lines[i], "~", "@");
                            }
                            else
                            {
                                word = richTextBox1.Lines[i].Substring(richTextBox1.Lines[i].IndexOf("~") + 1);
                            }
                        }
                        else
                        {
                            if (richTextBox1.Lines[i].Contains('@'))
                            {
                                word = getString(richTextBox1.Lines[i], "#", "@");
                            }
                            else
                            {
                                word = richTextBox1.Lines[i].Substring(richTextBox1.Lines[i].LastIndexOf("#") + 1);
                            }
                        }
                    }
                }
                else if (type == "server")
                {
                    if (richTextBox1.Lines[i].Contains(','))
                    {
                        if (richTextBox1.Lines[i].Contains('~'))
                        {
                            if (richTextBox1.Lines[i].Contains('@'))
                            {
                                word = getString(richTextBox1.Lines[i], "~", "@");
                            }
                            else
                            {
                                word = getString(richTextBox1.Lines[i], "~", ",");
                            }
                        }
                        else
                        {
                            if (richTextBox1.Lines[i].Contains('@'))
                            {
                                word = getString(richTextBox1.Lines[i], "#", "@");
                            }
                            else
                            {
                                word = getString(richTextBox1.Lines[i], "#", ",");
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(word))
                {
                    if (wordList.FindIndex(a => a == word) != -1)
                    {
                        MessageBox.Show("第" + (i + 1) + "行存在重复的ID:" + word + " 请检查");
                        return;
                    }
                    else
                    {
                        wordList.Add(word);
                    }
                }
            }
            MessageBox.Show("无重复ID");
        }
        /// <summary>
        /// 调用api返回json
        /// </summary>
        /// <param name="url">api地址</param>
        /// <param name="jsonstr">接收参数</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static string HttpApi(string url)
        {
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//webrequest请求api地址
            request.Accept = "text/html,application/xhtml+xml,*/*";
            request.ContentType = "application/json";
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            serverList.Clear();
            muluList.Clear();
            operationallayerList.Clear();
            informations.Clear();

            var configJsonObject = JObject.Parse(HttpApi(configJsonUrl.Text));
            var operationallayers = configJsonObject["map"]["operationallayers"];
            var layerList = configJsonObject["map"]["layerList"];
            int serverListNum = 0, muluListNum = 0;
            //map.layerList节点循环
            for (int i = 0; i < layerList.Count(); i++)
            {

                if (Convert.ToBoolean(layerList[i]["isleaf"]))
                {
                    serverList.Add(new server
                    {
                        id = Convert.ToString(layerList[i]["id"]),
                        name = Convert.ToString(layerList[i]["name"]),
                        parent = Convert.ToString(layerList[i]["parent"]),
                        isShow = Convert.ToBoolean(layerList[i]["isShow"]),
                        isEnable = Convert.ToBoolean(layerList[i]["isEnable"]),
                        @checked = Convert.ToBoolean(layerList[i]["checked"]),
                        type = Convert.ToString(layerList[i]["type"]),
                        description = Convert.ToString(layerList[i]["description"]),
                        createDate = Convert.ToString(layerList[i]["createDate"]),
                        origin = Convert.ToString(layerList[i]["origin"]),
                        isleaf = Convert.ToBoolean(layerList[i]["isleaf"]),
                        showLegend = Convert.ToBoolean(layerList[i]["showLegend"]),
                        url = Convert.ToString(layerList[i]["url"])
                    });

                    informations.Add(new parent.User
                    {
                        id = Convert.ToString(layerList[i]["type"])+Convert.ToString(layerList[i]["id"]),
                        realId = Convert.ToString(layerList[i]["id"]),
                        name = Convert.ToString(layerList[i]["name"]),
                        parentId = "mulu"+Convert.ToString(layerList[i]["parent"]),
                        type = Convert.ToString(layerList[i]["type"]),
                        url = Convert.ToString(layerList[i]["url"]),
                        index= serverListNum,
                        classLabel= (Convert.ToString(layerList[i]["parent"])=="所有数据")?"#":""
                    });

                    serverListNum += 1;
                }
                else
                {
                    muluList.Add(new mulu
                    {
                        id = Convert.ToString(layerList[i]["id"]),
                        name = Convert.ToString(layerList[i]["name"]),
                        description = Convert.ToString(layerList[i]["description"]),
                        parent = Convert.ToString(layerList[i]["parent"]),
                        @checked = Convert.ToBoolean(layerList[i]["checked"]),
                        isleaf = Convert.ToBoolean(layerList[i]["isleaf"])
                    });

                    informations.Add(new parent.User
                    {
                        id = "mulu" + Convert.ToString(layerList[i]["id"]),
                        realId =Convert.ToString(layerList[i]["id"]),
                        name = Convert.ToString(layerList[i]["name"]),
                        parentId = "mulu" + Convert.ToString(layerList[i]["parent"]),
                        type = "mulu",
                        url = "",
                        index = muluListNum,
                        classLabel = (Convert.ToString(layerList[i]["parent"]) == "所有数据") ? "#" : ""
                    });

                    muluListNum += 1;
                }

            }
            //map.operationallayers节点循环
            for (int i = 0; i < operationallayers.Count(); i++)
            {
                operationallayerList.Add(new operationallayer
                {
                    label = Convert.ToString(operationallayers[i]["label"]),
                    url = Convert.ToString(operationallayers[i]["url"]),
                    type = Convert.ToString(operationallayers[i]["type"]),
                    icon = Convert.ToString(operationallayers[i]["icon"]),
                    visible = Convert.ToBoolean(operationallayers[i]["visible"]),
                    isOperationalLayer = Convert.ToBoolean(operationallayers[i]["isOperationalLayer"]),
                });
            }

            parent treeNode = new parent(informations);
            treeNode.ur.classLabel = "";
            treeNode.Create(treeNode.ur, "mulu所有数据");
            treeNode.Find(treeNode.ur, informations);
            Print(treeNode.ur);
            richTextBox1.Text= richTextBox1.Text.Substring(0, richTextBox1.Text.Length - 1);
        }

        private void muluIdCheck_Click(object sender, EventArgs e)
        {
            idCheck("mulu");
        }

        private void serverIdCheck_Click(object sender, EventArgs e)
        {
            idCheck("server");
        }
        //打印查看结果
        private void Print(parent.UserR ur)
        {
            if (ur.realId!=null)
            {
                if (ur.type == "mulu")
                {
                    richTextBox1.AppendText(ur.classLabel + ur.name + "~" + ur.realId + "@" + ur.index + "\r\n");
                }
                else if (ur.u.Count==0)
                {
                    richTextBox1.AppendText(ur.classLabel + ur.name + "~" + ur.realId + "@" + ur.index + "," + ur.url + "\r\n");
                }
            }


            if (ur.u != null)
                foreach (var item in ur.u)
                {
                    item.classLabel = ur.classLabel + "#";
                    Print(item);
                }
        }
        static string getToken(string url)
        {
            try
            {
                string key = url.Substring(0, url.LastIndexOf(':'));
                var appSettings = ConfigurationManager.AppSettings;
                string result = (appSettings[key] != null) ? "&token=" + appSettings[key] : "";
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                MessageBox.Show("读取AppSettings错误");
                return "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.AppendText("#未在operationallayers节点配置的服务列表(请删除此行)"+  "\r\n");

            var configJsonObject = JObject.Parse(HttpApi(configJsonUrl.Text));
            var operationallayers = configJsonObject["map"]["operationallayers"];
            var layerList = configJsonObject["map"]["layerList"];
            for (int i = 0; i < layerList.Count(); i++)
            {
                if (Convert.ToBoolean(layerList[i]["isleaf"]))
                {
                    var ismatch = false;
                    for (int j = 0; j < operationallayers.Count(); j++)
                    {
                        if (Convert.ToString(operationallayers[j]["label"])== Convert.ToString(layerList[i]["id"]))
                        {
                            ismatch = true;
                            break;
                        }
                    }
                    if (!ismatch)
                    {
                        richTextBox1.AppendText("##" + Convert.ToString(layerList[i]["name"]) + "~" + Convert.ToString(layerList[i]["id"]) + "," + Convert.ToString(layerList[i]["url"]) + "\r\n");
                    }
                }
            }
            richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.Text.Length - 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.AppendText("#在operationallayers节点已配置的服务信息错误列表(请删除此行)" + "\r\n");

            var configJsonObject = JObject.Parse(HttpApi(configJsonUrl.Text));
            var operationallayers = configJsonObject["map"]["operationallayers"];
            var layerList = configJsonObject["map"]["layerList"];
            for (int i = 0; i < layerList.Count(); i++)
            {
                if (Convert.ToBoolean(layerList[i]["isleaf"]))
                {
                    var ismatch = false;
                    for (int j = 0; j < operationallayers.Count(); j++)
                    {
                        if (Convert.ToString(operationallayers[j]["label"]) == Convert.ToString(layerList[i]["id"]))
                        {
                            if (Convert.ToString(operationallayers[j]["url"]) == Convert.ToString(layerList[i]["url"]))
                            {
                                string type = "";
                                var layersObject = JObject.Parse(HttpApi(Convert.ToString(operationallayers[j]["url"]) + "?f=pjson"+getToken(Convert.ToString(operationallayers[j]["url"]))));
                                if (layersObject["singleFusedMapCache"] == null)
                                {
                                    MessageBox.Show("请检查exe.config中token信息是否填写正确");
                                }
                                else
                                {
                                    bool isdynamic = Convert.ToBoolean(layersObject["singleFusedMapCache"]);
                                    if (isdynamic)
                                    {
                                        type = "tiled";
                                    }
                                    else
                                    {
                                        type = "dynamic";
                                    }
                                }
                                if (type== Convert.ToString(operationallayers[j]["type"]))
                                {
                                    ismatch = true;
                                    break;
                                }

                            }

                        }
                    }
                    if (!ismatch)
                    {
                        richTextBox1.AppendText("##" + Convert.ToString(layerList[i]["name"]) + "~" + Convert.ToString(layerList[i]["id"]) + "," + Convert.ToString(layerList[i]["url"]) + "\r\n");
                    }
                }
            }
            richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.Text.Length - 1);
        }
    }
}
