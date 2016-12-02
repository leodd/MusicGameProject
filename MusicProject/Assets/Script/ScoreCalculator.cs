using UnityEngine;
using System.Collections;

public class ScoreCalculator {

    public enum ScoreType {
        GREAT = 1,
        PERFECT = 2,
        MISS = 3
    }

    private int combo = 0;
    private int bestCombo = 0;
    private float score = 0;
    private int missNum = 0;
    private int greatNum = 0;
    private int perfectNum = 0;
    private int passNum = 0;

    private float SCORE_BASE = 1;
    private float PERFECT_SCORE_MULTIPLIER = 1.02f;
    private float COMBO_SCORE_MULTIPLIER {
        get {
            return (float)combo / 100 + 1.0f;
        }
    }

    public void clearScore() {
        combo = 0;
        bestCombo = 0;
        score = 0;
        missNum = 0;
        greatNum = 0;
        perfectNum = 0;
        passNum = 0;
    }

    public int getCobomo() {
        return combo;
    }

    public int getBestCombo() {
        return bestCombo;
    }

    public int getScore() {
        return (int)score;
    }

    public int getMissNum() {
        return missNum;
    }

    public int getGreatNum() {
        return greatNum;
    }

    public int getPerfectNum() {
        return perfectNum;
    }

    public int getPassNum() {
        passNum = greatNum + perfectNum;
        return passNum;
    }

    public void update(ScoreType type) {
        switch (type) {
            case ScoreType.GREAT:
                greatNum++;
                combo++;
                score += SCORE_BASE * COMBO_SCORE_MULTIPLIER;
                break;
            case ScoreType.PERFECT:
                perfectNum++;
                combo++;
                score += SCORE_BASE * PERFECT_SCORE_MULTIPLIER * COMBO_SCORE_MULTIPLIER;
                break;
            case ScoreType.MISS:
                missNum++;
                combo = 0;
                break;
        }

        if (combo > bestCombo) {
            bestCombo = combo;
        }
    }

}
