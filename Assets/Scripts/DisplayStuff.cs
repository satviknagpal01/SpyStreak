using System;
using UnityEngine;
using UnityEngine.UI;
using  UnityEngine.SceneManagement;
using Weapon;

public class DisplayStuff : MonoBehaviour
{
    
    public static int ammoDisplayNumber;
    public GameObject ammoDisplay;
    public static int healthDisplayNumber;
    public int internalHealth;
    public GameObject healthDisplay;
    public GameObject[] healthDisplayImage;
    public static int lifeDisplayNumber=3;
    public int internalLife;
    public GameObject lifeDisplay;
    public static int ScoreDisplayNumber = 0;
    public int internalScore;
    public GameObject scoreDisplay;
    public GameObject finalScore;
    public static bool hasKey;
    public GameObject keyDisplay;
    public static int totalScore;
    public static int floorDisplayNumber ;
    public GameObject floorDisplay;
    
    private void Start()
    {
        healthDisplayNumber = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthDisplayNumber <= 0)
        {
            SceneManager.LoadScene("LevelRecycle");
        }

        internalScore = ScoreDisplayNumber;
        internalLife = lifeDisplayNumber;
        internalHealth = healthDisplayNumber;
        floorDisplayNumber = FloorComplete.floor;
        if (healthDisplayNumber >= 100)
        {
            healthDisplayNumber = 100;
        }
        lifeDisplay.GetComponent<Text>().text = lifeDisplayNumber.ToString();
        ammoDisplay.GetComponent<Text>().text = ammoDisplayNumber.ToString();
        healthDisplay.GetComponent<Text>().text = healthDisplayNumber + "%";
        scoreDisplay.GetComponent<Text>().text = ScoreDisplayNumber.ToString();
        finalScore.GetComponent<Text>().text = ScoreDisplayNumber.ToString();
        floorDisplay.GetComponent<Text>().text = floorDisplayNumber.ToString();
        if(hasKey)
            keyDisplay.SetActive(true);
        if (!hasKey)
            keyDisplay.SetActive(false);
        if (healthDisplayNumber > 80)
        {
            healthDisplayImage[0].SetActive(true);
            healthDisplayImage[1].SetActive(false);
            healthDisplayImage[2].SetActive(false);
            healthDisplayImage[3].SetActive(false);
            healthDisplayImage[4].SetActive(false);
        }
        else if (healthDisplayNumber > 60 && healthDisplayNumber < 80)
        {
            healthDisplayImage[0].SetActive(false);
            healthDisplayImage[1].SetActive(true);
            healthDisplayImage[2].SetActive(false);
            healthDisplayImage[3].SetActive(false);
            healthDisplayImage[4].SetActive(false);
        }
        else if(healthDisplayNumber>40 && healthDisplayNumber<60)
        {
            healthDisplayImage[0].SetActive(false);
            healthDisplayImage[1].SetActive(false);
            healthDisplayImage[2].SetActive(true);
            healthDisplayImage[3].SetActive(false);
            healthDisplayImage[4].SetActive(false);
        }
        else if(healthDisplayNumber>20 && healthDisplayNumber<40)
        {
            healthDisplayImage[0].SetActive(false);
            healthDisplayImage[1].SetActive(false);
            healthDisplayImage[2].SetActive(false);
            healthDisplayImage[3].SetActive(true);
            healthDisplayImage[4].SetActive(false);
        }
        else        
        {
            healthDisplayImage[0].SetActive(false);
            healthDisplayImage[1].SetActive(false);
            healthDisplayImage[2].SetActive(false);
            healthDisplayImage[3].SetActive(false);
            healthDisplayImage[4].SetActive(true);
        }
    }
}
