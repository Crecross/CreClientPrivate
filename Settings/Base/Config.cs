using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CreClientTest.Settings
{
    public class Config
    {
        public Config()
        {
            if (!Directory.Exists("CreClient"))
            {
                Directory.CreateDirectory("CreClient");
            }
            if (!File.Exists("CreClient/Config.ini"))
            {
                File.Create("CreClient/Config.ini").Close();
            }
            if (!Directory.Exists("CreClient/VRCA"))
            {
                Directory.CreateDirectory("CreClient/VRCA");
            }
            if (!Directory.Exists("CreClient/VRCW"))
            {
                Directory.CreateDirectory("CreClient/VRCW");
            }
            if (!Directory.Exists("CreClient/BlackList"))
            {
                Directory.CreateDirectory("CreClient/BlackList");
            }
            if (!Directory.Exists("CreClient/BlackList/Avatar"))
            {
                Directory.CreateDirectory("CreClient/BlackList/Avatar");
            }
            if (!File.Exists("CreClient/BlackList/Avatar/Shader.txt"))
            {
                File.Create("CreClient/BlackList/Avatar/Shader.txt").Close();
                File.WriteAllLines("CreClient/BlackList/Avatar/Shader.txt", shaderList);
            }
            if (!File.Exists("CreClient/BlackList/Avatar/Mesh.txt"))
            {
                File.Create("CreClient/BlackList/Avatar/Mesh.txt").Close();
                File.WriteAllLines("CreClient/BlackList/Avatar/Mesh.txt", meshList);
            }
            if (!Directory.Exists("CreClient/Logger"))
            {
                Directory.CreateDirectory("CreClient/Logger");
            }
            if (!File.Exists("CreClient/Logger/Players.txt"))
            {
                File.Create("CreClient/Logger/Players.txt").Close();
            }
        }

        public int getConfigInt(string key, int defaultVal)
        {
            if (File.ReadAllText("CreClient/Config.ini").Contains(key))
            {
                string[] arrLine = File.ReadAllLines("CreClient/Config.ini");
                for (int i = 0; i < arrLine.Length; i++)
                {
                    if (arrLine[i].Contains(key))
                    {
                        return int.Parse(arrLine[i].Split('=')[1]);
                    }
                }
                return 0;
            }
            else
            {
                File.AppendAllText("CreClient/Config.ini", "\n" + key + "=" + defaultVal);
                return defaultVal;
            }
        }

        public void setConfigBool(string key, bool state)
        {
            string[] arrLine = File.ReadAllLines("CreClient/Config.ini");
            for (int i = 0; i < arrLine.Length; i++)
            {
                if (arrLine[i].Contains(key))
                {
                    arrLine[i] = key + "=" + state;
                    break;
                }
            }
            File.WriteAllLines("CreClient/Config.ini", arrLine);
        }

        public bool getConfigBool(string key)
        {
            if (File.ReadAllText("CreClient/Config.ini").Contains(key))
            {
                string[] arrLine = File.ReadAllLines("CreClient/Config.ini");
                for (int i = 0; i < arrLine.Length; i++)
                {
                    if (arrLine[i].Contains(key))
                    {
                        return arrLine[i].Split('=')[1] == "True";
                    }
                }

                return false;
            }
            else
            {
                File.AppendAllText("CreClient/Config.ini", "\n" + key + "=False");
                return false;
            }
        }

        public Color getConfigColor(string key, Color defaultVal)
        {
            if (File.ReadAllText("CreClient/Config.ini").Contains(key))
            {
                string[] arrLine = File.ReadAllLines("CreClient/Config.ini");
                for (int i = 0; i < arrLine.Length; i++)
                {
                    if (arrLine[i].Contains(key))
                    {
                        string[] rgb = arrLine[i].Split('=')[1].Split(',');
                        try
                        {
                            return new Color(float.Parse(rgb[0]), float.Parse(rgb[1]), float.Parse(rgb[2]), float.Parse(rgb[3]));
                        }
                        catch
                        {
                            MelonLoader.MelonLogger.Msg(ConsoleColor.Red, "[Config] [Error] colors not saved as nummbers");
                            return defaultVal;
                        }

                    }
                }
                return defaultVal;
            }
            else
            {
                File.AppendAllText("CreClient/Config.ini", $"\n{key}={defaultVal.r},{defaultVal.g},{defaultVal.b},{defaultVal.a}");
                MelonLoader.MelonLogger.Msg($"[Config] created color {key}");
                return defaultVal;
            }
        }

        private string[] meshList = new string[]
        {
            "125k",
            "medusa",
            "inside",
            "outside",
            "mill"
        };
        private string[] shaderList = new string[] {
            "dbtc",
            "gpu",
            "crash",
            "nigg",
            "home",
            "bye",
            "distance",
            "tess",
            "cr4sh",
            "die",
            "fuck",
            "spryth",
            "hidden",
            "based",
            "vilar",
            "bluescreen",
            "butterfly",
            "bluescream",
            "custom",
            "ebola",
            "yeet",
            "kill",
            "lag ",
            " die ",
            "standard",
            "thot",
            "eatingmy",
            "undetected",
            "retard",
            "retrd",
            "kyuzu",
            "oof",
            ".star",
            ".woofaa",
            "medusa",
            "gang",
            "kyran",
            "onion",
            "pretty",
            "screen black",
            "kys",
            "kos",
            "??",
            "yeeet",
            "got em",
            "nigs",
            "sfere",
            "rip",
            "sanity",
            "school",
            "shooter",
            "bacon",
            "umbrella",
            "bpu",
            "clap",
            "cooch",
            "atençao",
            "izzy",
            "frag",
            "shinigami",
            "world",
            "killer",
            ".blaze",
            "troll",
            "makochill",
            "dead",
            "death",
            "coffin",
            "suspicious",
            "darkwing",
            "keylime",
            "brr",
            "temmie",
            "basically",
            "rampag",
            "reap",
            "C4",
            "edgy",
            "lag",
            "thotkyuzu",
            "loops",
            "overwatch",
            "slay",
            "autism",
            "penis",
            "randomname",
            "careful",
            "hurts",
            "truepink",
            "aнти",
            "Уфф",
            "рендер",
            "Это",
            "Ñoño",
            "nuke",
            "login",
           "ban",
           "buddy",
           "üõõüõ",
           "卍",
           "no sharing"
        };
    }
}