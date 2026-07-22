using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] private PlayableDirector cutsceneDirector;
    [SerializeField] private bool playOnStart = true;

    void Awake()
{
    Debug.Log("AWAKE RUNNING");
}

    void Start()
    {

    Debug.Log("START RUNNING");
        Debug.Log("Start() method called.");

        if (playOnStart)
        {
            Debug.Log("Play On Start is TRUE.");
        }
        else
        {
            Debug.Log("Play On Start is FALSE.");
        }

        if (cutsceneDirector == null)
        {
            Debug.LogError("Playable Director is NOT assigned!");
            return;
        }

        Debug.Log("Playable Director found: " + cutsceneDirector.name);

        if (playOnStart)
        {
            Debug.Log("Stopping Timeline...");
            cutsceneDirector.Stop();

            Debug.Log("Playing Timeline...");
            cutsceneDirector.Play();

            Debug.Log("Cutscene Started Successfully!");
        }
    }
}