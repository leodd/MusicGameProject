using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;

public class BeatMapLoader {

    private string beatMapPath;
    private List<BeatKey> beatMap = new List<BeatKey>();
    private int pointer;

    private BeatKey mReader = new BeatKey();
    public BeatKey reader {
        get { return mReader; }
    }

    public BeatMapLoader(string path) {
        this.beatMapPath = path;
        loadBeatMapXML(beatMapPath);
        pointer = 0;
    }

    private void loadBeatMapXML(string path) {
        if (!File.Exists(path))
        {
            return;
        }

        XmlTextReader reader = new XmlTextReader(path);

        try {
            while (reader.Read()) {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "timeline") {
                    readTimeLineXML(reader);
                }
            }
        }
        catch (XmlException ex) {
            Debug.Log(ex);
        }
    }

    private void readTimeLineXML(XmlReader reader) {
        int time = XmlConvert.ToInt32(reader.GetAttribute("time"));
        BeatKey key;

        while (reader.Read()) {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "key") {
                key = new BeatKey();
                key.time = time;
                key.type = XmlConvert.ToInt32(reader.GetAttribute("type"));
                key.weight = XmlConvert.ToInt32(reader.GetAttribute("weight"));
                key.position = XmlConvert.ToInt32(reader.GetAttribute("position"));

                beatMap.Add(key);
            }

            if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "timeline") {
                return;
            }
        }
    }

    public bool read() {
        if(pointer > beatMap.Count - 1)
        {
            return false;
        }

        mReader = beatMap[pointer];
        pointer++;

        return true;
    }

    public bool setPointer(int index) {
        if (index > beatMap.Count - 1 || index < 0) {
            return false;
        }

        pointer = index;
        mReader = beatMap[pointer];

        return true;
    }

    public int getPointer() {
        return pointer;
    }

    public void resetPointer() {
        pointer = 0;
    }

}
