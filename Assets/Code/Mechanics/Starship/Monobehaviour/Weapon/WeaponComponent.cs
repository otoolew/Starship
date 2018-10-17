using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : MonoBehaviour
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
    private FactionAlignment factionAlignment;
    public FactionAlignment FactionAlignment
    {
        get { return factionAlignment; }
        set { factionAlignment = value; }
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
    private float durability;
    public float Durability
    {
        get { return durability; }
        private set { durability = value; }
    }
    [SerializeField]
    private float componentDrag;
    public float ComponentDrag
    {
        get { return componentDrag; }
        private set { componentDrag = value; }
    }
    [SerializeField]
    private bool operational;
    public bool Operational
    {
        get { return operational; }
        private set { operational = value; }
    }
    #endregion

    #region Init
    public void InitComponent()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = weaponSchematic.partSprite;
        WeaponRange = weaponSchematic.weaponRange;
        WeaponPower = weaponSchematic.weaponPower;
        WeaponCooldown = weaponSchematic.weaponCooldown;
        WeaponTimer = weaponSchematic.weaponCooldown;
        Durability = weaponSchematic.durability;
        ComponentDrag = weaponSchematic.componentDrag;
        Operational = true;
    }
    #endregion

    #region Monobehaviour
    // Use this for initialization
    private void Awake()
    {

    }
    private void Start()
    {
        factionAlignment = GetComponentInParent<ActorController>().factionAlignment;
        InitComponent();
    }

    // Update is called once per frame
    private void Update()
    {
        CooldownWeapon();
    }
    #endregion

    ///// <summary>
    ///// Used when LoadWeaponSystems is called.
    ///// </summary>
    ///// <param name="weaponSystem"></param>
    ///// <returns></returns>
    //private Weapon MountWeapon(WeaponSchematic weaponSchematic)
    //{
    //    Weapon weapon = new Weapon
    //    {
    //        WeaponPrefab = weaponSchematic.weaponPrefab,
    //        WeaponName = weaponSchematic.partName,
    //        MunitionPrefab = weaponSchematic.munitionPrefab,
    //        WeaponRange = weaponSchematic.weaponRange,
    //        WeaponPower = weaponSchematic.weaponPower,
    //        WeaponCooldown = weaponSchematic.weaponCooldown,
    //        WeaponTimer = weaponSchematic.weaponCooldown
    //    };
    //    return weapon;
    //}

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
            Instantiate(WeaponSchematic.munitionPrefab, transform);
            WeaponTimer = WeaponCooldown;
            WeaponReady = false;
        }
    }
}
