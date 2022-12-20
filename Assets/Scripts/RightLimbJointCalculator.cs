using UnityEngine;

namespace Mediapipe.Unity
{
    public class RightLimbJointCalculator: LimbJointCalculator
    {
        public RightLimbJointCalculator (Transform t) : base(t) {}

        public override void Refresh ()
        {
            if (_landmarkList == null) return;

            v_hip_shoulder = new Vector3(
                -_landmarkList.Landmark[12].X + _landmarkList.Landmark[24].X,
                -_landmarkList.Landmark[12].Y + _landmarkList.Landmark[24].Y,
                -_landmarkList.Landmark[12].Z + _landmarkList.Landmark[24].Z
            );

            v_shoulder_elbow = new Vector3(
                -_landmarkList.Landmark[14].X + _landmarkList.Landmark[12].X,
                -_landmarkList.Landmark[14].Y + _landmarkList.Landmark[12].Y,
                -_landmarkList.Landmark[14].Z + _landmarkList.Landmark[12].Z
            );

            v_elbow_wrist = new Vector3(
                -_landmarkList.Landmark[16].X + _landmarkList.Landmark[14].X,
                -_landmarkList.Landmark[16].Y + _landmarkList.Landmark[14].Y,
                -_landmarkList.Landmark[16].Z + _landmarkList.Landmark[14].Z
            );

            v_wrist_thumb = new Vector3(
                -_landmarkList.Landmark[22].X + _landmarkList.Landmark[16].X,
                -_landmarkList.Landmark[22].Y + _landmarkList.Landmark[16].Y,
                -_landmarkList.Landmark[22].Z + _landmarkList.Landmark[16].Z
            );

            v_wrist_index = new Vector3(
                -_landmarkList.Landmark[20].X + _landmarkList.Landmark[16].X,
                -_landmarkList.Landmark[20].Y + _landmarkList.Landmark[16].Y,
                -_landmarkList.Landmark[20].Z + _landmarkList.Landmark[16].Z
            );

            v_wrist_pinky = new Vector3(
                -_landmarkList.Landmark[18].X + _landmarkList.Landmark[16].X,
                -_landmarkList.Landmark[18].Y + _landmarkList.Landmark[16].Y,
                -_landmarkList.Landmark[18].Z + _landmarkList.Landmark[16].Z
            );

            v_hip_knee = new Vector3(
                -_landmarkList.Landmark[26].X + _landmarkList.Landmark[24].X,
                -_landmarkList.Landmark[26].Y + _landmarkList.Landmark[24].Y,
                -_landmarkList.Landmark[26].Z + _landmarkList.Landmark[24].Z
            );

            v_knee_ankle = new Vector3(
                -_landmarkList.Landmark[28].X + _landmarkList.Landmark[26].X,
                -_landmarkList.Landmark[28].Y + _landmarkList.Landmark[26].Y,
                -_landmarkList.Landmark[28].Z + _landmarkList.Landmark[26].Z
            );

            v_ankle_heel = new Vector3(
                -_landmarkList.Landmark[30].X + _landmarkList.Landmark[28].X,
                -_landmarkList.Landmark[30].Y + _landmarkList.Landmark[28].Y,
                -_landmarkList.Landmark[30].Z + _landmarkList.Landmark[28].Z
            );

            v_ankle_index = new Vector3(
                -_landmarkList.Landmark[32].X + _landmarkList.Landmark[28].X,
                -_landmarkList.Landmark[32].Y + _landmarkList.Landmark[28].Y,
                -_landmarkList.Landmark[32].Z + _landmarkList.Landmark[28].Z
            );

        }

        public override void Calc () {}
    }
};