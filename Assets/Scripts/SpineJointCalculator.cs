using UnityEngine;
using System.Collections.Generic;

namespace Mediapipe.Unity
{
    public class SpineCalculator: HumanJointCalculator
    {   
        public SpineCalculator (Transform t) : base(t) {}

        public override void Calc () 
        {
            if (_landmarkList == null) return;

            var m_left = new Vector3(
                (-_landmarkList.Landmark[11].X - _landmarkList.Landmark[23].X) / 2,
                (-_landmarkList.Landmark[11].Y - _landmarkList.Landmark[23].Y) / 2,
                (-_landmarkList.Landmark[11].Z - _landmarkList.Landmark[23].Z) / 2
            );

            var m_right = new Vector3(
                (-_landmarkList.Landmark[12].X - _landmarkList.Landmark[24].X) / 2,
                (-_landmarkList.Landmark[12].Y - _landmarkList.Landmark[24].Y) / 2,
                (-_landmarkList.Landmark[12].Z - _landmarkList.Landmark[24].Z) / 2
            );

            var v_spine = m_left - m_right;

            obj.Rotate(
                Quaternion.FromToRotation(obj.forward, v_spine).eulerAngles,
                Space.World
            );            
        }
    }
};