using UnityEngine;

namespace Mediapipe.Unity
{
    public class LeftLimbJointCalculator: LimbJointCalculator
    {
        public LeftLimbJointCalculator (Transform t) : base(t) {}

        public override void Refresh ()
        {
            if (_landmarkList == null) return;

            v_hip_shoulder = new Vector3(
                -_landmarkList.Landmark[11].X + _landmarkList.Landmark[23].X,
                -_landmarkList.Landmark[11].Y + _landmarkList.Landmark[23].Y,
                -_landmarkList.Landmark[11].Z + _landmarkList.Landmark[23].Z
            );

            v_shoulder_elbow = new Vector3(
                -_landmarkList.Landmark[13].X + _landmarkList.Landmark[11].X,
                -_landmarkList.Landmark[13].Y + _landmarkList.Landmark[11].Y,
                -_landmarkList.Landmark[13].Z + _landmarkList.Landmark[11].Z
            );

            v_elbow_wrist = new Vector3(
                -_landmarkList.Landmark[15].X + _landmarkList.Landmark[13].X,
                -_landmarkList.Landmark[15].Y + _landmarkList.Landmark[13].Y,
                -_landmarkList.Landmark[15].Z + _landmarkList.Landmark[13].Z
            );

            v_wrist_thumb = new Vector3(
                -_landmarkList.Landmark[21].X + _landmarkList.Landmark[15].X,
                -_landmarkList.Landmark[21].Y + _landmarkList.Landmark[15].Y,
                -_landmarkList.Landmark[21].Z + _landmarkList.Landmark[15].Z
            );

            v_wrist_index = new Vector3(
                -_landmarkList.Landmark[19].X + _landmarkList.Landmark[15].X,
                -_landmarkList.Landmark[19].Y + _landmarkList.Landmark[15].Y,
                -_landmarkList.Landmark[19].Z + _landmarkList.Landmark[15].Z
            );

            v_wrist_pinky = new Vector3(
                -_landmarkList.Landmark[17].X + _landmarkList.Landmark[15].X,
                -_landmarkList.Landmark[17].Y + _landmarkList.Landmark[15].Y,
                -_landmarkList.Landmark[17].Z + _landmarkList.Landmark[15].Z
            );

            v_hip_knee = new Vector3(
                -_landmarkList.Landmark[25].X + _landmarkList.Landmark[23].X,
                -_landmarkList.Landmark[25].Y + _landmarkList.Landmark[23].Y,
                -_landmarkList.Landmark[25].Z + _landmarkList.Landmark[23].Z
            );

            v_knee_ankle = new Vector3(
                -_landmarkList.Landmark[27].X + _landmarkList.Landmark[25].X,
                -_landmarkList.Landmark[27].Y + _landmarkList.Landmark[25].Y,
                -_landmarkList.Landmark[27].Z + _landmarkList.Landmark[25].Z
            );

            v_ankle_heel = new Vector3(
                -_landmarkList.Landmark[29].X + _landmarkList.Landmark[27].X,
                -_landmarkList.Landmark[29].Y + _landmarkList.Landmark[27].Y,
                -_landmarkList.Landmark[29].Z + _landmarkList.Landmark[27].Z
            );

            v_ankle_index = new Vector3(
                -_landmarkList.Landmark[31].X + _landmarkList.Landmark[27].X,
                -_landmarkList.Landmark[31].Y + _landmarkList.Landmark[27].Y,
                -_landmarkList.Landmark[31].Z + _landmarkList.Landmark[27].Z
            );
        }

        public override void Calc () {}
    }
};