using UnityEngine;

namespace Mediapipe.Unity
{
    public class RightWristCalculator: RightLimbJointCalculator
    {   
        public RightWristCalculator (Transform t) : base(t) {}

        public override void Calc () 
        {
            if (_landmarkList == null) return;

            Refresh();

            var norm_x = Vector3.Cross(v_wrist_pinky, v_wrist_index);
            obj.Rotate(
                Quaternion.FromToRotation(-obj.forward, norm_x).eulerAngles,
                Space.World
            );
        }
    }
}