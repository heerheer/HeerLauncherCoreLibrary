using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitJson;

namespace HeerLauncherCoreLibrary
{
    class InnerOpe {
        public List<string> libraryPath() {
            return new List<string>();
        }
    }

    public class StartInfo {
        public string playerName { get; set; }
        public string uuid { get; set; }
        public string token { get; set; }
        public string tokencookie { get; set; }
        public int memory { get; set; }
        public string javaPath { get; set; }
        public string prefix { get; set; }
        public string suffix { get; set; }
        public string jvm { get; set; }
        /// <summary>
        /// 右下角那行字
        /// </summary>
        public string exText { get; set; }
        public string ip { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public string logPath { get; set; }

        /// <summary>
        /// 这是最全的实例化（其实你们一个一个自己写也可以啊==）
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="uuid"></param>
        /// <param name="token"></param>
        /// <param name="tokencookie"></param>
        /// <param name="memory"></param>
        /// <param name="javaPath"></param>
        /// <param name="prefix"></param>
        /// <param name="suffix"></param>
        /// <param name="jvm"></param>
        /// <param name="exText"></param>
        /// <param name="ip"></param>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <param name="logPath"></param>
        public StartInfo(string playerName,string uuid, string token, string tokencookie, int memory, string javaPath, string prefix, string suffix, string jvm, string exText, string ip, string height, string weight, string logPath) {
            this.playerName = playerName;
            this.uuid = uuid;
            this.token = token;
            this.tokencookie = tokencookie;
            this.memory = memory;
            this.javaPath = javaPath;
            this.prefix = prefix;
            this.suffix = suffix;
            this.jvm = jvm;
            this.exText = exText;
            this.ip = ip;
            this.height = height;
            this.weight = weight;
            this.logPath = logPath;
        }
        /// <summary>
        /// 我觉得这个最简洁惹。
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="javaPath"></param>
        public StartInfo(string playerName,string javaPath) {
            this.javaPath = javaPath;
            this.playerName = playerName;

        }



    }
    public class Game
    {
        /// <summary>
        /// 默认为运行目录+\.minecraft
        /// </summary>
        public string NativePath = Directory.GetCurrentDirectory() + "\\.minecraft";

        public Game() {
        }
        /// <summary>
        /// 使用.minecraft文件夹(可以使用其他名字)位置来实例化
        /// </summary>
        /// <param name="NativePath">.minecraft文件夹所在位置，末尾无需\\</param>
        public Game(string NativePath) {
            this.NativePath = NativePath;
        }

        /// <summary>
        /// 获取version下所有版本
        /// </summary>
        /// <returns>id的列表string</returns>
        public List<string> getAllNativeGameVersion() {
            List<string> returnc = new List<string>() ;
            string path = NativePath + "\\versions";
            
            var dir = new DirectoryInfo(path);
            var dir2=dir.GetDirectories();
            foreach (var item in dir2)
            {
                returnc.Add(item.Name);
            }
            return returnc;
        }
        public void start(string version,StartInfo startInfo) {

        }

        public string summonStartCmd(string version,StartInfo startInfo) {
            var a = "";
            MinecraftVersion mc = new MinecraftVersion();
            string normalstr= "{0}"+
            "\" -Dminecraft.launcher.version={1} -Dminecraft.launcher.brand={2} -Dminecraft.client.jar={3} \" - Dlog4j.configurationFile ={ dloag}"+
           " \" -XX:+UnlockExperimentalVMOptions -XX:+UseG1GC -XX:G1NewSizePercent=20 -XX:G1ReservePercent=20 -XX:MaxGCPauseMillis=50 -XX:G1HeapRegionSize=16M -XX:-UseAdaptiveSizePolicy -XX:-OmitStackTraceInFastThrow -Xmn{}m -Xmx{}m -Dfml.ignoreInvalidMinecraftCertificates=true -Dfml.ignorePatchDiscrepancies=true -XX:HeapDumpPath=MojangTricksIntelDriversForPerformance_javaw.exe_minecraft.exe.heapdump \" - Djava.library.path ={ natives}"+
            "\" -cp \"{ libs + jar)"+
            "\" net.minecraft.client.main.Main --username {name} --version \"{ }"+
            "\" --gameDir \"{.m}"+
            "\" --assetsDir \"{ a}"+
            "\" --assetIndex {aid} --uuid {uuid} --accessToken {token} --userType mojang --versionType release --height 480 --width 854\"";
            string r3 = NativePath + "\\versions\\" + version + "\\" + version + ".jar";

            string.Format(normalstr, startInfo.javaPath, "HLC", "0.1",r3);
            return a;
        }

    }
}
