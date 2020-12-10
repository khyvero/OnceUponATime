using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{

    private static CountDownTimer Instance;

    private Dictionary<string, TimerWrapper> Timers = new Dictionary<string, TimerWrapper>();


    private void Start()
    {
        Instance = this;
    }


    public void CountDown(float timeRemaining, DoOnTime doOntimme)
    {

        string id = System.Guid.NewGuid().ToString() ;
        TimerWrapper wrapper = new TimerWrapper(timeRemaining, doOntimme);

        Timers.Add(id, wrapper);
        
    }


    private void Update()
    {
        float deltaTime = Time.deltaTime;

        foreach(string timerKey in Timers.Keys)
        {
            TimerWrapper wrapper = Timers[timerKey];
            if (wrapper.TimeIsUp())
            {
                wrapper.DoTask();
            }
            else
            {
                wrapper.UpdateTime(deltaTime);
            }
        }
    }


    public class TimerWrapper
    {
        private DoOnTime DoOnTime;
        private float timeRemaining;
        private bool Done;

        public TimerWrapper(float timeRemaining, DoOnTime doOnTime)
        {
            this.timeRemaining = timeRemaining;
            this.DoOnTime = doOnTime;
        }

        public void UpdateTime(float DeltaTime)
        {
            timeRemaining -= DeltaTime;
        }

        public bool TimeIsUp()
        {
            return timeRemaining <= 0;
        }

        public void DoTask()
        {
            if (!Done)
            {
                Debug.Log("Doing timer job");
                DoOnTime.Invoke();
                Done = true;
            }

        }
    }

    
    public static CountDownTimer GetInstance()
    {
        return Instance;
    }


    public delegate void DoOnTime();
    
}
