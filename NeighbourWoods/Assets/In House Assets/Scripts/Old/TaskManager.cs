using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager.Level;
using Manager.Environment;
using Manager.UI;

//namespace Manager.Task
//{
//    #region TasManager Class
//    public class TaskManager : Singleton<TaskManager>
//    {
//        public Tasks[] tasks;
//        public LevelManager levelManager;
//        public UIManager uiManager;
//        public int taskPoints;
//        public int maxTaskPoints;
//        #region TaskStarted() TaskCompleted()
//        public int AddTaskPoints(int taskPointsAdd)
//        {
//            taskPointsAdd += taskPoints;
//            Debug.Log(taskPoints);
//            IfTaskPointsFull();
//            return taskPoints;
//        }
//        public void IfTaskPointsFull()
//        {
//            if (taskPoints == maxTaskPoints)
//            {
//                //levelManager.UpdateTime();
//                //uiManager.
//            }
//        }
//        #endregion
//    }
//    #endregion
//#region Task Class
//[Groups("Base Settings")]
//[System.Serializable]
//public class Tasks
//{
//    public TaskName taskName;
//    public bool taskStarted;
//    public bool taskCompleted;
//    public Taskstype tasksType;
//    public Day day;
//    public TimeSlot timeSlot;
//}
//    #endregion
//}
