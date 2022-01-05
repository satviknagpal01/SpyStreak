using System.Collections;
using System.Collections.Generic;
using Door;
using UnityEngine;
using UnityEngine.UI;

public class FloorComplete : MonoBehaviour
{
    public static int enemyCount=0;
    public static int treasureCount=0;
    public static int secretCount=0;
    public GameObject enemyDisplay;
    public GameObject treasureDisplay;
    public GameObject secretDisplay;
    public GameObject timeDisplay;
    public static int floor = 1;
    public GameObject floorDisplay;
    void Update()
    {
        floorDisplay.GetComponent<Text>().text = "Floor " +(floor-1)+" \nCompleted";
        enemyDisplay.GetComponent<Text>().text = enemyCount.ToString();
        treasureDisplay.GetComponent<Text>().text = treasureCount.ToString();
        secretDisplay.GetComponent<Text>().text = secretCount.ToString();
        if (TimeCounter.secs < 10)
        {
            if (TimeCounter.mins < 10)
            {
                timeDisplay.GetComponent<Text>().text ="0"+TimeCounter.mins + ":0"+TimeCounter.secs ;
            }
            else
            {
                timeDisplay.GetComponent<Text>().text =TimeCounter.mins + ":0"+TimeCounter.secs ;
            }
        }
        else
        {
            if (TimeCounter.mins < 10)
            {
                timeDisplay.GetComponent<Text>().text ="0"+TimeCounter.mins + ":"+TimeCounter.secs ;
            }
            else
            {
                timeDisplay.GetComponent<Text>().text =TimeCounter.mins + ":"+TimeCounter.secs ;
            }
        }
    }
}
