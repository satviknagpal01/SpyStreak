using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main_Menu
{
    public class PauseMenuControl : MonoBehaviour
    {
        public AudioSource clickSound;
        public GameObject pauseMenu;
        public GameObject fadeOut;
        public bool menu = false;
     
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(!menu)
                {
                    menu = true;
                    pauseMenu.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    menu = false;
                    pauseMenu.SetActive(false);
                    Time.timeScale = 1;
                }
            }

            if (!menu && pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
            }
        }

        public void Resume()
        {
            menu = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        
        public void ExitToDesktop()
        {
            clickSound.Play();
            Application.Quit();
        }
        
        public void ExitToMenu()
        {
            clickSound.Play();
            fadeOut.SetActive(true);
            SceneManager.LoadScene(0);
        }
    }
}
