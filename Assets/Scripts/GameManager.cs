using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI GameTimeTXT = null;
    [SerializeField] private GameObject gameplayUI = null;
    [SerializeField] private GameObject gameoverUI = null;
    [SerializeField] private TextMeshProUGUI gameplayTimeTXT = null;

    private int min;
    private float sec;

    // Start is called before the first frame update
    void Start()
    {
        gameoverUI.SetActive(false);
        min = 0;
        sec = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Incrementing time until game is over
        if (!PlayerController.isGameOver)
        {
            sec += Time.deltaTime;
            if (sec > 59)
            {
                sec = 0f;
                min++;
            }
            //Printing time elapsed in "00:00" format
            GameTimeTXT.SetText((min.ToString().Length > 1 ? min.ToString() : "0" + min.ToString()) + ":"
                               + (((int)sec).ToString().Length > 1 ? ((int)sec).ToString() : "0" + ((int)sec).ToString())
                                );
        }
        else
        {
            gameplayUI.SetActive(false);
            gameoverUI.SetActive(true);
            gameplayTimeTXT.SetText("TIME SURVIVED - " + GameTimeTXT.GetParsedText());
            int BestMin = PlayerPrefs.GetInt("Minutes");
            int BestSec = PlayerPrefs.GetInt("Seconds");

            if (sec > BestSec)
            {
                PlayerPrefs.SetInt("Seconds", (int)sec);
                PlayerPrefs.SetInt("Minutes", min);
            }
            else if(min >= BestMin && sec > BestSec)
            {
                PlayerPrefs.SetInt("Seconds", (int)sec);
                PlayerPrefs.SetInt("Minutes", min);
            }
        }


    }
}
