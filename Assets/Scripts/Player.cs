using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Vector2 targetPos;
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
    public int points = 0;

    private readonly ScoreFileManager scoreFileManager = new ScoreFileManager();
    public Restart restart;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (wphe < targetWphe)
        {
            wpheDisplay.text = string.Format("WPHE: {0}/{1}", Mathf.Round(wphe * 1000.0f) / 1000.0f, targetWphe);
            scoreDisplay.text = string.Format("Punkty: {0}", points);
        }

        if (wphe >= targetWphe)
        {
            scoreFileManager.SaveResultToFile(points);
            wpheDisplay.text = string.Format("WPHE: {0}/{1}", targetWphe, targetWphe);
            scoreDisplay.text = string.Format("Punkty: {0}", points);
            highScoreDisplay.text = string.Format("Najlepszy wynik: {0}", scoreFileManager.GetBestResult());
            highScoreDisplay.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            restart.DestroyGameObjects();
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + 10);
            transform.position = targetPos;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - 10);
            transform.position = targetPos;
        }
    }

}
