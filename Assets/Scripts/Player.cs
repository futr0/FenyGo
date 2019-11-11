using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Variables
    public int points = 0;
    public float yIncrement;
    public float speed;
    public float maxHeight;
    public float minHeight;
    public float wphe;
    public float targetWphe;
    public Text wpheDisplay;
    public Text scoreDisplay;
    public Text highScoreDisplay;
    public Button restartButton;
    public Restart restart;

    private Vector2 targetPos;
    private readonly ScoreFileManager scoreFileManager = new ScoreFileManager();
    #endregion

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
           restart.QuitApp();
        }

        if (wphe < targetWphe)
        {
            UpdateHUDScores(Mathf.Round(wphe * 1000.0f) / 1000.0f);
        }

        if (wphe >= targetWphe)
        {
            SavePoints();
            UpdateHUDScores(targetWphe);
            PrintBestScore();
            PrepareToRestart();
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + maxHeight);
            transform.position = targetPos;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - maxHeight);
            transform.position = targetPos;
        }
    }

    private void SavePoints()
    {
        scoreFileManager.SaveResultToFile(points);
    }

    private void UpdateHUDScores(float wphe)
    {
        wpheDisplay.text = string.Format("WPHE: {0}/{1}", wphe, targetWphe);
        scoreDisplay.text = string.Format("Punkty: {0}", points);
    }

    private void PrintBestScore()
    {
        highScoreDisplay.text = string.Format("Najlepszy wynik: {0}", scoreFileManager.GetBestResult());
        highScoreDisplay.gameObject.SetActive(true);
    }

    private void PrepareToRestart()
    {
        restartButton.gameObject.SetActive(true);
        restart.DestroyGameObjects();
    }
}
