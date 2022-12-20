using UnityEngine;
using System.Collections.Generic;

namespace Mediapipe.Unity
{
    public class RightShoulderCalculator : RightLimbJointCalculator
    {
        public RightShoulderCalculator (Transform t) : base(t) {}

        public override void Calc ()
        {
            if (_landmarkList == null) return;

            Refresh();

            obj.Rotate(
                Quaternion.FromToRotation(-obj.right, v_shoulder_elbow).eulerAngles,
                Space.World
            );

            var norm_x = Vector3.Cross(v_shoulder_elbow, v_elbow_wrist);
            obj.Rotate(
                Quaternion.FromToRotation(-obj.forward, norm_x).eulerAngles,
                Space.World
            );
        }

    }
}