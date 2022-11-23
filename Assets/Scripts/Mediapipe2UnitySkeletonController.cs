using Mediapipe;
using UnityEngine;
using System.Collections.Generic;
using System;

namespace Medipipe.Unity
{
  public class Mediapipe2UnitySkeletonController : MonoBehaviour
  {
    private bool dirty;
    private Vector3 mpos;
    public Transform spine;
    public Transform chest;
    public Transform rightElbow;
    public Transform leftElbow;
    public Transform rightShoulder;
    public Transform leftShoulder;
    public Transform leftKnee;
    public Transform rightKnee;
    public Transform leftHip;
    public Transform rightHip;
    public Transform hip;
    public Transform rightFoot;
    public Transform leftFoot;
    public Transform rightHand;
    public Transform leftHand;
    public Transform head;

    private LandmarkList _target;
    private LandmarkList _target_new;
    private Animator _anim;

    private void Start()
    {
      _anim = GetComponent<Animator>();
      head = _anim.GetBoneTransform(HumanBodyBones.Neck);
      hip = GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Hips);
      spine = GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Spine);
      rightElbow = GetComponent<Animator>().GetBoneTransform(HumanBodyBones.RightLowerArm);
      rightShoulder = GetComponent<Animator>().GetBoneTransform(HumanBodyBones.RightUpperArm);
      leftElbow = GetComponent<Animator>().GetBoneTransform(HumanBodyBones.LeftLowerArm);
      leftShoulder = GetComponent<Animator>().GetBoneTransform(HumanBodyBones.LeftUpperArm);

      leftKnee = GetComponent<Animator>().GetBoneTransform(HumanBodyBones.LeftLowerLeg);
      rightKnee = GetComponent<Animator>().GetBoneTransform(HumanBodyBones.RightLowerLeg);

      rightHip = GetComponent<Animator>().GetBoneTransform(HumanBodyBones.RightUpperLeg);
      leftHip = GetComponent<Animator>().GetBoneTransform(HumanBodyBones.LeftUpperLeg);

      rightFoot = GetComponent<Animator>().GetBoneTransform(HumanBodyBones.RightFoot);
      leftFoot = GetComponent<Animator>().GetBoneTransform(HumanBodyBones.LeftFoot);

      rightHand = _anim.GetBoneTransform(HumanBodyBones.RightHand);
      leftHand = _anim.GetBoneTransform(HumanBodyBones.LeftHand);

