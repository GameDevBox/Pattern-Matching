using System;

namespace GameDevBox.Tutorial;

public enum WeaponType { Sword, Dagger, Staff }
public enum Element { Physical, Fire, Ice, Water }

public class Enemy
{
    public bool IsInvulnerable { get; set; }
    public float Armor { get; set; }
    public float Health { get; set; }
    public Element Weakness { get; set; }
}

public static class CombatCalculator
{
    // 1. Basic Switch Expression: maps weapon to damage multiplier
    public static float GetWeaponMultiplier(WeaponType weapon) => weapon switch
    {
        WeaponType.Dagger => 1.5f,
        WeaponType.Staff  => 1.2f,
        WeaponType.Sword  => 1.0f,
        _                 => 1.0f
    };

    // 2. Property & Relational Pattern Matching: checks enemy state directly
    public static float CalculateDamage(float baseDamage, Enemy target) => target switch
    {
        { IsInvulnerable: true } => 0f,
        { Armor: > 50f }         => baseDamage * 0.5f,
        { Health: <= 20f }       => baseDamage * 2.0f,
        _                        => baseDamage
    };

    // 3. Tuple Pattern: combines attack element with enemy weakness
    public static float GetElementalMultiplier(Element attack, Element weakness) => (attack, weakness) switch
    {
        (Element.Fire, Element.Ice)   => 2.0f,
        (Element.Water, Element.Fire) => 1.5f,
        (var a, var w) when a == w    => 0.75f,
        _                             => 1.0f
    };

    public static void Main()
    {
        Console.WriteLine("=== GameDevBox C# Pattern Matching Demo ===");
        var armoredEnemy = new Enemy { Armor = 75f, Health = 100f, Weakness = Element.Ice };
        var dyingEnemy = new Enemy { Armor = 10f, Health = 15f, Weakness = Element.Fire };

        float daggerDmg = 100f * GetWeaponMultiplier(WeaponType.Dagger);
        Console.WriteLine($"Dagger damage: {daggerDmg}");

        float hitArmored = CalculateDamage(daggerDmg, armoredEnemy);
        Console.WriteLine($"Hit vs Armored (>50 armor): {hitArmored}");

        float hitDying = CalculateDamage(daggerDmg, dyingEnemy);
        Console.WriteLine($"Hit vs Low Health (<=20 hp): {hitDying}");

        float fireVsIce = daggerDmg * GetElementalMultiplier(Element.Fire, armoredEnemy.Weakness);
        Console.WriteLine($"Fire vs Ice weakness: {fireVsIce}");
    }
}
