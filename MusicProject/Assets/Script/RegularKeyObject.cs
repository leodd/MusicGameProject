using UnityEngine;
using System.Collections;
using System;

public class RegularKeyObject : MonoBehaviour, IKeyObject {

    private int time = 10000;
    private int weight = 0;
    private int position = 2;

    private double musicTime = 0;

    private GameTable gameTable;

    private bool workingFlag;

    public RespondType checkRespond(float touchPosition, TouchPhase touchPhase)
    {
        throw new NotImplementedException();
    }

    public bool checkTimeOut()
    {
        if (time - musicTime > KeyUtil.MISS_SLOP) {
            return false;
        }

        return true;
    }

    public int getPosition()
    {
        return position;
    }

    public int getTime()
    {
        return time;
    }

    public int getWeight()
    {
        return weight;
    }

    public void setPosition(int position)
    {
        this.position = position;
    }

    public void setTime(int time)
    {
        this.time = time;
    }

    public void setWeight(int weight)
    {
        float scaleMultiplier;
        switch (weight) {
            case 1: scaleMultiplier = KeyUtil.WEIGTH_SMALL;
                break;
            case 2: scaleMultiplier = KeyUtil.WEIGTH_MID;
                break;
            case 3: scaleMultiplier = KeyUtil.WEIGHT_LARGE;
                break;
            default: scaleMultiplier = 1.0f;
                break;
        }
        
        this.transform.localScale = new Vector3(scaleMultiplier, 1, 1);
        this.weight = weight;
    }

    public void updateMusicTime(float musicTime)
    {
        this.musicTime = musicTime;
    }

    private void updateVerticalPosition() {

    }

    public void initial(BeatKey beatKey)
    {
        setTime(beatKey.time);
        setWeight(beatKey.weight);
        setPosition(beatKey.position);
    }

    public void initial(int time, int weight, int position)
    {
        this.time = time;
        this.weight = weight;
        this.position = position;
    }

    private void updatePosition() {
        this.transform.position = gameTable.calculateKeyPosition(time, position);
    }

    public void startWork()
    {
        if (gameTable == null) {
            gameTable = GameTable.getInstance();
        }

        updatePosition();
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -gameTable.getActualSpeed());
        
        //workingFlag = true;
        //StartCoroutine(ControlledUpdate());
    }

    public void stopWork()
    {
        workingFlag = false;
        Destroy(gameObject);
    }

    public void playAnimation()
    {
        throw new NotImplementedException();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    IEnumerator ControlledUpdate()
    {
        while (workingFlag) {
            updatePosition();
            yield return 0;
        }
    }
}
