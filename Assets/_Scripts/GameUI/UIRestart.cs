using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameUI
{
    public class UIRestart : MonoBehaviour
    {
        [SerializeField] private Button button;

        private void Start()
        {
            button.onClick.AddListener(Restart);
        }

        public void ShowButton()
        {
            button.gameObject.SetActive(true);
        }

        private void Restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}
