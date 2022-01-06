using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using Weapon;
using UnityEngine.SceneManagement;

namespace Door
{
    public class NextLevel : MonoBehaviour
    {
        public GameObject fadeOut;
        public GameObject floorEvent;
        public GameObject player;
        public GameObject floorTimer;
        public GameObject gun;

        private void OnTriggerEnter(Collider other)
        {
            floorTimer.SetActive(false);
            player.GetComponent<FirstPersonController>().enabled = false;
            gun.GetComponent<Gun>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(Completed());
        }

        IEnumerator Completed()
        {
            fadeOut.SetActive(true);
            FloorComplete.floor++;
            PlayerPrefs.SetInt("SceneToLoad",FloorComplete.floor);
            PlayerPrefs.SetInt("LivesSaved",DisplayStuff.lifeDisplayNumber);
            PlayerPrefs.SetInt("Score",DisplayStuff.ScoreDisplayNumber);
            PlayerPrefs.SetInt("Ammo",DisplayStuff.ammoDisplayNumber);
            yield return new WaitForSeconds(1.5f);
            floorEvent.SetActive(true);
            yield return new WaitForSeconds(7);
            DisplayStuff.totalScore += DisplayStuff.ScoreDisplayNumber;
            DisplayStuff.ScoreDisplayNumber = 0;
            FloorComplete.treasureCount = 0;
            FloorComplete.enemyCount = 0;
            FloorComplete.secretCount = 0;
            SceneManager.LoadScene(FloorComplete.floor);
        }
    }
}
