using UnityEngine;

[CreateAssetMenu(fileName = "NewLevel", menuName = "Levels/Level Data")]
public class LevelData : ScriptableObject
{
    [Header("Player")]
    public Vector2 playerStartPosition;
    public float playerStartRotation;

    [Header("Enemies")]
    public Vector2[] enemyPositions;

    [Header("Boxes")]
    public Vector2[] boxPositions;
}
