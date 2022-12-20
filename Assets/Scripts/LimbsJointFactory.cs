using UnityEngine;
using System.Collections.Generic;

namespace Mediapipe.Unity
{
    public class LimbsJointFactory
    {
        RightLimbsJointFactory rightLimbsJointFactory;
        LeftLimbsJointFactory leftLimbsJointFactory;

        public LimbsJointFactory(Animator anim)
        {
            rightLimbsJointFactory = new RightLimbsJointFactory(anim);
            leftLimbsJointFactory = new LeftLimbsJointFactory(anim);
        }

        public HashSet<HumanJointCalculator> Generate ()
        {
            HashSet<HumanJointCalculator> calculators = new HashSet<HumanJointCalculator>();
            HashSet<HumanJointCalculator> rightLimbsJointCalculator = rightLimbsJointFactory.Generate();
            HashSet<HumanJointCalculator> leftLimbsJointCalculator = leftLimbsJointFactory.Generate();

            calculators.UnionWith(rightLimbsJointCalculator);
            calculators.UnionWith(leftLimbsJointCalculator);

            return calculators;
        }
    }
};