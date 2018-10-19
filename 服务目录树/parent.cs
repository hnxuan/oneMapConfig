using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 生成服务目录树
{
   public class parent
    {

        public parent(List<User> tolist)
        {
            list = tolist;
        }
        public List<User> list { get; set; }

        //最终结果
        public UserR ur = new UserR();

        //递归遍历
        public  void Create(UserR node, string id)
        {
            var q = list.Where(x => x.parentId == id).ToList();
            if (id == "mulu所有数据")                                  // id = "mulu所有数据" 是根节点   
            {
                for (int i = 0; i < q.Count; i++)
                {
                    UserR nd = new UserR();
                    nd.id = q[i].id;
                    nd.name = q[i].name;
                    nd.realId = q[i].realId;
                    nd.type = q[i].type;
                    nd.url = q[i].url;
                    nd.index = q[i].index;
                    nd.classLabel = q[i].classLabel;
                    nd.parentId = q[i].parentId;
                    Create(nd, q[i].id);
                    ur.u.Add(nd);
                }
            }
            else
            {
                for (int i = 0; i < q.Count; i++)
                {
                    UserR Tnode = new UserR();
                    Tnode.id = q[i].id;
                    Tnode.name = q[i].name;
                    Tnode.realId = q[i].realId;
                    Tnode.type = q[i].type;
                    Tnode.url = q[i].url;
                    Tnode.index = q[i].index;
                    Tnode.classLabel = q[i].classLabel;
                    Tnode.parentId = q[i].parentId;
                    Create(Tnode, q[i].id);
                    node.u.Add(Tnode);
                }
            }
        }
        public void Find(UserR node, List<User> informations)
        {
            List<indexResult> results = new List<indexResult>();
            var q = node.u.Where(x => x.parentId == "mulu所有数据").ToList();
            for (int i = 0; i < q.Count; i++)
            {
                bool isAllmulu = true;
                if (q[i].u.Where(x => x.u.Count == 0).ToList().Count > 0)
                {
                    isAllmulu = false;
                }
                if (isAllmulu)
                {
                    Find(q[i], informations, results, q[i].realId);
                }
                else
                {
                    results.Add(new indexResult { label = q[i].realId, index = q[i].index });
                }
            }
            for (int i = 0; i < results.Count; i++)
            {
                node.u.Find(x => x.realId == results[i].label).arryIndex = results[i].index;
            }
            node.u.Sort(delegate (UserR x, UserR y) { return x.arryIndex.CompareTo(y.arryIndex); });
        }

        //查找排序
        public void Find(UserR node,List<User> informations,List<indexResult> results,string label)
        {
            if (node.u.Count==0)
            {
                indexResult result = new indexResult();
                result.label = label;
                result.index = informations.Find(a => a.id == node.parentId && a.type == "mulu").index;
                results.Add(result);
            }
            else
            {
                Find(node.u[0], informations, results, label);
            }
        }

        //打印查看结果
        static void Print(UserR ur)
        {
            Console.WriteLine(ur.name);
            if (ur.u != null)
                foreach (var item in ur.u)
                {
                    Print(item);
                }
        }

        //查询出的实体层
        public class User
        {
            public string id { get; set; }
            public string realId { get; set; }
            public string name { get; set; }
            public string parentId { get; set; }
            public string type { get; set; }
            public string url { get; set; }
            public int index { get; set; }
            public string classLabel { get; set; }
        }
        //遍历后的实体层
        public class UserR
        {
            public string id { get; set; }
            public string realId { get; set; }
            public string name { get; set; }
            public string parentId { get; set; }
            public string type { get; set; }
            public string url { get; set; }
            public int index { get; set; }
            public int arryIndex { get; set; }
            public string classLabel { get; set; }
            public List<UserR> u = new List<UserR>();
        }

        public class indexResult{
            public string label { get; set; }
            public int index { get; set; } 
        }
    }
}
