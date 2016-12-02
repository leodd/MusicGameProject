using UnityEngine;
using System.Collections;

public class KeyUtil {
    //unit: millisecond
    public readonly static int RESPOND_SLOP = 500;
    public readonly static int GREAT_SLOP = 300;
    public readonly static int PERFECT_SLOP = 100;
    public readonly static int LOWER_PERFECT_SLOP = -50;
    public readonly static int MISS_SLOP = -200;

    public readonly static float WEIGTH_SMALL = 0.7f;
    public readonly static float WEIGTH_MID = 1.0f;
    public readonly static float WEIGHT_LARGE = 1.3f;
}

public class GameTableUtil {

    public readonly static int NUMBER_OF_LINE = 15;
}