using UnityEngine;
using System.Collections.Generic;

namespace Mediapipe.Unity
{
    class NeckJointCalculator: HumanJointCalculator
    {
        private Vector3 v_shoulder;
        private Vector3 v_mouth;
        private Vector3 v_shoulder_mouth;

        public NeckJointCalculator (Transform t) : base(t) {}

        public override void Calc ()
        {
            if (_landmarkList == null) return;

            v_shoulder = new Vector3(
                (-_landmarkList.Landmark[11].X + _landmarkList.Landmark[12].X),
                (-_landmarkList.Landmark[11].Y + _landmarkList.Landmark[12].Y),
                (-_landmarkList.Landmark[11].Z + _landmarkList.Landmark[12].Z)
            );

            v_mouth = new Vector3(
                (-_landmarkList.Landmark[9].X + _landmarkList.Landmark[10].X),
                (-_landmarkList.Landmark[9].Y + _landmarkList.Landmark[10].Y),
                (-_landmarkList.Landmark[9].Z + _landmarkList.Landmark[10].Z)
            );

            obj.localEulerAngles = new Vector3(0, 0, -20);
            obj.Rotate(
                Quaternion.FromToRotation(v_shoulder, v_mouth).eulerAngles,
                Space.World
            );
        }
    }
};