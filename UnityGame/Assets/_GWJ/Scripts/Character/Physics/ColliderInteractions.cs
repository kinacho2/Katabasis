using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderInteractions : MonoBehaviour
{
    [SerializeField] bool _top;
    [SerializeField] bool _bottom;
    [SerializeField] bool _left;
    [SerializeField] bool _right;
    [SerializeField] bool _grounded;

    public bool Top { get { return _top; } set { _top = value; } }
    public bool Bottom { get { return _bottom; } set { _bottom = value; } }
    public bool Left { get { return _left; } set { _left = value; } }
    public bool Right { get { return _right; } set { _right = value; } }
    public bool Grounded { get { return _grounded; } set { _grounded = value; } }

    [SerializeField] CCollider TopCollider;
    [SerializeField] CCollider BottomCollider;
    [SerializeField] CCollider LeftCollider;
    [SerializeField] CCollider RightCollider;
    [SerializeField] CCollider GroundedCollider;

    private void Awake()
    {
        TopCollider.SetCollisionAction(TopCollision);
        BottomCollider.SetCollisionAction(BotCollision);
        LeftCollider.SetCollisionAction(LeftCollision);
        RightCollider.SetCollisionAction(RightCollision);
        GroundedCollider.SetCollisionAction(GroundCollision);
    }

    void TopCollision(bool value)
    {
        Top = value;
    }
    void BotCollision(bool value)
    {
        Bottom = value;
    }
    void LeftCollision(bool value)
    {
        Left = value;
    }
    void RightCollision(bool value)
    {
        Right = value;
    }
    void GroundCollision(bool value)
    {
        Grounded = value;
    }
}
