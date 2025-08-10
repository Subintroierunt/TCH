using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI
{
    public class UIOverlay : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;

        private void Start()
        {
            canvas.worldCamera = Camera.main;
        }
    }
}
