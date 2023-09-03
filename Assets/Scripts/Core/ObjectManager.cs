using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectManager : MonoBehaviour
{
    public static ObjectManager Instance;
    public abstract void SetInstance();
}
