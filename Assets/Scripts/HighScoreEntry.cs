[System.Serializable]
public class HighScoreEntry
{
    public string time;
    public int score;

    public HighScoreEntry(string time, int score)
    { 
        this.time = time;
        this.score = score;
    }
}
