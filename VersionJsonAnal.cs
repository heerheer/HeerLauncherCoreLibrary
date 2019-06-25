using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitJson;

namespace HeerLauncherCoreLibrary
{

    class ArgHelper {

        private bool isForge(string jsonText)
        {
            JsonData json = JsonMapper.ToObject(jsonText);
            if (json["inheritsFrom"] != null)
            {
                return true;
            }
            return false;
        }
    }


    public class Arguments
    {
        public List<object> game { get; set; }
        public List<object> jvm { get; set; }
    }
    public class AssetIndex
    {
        public string id { get; set; }
        public string sha1 { get; set; }
        public int size { get; set; }
        public int totalSize { get; set; }
        public string url { get; set; }
    }
    public class Client
    {
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }
    public class Server
    {
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }
    public class Downloads
    {
        public Client client { get; set; }
        public Server server { get; set; }
    }
    public class Artifact
    {
        public string path { get; set; }
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }
    public class Javadoc
    {
        public string path { get; set; }
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }
    public class NativesLinux
    {
        public string path { get; set; }
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }
    public class NativesMacos
    {
        public string path { get; set; }
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }
    public class NativesWindows
    {
        public string path { get; set; }
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }
    public class Sources
    {
        public string path { get; set; }
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }
    public class NativesOsx
    {
        public string path { get; set; }
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }
    public class Classifiers
    {
        public Javadoc javadoc { get; set; }
        public NativesLinux __invalid_name__natives_linux { get; set; }
        public NativesMacos __invalid_name__natives_macos { get; set; }
        public NativesWindows __invalid_name__natives_windows { get; set; }
        public Sources sources { get; set; }
        public NativesOsx __invalid_name__natives_osx { get; set; }
    }
    public class Downloads2
    {
        public Artifact artifact { get; set; }
        public Classifiers classifiers { get; set; }
    }
    public class Natives
    {
        public string linux { get; set; }
        public string osx { get; set; }
        public string windows { get; set; }
    }
    public class Extract
    {
        public List<string> exclude { get; set; }
    }
    public class Os
    {
        public string name { get; set; }
    }
    public class Rule
    {
        public string action { get; set; }
        public Os os { get; set; }
    }
    public class Library
    {
        public Downloads2 downloads { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public Natives natives { get; set; }
        public Extract extract { get; set; }
        public List<Rule> rules { get; set; }
    }
    public class File
    {
        public string id { get; set; }
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }
    public class Client2
    {
        public string argument { get; set; }
        public File file { get; set; }
        public string type { get; set; }
    }
    public class Logging
    {
        public Client2 client { get; set; }
    }
    public class MinecraftVersion
    {

        public Arguments arguments { get; set; }
        public AssetIndex assetIndex { get; set; }
        public string assets { get; set; }
        public Downloads downloads { get; set; }
        public string id { get; set; }
        public List<Library> libraries { get; set; }
        public Logging logging { get; set; }
        public string mainClass { get; set; }
        public int minimumLauncherVersion { get; set; }
        public DateTime releaseTime { get; set; }
        public DateTime time { get; set; }
        public string type { get; set; }
    }
}
