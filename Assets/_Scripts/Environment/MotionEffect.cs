using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Environment
{
    public class MotionEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem blur;

        public void StopScroll()
        {
            blur.Stop();
        }

        public void PlayScroll()
        {
            blur.Play();
        }

        private void OnDestroy()
        {
            StopScroll();
        }
    }
}
