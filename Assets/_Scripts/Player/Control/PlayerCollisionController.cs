using Managers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;


namespace Player
{
    public class PlayerCollisionController : MonoBehaviour
    {
        PlayerController _playerController;
        MenuManager menuManager;
        public int score = 0;
        void Awake()
        {
            _playerController = GetComponent<PlayerController>();
            menuManager = GameObject.Find("MenuCanvas").GetComponent<MenuManager>();
        }
        void OnCollisionEnter(Collision collision)
        {
            switch (collision.collider.tag)
            {
                case "Floor":
                    
                    if (GameManager.currentState == GameManager.GetState("Jump"))
                    {
                        GameManager.SetState("Running");
                    }
                    break;

                case "_obstacle":
                    if (GameManager.currentState == GameManager.GetState("Dead"))
                    {
                        return;
                    }
                    GameManager.SetState("Dead");
                    SoundManager.Instance.ObstacleCrashMusic();
                    break;

                case "_finishLine":
                    if (GameManager.currentState == GameManager.GetState("Win")) 
                    {
                        return; 
                    }
                    GameManager.SetState("Win");
                    break;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("STAR"))
            {
                score++;
                menuManager.InGameMenu.transform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
            }
        }
    }

  
}

