using UnityEngine;

namespace Mediapipe.Unity
{
    public class RightKneeCalculator: RightLimbJointCalculator
    {   
        public RightKneeCalculator (Transform t) : base(t) {}

        public override void Calc () 
        {
            if (_landmarkList == null) return;

            Refresh();

            obj.Rotate(
                Quaternion.FromToRotation(-obj.right, v_knee_ankle).eulerAngles,
                Space.World
            );

            var norm_x = Vector3.Cross(v_ankle_index, v_ankle_heel);
            obj.Rotate(
                Quaternion.FromToRotation(obj.forward, norm_x).eulerAngles,
                Space.World
            );
        }
    }
};