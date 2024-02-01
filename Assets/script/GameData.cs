using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Custom/GameData")]
public class GameData : ScriptableObject
{
    [Header("Level")]
    public int currentLevel = 1;

    [Header("Audio Settings")]
    [Range(0f, 1f)]
    public float backgroundVolume = 0.5f;

    [Range(0f, 1f)]
    public float gameVolume = 0.8f;
}
