using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main_Menu
{
    public class MainMenuControl : MonoBehaviour
    {
        public AudioSource clickSound;
        public GameObject fadeOut;
        public int loadScene;
        public int loadScore;
        public int loadLife;
        public int loadAmmo;
        public int loadHandGun;
        //public int loadShotGun;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }

        public void NewGame()
        {
            StartCoroutine(NewGameRoutine());
        }

        public void Exit()
        {
            clickSound.Play();
            Application.Quit();
        }

        IEnumerator NewGameRoutine()
        {
            clickSound.Play();
            fadeOut.SetActive(true);
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Level001");
        }

        public void ResetGame()
        {
            PlayerPrefs.SetInt("SceneToLoad", 0);
            PlayerPrefs.SetInt("LivesSaved", 0);
            PlayerPrefs.SetInt("Score", 0);
            PlayerPrefs.SetInt("Ammo", 0);
            PlayerPrefs.SetInt("Handgun", 0);
            //PlayerPrefs.SetInt("Shotgun", 0);
            SceneManager.LoadScene("Main Menu");
        }

        public void LoadGame()
        {
            loadScene = PlayerPrefs.GetInt("SceneToLoad");
            if (loadScene == 0)
            {
                //do nothing
            }
            else
            {
                StartCoroutine(LoadGameRoutine());
            }
        }

        IEnumerator LoadGameRoutine()
        {
            clickSound.Play();
            loadLife = PlayerPrefs.GetInt("LivesSaved");
            loadScore = PlayerPrefs.GetInt("Score");
            loadAmmo = PlayerPrefs.GetInt("Ammo");
            loadHandGun = PlayerPrefs.GetInt("Handgun");
            //loadShotGun = PlayerPrefs.GetInt("Shotgun");
            fadeOut.SetActive(true);
            yield return new WaitForSeconds(loadScene);
            FloorComplete.floor = loadScene;
            DisplayStuff.lifeDisplayNumber = loadLife;
            DisplayStuff.ScoreDisplayNumber = loadScore;
            DisplayStuff.ammoDisplayNumber = loadAmmo;
            SceneManager.LoadScene(loadScene);
        }

        public void Credits()
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
