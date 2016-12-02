using UnityEngine;
using System.Collections;

public class BeatKey {

    public int time;

    public int weight;

    public int position;

    public int type;

    public BeatKey() : this(0, 1, 1, 1) { }

    public BeatKey(int time, int type, int weight, int position) {
        this.time = time;
        this.type = type;
        this.weight = weight;
        this.position = position;
    }

    public BeatKey(BeatKey beatKey) {
        time = beatKey.time;
        type = beatKey.type;
        weight = beatKey.weight;
        position = beatKey.position;
    }

    public override string ToString() {
        return "time:" + time + " type:" + type + " weight:" + weight + " position:" + position;
    }

}
