using UnityEngine;
using UnityEngine.Playables;
using Yarn.Unity;

public class TimelineCommandHandler : MonoBehaviour
{
    [System.Serializable]
    public class NamedTimeline
    {
        public string name;
        public PlayableDirector director;
    }

    public NamedTimeline[] timelines;



    [YarnCommand("play_timeline")]
    public void PlayTimeline(string timelineName)
    {
        foreach (var t in timelines)
        {
            if (t.name == timelineName && t.director != null)
            {
                t.director.Play();
                return;
            }
        }
        Debug.LogWarning($"Timeline '{timelineName}' not found!");
    }

    [YarnCommand("play_timeline_and_wait")]
    public static System.Collections.IEnumerator PlayTimelineAndWait(string timelineName)
    {
        var handler = FindFirstObjectByType<TimelineCommandHandler>();
        var timeline = System.Array.Find(handler.timelines, t => t.name == timelineName);
        if (timeline != null && timeline.director != null)
        {
            timeline.director.Play();
            yield return new WaitUntil(() => timeline.director.state != PlayState.Playing);
        }
    }
}
