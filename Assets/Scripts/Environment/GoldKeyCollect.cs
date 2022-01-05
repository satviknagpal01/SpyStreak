using System;
using UnityEngine;
using UnityEngine.UI;

namespace Environment
{
    public class GoldKeyCollect : MonoBehaviour
    {
        public GameObject goldKey;
        public GameObject pickUpDisplay;
        public AudioSource keyPickUpFX;

        private void OnTriggerEnter(Collider other)
        {
            goldKey.SetActive(false);
            keyPickUpFX.Play();
            DisplayStuff.hasKey = true;
            pickUpDisplay.SetActive(false);
            pickUpDisplay.GetComponent<Text>().text = "Gold Key picked up";
            pickUpDisplay.SetActive(true);
        }
    }
}