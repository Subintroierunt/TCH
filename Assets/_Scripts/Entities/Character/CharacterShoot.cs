using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class CharacterShoot : MonoBehaviour, ICharacterAction
    {
        [SerializeField] private ProjectileRoot prefab;
        [SerializeField] private Transform spawnPoint;

        private CharacterRoot root;

        private CharacterRoot shootTarget;
        private Queue<ProjectileRoot> projectilePool = new Queue<ProjectileRoot>();
        private List<ProjectileRoot> projectileActive = new List<ProjectileRoot>();

        private float damageMod = 0;

        public void Init(CharacterRoot root)
        {
            this.root = root;
        }

        public void DoAction()
        {
            Debug.Log("shoot");
            if (shootTarget != null)
            {
                Shoot();
            }
        }

        public void AddDamageMod(int value) =>
            damageMod += value;

        public float GetCurDamage() =>
            root.CharacterData.Damage + damageMod;

        public void SetTarget(CharacterRoot target) =>
            shootTarget = target;

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
            bullet.ProjectileHit.SetTarget(shootTarget.CharacterHealth);
            bullet.ProjectileHit.SetDamage(GetCurDamage());
            bullet.ProjectileAnimation.Launch(shootTarget.transform);
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
