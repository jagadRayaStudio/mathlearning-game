using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animarket
{
    [System.Serializable]
    public class Task
    {
        public Item item;
        public int amount;
        public bool isDone;
    }

    public class TaskManager : MonoBehaviour
    {
        [SerializeField] private List<Task> taskList;

        public List<Task> GetTaskList()
        {
            return taskList;
        }
    }
}
