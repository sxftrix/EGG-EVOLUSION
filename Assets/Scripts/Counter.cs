using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public int eggCount = 0;
    public int chickCount = 0;
    public int henCount = 0;
    public int kirosterCount = 0;

    public Image eggImage;
    public Image chickImage;
    public Image henImage;
    public Image kirosterImage;

    public Text clockText;

    private float elapsedTime = 0f;

    private void Update()
    {
        // Update the count text next to each image
        eggImage.transform.GetChild(0).GetComponent<Text>().text = eggCount.ToString();
        chickImage.transform.GetChild(0).GetComponent<Text>().text = chickCount.ToString();
        henImage.transform.GetChild(0).GetComponent<Text>().text = henCount.ToString();
        kirosterImage.transform.GetChild(0).GetComponent<Text>().text = kirosterCount.ToString();

        // Update the clock
        elapsedTime += Time.deltaTime;
        DisplayTime(elapsedTime);
    }

    void DisplayTime(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        clockText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
