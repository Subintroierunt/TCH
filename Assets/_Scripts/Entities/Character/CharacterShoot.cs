using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class CharacterShoot : MonoBehaviour
    {
        [SerializeField] private ProjectileRoot prefab;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private CharacterRoot debugTarget;

        private Queue<ProjectileRoot> projectilePool = new Queue<ProjectileRoot>();
        private List<ProjectileRoot> projectileActive = new List<ProjectileRoot>();

        public void SetTarget(CharacterRoot target) =>
            debugTarget = target;

        public void Shoot()
        {
            ProjectileRoot bullet;

            if (projectilePool.Count == 0)
            {
                bullet = CreateProjectile();
            }
            else
            {
                bullet = projectilePool.Dequeue();
                bullet.transform.position = spawnPoint.position;
                bullet.gameObject.SetActive(true);
            }
            projectileActive.Add(bullet);
            bullet.ProjectileHit.SetTarget(debugTarget.CharacterHealth);
            bullet.ProjectileAnimation.Launch(debugTarget.transform);
        }

        private ProjectileRoot CreateProjectile()
        {
            ProjectileRoot bullet = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

            bullet.ProjectileHit.Hitted += () =>
            {
                projectilePool.Enqueue(bullet);
                projectileActive.Remove(bullet);
            };

            return bullet;
        }
    }
}
