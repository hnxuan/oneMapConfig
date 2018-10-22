using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace 点选查询
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string[] services = servicesText.Text.Split('\n');
            List<layeInfo> layeInfos = new List<layeInfo>();

            for (int i = 0; i < services.Length; i++)
            {
                //单个服务
                layeInfo layeInf = new layeInfo();

                bool isLayerInfo = getLayerInfo(services[i], ref layeInf);
                if (!isLayerInfo)
                {
                    return;
                }
                if (layeInf.layerorder.Count != 0)
                {
                    layeInfos.Add(layeInf);
                }

            }
            if (!isKeyField.Checked)
            {
                JsonSerializerSettings jsetting = new JsonSerializerSettings();
                jsetting.NullValueHandling = NullValueHandling.Ignore;
                configText.Text = ConvertJsonString(JsonConvert.SerializeObject(layeInfos, Formatting.Indented, jsetting));
            }
            else
            {
                configText.Text = ConvertJsonString(JsonConvert.SerializeObject(layeInfos));
            }

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

        private void check_Btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(configJsonUrl.Text) || string.IsNullOrEmpty(checkConfigJsonUrl.Text))
            {
                MessageBox.Show("两个地址都不能为空！");
                return;
            }
            servicesText.Text = "";
            var configJsonObject = JObject.Parse(HttpApi(configJsonUrl.Text));
            var layerList = configJsonObject["map"]["layerList"];
            var checkConfigJsonObject = JObject.Parse(HttpApi(checkConfigJsonUrl.Text));
            var layersInfo = checkConfigJsonObject["layersInfo"];
            var checkWord = new string[] { "" };
            if (!string.IsNullOrEmpty(idKeyWord.Text))
            {
                if (idKeyWord.Text.Contains(','))
                {
                    checkWord = idKeyWord.Text.Split(',');
                }
                else
                {
                    checkWord = new string[] { idKeyWord.Text };
                }

            }
            for (var i = 0; i < layerList.Count(); i++)
            {
                if (Convert.ToBoolean(layerList[i]["isleaf"]) == true)
                {
                    var ismatch = false;
                    for (var j = 0; j < layersInfo.Count(); j++)
                    {
                        //id一致性检查
                        if (Convert.ToString(layerList[i]["id"]) == Convert.ToString(layersInfo[j]["id"]))
                        {
                            ismatch = true;
                            break;
                        }
                    }
                    for (int k = 0; k < checkWord.Length; k++)
                    {
                        if (Convert.ToString(layerList[i]["id"]) == checkWord[k])
                        {
                            ismatch = true;
                            break;
                        }
                    }
                    if (!ismatch)
                    {
                        servicesText.AppendText(layerList[i]["id"] + "@" + layerList[i]["url"] + "\r\n");
                    }
                }
            }
            servicesText.Text = servicesText.Text.Trim();
        }

        private bool isFilter(ref string[] arry, string filterString)
        {
            if (!string.IsNullOrEmpty(filterString))
            {
                if (filterString.Contains(','))
                {
                    arry = filterString.Trim().Split(',');
                }
                else
                {
                    arry = new string[] { filterString.Trim() };
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool getLayerInfo(string service, ref layeInfo layeInf)
        {

            //是否过滤图层名,字段,单位
            bool isFilterLayerName = false, isFilterField = false, isFilterUnit = false;
            string[] layerName_wordArry = new string[] { "" }, field_wordArry = new string[] { "" }, Unit_wordArry = new string[] { "" };

            string tokenVal = "";
            if (!string.IsNullOrEmpty(tokenValue.Text))
            {
                tokenVal = "&token=" + tokenValue.Text;
            }
            //过滤图层名
            isFilterLayerName = isFilter(ref layerName_wordArry, layerNameKeyWord.Text);
            //过滤字段名
            isFilterField = isFilter(ref field_wordArry, keyWord.Text);
            //过滤单位名
            isFilterUnit = isFilter(ref Unit_wordArry, unitKeyWord.Text);

            //单个服务
            layeInf.layerorder = new List<string>();
            layeInf.fields = new List<fieldsInfo>();

            var layerId = "";

            if (service.Contains("@"))
            {
                layerId = service.Substring(0, service.IndexOf("@"));
                service = service.Substring(service.IndexOf("@") + 1);
            }

            var layersObject = JObject.Parse(HttpApi(service + "?f=pjson" + tokenVal));

            string lname = HttpUtility.UrlDecode(service.Split('/')[(service.Split('/').Length - 2)], System.Text.Encoding.UTF8);

            if (!string.IsNullOrEmpty(layerId))
            {
                layeInf.id = layerId;
            }
            else
            {
                layeInf.id = lname;
            }
            layeInf.label = lname;
            layeInf.title = lname;
            layeInf.sub_title = "";
            layeInf.body_sub_title = "";
            layeInf.details = new List<string>();

            //图层数
            if (layersObject["layers"] == null)
            {
                MessageBox.Show("请检查服务(是否添加token)：" + layeInf.id + "@" + service);
                return false;
            }
            int layerNum = layersObject["layers"].Count();
            for (int j = 0; j < layerNum; j++)
            {
                var layerObject = JObject.Parse(HttpApi(service + "//" + j + "?f=pjson" + tokenVal));

                string layerName = Convert.ToString(layerObject["name"]);
                //判断是否过滤该图层

                bool isLayerNameContinue = true;

                if (isFilterLayerName)
                {
                    foreach (var ite in layerName_wordArry)
                    {
                        if (layerName == ite)
                        {
                            isLayerNameContinue = false;
                            break;
                        }
                    }
                }

                if (!isLayerNameContinue)
                {
                    continue;
                }

                //过滤图层名不包含中文
                if (chineseLayerName.Checked && !System.Text.RegularExpressions.Regex.IsMatch(layerName, "[\u4e00-\u9fa5]"))
                {
                    continue;
                }

                //单个图层
                fieldsInfo fieldInf = new fieldsInfo();
                fieldInf.layername = layerName;
                fieldInf.keyField = "";
                if (!isKeyField.Checked)
                {
                    fieldInf.keyField = null;
                }
                fieldInf.value = new List<valueInfo>();

                var fields = layerObject["fields"];
                foreach (var item in fields)
                {
                    string fieldName = Convert.ToString(item["name"]);
                    if (!string.IsNullOrEmpty(keyWord.Text))
                    {
                        bool isContinue = true;

                        if (isFilterField)
                        {
                            foreach (var ite in field_wordArry)
                            {
                                if (fieldName.ToLower() == ite.ToLower())
                                {
                                    isContinue = false;
                                    break;
                                }
                            }
                        }

                        if (!isContinue)
                        {
                            continue;
                        }
                    }
                    //过滤字段不包含中文
                    if (isEnglish.Checked && !System.Text.RegularExpressions.Regex.IsMatch(Convert.ToString(item["alias"]), "[\u4e00-\u9fa5]"))
                    {
                        continue;
                    }
                    //过滤重复别名
                    if (fieldInf.value.FindIndex(a => a.alias == Convert.ToString(item["alias"])) != -1)
                    {
                        continue;
                    }

                    valueInfo val = new valueInfo();
                    val.name = fieldName;
                    val.alias = Convert.ToString(item["alias"]);

                    //提取单位关键字
                    bool isKeyWord = true;
                    string unitWord = "";

                    if (isFilterUnit)
                    {
                        foreach (var ite in Unit_wordArry)
                        {
                            if (val.alias.Contains(ite))
                            {
                                isKeyWord = false;
                                unitWord = ite;
                                break;
                            }
                        }
                    }

                    if (!isKeyWord)
                    {
                        string aliasString = Convert.ToString(item["alias"]);
                        if (aliasString.IndexOf("(") != -1)
                        {
                            val.@default = aliasString.Substring(0, aliasString.IndexOf("("));
                        }
                        else if (aliasString.IndexOf("（") != -1)
                        {
                            val.@default = aliasString.Substring(0, aliasString.IndexOf("（"));
                        }
                        else
                        {
                            MessageBox.Show("该服务" + layeInf.id + "@" + service + "的面积字段填写不规范，请检查。面积单位：" + unitWord + "。 请在单位关键字删除该单位后生成json并手工提取单位关键字！！");
                            return false;
                        }

                        val.unit = unitWord;
                    }
                    else
                    {
                        val.@default = Convert.ToString(item["alias"]);
                        val.unit = "";
                    }
                    fieldInf.value.Add(val);
                }
                if (fieldInf.value.Count != 0)
                {
                    layeInf.fields.Add(fieldInf);
                    layeInf.layerorder.Add(layerName);
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(configJsonUrl.Text) || string.IsNullOrEmpty(checkConfigJsonUrl.Text))
            {
                MessageBox.Show("两个地址都不能为空！");
                return;
            }
            servicesText.Text = "";
            var configJsonObject = JObject.Parse(HttpApi(configJsonUrl.Text));
            var layerList = configJsonObject["map"]["operationallayers"];
            var checkConfigJsonObject = JObject.Parse(HttpApi(checkConfigJsonUrl.Text));
            var layersInfo = checkConfigJsonObject["layersInfo"];

            for (var j = 0; j < layersInfo.Count(); j++)
            {
                string id = Convert.ToString(layersInfo[j]["id"]), url = "";
                bool ismatch = true;
                if (layerList.Where(a => Convert.ToString(a["label"]) == Convert.ToString(layersInfo[j]["id"])).Count() > 0)
                {
                    var layer = layerList.Where(a => Convert.ToString(a["label"]) == Convert.ToString(layersInfo[j]["id"])).First();
                    layeInfo layeInf = new layeInfo();
                    if (getLayerInfo(Convert.ToString(layer["url"]), ref layeInf))
                    {
                        id = Convert.ToString(layer["label"]);
                        url = Convert.ToString(layer["url"]);
                        for (int k = 0; k < layeInf.fields.Count; k++)
                        {
                            if (layersInfo[j]["fields"].Where(a => Convert.ToString(a["layername"]) == layeInf.fields[k].layername).Count() > 0)
                            {
                                foreach (var ite in layeInf.fields[k].value)
                                {
                                    var array = layersInfo[j]["fields"].Where(a => Convert.ToString(a["layername"]) == layeInf.fields[k].layername).ToList();
                                    if (array[0]["value"].Where(a => Convert.ToString(a["alias"]) == ite.alias).Count() == 0)
                                    {
                                        ismatch = false;
                                        break;
                                    }
                                }
                            }
                            if (!ismatch)
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    servicesText.AppendText(id + "----------未找到的id,请删除此行" + url + "\r\n");
                }
                if (!ismatch)
                {
                    servicesText.AppendText(id + "@" + url + "\r\n");
                }
            }
            servicesText.Text = servicesText.Text.Trim();
        }
    }
}
