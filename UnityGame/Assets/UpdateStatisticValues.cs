using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateStatisticValues : MonoBehaviour
{

    [SerializeField] Statistics GroundedStatistics;
    [SerializeField] Statistics AirStatistics;
    [SerializeField] Statistics JumpStatistics;
    [SerializeField] Statistics IdleStatistics;
    [SerializeField] Statistics GenericCharacterStatistics;

    [SerializeField] UITestBlock Gravity;
    [SerializeField] UITestBlock MaxHorizontalSpeed;
    [SerializeField] UITestBlock AceleracionHorizontalTierra;
    [SerializeField] UITestBlock AceleracionHorizontalAire;
    [SerializeField] UITestBlock GroundFriction;
    [SerializeField] UITestBlock GroundFrictionWhenStops;
    [SerializeField] UITestBlock AirFriction;
    [SerializeField] UITestBlock MinJumpHeight;
    [SerializeField] UITestBlock AcelerationVertJump;
    [SerializeField] UITestBlock MaxJumpHeight;
    [SerializeField] UITestBlock MaxJumpVelocity;
    [SerializeField] UITestBlock MaxFallVelocity;
    // Start is called before the first frame update
    void Start()
    {
        Gravity.SetValue(GenericCharacterStatistics.Gravity);
        MaxHorizontalSpeed.SetValue(GenericCharacterStatistics.Speed.x);
        AceleracionHorizontalTierra.SetValue(GroundedStatistics.Acceleration);
        AceleracionHorizontalAire.SetValue(AirStatistics.Acceleration);
        GroundFriction.SetValue(GroundedStatistics.Friction);
        GroundFrictionWhenStops.SetValue(GroundedStatistics.Friction);
        AirFriction.SetValue(AirStatistics.Friction);
        MinJumpHeight.SetValue(JumpStatistics.JumpHeight);
        AcelerationVertJump.SetValue(JumpStatistics.JumpAcceleration);
        MaxJumpHeight.SetValue(JumpStatistics.JumpAcceleration + JumpStatistics.JumpHeight);
        MaxJumpVelocity.SetValue(JumpStatistics.Speed.y);
        MaxFallVelocity.SetValue(AirStatistics.Speed.y);


        Gravity.SetText("Gravity");
        MaxHorizontalSpeed.SetText("MaxHorizontalSpeed");
        AceleracionHorizontalTierra.SetText("AcelHoriz\nTierra");
        AceleracionHorizontalAire.SetText("AcelHoriz\nAire");
        GroundFriction.SetText("GroundFriction");
        GroundFrictionWhenStops.SetText("GroundFriction\nWhenStops");
        AirFriction.SetText("AirFriction");
        MinJumpHeight.SetText("MinJumpHeight");
        AcelerationVertJump.SetText("AcelerationVert\nJump");
        MaxJumpHeight.SetText("MaxJumpHeight");
        MaxJumpVelocity.SetText("MaxJumpVelocity");
        MaxFallVelocity.SetText("MaxFallVelocity");


    }

    // Update is called once per frame
    void Update()
    {
        Gravity.UpdateValue(ref GenericCharacterStatistics.Gravity);
        MaxHorizontalSpeed.UpdateValue(ref GenericCharacterStatistics.Speed.x);
        AceleracionHorizontalTierra.UpdateValue(ref GroundedStatistics.Acceleration);
        AceleracionHorizontalAire.UpdateValue(ref GenericCharacterStatistics.Acceleration);
        GroundFriction.UpdateValue(ref GroundedStatistics.Friction);
        GroundFrictionWhenStops.SetValue(GroundedStatistics.Friction);
        AirFriction.UpdateValue(ref AirStatistics.Friction);
        MinJumpHeight.UpdateValue(ref JumpStatistics.JumpHeight);
        AcelerationVertJump.UpdateValue(ref JumpStatistics.JumpAcceleration);
        MaxJumpHeight.SetValue(JumpStatistics.JumpAcceleration + JumpStatistics.JumpHeight);
        MaxJumpVelocity.UpdateValue(ref JumpStatistics.Speed.y);
        MaxFallVelocity.UpdateValue(ref AirStatistics.Speed.y);
    }
}
