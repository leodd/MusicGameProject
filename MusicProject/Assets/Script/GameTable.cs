using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class GameTable : MonoBehaviour {

    public Transform beginBorder;
    public Transform endBorder;
    public Transform leftBorder;
    public Transform rightBorder;

    public GameManager gameManager;

    private static GameTable instance;

    private float beginCoordinate;
    private float endCoordinate;
    private float leftCoordinate;
    private float rightCoordinate;

    private float tableWidth;
    private float tableLength;
    private float gap;
    private float speed;

    public static GameTable getInstance() {
        if (instance == null) {
            Debug.Log("error: instance of gameTable doesn't exist");
        }

        return instance;
    }

    public void initialize() {
        if (beginBorder == null || endBorder == null || leftBorder == null || rightBorder == null) {
            Debug.Log("error: there's something wrong with the border");
            return;
        }

        if (gameManager == null) {
            Debug.Log("error: gameManager doesn't exist");
            return;
        }

        beginCoordinate = beginBorder.position.z;
        endCoordinate = endBorder.position.z;
        leftCoordinate = leftBorder.position.x;
        rightCoordinate = rightBorder.position.x;

        tableWidth = rightCoordinate - leftCoordinate;
        tableLength = beginCoordinate - endCoordinate;
        gap = tableWidth / GameTableUtil.NUMBER_OF_LINE;
        speed = tableLength / MovingSpeedGlobalVariable.MOVING_TIME;
    }

    public float getActualSpeed() {
        return speed * 1000;
    }

    public Vector3 calculateKeyPosition(int time, int linePosition) {
        Vector3 position = new Vector3(0, 0, 0);

        position.z = ((float)time - gameManager.getMusicTime()) * speed + endCoordinate;
        position.x = ((float)linePosition - 0.5f) * gap + leftCoordinate;

        return position;
    }

    public Vector3 calculateFinalPosition(int linePosition) {
        Vector3 position = new Vector3(0, 0, 0);

        position.x = ((float)linePosition - 1.5f) * gap;
        position.z = endCoordinate;

        return position;
    }

	// Use this for initialization
	void Start () {
        initialize();
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
