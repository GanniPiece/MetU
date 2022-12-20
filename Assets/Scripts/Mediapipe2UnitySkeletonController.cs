using Mediapipe;
using UnityEngine;
using System.Collections.Generic;
using System;

namespace Mediapipe.Unity
{
  public class Mediapipe2UnitySkeletonController : MonoBehaviour
  {
    private HumanJointFactory jointFactory;
    private HashSet<HumanJointCalculator> calculators;
    
    private Animator _anim;

    private void Start()
    {      
      _anim = GetComponent<Animator>();

      jointFactory = new HumanJointFactory(_anim);
      calculators = jointFactory.Generate();
    }

    private void Update()
    {
      foreach (var calculator in calculators)
      {
        calculator.Calc();
      }
    }

    public void Refresh(LandmarkList target)
    {
      foreach (var calculator in calculators)
      {
        calculator.Refresh(target);
      }
    }
  }
}