using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Pour etre certain d'avoir les composant Rigidbody et PlayerController j'utilise le RequiereComponent
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerController))]

/// <summary>
/// La class PlayerCharacter est une class m�re qui va me permettre d'user du Polymorphisme et de red�finir les comp�tences d'action.
/// Les mouvements par exemple ne changent pas alors je n'aurais pas besoin de les red�finirs.
/// </summary>
public class PlayerCharacter : MonoBehaviour
{
    //Cet enum�ration me permet de trouver et de s�l�ctionner plus facilement les comp�tences d'action lors de l'appel.
    public enum Action
    {
        Action_A, Action_Z, Action_R
    }

    //Permet de savoir dans quel �quipe est le personnage.
    public GameManager.Team team;

    //Vitesse de d�placement
    [SerializeField] private float moveSpeed = 10f;

    //Le personnage peut-il se d�placer ?
    protected bool isCanMove = false;
    //Le personnage a-il une action en cour ?
    protected bool actionInCours = false;

    //C'est la position que le personnage doit rejoindre.
    protected Vector3 newLocation = Vector3.zero;
    
    //C'est la distance de la nouvelle position a laquelle le personnage peut s'arr�ter.
    //Il permet au palier � l'anomalie de pr�cision du Vector3.Lerp().
    [SerializeField] float minDistanceToLocation = 0;


    //Permet d'acc�der � la liste de comp�tence du jeu.
    protected Skills skill;

    protected void Start()
    {
        skill = new Skills();
        Debug.Log("Parent Start.");

        if (skill == null)
            Debug.Log("Skill is null.");
        else
            Debug.Log("Skill is ready.");


    }

    // Update is called once per frame
    protected void Update()
    {
        MoveToLocation();
    }

    /// <summary>
    /// Si le joueur peut bouger et qu'une action n'est pas en cour alors il se d�place vers la nouvelle position.
    /// Si le joueur arrive a son objectif alors il ne peut plus bouger.
    /// Il faut donc d�finir une nouvelle position � l'aide de la fonction "SetMovementLocation(Vector3 pLocation)".
    /// </summary>
    private void MoveToLocation()
    {
        if (isCanMove && !actionInCours)
        {
            float distance = Vector3.Distance(this.transform.position, newLocation);
            if (distance > minDistanceToLocation)
                this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(newLocation.x, this.transform.position.y, newLocation.z), moveSpeed * Time.deltaTime);
            else
                isCanMove = false;
        }
    }

    /// <summary>
    /// D�fini la nouvelle position a rejoindre
    /// </summary>
    /// <param name="pLocation">Nouvelle position</param>
    public virtual void SetMovementLocation(Vector3 pLocation)
    {
        if (!isCanMove)
            isCanMove = true;

        newLocation = pLocation;
    }

    /// <summary>
    /// Permet de s�l�ctionner une comp�tence � appeler
    /// </summary>
    /// <param name="pAction">Enum�ration qui permet d'identifer la comp�tence � appeler</param>
    public void SelectAction(Action pAction)
    {
        actionInCours = true;

        switch (pAction)
        {
            case Action.Action_A:
                Action_A();
                break;
            case Action.Action_Z:
                Action_Z();
                break;
            case Action.Action_R:
                Action_R();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Execute l'action appeler par la touche clavier A.
    /// </summary>
    public virtual void Action_A()
    {
        Debug.Log("Parent Action: A");
    }
    
    /// <summary>
    /// Execute l'action appeler par la touche clavier Z.
    /// </summary>
    public virtual void Action_Z()
    {
        Debug.Log("Parent Action: Z");
    }

    /// <summary>
    /// Execute l'action appeler par la touche clavier R.
    /// </summary>
    public virtual void Action_R()
    {
        Debug.Log("Parent Action: R");
    }
}
