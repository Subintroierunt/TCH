using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class ProjectileRoot : MonoBehaviour
    {
        [SerializeField] private ProjectileAnimation projectileAnimation;
        [SerializeField] private ProjectileData projectileData;
        [SerializeField] private ProjectileHit projectileHit;


        public ProjectileAnimation ProjectileAnimation =>
            projectileAnimation;
        public ProjectileData ProjectileData => 
            projectileData;
        public ProjectileHit ProjectileHit => 
            projectileHit;

        private void Awake()
        {
            projectileAnimation.Init(this);
            projectileHit.Init(this);
        }

    }
}
