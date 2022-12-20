using UnityEngine;
using System.Collections.Generic;

namespace Mediapipe.Unity
{
    public class LeftLimbsJointFactory
    {
        LeftShoulderCalculator leftShoulderCalculator;
        LeftElbowCalculator leftElbowCalculator;
        LeftWristCalculator leftWristCalculator;
        LeftHipCalculator leftHipCalculator;
        LeftKneeCalculator leftKneeCalculator;
        LeftAnkleCalculator leftAnkleCalculator;

        public LeftLimbsJointFactory(Animator anim)
        {
            leftShoulderCalculator = new LeftShoulderCalculator(
                anim.GetBoneTransform(HumanBodyBones.LeftUpperArm)
            );
            leftElbowCalculator = new LeftElbowCalculator(
                anim.GetBoneTransform(HumanBodyBones.LeftLowerArm)
            );
            leftWristCalculator = new LeftWristCalculator(
                anim.GetBoneTransform(HumanBodyBones.LeftHand)
            );
            leftHipCalculator = new LeftHipCalculator(
                anim.GetBoneTransform(HumanBodyBones.LeftUpperLeg)
            );
            leftKneeCalculator = new LeftKneeCalculator(
                anim.GetBoneTransform(HumanBodyBones.LeftLowerLeg)
            );
            leftAnkleCalculator = new LeftAnkleCalculator(
                anim.GetBoneTransform(HumanBodyBones.LeftFoot)
            );
        }

        public HashSet<HumanJointCalculator> Generate ()
        {
            HashSet<HumanJointCalculator> calculators = new HashSet<HumanJointCalculator>();
            calculators.Add(leftShoulderCalculator);
            calculators.Add(leftElbowCalculator);
            calculators.Add(leftWristCalculator);
            calculators.Add(leftHipCalculator);
            calculators.Add(leftKneeCalculator);
            calculators.Add(leftAnkleCalculator);
            return calculators;
        }
    }
};