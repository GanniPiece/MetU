using UnityEngine;

namespace Mediapipe.Unity
{
    public class LeftHipCalculator: LeftLimbJointCalculator
    {   
        public LeftHipCalculator (Transform t) : base(t) {}

        public override void Calc () 
        {
            if (_landmarkList == null) return;

            Refresh();

            obj.Rotate(
                Quaternion.FromToRotation(-obj.right, v_hip_knee).eulerAngles,
                Space.World
            );

            var norm_x = Vector3.Cross(v_hip_knee, v_knee_ankle);
            obj.Rotate(
                Quaternion.FromToRotation(obj.forward, norm_x).eulerAngles,
                Space.World
            );
        }
    }
};