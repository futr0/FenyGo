using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Text highScoreText;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            QuitApp();
        }
    }
    public void RestartGame()
    {
        Time.timeScale = 0;
        highScoreText.gameObject.SetActive(false);
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void DestroyGameObjects()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("Spawner"));

        GameObject[] GameObjects = GameObject.FindGameObjectsWithTag("Obstacle");
        for (int i = 0; i < GameObjects.Length; i++)
        {
            Destroy(GameObjects[i]);
        }
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
