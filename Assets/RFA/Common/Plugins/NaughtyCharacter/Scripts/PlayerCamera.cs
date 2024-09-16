using UnityEngine;

namespace NaughtyCharacter
{
    public class PlayerCamera : MonoBehaviour
    {
        public Transform Rig; // The root transform of the camera rig
        public Transform Pivot; // The point at which the camera pivots around
        public Transform Target; // The point at which the camera pivots around

        private float hegiht = 1f;

        private void LateUpdate()
        {
            Cursor.lockState = CursorLockMode.Confined;
            SetPosition(Target.transform.position);
            // Remove the part that updates the control rotation based on mouse input
        }

        public void SetPosition(Vector3 position)
        {
            Rig.position = position + new Vector3(0, hegiht, -1f);
            Pivot.rotation = Quaternion.Euler(30f, 0f, 0f);
        }

        public void SetControlRotation(Vector2 controlRotation)
        {
            // Y Rotation (Yaw Rotation)
            Quaternion rigTargetLocalRotation = Quaternion.Euler(0.0f, controlRotation.y, 0.0f);

            // X Rotation (Pitch Rotation)
            Quaternion pivotTargetLocalRotation = Quaternion.Euler(controlRotation.x, 0.0f, 0.0f);

            Rig.localRotation = rigTargetLocalRotation;
            Pivot.localRotation = pivotTargetLocalRotation;
        }
    }
}
