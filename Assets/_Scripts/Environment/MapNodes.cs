using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Environment
{
    public class MapNodes : MonoBehaviour
    {
        [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
        [SerializeField] private List<Transform> startPoints = new List<Transform>();
        [SerializeField] private List<Transform> invadeNodesTop = new List<Transform>();
        [SerializeField] private List<Transform> invadeNodesMid = new List<Transform>();
        [SerializeField] private List<Transform> invadeNodesBot = new List<Transform>();


        public Transform GetNode(MapNodeType type, int pos)
        {
            switch (type)
            {
                case MapNodeType.SpawnPoint:
                    return spawnPoints[pos];
                case MapNodeType.InvadeNodeTop:
                    return invadeNodesTop[pos];
                case MapNodeType.InvadeNodeMid:
                    return invadeNodesMid[pos];
                case MapNodeType.InvadeNodeBot:
                    return invadeNodesBot[pos];
                case MapNodeType.StartPoint:
                    return startPoints[pos];
            }

            return null;
        }
    }
}
