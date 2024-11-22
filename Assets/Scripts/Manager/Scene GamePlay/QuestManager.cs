using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    [SerializeField]protected List<QuestPoint> points;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadQuestPoint();
    }

    protected virtual void LoadQuestPoint()
    {
        if (points.Count > 0) return;

        QuestPoint[] questPoints = GameObject.FindObjectsByType<QuestPoint>(FindObjectsSortMode.None);
        Debug.Log(GetComponents<QuestPoint>().Length);
        foreach (QuestPoint p in questPoints)
        {
            points.Add(p);
        }
        Debug.Log(transform.name + ": LoadQuestPoint", gameObject);
    }

    public QuestPoint GetQuestPoint(IDNPC id)
    {
        foreach (var point in points)
        {
            if (point.CheckQuestPoint(id) != null) return point;
        }
        return null;
    }
}
