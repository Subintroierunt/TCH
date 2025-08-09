using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class ProjectileAnimation : MonoBehaviour
    {
        private ProjectileRoot root;
        private Transform curTarget;

        public void Init(ProjectileRoot root) =>
            this.root = root;

        public void Launch(Transform target)
        {
            curTarget = target;
        }

        private void Update()
        {
            if (curTarget != null)
            {
                Vector3 direction = curTarget.position - transform.position;
                if (direction.magnitude < root.ProjectileData.Speed * Time.deltaTime)
                {
                    Hit();
                }
                else
                {
                    direction += Vector3.up * direction.magnitude / 2;
                    transform.position += direction.normalized * root.ProjectileData.Speed * Time.deltaTime; //Add level up mod
                    transform.right = direction;
                }    
            }
        }

        private void Hit()
        {
            curTarget = null;
            root.ProjectileHit.DealDamage();
            gameObject.SetActive(false);
            //Some VFX
        }
    }
}
