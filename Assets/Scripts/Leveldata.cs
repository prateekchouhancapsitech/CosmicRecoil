using UnityEngine;
using static UnityEditor.U2D.ScriptablePacker;

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
    public SpikeData[] spikes;

    [System.Serializable]
    public class BlockData
    {
        public Vector2 position;
        public Vector2 scale;
        public float rotation;
    }
    [System.Serializable]
    public class SpikeData
    {
        public Vector2 position;
        public Vector2 scale;
        public float rotation;
    }
}
