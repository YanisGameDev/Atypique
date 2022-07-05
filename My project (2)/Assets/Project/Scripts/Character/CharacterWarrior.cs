using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWarrior : PlayerCharacter
{
    new void Start()
    {
        //Execute la fonction Start de la class Parent (PlayerCharacter)
        base.Start();
    }

    new void Update()
    {
        //Execute la fonction Update de la class Parent (PlayerCharacter)
        base.Update();
    }

    public override void SetMovementLocation(Vector3 pLocation)
    {
        //Execute la fonction SetMovementLocation de la class Parent (PlayerCharacter)
        base.SetMovementLocation(pLocation);
    }

    public override void Action_A()
    {
        Debug.Log("Warrior Action: A => Mortal Strike");
        Instantiate(skill.MortalStrike(), this.transform);
        actionInCours = false;
    }
    public override void Action_Z()
    {
        Debug.Log("Warrior Action: Z => Rage");
    }
    public override void Action_R()
    {
        Debug.Log("Warrior Action: R => Shield");
        Instantiate(skill.Shield(), this.transform);
        actionInCours = false;
    }
}
