using UnityEngine;

namespace Mediapipe.Unity
{
    public class RightAnkleCalculator: RightLimbJointCalculator
    {   
        public RightAnkleCalculator (Transform t) : base(t) {}

        public override void Calc () 
        {
            if (_landmarkList == null) return;

            Refresh();

            obj.Rotate(
                Quaternion.FromToRotation(-obj.right, v_ankle_heel).eulerAngles,
                Space.World
            );
        }
    }
};