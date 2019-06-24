using System.Collections;
using System.Collections.Generic;


public class GameUnit
{
    
    private int meleeDamage;
    private float speed;
    private int normalDefense;
    private int specialDefense;
    private bool damageToPlayerOnContact;
    private int health;
    private float proximityToEndOfSpline;
    bool flyer;
    bool enemy;
    bool playerUnit;
    bool boss;
    bool hidden;
    bool isValidTarget;

    public int MeleeDamage { get => meleeDamage; set => meleeDamage = value; }
    public float Speed { get => speed; set => speed = value; }
    public int NormalDefense { get => normalDefense; set => normalDefense = value; }
    public int SpecialDefense { get => specialDefense; set => specialDefense = value; }
    public bool DamageToPlayerOnContact { get => damageToPlayerOnContact; set => damageToPlayerOnContact = value; }
    public int Health { get => health; set => health = value; }
    public float ProximityToEndOfSpline { get => proximityToEndOfSpline; set => proximityToEndOfSpline = value; }
    public bool Flyer { get => flyer; set => flyer = value; }
    public bool Enemy { get => enemy; set => enemy = value; }
    public bool PlayerUnit { get => playerUnit; set => playerUnit = value; }
    public bool Boss { get => boss; set => boss = value; }
    public bool Hidden { get => hidden; set => hidden = value; }
    public bool IsValidTarget { get => isValidTarget; set => isValidTarget = value; }
}
