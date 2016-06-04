
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable()]
public class Scores
{

    LinkedList<Score> scores;

    public Scores()
    {
        scores = new LinkedList<Score>();


    }

    public void addscore(string name, float val)
    {
        Score newscore = new Score(name, val);
        for (int i = 0; i <10 ;i++) {
            if (i == scores.Count)
            {
                scores.AddLast(newscore);
                return;
            }
            else if (val > scores.ElementAt(i).points) {
                scores.AddBefore(scores.Find(scores.ElementAt(i)), newscore);
                return;
            }
        }
    }

    public int getcount()
    {
        return scores.Count;
    }

    public LinkedList<Score> getscores()
    {
        return scores;
    }


}
