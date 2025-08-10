using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Entities
{
    public class CharacterInput : MonoBehaviour
    {
        [SerializeField] private InputAction click;

        private CharacterRoot root;

        public void Init(CharacterRoot root) =>
            this.root = root;

        private void Start()
        {
            //click.Enable();
            //click.performed += _ =>
            //{
            //    root.CharacterShoot.Shoot();
            //};
        }
    }
}
