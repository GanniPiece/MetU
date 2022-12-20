using UnityEngine;
using System.Collections.Generic;

namespace Mediapipe.Unity
{
    public class HumanJointFactory
    {
        TorsoJointFactory torsoJointFactory;
        LimbsJointFactory limbsJointFactory;
        HeadJointFactory headJointFactory;

        public HumanJointFactory (Animator anim)
        {
            torsoJointFactory = new TorsoJointFactory(anim);
            limbsJointFactory = new LimbsJointFactory(anim);
            headJointFactory = new HeadJointFactory(anim);
        }

        public HashSet<HumanJointCalculator> Generate()
        {
            HashSet<HumanJointCalculator> calculators = new HashSet<HumanJointCalculator>();
            HashSet<HumanJointCalculator> torsoCalculators = torsoJointFactory.Generate();
            HashSet<HumanJointCalculator> limbJointCalculators = limbsJointFactory.Generate();
            HashSet<HumanJointCalculator> headJointCalculators = headJointFactory.Generate();
           
            calculators.UnionWith(torsoCalculators);
            calculators.UnionWith(limbJointCalculators);
            calculators.UnionWith(headJointCalculators);

            return calculators;
        }
    }
};