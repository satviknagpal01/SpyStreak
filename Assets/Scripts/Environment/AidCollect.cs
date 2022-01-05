using System;
using UnityEngine;
using UnityEngine.UI;

namespace Environment
{
    public class AidCollect : MonoBehaviour
    {
        public GameObject firstAid;
        public GameObject pickUpDisplay;
        public int aidNumber = 10;
        public AudioSource aidPickUpFX;

        private void OnTriggerEnter(Collider other)
        {
            firstAid.SetActive(false);
            aidPickUpFX.Play();
            DisplayStuff.healthDisplayNumber += aidNumber;
            pickUpDisplay.SetActive(false);
            pickUpDisplay.GetComponent<Text>().text = "Gold Trophie picked up";
            pickUpDisplay.SetActive(true);
        }
    }
}