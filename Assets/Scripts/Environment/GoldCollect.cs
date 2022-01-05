using System;
using UnityEngine;
using UnityEngine.UI;

namespace Environment
{
    public class GoldCollect : MonoBehaviour
    {
        public GameObject goldTrophie;
        public GameObject pickUpDisplay;
        public AudioSource goldPickUpFX;

        private void OnTriggerEnter(Collider other)
        {
            goldTrophie.SetActive(false);
            goldPickUpFX.Play();
            DisplayStuff.ScoreDisplayNumber += 50;
            FloorComplete.treasureCount++;
            pickUpDisplay.SetActive(false);
            pickUpDisplay.GetComponent<Text>().text = "Gold picked up";
            pickUpDisplay.SetActive(true);
        }
    }
}