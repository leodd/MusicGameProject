using UnityEngine;
using System.Collections;

public interface IKeyObject {
    void initial(BeatKey beatKey);

    void initial(int time, int weight, int position);

    void setTime(int time);

    void setWeight(int weight);

    void setPosition(int position);

    int getTime();

    int getWeight();

    int getPosition();

    RespondType checkRespond(float touchPosition, TouchPhase touchPhase);

    bool checkTimeOut();

    void updateMusicTime(float musicTime);

    void startWork();

    void stopWork();

    void playAnimation();
}

public enum RespondType {
    PERFECT = 1,
    GREAT = 2,
    MISS = 3,
    APPEND = 4
}
