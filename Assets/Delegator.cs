using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delegator : MonoBehaviour
{
    public delegate void UpdateHealth();
    public UpdateHealth updateUI;

    private void Start()
    {
        updateUI += DummyMethod;
    }

    private void DummyMethod()
    {

    }
}
