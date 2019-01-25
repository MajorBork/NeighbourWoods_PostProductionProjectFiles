using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager.Player;
using Manager.Level;
using Manager;
using Manager.Inventory;

public static class GameEvents 
{
    #region Events Variables
    public static event Action<Vision> OnVisionChange = null;
    public static event Action<GameState> OnGameStateChange = null;
    public static event Action<Day> OnDayChange = null;
    //public static event Action<TimeSlot> OnTimeSlotChange = null;
    public static event Action<TimeSlot, Day> OnTimeChange = null;
    public static event Action<bool> OnInventoryVisChange = null;
    public static event Action<int> OnCharacterTalk = null;
    //public static event Action<Tasks> OnTaskStartedChange = null;
    #endregion
    #region Events
    public static void ReportVisionChange(Vision vision) // reporting vision change 
    {
        //Debug.Log (">>> EVENT: ReportOnVisionChange((" + vision +")");
        if (OnVisionChange != null)
        {
            OnVisionChange(vision);
        }
    }
    public static void ReportGameStateChange(GameState gamestate)
    {
        //Debug.Log ("Changed State " + gamestate);
        if (OnGameStateChange != null)
        {
            OnGameStateChange(gamestate);
        }
    }
    public static void ReportDayChange(Day day)
    {
        if(OnDayChange != null)
        {
            OnDayChange(day);
        }
    }
    //public static void ReportOnTimeSlotChange(TimeSlot timeSlot)
    //{
    //    if (OnTimeSlotChange != null)
    //    {
    //        OnTimeSlotChange(timeSlot);
    //    }
    //}
    public static void ReportOnTimeChange(TimeSlot timeSlot, Day day)
    {
        if (OnTimeChange != null)
        {
            OnTimeChange(timeSlot,day);
        }
    }
    public static void ReportOnInventoryChange(bool inventoryShowing)
    {
        if (OnInventoryVisChange != null)
        {
            OnInventoryVisChange(inventoryShowing);
        }
    }
    public static void ReportCharacterTalkingChange(int friendshipPoint)
    {
        if(OnCharacterTalk != null)
        {
            OnCharacterTalk(friendshipPoint);
        }
    }
    #endregion
}
