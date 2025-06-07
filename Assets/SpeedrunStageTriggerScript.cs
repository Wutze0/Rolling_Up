using UnityEngine;

public class SpeedrunStageTriggerScript : MonoBehaviour
{
    public enum TriggerType { Start, End }
    public TriggerType triggerType;

    public SpeedrunStageTimerScript timerScript;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (triggerType == TriggerType.Start)
            {
                timerScript.StartTimer();
            }
            else if (triggerType == TriggerType.End)
            {
                timerScript.StopTimer();
            }
        }
    }
}
