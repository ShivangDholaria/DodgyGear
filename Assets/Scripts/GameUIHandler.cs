using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUIHandler : MonoBehaviour
{
    internal static bool StartGame = false;
    [SerializeField] private PlayerController playercontroller = null;
    [SerializeField] private GearSpawner gearspawner = null;
    [SerializeField] private TextMeshProUGUI bestTimeTxt = null;

    // Start is called before the first frame update
    void Start()
    {
        bestTimeTxt.SetText("Best Time Survived : " + (PlayerPrefs.GetInt("Minutes").ToString().Length > 1 ? PlayerPrefs.GetInt("Minutes").ToString() : "0" + PlayerPrefs.GetInt("Minutes").ToString()) + ":"
                               + (PlayerPrefs.GetInt("Seconds").ToString().Length > 1 ? PlayerPrefs.GetInt("Seconds").ToString() : "0" + PlayerPrefs.GetInt("Seconds").ToString())
                                );
        StartGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameBtn()
    {
        StartGame = true;
        playercontroller.enabled = true;
        gearspawner.enabled = true;
    }

    public void retry()
    {
        SceneManager.LoadScene(0);
    }
}
