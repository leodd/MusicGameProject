using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicList {

    private string name;

    private string coverPath;
    private string coverLink;

    private string audioPath;
    private string audioLink;

    private string author;

    private float time;
    private int maxTime;

    private Dictionary<int, BeatMapList> beatMapList = new Dictionary<int, BeatMapList>();

    public void setName(string name) {
        this.name = name;
    }

    public void setCover(string cover, string link) {
        this.coverPath = Application.dataPath + @"/Cover/" + cover + ".jpg";
        this.coverLink = link;
    }

    public void setAuthor(string author) {
        this.author = author;
    }

    public void setAudio(string audio, string link) {
        this.audioPath = Application.dataPath + @"/Audio/" + audio + ".mp3";
        this.audioLink = link;
    }

    public void setTime(float time) {
        if (time <= 0) {
            Debug.Log("time cannot be negative!");
            return;
        }
        this.time = time;
    }

    public void setMaxTime(int time) {
        if (time <= 0) {
            Debug.Log("maxTime cannot be negative!");
            return;
        }
        this.maxTime = time;
    }

    public void addBeatMap(int mode, int difficulty, string path, string link) {
        if (mode < 1 || mode > 3) {
            Debug.Log("out of the range of mode!");
            return;
        }

        if (difficulty < 1 || difficulty > 8) {
            Debug.Log("out of the range of difficulty!");
            return;
        }

        BeatMapList bml = new BeatMapList();

        bml.mode = mode;
        bml.difficulty = difficulty;
        bml.path = path;
        bml.link = link;

        if (beatMapList.ContainsKey(mode))
        {
            beatMapList[mode] = bml;
        }
        else {
            beatMapList.Add(mode, bml);
        }
    }

    public void clearBeatMapList() {
        beatMapList.Clear();
    }

    public string getName() {
        return name;
    }

    public string getAuthor() {
        return author;
    }

    public string getCoverPath() {
        return coverPath;
    }

    public string getCoverLink() {
        return coverLink;
    }

    public float getTime() {
        return time;
    }

    public int getMaxTime() {
        return maxTime;
    }

    public string getAudioPath() {
        return audioPath;
    }

    public string getAudioLink() {
        return audioLink;
    }

    public BeatMapList getBeatMapList(int mode) {
        if (!beatMapList.ContainsKey(mode)) {
            return null;
        }
        return beatMapList[mode];
    }

    public override string ToString() {
        string str = "name:" + name + " author:" + author + " time:" + time + "\n coverPath:" + coverPath + "\n audioPath:" + audioPath;
        foreach (KeyValuePair<int, BeatMapList> bml in beatMapList) {
            str += "\n beatMap:" + bml.Value.path;
        }
        return str;
    }
}