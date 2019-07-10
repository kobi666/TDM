using System.Collections;
using System.Collections.Generic;


public class GameUnit
{
    private int unitMeleeDamage;
    private float unitSpeed;
    private int unitNormalDefense;
    private int unitSpecialDefense;
    private bool unitDamageToPlayerHealthOnContact;
    private int unitHealth;
    private float unitProximityToEndOfSpline;
    bool unitIsFlyer;
    bool unitIsEnemy;
    bool unitIsPlayerUnit;
    bool unitIsBoss;
    bool unitIsHidden;
    bool unitIsTargetable() {
        if (UnitIsBoss == true || UnitIsEnemy == true) {
            if (UnitIsPlayerUnit != true) {
                if (unitIsHidden != )
            }
        }
    }

    public int UnitMeleeDamage { get => unitMeleeDamage; set => unitMeleeDamage = value; }
    public float UnitSpeed { get => unitSpeed; set => unitSpeed = value; }
    public int UnitNormalDefense { get => unitNormalDefense; set => unitNormalDefense = value; }
    public int UnitSpecialDefense { get => unitSpecialDefense; set => unitSpecialDefense = value; }
    public bool UnitDamageToPlayerHealthOnContact { get => unitDamageToPlayerHealthOnContact; set => unitDamageToPlayerHealthOnContact = value; }
    public int UnitHealth { get => unitHealth; set => unitHealth = value; }
    public float UnitProximityToEndOfSpline { get => unitProximityToEndOfSpline; set => unitProximityToEndOfSpline = value; }
    public bool UnitIsFlyer { get => unitIsFlyer; set => unitIsFlyer = value; }
    public bool UnitIsEnemy { get => unitIsEnemy; set => unitIsEnemy = value; }
    public bool UnitIsPlayerUnit { get => unitIsPlayerUnit; set => unitIsPlayerUnit = value; }
    public bool UnitIsBoss { get => unitIsBoss; set => unitIsBoss = value; }
    public bool UnitIsHidden { get => unitIsHidden; set => unitIsHidden = value; }
    public bool UnitIsTargetable { get => unitIsTargetable; set => unitIsTargetable = value; }
}
