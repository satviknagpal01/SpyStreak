using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public static int secs = 0;
    public static int mins = 0;
    private bool addingTime = false;
    void Update()
    {
        if (!addingTime)
        {
            StartCoroutine(AddTime());
        }
    }

    IEnumerator AddTime()
    {
        addingTime = true;
        yield return new WaitForSeconds(1);
        secs++;
        if (secs == 60)
        {
            mins++;
            secs = 0;
        }
        addingTime = false;
    }
}
