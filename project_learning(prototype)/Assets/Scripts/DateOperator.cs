using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//public class DateOperator : MonoBehaviour
public static class DateOperator
{
    //月の日数を求める
    public static int DaysInMonth(this DateTime dateTime)
    {
        return DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
    }

    
}
