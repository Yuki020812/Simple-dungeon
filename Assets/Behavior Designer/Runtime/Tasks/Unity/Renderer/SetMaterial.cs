using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace Behavior_Designer.Runtime.Tasks.Unity.Renderer
{
    [TaskCategory("Unity/Renderer")]
    [TaskDescription("Sets the material on the Renderer.")]
    public class SetMaterial : Action
    {
        [UnityEngine.Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;
        [UnityEngine.Tooltip("The material to set")]
        public SharedMaterial material;

        // cache the renderer component
        private UnityEngine.Renderer renderer;
        private GameObject prevGameObject;

        public override void OnStart()
        {
            var currentGameObject = GetDefaultGameObject(targetGameObject.Value);
            if (currentGameObject != prevGameObject) {
                renderer = currentGameObject.GetComponent<UnityEngine.Renderer>();
                prevGameObject = currentGameObject;
            }
        }

        public override TaskStatus OnUpdate()
        {
            if (renderer == null) {
                Debug.LogWarning("Renderer is null");
                return TaskStatus.Failure;
            }
            renderer.material = material.Value;
            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            targetGameObject = null;
            material = null;
        }
    }
}