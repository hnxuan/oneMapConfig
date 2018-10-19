using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 点选查询
{
    public class layeInfo
    {
        public string id;
        public string label;
        public List<string> layerorder;
        public string title;
        public string sub_title;
        public string body_sub_title;
        public List<string> details;
        public List<fieldsInfo> fields;
    }

    public class fieldsInfo
    {
        public string layername;
        public string keyField;
        public List<valueInfo> value;
    }

    public class valueInfo
    {
        public string name;
        public string alias;
        public string unit;
        public string @default;
    }
}
