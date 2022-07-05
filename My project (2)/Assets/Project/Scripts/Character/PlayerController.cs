using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Le controlleur est un script séparé du personnage ce qui permet de faire différents controlleur 
/// ou de le géré via une IA sans toucher au personnage.
/// </summary>
public class PlayerController : MonoBehaviour
{
    private PlayerCharacter character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<PlayerCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTileOnMap();
        InputAction();
    }

    /// <summary>
    /// Retourne la position au sol de ma souris dans le monde.
    /// </summary>
    /// <returns></returns>
    private Vector3 MousePositionOnMap()
    {
        Vector3 mousePos = Input.mousePosition;
        Ray pointRay = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(pointRay, out hit))
        {
            return hit.point;
        }
        else return Vector3.zero;
    }

    /// <summary>
    /// Permet de déplacer le personnage sur la carte en appelant sa fonction SetMovementToLocation.
    /// </summary>
    private void MoveToLocation()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (character != null)
                character.SetMovementLocation(MousePositionOnMap());
        }
    }

    /// <summary>
    /// Permet de déplacer le personnage sur des points définie de la carte.
    /// Dans ce cas la les tile de la carte de jeu.
    /// </summary>
    private void MoveToTileOnMap()
    {
        GameManager.instance.map.ColorTile(GameManager.instance.map.GetTileByPosition(MousePositionOnMap()));
        if (Input.GetMouseButtonDown(0))
        {
            if (character != null)
                character.SetMovementLocation(GameManager.instance.map.GetTileByPosition(MousePositionOnMap()).transform.position);
        }
    }


    private void InputAction()
    {
        if (character != null)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                character.SelectAction(PlayerCharacter.Action.Action_A);
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                character.SelectAction(PlayerCharacter.Action.Action_Z);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                character.SelectAction(PlayerCharacter.Action.Action_R);
            }
        }
    }
}