      chest = _anim.GetBoneTransform(HumanBodyBones.Chest);
    }

    private void Update()
    {

      if (AdjustMovement())
      {
        Calc();
      }
    }

    public void Refresh(LandmarkList target)
    {
      _target_new = target;
    }

    private bool AdjustMovement()
    {
      if (_target_new == null)
      {
        return false;
      }
      if (_target == null)
      {
        _target = _target_new;
      }

      var min_confidence = 0.3f;
      var adjust = false;

      for (var i = 0; i < 33; i++)
      {
        var conf = _target_new.Landmark[i].Visibility;

        if (conf >= min_confidence)
        {
          _target.Landmark[i] = _target_new.Landmark[i];
          adjust = true;
        }
      }
      return adjust;
    }

    private void Calc()
    {
      CalcHip();

      CalcHead();
      CalcSpine();

      CalcRightShoulder();
      CalcLeftShoulder();

      CalcRightElbow();
      CalcLeftElbow();

      CalcLeftHip();
      CalcRightHip();

      CalcRightKnee();
      CalcLeftKnee();

      CalcLeftFoot();
      CalcRightFoot();

      CalcRightHand();
      CalcLeftHand();

    }

    private void CalcHead()
    {
      if (_target == null)
      {
        return;
      }

      var mouth_l = new Vector3(-_target.Landmark[9].X,
                              -_target.Landmark[9].Y,
                              -_target.Landmark[9].Z);
      var mouth_r = new Vector3(-_target.Landmark[10].X,
                              -_target.Landmark[10].Y,
                              -_target.Landmark[10].Z);
      var nose = new Vector3(-_target.Landmark[0].X,
                              -_target.Landmark[0].Y,
                              -_target.Landmark[0].Z);
      var shoulder_l = new Vector3(-_target.Landmark[11].X,
                              -_target.Landmark[11].Y,
                              -_target.Landmark[11].Z);
      var shoulder_r = new Vector3(-_target.Landmark[12].X,
                              -_target.Landmark[12].Y,
                              -_target.Landmark[12].Z);

      var vec1 = shoulder_r - shoulder_l;
      var vec2 = mouth_r - mouth_l;
      var angle = Quaternion.FromToRotation(vec1, vec2);
      head.localEulerAngles = new Vector3(0, 0, -20);
      head.Rotate(angle.eulerAngles, Space.World);

    }

    private void CalcHip()
    {
      if (_target == null)
      {
        return;
      }

      var hip_l = new Vector3(-_target.Landmark[23].X,
                              -_target.Landmark[23].Y,
                              -_target.Landmark[23].Z);
      var hip_r = new Vector3(-_target.Landmark[24].X,
                              -_target.Landmark[24].Y,
                              -_target.Landmark[24].Z);

      var vec1 = Vector3.right;
      var vec2 = hip_r - hip_l;

      var angle = Quaternion.FromToRotation(vec1, vec2);
      transform.localEulerAngles = new Vector3(0, 0, 0);
      transform.Rotate(angle.eulerAngles);
    }

    private void CalcSpine()
    {
      if (_target == null)
      {
        return;
      }

      var shoulder_l = new Vector3(-_target.Landmark[11].X,
                                   -_target.Landmark[11].Y,
                                   -_target.Landmark[11].Z);
      var shoulder_r = new Vector3(-_target.Landmark[12].X,
                                   -_target.Landmark[12].Y,
                                   -_target.Landmark[12].Z);
      var hip_l = new Vector3(-_target.Landmark[23].X,
                              -_target.Landmark[23].Y,
                              -_target.Landmark[23].Z);
      var hip_r = new Vector3(-_target.Landmark[24].X,
                              -_target.Landmark[24].Y,
                              -_target.Landmark[24].Z);

      //var vec1 = shoulder_l - shoulder_r;

      var hip_m = Vector3.Lerp(hip_l, hip_r, 1 / 2);
      var shoulder_m = Vector3.Lerp(shoulder_l, shoulder_r, 1 / 2);
      var vec1 = hip_l - hip_r;
      var vec2 = shoulder_m - hip_m;

      var angle = Quaternion.FromToRotation(vec1, vec2);
      spine.localEulerAngles = new Vector3(0, 90, 0);
      spine.Rotate(angle.eulerAngles, Space.World);
    }

    #region right
    private void CalcRightElbow()
    {
      if (_target == null)
      {
        return;
      }

      var elbow = new Vector3(-_target.Landmark[14].X,
                              -_target.Landmark[14].Y,
                              -_target.Landmark[14].Z);

      var shoulder = new Vector3(-_target.Landmark[12].X,
                                 -_target.Landmark[12].Y,
                                 -_target.Landmark[12].Z);

      var wrist = new Vector3(-_target.Landmark[16].X,
                              -_target.Landmark[16].Y,
                              -_target.Landmark[16].Z);

      var vec1 = elbow - shoulder;
      var vec2 = wrist - elbow;

      var angle = Quaternion.FromToRotation(vec1, vec2);

      rightElbow.localRotation = Quaternion.Euler(0, 0, 0);
      rightElbow.Rotate(angle.eulerAngles, Space.World);

      Debug.DrawLine(elbow, shoulder, UnityEngine.Color.blue);
      Debug.DrawLine(elbow, wrist, UnityEngine.Color.red);

    }

    private void CalcRightShoulder()
    {
      if (_target == null)
      {
        return;
      }

      var shoulder = new Vector3(-_target.Landmark[12].X,
                                 -_target.Landmark[12].Y,
                                 -_target.Landmark[12].Z);

      var hip = new Vector3(-_target.Landmark[24].X,
                                 -_target.Landmark[24].Y,
                                 -_target.Landmark[24].Z);

      var elbow = new Vector3(-_target.Landmark[14].X,
                              -_target.Landmark[14].Y,
                              -_target.Landmark[14].Z);


      var vec1 = shoulder - hip;
      var vec2 = elbow - shoulder;

      var angle = Quaternion.FromToRotation(vec1, vec2);

      rightShoulder.localRotation = Quaternion.Euler(0, 90, 0);
      rightShoulder.Rotate(angle.eulerAngles, Space.World);

      Debug.DrawLine(hip, shoulder, UnityEngine.Color.blue);
      Debug.DrawLine(elbow, shoulder, UnityEngine.Color.red);
    }

    private void CalcRightKnee()
    {
      if (_target == null)
      {
        return;
      }

      var hip = new Vector3(-_target.Landmark[24].X,
                                 -_target.Landmark[24].Y,
                                 -_target.Landmark[24].Z);

      var knee = new Vector3(-_target.Landmark[26].X,
                                 -_target.Landmark[26].Y,
                                 -_target.Landmark[26].Z);

      var ankle = new Vector3(-_target.Landmark[28].X,
                              -_target.Landmark[28].Y,
                              -_target.Landmark[28].Z);

      var vec1 = knee - hip;
      var vec2 = ankle - knee;

      var angle = Quaternion.FromToRotation(vec1, vec2);

      rightKnee.localRotation = Quaternion.Euler(0, 0, 0);
      rightKnee.Rotate(angle.eulerAngles, Space.World);

      Debug.DrawLine(hip, knee, UnityEngine.Color.blue);
      Debug.DrawLine(knee, ankle, UnityEngine.Color.red);
    }

    private void CalcRightHip()
    {
      if (_target == null)
      {
        return;
      }

      var hip_r = new Vector3(-_target.Landmark[24].X,
                           -_target.Landmark[24].Y,
                           -_target.Landmark[24].Z);

      var hip_l = new Vector3(-_target.Landmark[23].X,
                                 -_target.Landmark[23].Y,
                                 -_target.Landmark[23].Z);

      var knee = new Vector3(-_target.Landmark[26].X,
                              -_target.Landmark[26].Y,
                              -_target.Landmark[26].Z);

      var vec1 = hip_r - hip_l;
      var vec2 = knee - hip_r;

      var angle = Quaternion.FromToRotation(vec1, vec2);

      rightHip.localRotation = Quaternion.Euler(0, -90, 0);
      rightHip.Rotate(angle.eulerAngles, Space.World);

      Debug.DrawLine(hip_l, hip_r, UnityEngine.Color.blue);
      Debug.DrawLine(hip_r, knee, UnityEngine.Color.red);
    }

    private void CalcRightFoot()
    {
      if (_target == null)
      {
        return;
      }

      var knee = new Vector3(-_target.Landmark[26].X,
                                 -_target.Landmark[26].Y,
                                 -_target.Landmark[26].Z);

      var ankle = new Vector3(-_target.Landmark[28].X,
                                 -_target.Landmark[28].Y,
                                 -_target.Landmark[28].Z);

      var heal = new Vector3(-_target.Landmark[30].X,
                              -_target.Landmark[30].Y,
                              -_target.Landmark[30].Z);

      var vec1 = knee - ankle;
      var vec2 = heal - ankle;

      var angle = Quaternion.FromToRotation(vec1, vec2);

      rightFoot.localRotation = Quaternion.Euler(0, 0, -210);
      rightFoot.Rotate(angle.eulerAngles, Space.World);

      Debug.DrawLine(knee, ankle, UnityEngine.Color.blue);
      Debug.DrawLine(ankle, heal, UnityEngine.Color.red);
    }

    private void CalcRightHand()
    {
      if (_target == null)
      {
        return;
      }

      var wrist = new Vector3(-_target.Landmark[16].X,
                                 -_target.Landmark[16].Y,
                                 -_target.Landmark[16].Z);

      var index = new Vector3(-_target.Landmark[20].X,
                              -_target.Landmark[20].Y,
                              -_target.Landmark[20].Z);

      var pinky = new Vector3(-_target.Landmark[18].X,
                        -_target.Landmark[18].Y,
                        -_target.Landmark[18].Z);

      var vec1 = Vector3.Cross(_anim.GetBoneTransform(HumanBodyBones.RightRingProximal).position - rightHand.position,
                _anim.GetBoneTransform(HumanBodyBones.RightIndexProximal).position - rightHand.position);
      var vec2 = Vector3.Cross(pinky - wrist, index - wrist);

      var angle = Quaternion.FromToRotation(vec1, vec2);

      rightElbow.Rotate(angle.eulerAngles, Space.World);

      Debug.DrawLine(wrist, index, UnityEngine.Color.blue);
      Debug.DrawLine(wrist, pinky, UnityEngine.Color.red);

    }

    #endregion

    #region left
    private void CalcLeftElbow()
    {
      if (_target == null)
      {
        return;
      }

      var elbow = new Vector3(-_target.Landmark[13].X,
                              -_target.Landmark[13].Y,
                              -_target.Landmark[13].Z);

      var shoulder = new Vector3(-_target.Landmark[11].X,
                                 -_target.Landmark[11].Y,
                                 -_target.Landmark[11].Z);

      var wrist = new Vector3(-_target.Landmark[15].X,
                              -_target.Landmark[15].Y,
                              -_target.Landmark[15].Z);




      var vec1 = elbow - shoulder;
      var vec2 = wrist - elbow;

      var angle = Quaternion.FromToRotation(vec1, vec2);


      leftElbow.localRotation = Quaternion.Euler(0, 0, 0);
      leftElbow.Rotate(angle.eulerAngles, Space.World);

      Debug.DrawLine(shoulder, elbow, UnityEngine.Color.blue);
      Debug.DrawLine(elbow, wrist, UnityEngine.Color.red);

    }

    private void CalcLeftShoulder()
    {
      if (_target == null)
      {
        return;
      }

      var shoulder = new Vector3(-_target.Landmark[11].X,
                                 -_target.Landmark[11].Y,
                                 -_target.Landmark[11].Z);

      var hip = new Vector3(-_target.Landmark[23].X,
                                 -_target.Landmark[23].Y,
                                 -_target.Landmark[23].Z);

      var elbow = new Vector3(-_target.Landmark[13].X,
                              -_target.Landmark[13].Y,
                              -_target.Landmark[13].Z);

      var vec1 = shoulder - hip;
      var vec2 = elbow - shoulder;

      var angle = Quaternion.FromToRotation(vec1, vec2);

      leftShoulder.localRotation = Quaternion.Euler(0, -90, 0);
      leftShoulder.Rotate(angle.eulerAngles, Space.World);

      Debug.DrawLine(shoulder, hip, UnityEngine.Color.blue);
      Debug.DrawLine(shoulder, elbow, UnityEngine.Color.red);
    }

    private void CalcLeftKnee()
    {
      if (_target == null)
      {
        return;
      }

      var hip = new Vector3(-_target.Landmark[23].X,
                            -_target.Landmark[23].Y,
                            -_target.Landmark[23].Z);

      var knee = new Vector3(-_target.Landmark[25].X,
                             -_target.Landmark[25].Y,
                             -_target.Landmark[25].Z);

      var ankle = new Vector3(-_target.Landmark[27].X,
                              -_target.Landmark[27].Y,
                              -_target.Landmark[27].Z);

      var vec1 = knee - hip;
      var vec2 = ankle - knee;

      var angle = Quaternion.FromToRotation(vec1, vec2);

      leftKnee.localRotation = Quaternion.Euler(0, 0, 0);
      leftKnee.Rotate(angle.eulerAngles, Space.World);

      Debug.DrawLine(hip, knee, UnityEngine.Color.blue);
      Debug.DrawLine(knee, ankle, UnityEngine.Color.red);
    }

    private void CalcLeftHip()
    {
      if (_target == null)
      {
        return;
      }

      var hip_r = new Vector3(-_target.Landmark[24].X,
                                 -_target.Landmark[24].Y,
                                 -_target.Landmark[24].Z);

      var hip_l = new Vector3(-_target.Landmark[23].X,
                            -_target.Landmark[23].Y,
                            -_target.Landmark[23].Z);

      var knee = new Vector3(-_target.Landmark[25].X,
                             -_target.Landmark[25].Y,
                             -_target.Landmark[25].Z);

      var vec1 = hip_l - hip_r;
      var vec2 = knee - hip_l;

      var angle = Quaternion.FromToRotation(vec1, vec2);

      leftHip.localRotation = Quaternion.Euler(0, 90, 0);
      leftHip.Rotate(angle.eulerAngles, Space.World);

      Debug.DrawLine(hip_l, hip_r, UnityEngine.Color.blue);
      Debug.DrawLine(hip_l, knee, UnityEngine.Color.red);
    }

    private void CalcLeftFoot()
    {
      if (_target == null)
      {
        return;
      }

      var knee = new Vector3(-_target.Landmark[25].X,
                                 -_target.Landmark[25].Y,
                                 -_target.Landmark[25].Z);

      var ankle = new Vector3(-_target.Landmark[27].X,
                                 -_target.Landmark[27].Y,
                                 -_target.Landmark[27].Z);

      var heal = new Vector3(-_target.Landmark[29].X,
                              -_target.Landmark[29].Y,
                              -_target.Landmark[29].Z);

      var vec1 = knee - ankle;
      var vec2 = heal - ankle;

      var angle = Quaternion.FromToRotation(vec1, vec2);

      leftFoot.localRotation = Quaternion.Euler(0, 0, -210);
      leftFoot.Rotate(angle.eulerAngles, Space.World);

      Debug.DrawLine(knee, ankle, UnityEngine.Color.blue);
      Debug.DrawLine(ankle, heal, UnityEngine.Color.red);
    }

    private void CalcLeftHand()
    {
      if (_target == null)
      {
        return;
      }

      var wrist = new Vector3(-_target.Landmark[15].X,
                                 -_target.Landmark[15].Y,
                                 -_target.Landmark[15].Z);

      var index = new Vector3(-_target.Landmark[19].X,
                              -_target.Landmark[19].Y,
                              -_target.Landmark[19].Z);

      var pinky = new Vector3(-_target.Landmark[17].X,
                              -_target.Landmark[17].Y,
                              -_target.Landmark[17].Z);
      var vec1 = Vector3.Cross(_anim.GetBoneTransform(HumanBodyBones.LeftIndexProximal).position - leftHand.position, _anim.GetBoneTransform(HumanBodyBones.LeftRingProximal).position - leftHand.position);
      var vec2 = Vector3.Cross(pinky - wrist, index - wrist);

      var angle = Quaternion.FromToRotation(vec1, vec2);

      leftElbow.Rotate(angle.eulerAngles, Space.World);

      Debug.DrawLine(wrist, index, UnityEngine.Color.blue);
      Debug.DrawLine(wrist, pinky, UnityEngine.Color.red);

    }

    #endregion
  }
}