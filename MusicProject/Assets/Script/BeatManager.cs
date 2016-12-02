using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class BeatManager : MonoBehaviour {

    private string audioPath;
    private AudioClip audioClip;
    private AudioSource audioSource;

    private bool mIsLoad = false;
    public bool isLoad {
        get
        {
            return mIsLoad;
        }
    }

    public bool isPlay {
        get {
            if (audioSource == null || !audioSource.isPlaying) {
                return false;
            }

            return true;
        }
    }

    private int sampleTime = 0;
    private int frequency = 1;
    private float playedTime = 0;
    public float musicTime {
        get {
            return playedTime;
        }
    }

    public Text text;

	// Use this for initialization
	void Start () {
        StartCoroutine(ControlledUpdate());
        loadAudio("/Audio/Sleep Away.OGG");
        playAudio();
    }

    IEnumerator ControlledUpdate() {
        while (true) {
            if (audioSource != null)
            {
                sampleTime = audioSource.timeSamples;
                playedTime = ((float)sampleTime / frequency * 1000);
            }
            else
            {
                playedTime = 0;
            }

            text.text = (int)musicTime + "";

            yield return 0;
        }
    }

    public void loadAudio(string path) {
        audioPath = path;

        StartCoroutine(loadAudioFromFile(audioPath));
    }

    private IEnumerator loadAudioFromFile(string path) {
        mIsLoad = true;
        WWW www = new WWW(GlobalPath.assetsPath + path);

        while (!www.isDone) {
            yield return 0;
        }

        audioClip = www.audioClip;

        mIsLoad = false;
    }

    public void playAudio() {
        if (audioClip == null && mIsLoad == false) {
            return;
        }

        if (audioSource == null)
        {
            audioSource = this.GetComponent<AudioSource>();
        }

        if (audioSource.clip != null) {
            frequency = audioClip.frequency;
            audioSource.Play();
            return;
        }

        StartCoroutine(waitAndPlay());
    }

    private IEnumerator waitAndPlay() {
        while (isLoad) {
            yield return 0;
        }

        frequency = audioClip.frequency;
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void pauseOrResume() {
        if (audioSource == null) {
            return;
        }

        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else {
            audioSource.Play();
        }
    }
}
