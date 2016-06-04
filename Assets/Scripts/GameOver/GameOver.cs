using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public GameObject newscore;
    public GameObject highscore;
    public GameObject scoretable;
    public GameObject exitbutton;
    public Text playername;
    float time;
    Scores scores;
    string filepath = "scores";

    // Use this for initialization
    void Start()
    {
        if (!File.Exists(filepath))
        {
            Debug.Log("new");
            scores = new Scores();
        }
        else
            loadfile();

        time = MainControl.getEndTime();

        if (scores.getcount() < 10)
        {

            newscore.SetActive(true);
        }
        else if(time > scores.getscores().Last().points)
        {


        }
        else {
            exitbutton.SetActive(true);
            highscore.SetActive(true);
            setTable();
        }
    }
    void Update() {}

    void setTable() {
        foreach (Score score in scores.getscores()) {
            GameObject scorerow = (GameObject) Instantiate(Resources.Load("Score"));
            scorerow.GetComponent<ScoreRow>().setScore(score);
            scorerow.transform.parent=scoretable.transform;

        }
    }

    void savefile()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(filepath, FileMode.Create, FileAccess.Write, FileShare.None);
        formatter.Serialize(stream, scores);
        stream.Close();

    }


    void loadfile()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
        scores = (Scores)formatter.Deserialize(stream);
        stream.Close();


    }

    public void submithighscore()
    {
        scores.addscore(playername.text, time);
        newscore.SetActive(false);
        exitbutton.SetActive(true);
        highscore.SetActive(true);
        setTable();
    }

    public void leaveGameOver() {
        savefile();
        Application.LoadLevel(0);

    }
}
