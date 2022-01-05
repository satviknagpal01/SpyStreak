using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecycleLevel : MonoBehaviour
{
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        DisplayStuff.lifeDisplayNumber--;
        if (DisplayStuff.lifeDisplayNumber <= 0)
        {
            gameOver.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(FloorComplete.floor);
        }
    }

}
