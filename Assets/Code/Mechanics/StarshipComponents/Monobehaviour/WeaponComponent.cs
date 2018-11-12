using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : StarshipComponent
{
    #region Variable Declarations
    [SerializeField]
    private WeaponSchematic weaponSchematic;
    public WeaponSchematic WeaponSchematic
    {
        get { return weaponSchematic; }
        set { weaponSchematic = value; }
    }

    [SerializeField]
    private StarshipController controller;
    public override StarshipController Controller
    {
        get { return controller; }
        set { controller = value; }
    }
    [SerializeField]
    private Transform firePoint;
    public Transform FirePoint
    {
        get { return firePoint; }
        set { firePoint = value; }
    }
    [SerializeField]
    private float weaponRange;
    public float WeaponRange
    {
        get { return weaponRange; }
        private set { weaponRange = value; }
    }
    [SerializeField]
    private float weaponPower;
    public float WeaponPower
    {
        get { return weaponPower; }
        private set { weaponPower = value; }
    }
    [SerializeField]
    private float weaponCooldown;
    public float WeaponCooldown
    {
        get { return weaponCooldown; }
        private set { weaponCooldown = value; }
    }
    [SerializeField]
    private float weaponTimer;
    public float WeaponTimer
    {
        get { return weaponTimer; }
        set { weaponTimer = value; }
    }
    [SerializeField]
    private bool triggerTime;
    public bool TriggerTime
    {
        get { return triggerTime; }
        set { triggerTime = value; }
    }
    [SerializeField]
    private bool weaponReady;
    public bool WeaponReady
    {
        get { return weaponReady; }
        set { weaponReady = value; }
    }
    [SerializeField]
    private float hP;
    public float HP
    {
        get { return hP; }
        private set { hP = value; }
    }

    [SerializeField]
    private bool operational;
    public bool Operational
    {
        get { return operational; }
        private set { operational = value; }
    }
    #endregion
    #region Events
    public Events.WeaponDisabled onWeaponDisabled;
    #endregion
    #region Init
    public void InitComponent()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = weaponSchematic.partSprite;
        WeaponRange = weaponSchematic.weaponRange;
        WeaponPower = weaponSchematic.weaponPower;
        WeaponCooldown = weaponSchematic.weaponCooldown;
        WeaponTimer = weaponSchematic.weaponCooldown;
        Operational = true;
    }
    #endregion

    #region Monobehaviour
    // Use this for initialization
    private void Awake()
    {
        //InitComponent();
    }
    private void Start()
    {
        //factionAlignment = GetComponentInParent<ActorController>().factionAlignment;
        InitComponent();
        GetComponent<Collider>().enabled = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if(operational)
            CooldownWeapon();
    }
    #endregion

    private void CooldownWeapon()
    {
        if (WeaponTimer <= 0)
        {
            WeaponTimer = 0;
            WeaponReady = true;
        }
        else
        {
            WeaponTimer -= Time.deltaTime;
            WeaponReady = false;
        }

    }
    public void Fire()
    {
        if (WeaponReady)
        {
            Instantiate(WeaponSchematic.munitionPrefab, firePoint);
            WeaponTimer = WeaponCooldown;
            WeaponReady = false;
        }
    }

    public override void ApplyDamage(int amount)
    {
        Debug.Log(controller + "'s " + gameObject.name + " Hit");
        hP -= amount;
        if (hP <= 0)
        {
            operational = false;
            onWeaponDisabled.Invoke(this);
        }
    }

    public override void RepairDamage(int amount)
    {
        hP += amount;
    }
    public override void DisableEffect()
    {
        throw new System.NotImplementedException();
    }
}
