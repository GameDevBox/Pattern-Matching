using System;

namespace GameDevBox.Tutorial;

/// <summary>
/// The traditional procedural approach using nested if-else ladders and switch statements.
/// Compare this with CombatCalculator.cs to see how modern C# pattern matching cleans this up!
/// </summary>
public static class CombatIfElse
{
    // 1. Traditional If-Else Ladder: weapon multiplier
    public static float GetWeaponMultiplier(WeaponType weapon)
    {
        if (weapon == WeaponType.Dagger)
        {
            return 1.5f;
        }
        else if (weapon == WeaponType.Staff)
        {
            return 1.2f;
        }
        else if (weapon == WeaponType.Sword)
        {
            return 1.0f;
        }
        else
        {
            return 1.0f;
        }
    }

    // 2. Traditional If-Else: enemy state & health checks
    public static float CalculateDamage(float baseDamage, Enemy target)
    {
        if (target.IsInvulnerable)
        {
            return 0f;
        }
        else if (target.Armor > 50f)
        {
            return baseDamage * 0.5f;
        }
        else if (target.Health <= 20f)
        {
            return baseDamage * 2.0f;
        }
        else
        {
            return baseDamage;
        }
    }

    // 3. Traditional Nested Matrix: elemental combination multipliers
    public static float GetElementalMultiplier(Element attack, Element weakness)
    {
        if (attack == Element.Fire && weakness == Element.Ice)
        {
            return 2.0f;
        }
        else if (attack == Element.Water && weakness == Element.Fire)
        {
            return 1.5f;
        }
        else if (attack == weakness)
        {
            return 0.75f;
        }
        else
        {
            return 1.0f;
        }
    }
}
