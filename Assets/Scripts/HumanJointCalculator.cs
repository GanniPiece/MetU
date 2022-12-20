using UnityEngine;

namespace Mediapipe.Unity
{
    public class HumanJointCalculator
    {
        public Transform obj;
        public LandmarkList _landmarkList;

        public HumanJointCalculator (Transform t)
        {
            obj = t;
        }
        
        public void Refresh (LandmarkList landmarkList) 
        {
            _landmarkList = landmarkList;
        }
        
        public virtual void Calc () {}
    }
};