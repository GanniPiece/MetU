using UnityEngine;
using System.Collections.Generic;

namespace Mediapipe.Unity
{
    public class RightLimbsJointFactory
    {
        RightShoulderCalculator rightShoulderCalculator;
        RightElbowCalculator rightElbowCalculator;
        RightWristCalculator rightWristCalculator;
        RightHipCalculator rightHipCalculator;
        RightKneeCalculator rightKneeCalculator;
        RightAnkleCalculator rightAnkleCalculator;

        public RightLimbsJointFactory(Animator anim)
        {
            rightShoulderCalculator = new RightShoulderCalculator(
                anim.GetBoneTransform(HumanBodyBones.RightUpperArm)
            );
            rightElbowCalculator = new RightElbowCalculator(
                anim.GetBoneTransform(HumanBodyBones.RightLowerArm)
            );
            rightWristCalculator = new RightWristCalculator(
                anim.GetBoneTransform(HumanBodyBones.RightHand)
            );
            rightHipCalculator = new RightHipCalculator(
                anim.GetBoneTransform(HumanBodyBones.RightUpperLeg)
            );
            rightKneeCalculator = new RightKneeCalculator(
                anim.GetBoneTransform(HumanBodyBones.RightLowerLeg)
            );
            rightAnkleCalculator = new RightAnkleCalculator(
                anim.GetBoneTransform(HumanBodyBones.RightFoot)
            );
        }

        public HashSet<HumanJointCalculator> Generate ()
        {
            HashSet<HumanJointCalculator> calculators = new HashSet<HumanJointCalculator>();
            calculators.Add(rightShoulderCalculator);
            calculators.Add(rightElbowCalculator);
            calculators.Add(rightWristCalculator);
            calculators.Add(rightHipCalculator);
            calculators.Add(rightKneeCalculator);
            calculators.Add(rightAnkleCalculator);
            return calculators;
        }
    }
};