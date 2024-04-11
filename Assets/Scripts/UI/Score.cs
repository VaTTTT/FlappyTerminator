using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TMP_Text _scoreText;
    private int _score;

    private void Start()
    {
        _scoreText = GetComponent<TMP_Text>();    
    }

    public void IncreaseScore(int value)
    {
        _score += value;
        _scoreText.text = _score.ToString();
    }

    public void ResetScore()
    {
        _score = 0;
        _scoreText.text = _score.ToString();
    }
}
