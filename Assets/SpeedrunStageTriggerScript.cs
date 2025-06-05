using UnityEngine;

public class SpeedrunStageTriggerScript : MonoBehaviour
{
    public enum TriggerType { Start, End }
    public TriggerType triggerType;

    public SpeedrunStageTimerScript timerScript;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("enterd");
        if (col.CompareTag("Player"))
        {
            if (triggerType == TriggerType.Start)
            {
                Debug.Log("aktiv");
                timerScript.StartTimer();
            }
            else if (triggerType == TriggerType.End)
            {
                Debug.Log("nicht aktiv");
                timerScript.StopTimer();
            }
        }
    }
}
