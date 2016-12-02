using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;

public class MusicListLoader : MusicList {

    private string musicListPath;

    public MusicListLoader(string name) {
        musicListPath = Application.dataPath + @"/MusicList/" + name + ".xml";
        loadMusicListXML(musicListPath);
    }

    public void loadByName(string name)
    {
        musicListPath = Application.dataPath + @"/MusicList/" + name + ".xml";
        loadMusicListXML(musicListPath);
    }

    private void loadMusicListXML(string path) {
        if (!File.Exists(path)) {
            return;
        }

        XmlTextReader reader = new XmlTextReader(path);

        try {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "name")
                    {
                        setName(reader.ReadElementString().Trim());
                    }

                    if (reader.Name == "cover")
                    {
                        setCover(reader.ReadElementString().Trim(), reader.GetAttribute("link"));
                    }

                    if (reader.Name == "audio")
                    {
                        setAudio(reader.ReadElementString().Trim(), reader.GetAttribute("link"));
                    }

                    if (reader.Name == "author")
                    {
                        setAuthor(reader.ReadElementString().Trim());
                    }

                    if (reader.Name == "time")
                    {
                        setTime((float)XmlConvert.ToDouble(reader.ReadElementString().Trim()));
                    }

                    if (reader.Name == "maxtime")
                    {
                        setMaxTime(XmlConvert.ToInt32(reader.ReadElementString().Trim()));
                    }

                    if (reader.Name == "beatmap")
                    {
                        clearBeatMapList();

                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "name")
                            {
                                int bmode = XmlConvert.ToInt32(reader.GetAttribute("mode"));
                                int bdifficulty = XmlConvert.ToInt32(reader.GetAttribute("difficulty"));
                                string blink = reader.GetAttribute("link");
                                string bpath = Application.dataPath + @"/BeatMap/" + reader.ReadElementString().Trim() + ".xml";
                                addBeatMap(bmode, bdifficulty, bpath, blink);
                            }

                            if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "beatmap")
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        catch (XmlException ex) {
            Debug.Log(ex);
        }

        reader.Close();
    }


}
