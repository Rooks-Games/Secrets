using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Scripts.Npcs
{
    [CreateAssetMenu(fileName = "NpcDatabase", menuName = "ScriptableObjects/NpcDatabase")]
    public class NpcDatabase : ScriptableObject
    {
        [Serialize] public List<NpcMetaData> NpcsData;
    }
}
