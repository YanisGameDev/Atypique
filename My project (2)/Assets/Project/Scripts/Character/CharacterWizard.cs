using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWizard : PlayerCharacter
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
        Instantiate(skill.FireBolt(), this.transform);
        actionInCours = false;
    }
    public override void Action_Z()
    {
        Debug.Log("Wizard Action: Z => Slow Enemies");
    }
    public override void Action_R()
    {
        Debug.Log("Wizard Action: R => Teleport to point");
    }
}
