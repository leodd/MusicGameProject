using UnityEngine;
using System.Collections;

public class MovingSpeedGlobalVariable {
    public static int MOVING_SPEED = 6;
    public static float MOVING_TIME_BASE = 6000.0f;
    public static float MOVING_TIME = 6000.0f / 6.0f;
}

public class GlobalPath {
    public static string assetsPath =

#if UNITY_ANDROID
        "jar:file://" + Application.dataPath + "!/assets";

#elif UNITY_IPHONE
        "file://" + Application.dataPath + "/Raw";

#else
        "file://" + Application.dataPath + "/StreamingAssets";

#endif

    public static string dataPath = Application.persistentDataPath;
    //public static string musicPath = assetsPath + "MusicList/";
}
