using Entities;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GameUI
{
    public class DamagePopup : MonoBehaviour
    {
        [SerializeField] private CharacterRoot characterRoot;
        [SerializeField] private List<TextMeshProUGUI> popupPool = new List<TextMeshProUGUI>();
        [SerializeField] private float liftTime = 1;
        [SerializeField] private Transform spawnPoint;

        private int queue;
        private Dictionary<int,Coroutine> coroutines = new Dictionary<int, Coroutine>();

        private void Start()
        {
            characterRoot.CharacterHealth.HealthChanged += ShowPopup;
            for (int i = 0; i < popupPool.Count; i++)
            {
                coroutines.Add(i, null);
            }
        }

        private void ShowPopup(float damage, float curHealth)
        {
            if (curHealth > 0)
            {
                if (coroutines[queue] != null)
                {
                    StopCoroutine(coroutines[queue]);
                }

                if (damage > 0)
                {
                    popupPool[queue].color = Color.red;
                }
                else
                {
                    if (damage == 0)
                    {
                        return;
                    }
                    popupPool[queue].color = Color.green;
                }

                popupPool[queue].text = Mathf.RoundToInt(damage).ToString();
                popupPool[queue].transform.position = spawnPoint.position;
                popupPool[queue].gameObject.SetActive(true);
                coroutines[queue] = StartCoroutine(PopupLift(queue));

                queue++;
                if (queue >= popupPool.Count)
                {
                    queue = 0;
                }
            }
        }

        private IEnumerator PopupLift(int number)
        {
            for (float i = 0; i < liftTime; i += Time.deltaTime)
            {
                popupPool[number].transform.position += Vector3.up * Time.deltaTime;
                yield return null;
            }
            popupPool[number].gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            StopAllCoroutines();
            popupPool.ForEach(p => p.gameObject.SetActive(false));
        }
    }
}
