using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
[CreateAssetMenu]
public class Pokemon : SerializedScriptableObject
{
  public RoleModel RoleModel;
  public SkillConfig NormalSkill;
  public PokemonAttr PokemonAttr;
}
