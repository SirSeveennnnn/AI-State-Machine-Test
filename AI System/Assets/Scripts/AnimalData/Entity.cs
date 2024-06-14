using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalType
{
    Boar,
    Eagle
}

public enum Interaction
{
    Chase,
    Flee
}

public class Entity : MonoBehaviour
{
    public AnimalType animalType;
}
