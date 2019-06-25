using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LitJson;

namespace HeerLauncherCoreLibrary
{
    public class MinecraftStartHelper
    {
        private string mainClass;
        public string NativePath = Directory.GetCurrentDirectory() + "\\.minecraft";
        public List<MinecraftVersion> verList { get; set; }
        public List<Library> libs { get; set; }
        /// <summary>
        /// 是否是单一层版本
        /// </summary>
        public bool isOriginal { get; set; }

        //
        /// <summary>
        /// 通过版本进行实例化。
        /// </summary>
        /// <param name="version"></param>
        public MinecraftStartHelper(string version) {
            verList = new List<MinecraftVersion>();
            libs = new List<Library>();

            var version2 = version;
            var jsonText = new StreamReader(NativePath + "\\versions\\" + version2 + "\\" + version2 + ".json").ReadToEnd();
            JsonData json = JsonMapper.ToObject(jsonText);
            MinecraftVersion mv= JsonMapper.ToObject<MinecraftVersion>(jsonText);
            this.mainClass = json["mainClass"].ToString();
            verList.Add(mv);
            if (json.Keys.Contains("inheritsFrom")) {
                this.isOriginal = true;
            }
            while (json.Keys.Contains("inheritsFrom") )
            {
                
                version2 = json["inheritsFrom"].ToString();
                jsonText= new StreamReader(NativePath + "\\versions\\" + version2 + "\\" + version2 + ".json").ReadToEnd();
                json.Clear();
                json = JsonMapper.ToObject(jsonText);
                mv= JsonMapper.ToObject<MinecraftVersion>(jsonText);
                verList.Add(mv);
            }//把所有层次版本搞出来

            foreach (MinecraftVersion item in verList)
            {
                libs.AddRange(item.libraries);
            }

            this.getLatestLibFromLibList();

        }

        private void getLatestLibFromLibList() {
            var libs2 = this.libs;
            List<cuteLibNameIncVersion> lc = new List<cuteLibNameIncVersion>();//持久list
            List<cuteLibNameIncVersion> rList = new List<cuteLibNameIncVersion>();//最后的List
            foreach (var item in libs2)
            {
                char c = ':';
                var spiltedName= item.name.Split(c);
                cuteLibNameIncVersion temp = new cuteLibNameIncVersion();
                temp.name = spiltedName[0] + spiltedName[1];
                temp.version = Int32.Parse( Regex.Replace(spiltedName[2], @"[^\d]*", ""));
                temp.theLib = item;
                lc.Add(temp);

            }
            //上面把每个lib分析了下。
            var has = false;
            foreach (var item in lc)
            {
                foreach (var item2 in lc)
                {
                    if (item.name == item2.name && item.version > item2.version)
                    {
                        rList.Add(item);
                        has = true;
                        break;
                    }
                    else if (item.name == item2.name && item.version < item2.version)
                    {
                        has = true;
                        rList.Add(item2);
                        break;
                    }
                    else {
                        has = false;
                    }
                }
                if (has != true) { rList.Add(item); }
                has = false;

            }//该死的循环，别管。
            this.libs.Clear();
            foreach (var item in rList)
            {
                this.libs.Add(item.theLib);
            }
        }//lib独立版本比较

        public string getmainClass() {
            return this.mainClass;
        }

        
    }
     class cuteLibNameIncVersion {
        public string name;
        public int version;
        public Library theLib;
    }
}
