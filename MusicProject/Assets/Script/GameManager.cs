using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public BeatManager beatManager;
    public GameBS gameBS;

    private BeatMapLoader bml;
    private MusicListLoader mll;
    private ScoreCalculator scoreCalculator;

    private int MAX_HIT = 0;
    private int MAX_MILLI_TIME = 0;
    private float MAX_TIME = 0;
    private int MAX_WIDTH = 0;
    private int MODE = 1;
    private string MUSIC_NAME = "test_music";

    // Use this for initialization
    void Start () {
        //loadMusic(MUSIC_NAME, MODE);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void loadMusic(string name, int mode) {
        mll = new MusicListLoader(name);

        string beatMapPath = mll.getBeatMapList(mode).path;
        bml = new BeatMapLoader(beatMapPath);
    }

    public float getMusicTime() {
        if (beatManager == null) {
            Debug.Log("error: beatManager doesn't exist");
            return 0;
        }

        return beatManager.musicTime;
    }

    public void scoreUpdate(ScoreCalculator.ScoreType type) {
        if (scoreCalculator == null) {
            Debug.Log("error: scoreCalculator doesn't exist");
            return;
        }

        scoreCalculator.update(type);
    }

    public bool moveToNextKey() {
        return bml.read();
    }

    public BeatKey getCurrentKey() {
        return new BeatKey(bml.reader);
    }

    public int getPointerOfBeatKeyList() {
        return bml.getPointer();
    }

    public bool setPointerOfBeatKeyList(int index) {
        return bml.setPointer(index);
    }

    public void resetPointerOfBeatKeyList() {
        bml.resetPointer();
    }

}
