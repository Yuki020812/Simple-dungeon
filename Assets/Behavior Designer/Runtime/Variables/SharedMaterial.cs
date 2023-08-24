using UnityEngine;

namespace BehaviorDesigner.Runtime
{
    [System.Serializable]
    public class SharedMaterial : SharedVariable<UnityEngine.Material>
    {
        public static implicit operator SharedMaterial(UnityEngine.Material value) { return new SharedMaterial { mValue = value }; }
    }
}