using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitForCredits());
    }

    // Update is called once per frame
    IEnumerator waitForCredits()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Main Menu");
    }
}
