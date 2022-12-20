using UnityEngine;
using System.Collections.Generic;

namespace Mediapipe.Unity
{
    public class TorsoJointFactory
    {
        HipCalculator hipCalculator;
        SpineCalculator spineCalculator;

        public TorsoJointFactory(Animator anim)
        {
            hipCalculator = new HipCalculator(
                anim.GetBoneTransform(HumanBodyBones.Hips)
            );
            spineCalculator = new SpineCalculator(
                anim.GetBoneTransform(HumanBodyBones.Spine)
            );
        }

        public HashSet<HumanJointCalculator> Generate ()
        {
            HashSet<HumanJointCalculator> calculators = new HashSet<HumanJointCalculator>();

            calculators.Add(hipCalculator);
            calculators.Add(spineCalculator);

            return calculators;
        }
    }
};