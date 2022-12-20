using UnityEngine;

namespace Mediapipe.Unity
{
    public class HipCalculator: HumanJointCalculator
    {   
        public HipCalculator (Transform t) : base(t) {}

        public override void Calc () 
        {
            if (_landmarkList == null) return;

            var v_hips = new Vector3(
                -_landmarkList.Landmark[23].X + _landmarkList.Landmark[24].X,
                -_landmarkList.Landmark[23].Y + _landmarkList.Landmark[24].Y,
                -_landmarkList.Landmark[23].Z + _landmarkList.Landmark[24].Z
            );

            obj.Rotate(
                Quaternion.FromToRotation(obj.forward, v_hips).eulerAngles,
                Space.World
            );
        }
    }
};