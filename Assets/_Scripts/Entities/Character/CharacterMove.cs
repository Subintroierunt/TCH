using Environment;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class CharacterMove : MonoBehaviour
    {
        private CharacterRoot root;
        private Transform curTarget;
        private MapNodes mapNodes;
        private int curReach;

        public int CurReach =>
            curReach;

        public event Action Reached;

        public void Init(CharacterRoot characterRoot) =>
            root = characterRoot;

        public void SetTarget(Transform target) =>
            curTarget = target;

        public void SetNodes(MapNodes mapNodes) =>
            this.mapNodes = mapNodes;

        public void MoveNextNode()
        {
            SetTarget(mapNodes.GetNode((MapNodeType)root.CharacterData.CurPos, curReach));
            curReach++;
        }

        private void OnEnable()
        {
            curReach = 0;
        }

        private void Update()
        {
            if (curTarget != null)
            {
                Vector3 direction = curTarget.position - transform.position;
                if (direction.magnitude < root.CharacterData.Speed * Time.deltaTime)
                {
                    curTarget = null;
                    Reached?.Invoke();
                    //Idle anim
                }
                else
                {
                    transform.position += direction.normalized * root.CharacterData.Speed * Time.deltaTime;
                }
            }
        }
    }
}
