using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBS : MonoBehaviour {

    public GameManager gameManager;

    private GameObject regularKeyPrefab;
    private GameObject slidingKeyPrefab;

    private bool workingFlag;

    private List<IKeyObject> showList = new List<IKeyObject>();
    //private List<IKeyObject> recycleList = new List<IKeyObject>();

    private void fillshowList() {
        int pointer = gameManager.getPointerOfBeatKeyList();
        IKeyObject keyObject;

        while (gameManager.setPointerOfBeatKeyList(pointer) && gameManager.getCurrentKey().time < showTime()) {
            keyObject = createKeyInstance(gameManager.getCurrentKey());
            showList.Add(keyObject);
            keyObject.startWork();
        }
    }

    private IKeyObject createKeyInstance(BeatKey beatKey) {
        GameObject gameObject =  Instantiate(regularKeyPrefab);
        IKeyObject keyObject = gameObject.GetComponent<IKeyObject>();

        keyObject.initial(beatKey);

        return keyObject;
    }

    public void test() {
        BeatKey beatKey = new BeatKey((int)showTime(), 1, 3, 1);
        IKeyObject keyObject;

        //if (recycleList.Count > 0)
        //{
        //    keyObject = recycleList[0];
        //    recycleList.RemoveAt(0);
        //    keyObject.initial(beatKey);
        //}
        //else
        //{
        //    keyObject = createKeyInstance(beatKey);
        //}

        keyObject = createKeyInstance(beatKey);

        showList.Add(keyObject);
        
        keyObject.startWork();
    }

    private float showTime() {
        return gameManager.getMusicTime() + MovingSpeedGlobalVariable.MOVING_TIME;
    }

    private bool loadPrefab() {
        regularKeyPrefab = (GameObject)Resources.Load("Prefab/RegularKey");
        slidingKeyPrefab = (GameObject)Resources.Load("Prefab/SlidingKey");

        if (regularKeyPrefab == null || slidingKeyPrefab == null) {
            Debug.Log("error: cannot load prefab from the resources");
            return false;
        }

        return true;
    }

    private void checkTimeOut() {
        while (showList.Count > 0) {
            if (showList[0].getTime() < gameManager.getMusicTime() + KeyUtil.MISS_SLOP)
            {
                //recycleList.Add(showList[0]);
                showList[0].stopWork();
                showList.RemoveAt(0);
            }
            else {
                break;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        loadPrefab();
        if (gameManager == null)
        {
            Debug.Log("error: gameManager doesn't exist");
        }

        workingFlag = true;
        StartCoroutine(ControlledUpdate());
    }

    // Update is called once per frame
    IEnumerator ControlledUpdate()
    {
        while (workingFlag) {
            checkTimeOut();
            yield return 0;
        }
    }

    void OnEnable() {
        TouchManager.onRespond += onRespond;
    }

    void OnDisable() {
        TouchManager.onRespond -= onRespond;
    }

    private bool onRespond(TouchUnit touchUnit) {
        test();
        return false;
    }

}
