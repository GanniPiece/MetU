using UnityEngine;

namespace Mediapipe.Unity
{
    public class LimbJointCalculator: HumanJointCalculator
    {
        public Vector3 v_hip_shoulder;
        public Vector3 v_shoulder_elbow;
        public Vector3 v_elbow_wrist;
        public Vector3 v_wrist_thumb;
        public Vector3 v_wrist_index;
        public Vector3 v_wrist_pinky;
        public Vector3 v_hip_knee;
        public Vector3 v_knee_ankle;
        public Vector3 v_ankle_heel;
        public Vector3 v_ankle_index;

        public LimbJointCalculator (Transform t) : base(t) {}
        
        public virtual void Refresh () {}

        public override void Calc () {}
    }
};