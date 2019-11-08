using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Vector2 targetPos;
    public float yIncrement;
    public float speed;
    public float maxHeight;
    public float minHeight;

    public int health;
    public Text healthDisplay;

    private void Update()
    {
        healthDisplay.text = "Życie: " + health.ToString();

        if(health <=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + yIncrement);
            transform.position = targetPos;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - yIncrement);
            transform.position = targetPos;
        }
    }
}
