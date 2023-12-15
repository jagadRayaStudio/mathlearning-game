using System;
using System.Collections.Generic;
using UnityEngine;

namespace Animarket
{
    [Serializable]
    public class Task
    {
        public Item item;
        public int amount;
        public bool isDone;
    }

    public class TaskManager : MonoBehaviour
    {
        [SerializeField] private List<Task> taskList;

        private void OnEnable()
        {
            EventManager.OnGrandTotalCorrectE += CheckTask;
        }

        private void OnDisable()
        {
            EventManager.OnGrandTotalCorrectE -= CheckTask;
        }

        public List<Task> GetTaskList()
        {
            return taskList;
        }

        public Task GetTaskFromItemObject(Item item)
        {
            foreach (Task task in taskList)
            {
                if (task.item == item)
                    return task;
            }

            return null;
        }

        public void SetTaskDone(Task task, bool status)
        {
            Task _task = GetTaskFromItemObject(task.item);
            if (_task != null)
            {
                _task.isDone = status;
            }
        }

        public bool IsItemInTaskList(Item item)
        {
            return taskList.Exists(task => task.item == item);
        }

        public int GetTaskAmount(Item item)
        {
            Task task = GetTaskFromItemObject(item);
            return task != null ? task.amount : 0;
        }

        public void SetTaskAmount(Item item, int amount)
        {
            Task task = GetTaskFromItemObject(item);
            if (task != null)
            {
                task.amount = amount;
            }
        }

        public void CheckTask()
        {
            foreach (Task task in taskList)
            {
                if (!task.isDone)
                    return;
            }

            // Win Condition here
            Debug.Log("You WIN!!!!");
            EventManager.OnFinish();
        }
    }
}
