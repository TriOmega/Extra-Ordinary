using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IStunnable
{
    bool IsStunned { get; }
    float StunDurationSeconds { get; }
    void Stun();
}
