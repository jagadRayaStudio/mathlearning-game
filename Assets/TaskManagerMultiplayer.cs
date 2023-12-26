using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace Animarket
{
    public class TaskManagerMultiplayer : MonoBehaviourPun
    {
        [SerializeField] private Transform taskListParent;
        [SerializeField] private GameObject taskPrefab;

        private List<GameObject> taskItems = new List<GameObject>();
    }
}
