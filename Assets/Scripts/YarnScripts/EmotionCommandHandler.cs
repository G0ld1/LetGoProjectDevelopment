using UnityEngine;
using Yarn.Unity;

public class EmotionCommandHandler : MonoBehaviour
{
    public static string CurrentEmotion { get; private set; } = "default";
    public static string CurrentCharacter { get; private set; } = "";

    [YarnCommand("emotion")]
    public static void SetEmotion(string character, string emotion)
    {
        CurrentCharacter = character;
        CurrentEmotion = emotion;
        Debug.Log($"Emotion set: {character} - {emotion}");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
