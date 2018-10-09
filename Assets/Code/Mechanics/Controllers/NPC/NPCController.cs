// ----------------------------------------------------------------------------
//  William O'Toole 
//  Project: Starship
//  OCT 2018
// ----------------------------------------------------------------------------
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NPCShipController))]
[RequireComponent(typeof(NPCWeaponController))]
public class NPCController : ActorController
{
    #region Variable Declarations
    public Enums.NPCState npcState;

    [SerializeField]
    private NPCShipController shipController;
    public NPCShipController ShipController
    {
        get { return shipController; }
        private set { shipController = value; }
    }

    [SerializeField]
    private NPCWeaponController weaponController;
    public NPCWeaponController WeaponController
    {
        get { return weaponController; }
        private set { weaponController = value; }
    }
    [SerializeField]
    private TargetController targetController;
    public TargetController TargetController
    {
        get { return targetController; }
        private set { targetController = value; }
    }
    public float Velocity
    {
        get { return GetComponent<Rigidbody>().velocity.magnitude; }
    }
    [SerializeField]
    private Transform targetDestination;
    public Transform TargetDestination
    {
        get { return targetDestination; }
        private set { targetDestination = value; }
    }
    #endregion
    #region Events
   
    #endregion

    #region EventHandlers
    //public void HandleAcquiredTarget(ActorController target)
    //{
    //    Debug.Log(ActorName + " [NPCController] acquired " + target);
    //    if(target != null)
    //        targetDestination = target.transform;
    //}
    #endregion

    // Use this for initialization
    void Start ()
    {
        //targetController.onAcquiredTarget.AddListener(HandleAcquiredTarget);

    }
    #region Methods

    void UpdateDestination(Transform newDestination)
    {
        targetDestination = newDestination;
    }
    private void OnDisable()
    {
        onTargetDeath.Invoke(this);
    }
    private void OnDestroy()
    {
        
    }
    #endregion
    // Update is called once per frame
    void Update ()
    {
		
	}

}
