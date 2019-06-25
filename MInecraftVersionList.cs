using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeerLauncherCoreLibrary.Tool;
using LitJson;

namespace HeerLauncherCoreLibrary
{
    public class Latest
    {/// <summary>
    /// 最新的正式版id
    /// </summary>
        public string release { get; set; }
        /// <summary>
        /// 最新快照id
        /// </summary>
        public string snapshot { get; set; }
    }

    /// <summary>
    /// 就是一个版本信息！
    /// </summary>
    public class Version
    {
        public string id { get; set; }
        public string type { get; set; }
        /// <summary>
        /// 该版本json下载地址
        /// </summary>
        public string url { get; set; }
        public DateTime time { get; set; }
        public DateTime releaseTime { get; set; }
    }
    public class MInecraftVersionList
    {
        public Latest latest { get; set; }
        public List<Version> versions { get; set; }


        /// <summary>
        /// 获取一个MInecraftVersionList实例
        /// </summary>
        /// <returns></returns>
        public static MInecraftVersionList getMInecraftVersionList() {
            var a=Http.GetHttpResponse("https://launchermeta.mojang.com/mc/game/version_manifest.json", 6000);
            if (a==String.Empty)
            {
                return null;
            }
            else
            {
                var b = JsonMapper.ToObject<MInecraftVersionList>(a);
                return b;
            }
        }
    }

}
