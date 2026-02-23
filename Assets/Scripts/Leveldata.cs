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

    [Header("Blocks")]
    public BlockData[] blocks;

    [Header("Spikes")]
    public Vector2[] spikePositions;

    [System.Serializable]
    public class BlockData
    {
        public Vector2 position;
        public Vector2 scale;
        public float rotation;
    }
}
