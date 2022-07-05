using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Pour etre certain d'avoir les composant Rigidbody et PlayerController j'utilise le RequiereComponent
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerController))]

/// <summary>
/// La class PlayerCharacter est une class mère qui va me permettre d'user du Polymorphisme et de redéfinir les compétences d'action.
/// Les mouvements par exemple ne changent pas alors je n'aurais pas besoin de les redéfinirs.
/// </summary>
public class PlayerCharacter : MonoBehaviour
{
    //Cet enumération me permet de trouver et de séléctionner plus facilement les compétences d'action lors de l'appel.
    public enum Action
    {
        Action_A, Action_Z, Action_R
    }

    //Permet de savoir dans quel équipe est le personnage.
    public GameManager.Team team;

    //Vitesse de déplacement
    [SerializeField] private float moveSpeed = 10f;

    //Le personnage peut-il se déplacer ?
    protected bool isCanMove = false;
    //Le personnage a-il une action en cour ?
    protected bool actionInCours = false;

    //C'est la position que le personnage doit rejoindre.
    protected Vector3 newLocation = Vector3.zero;
    
    //C'est la distance de la nouvelle position a laquelle le personnage peut s'arréter.
    //Il permet au palier à l'anomalie de précision du Vector3.Lerp().
    [SerializeField] float minDistanceToLocation = 0;


    //Permet d'accéder à la liste de compétence du jeu.
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
    /// Si le joueur peut bouger et qu'une action n'est pas en cour alors il se déplace vers la nouvelle position.
    /// Si le joueur arrive a son objectif alors il ne peut plus bouger.
    /// Il faut donc définir une nouvelle position à l'aide de la fonction "SetMovementLocation(Vector3 pLocation)".
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
    /// Défini la nouvelle position a rejoindre
    /// </summary>
    /// <param name="pLocation">Nouvelle position</param>
    public virtual void SetMovementLocation(Vector3 pLocation)
    {
        if (!isCanMove)
            isCanMove = true;

        newLocation = pLocation;
    }

    /// <summary>
    /// Permet de séléctionner une compétence à appeler
    /// </summary>
    /// <param name="pAction">Enumération qui permet d'identifer la compétence à appeler</param>
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
