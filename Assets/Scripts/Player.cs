using System.Collections;
using System.Collections.Generic;
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

    public Button restart;
    public int points = 0;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (wphe < targetWphe)
        {
            wpheDisplay.text = "WPhe: " + (Mathf.Round(wphe * 1000.0f) / 1000.0f).ToString();
            scoreDisplay.text = "Punkty: " + points;
        }

        if (wphe >= targetWphe)
        {
            wpheDisplay.text = "WPhe: " + targetWphe;
            scoreDisplay.text = "Punkty: " + points;
            restart.gameObject.SetActive(true);
            DestroyGameObjects();
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

    private void DestroyGameObjects()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("Spawner"));

        GameObject[] GameObjects = GameObject.FindGameObjectsWithTag("Obstacle");
        for (int i = 0; i < GameObjects.Length; i++)
        {
            Destroy(GameObjects[i]);
        }
    }
}
