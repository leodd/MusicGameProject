using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testing : MonoBehaviour {

    public Text text;

    private BeatMapLoader bml;
    private MusicListLoader mll;

	// Use this for initialization
	void Start () {
        bml = new BeatMapLoader(Application.dataPath + @"/BeatMap/test_music_easy.xml");

        while (bml.read()) {
            text.text += bml.reader.ToString() + "\n";
        }

        mll = new MusicListLoader("test_music");

        text.text += mll.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
