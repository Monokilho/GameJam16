using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreRow : MonoBehaviour {

    public Text playername;
    public Text playerscore;

    public void setScore(Score score) {
        playername.text = score.name;
        playerscore.text = score.points.ToString();
    }
}
