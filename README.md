# Modern C# Pattern Matching & Switch Expressions

The combat calculation scripts from the GameDevBox video **"Stop Writing Nested Ifs in C#: Modern Pattern Matching in 2 Minutes"**

▶️ Watch the video: [Modern C# Pattern Matching & Switch Expressions](https://youtu.be/4R4kFtTIkD8)]

| Script | What it shows |
| --- | --- |
| [`CombatIfElse.cs`](CombatIfElse.cs) | The **red corner**: The old procedural way — nested `if-else` ladders, repetitive `return` keywords, multi-variable boolean chains, and verbose boilerplate. |
| [`CombatCalculator.cs`](CombatCalculator.cs) | The **blue corner**: The modern C# way — concise `switch` expressions, property patterns `{ IsInvulnerable: true }`, relational patterns `{ Armor: > 50f }`, tuple patterns `(attack, weakness)`, and `when` guards. |

## Quick comparison

| Feature | Nested `if-else` | Modern Pattern Matching |
| --- | --- | --- |
| **Paradigm** | Procedural statement branching | Declarative expression (yields a value directly) |
| **Syntax overhead** | Repeated `return`, braces, `else if` | Lean `pattern => result,` syntax |
| **Object property inspection** | `if (target.Armor > 50f)` | Property pattern `{ Armor: > 50f }` |
| **Value & range checks** | `if (target.Health <= 20f)` | Relational pattern `{ Health: <= 20f }` |
| **Fallback / default** | `else { return fallback; }` | Discard pattern `_ => fallback` |
| **Multi-variable pairing** | `if (a == Fire && w == Ice)` | Tuple pattern `(Element.Fire, Element.Ice)` |
| **Custom condition guards** | Deep nested if statements | `(var a, var w) when a == w => ...` |
| **Compiler safety** | Easy to miss unhandled enum cases | Compiler warns if non-exhaustive |
| **Readability** | 30+ lines of structural noise | Reads like a design balance spreadsheet |

**Rule of thumb:** Use standard `if` statements for one-off early exits (guard clauses like `if (target == null) return;`). Use **switch expressions and pattern matching** whenever you are transforming state or inputs into a value — such as damage formulas, state machines, crafting recipes, elemental matrices, or weapon modifiers.

---

## Code at a glance

### 1. Switch Expressions
```csharp
public static float GetWeaponMultiplier(WeaponType weapon) => weapon switch
{
    WeaponType.Dagger => 1.5f,
    WeaponType.Staff  => 1.2f,
    WeaponType.Sword  => 1.0f,
    _                 => 1.0f
};
```

### 2. Property & Relational Patterns
```csharp
public static float CalculateDamage(float baseDamage, Enemy target) => target switch
{
    { IsInvulnerable: true } => 0f,
    { Armor: > 50f }         => baseDamage * 0.5f,
    { Health: <= 20f }       => baseDamage * 2.0f,
    _                        => baseDamage
};
```

### 3. Tuple Patterns with `when` Guards
```csharp
public static float GetElementalMultiplier(Element attack, Element weakness) => (attack, weakness) switch
{
    (Element.Fire, Element.Ice)   => 2.0f,
    (Element.Water, Element.Fire) => 1.5f,
    (var a, var w) when a == w    => 0.75f,
    _                             => 1.0f
};
```

More Unity & C# tutorials on [GameDevBox](https://www.youtube.com/channel/UCgXs2PTiL19Rv1qOn1SI7XQ?sub_confirmation=1).
