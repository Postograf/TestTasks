using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IScorable
{
    public event UnityAction Scored;
}
