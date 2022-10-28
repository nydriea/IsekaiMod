﻿using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.GodEmporer
{
    class SiphoningAuraFeature
    {
        public static void Add()
        {
            var Icon_SiphoningAura = AssetLoader.LoadInternal("Features", "ICON_SIPHONING_AURA.png");
            var SiphoningAuraBuff = Helpers.CreateBlueprint<BlueprintBuff>("SiphoningAuraBuff", bp => {
                bp.SetName("Siphoning Aura");
                bp.SetDescription("This creature has a –2 penalty on all attributes.");
                bp.IsClassFeature = true;
                bp.m_Icon = Icon_SiphoningAura;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Strength;
                    c.Value = -2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Dexterity;
                    c.Value = -2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Constitution;
                    c.Value = -2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Intelligence;
                    c.Value = -2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Wisdom;
                    c.Value = -2;
                });
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.Penalty;
                    c.Stat = StatType.Charisma;
                    c.Value = -2;
                });
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var SiphoningAuraArea = Helpers.CreateBlueprint<BlueprintAbilityAreaEffect>("SiphoningAuraArea", bp => {
                bp.m_TargetType = BlueprintAbilityAreaEffect.TargetType.Enemy;
                bp.SpellResistance = false;
                bp.AggroEnemies = false;
                bp.AffectEnemies = true;
                bp.Shape = AreaEffectShape.Cylinder;
                bp.Size = new Feet() { m_Value = 40 };
                bp.Fx = new PrefabLink();
                bp.AddComponent(AuraUtils.CreateUnconditionalAuraEffect(SiphoningAuraBuff.ToReference<BlueprintBuffReference>()));
            });
            var SiphoningAuraAreaBuff = Helpers.CreateBlueprint<BlueprintBuff>("SiphoningAuraAreaBuff", bp => {
                bp.SetName("Siphoning Aura");
                bp.SetDescription("Enemies within 40 feet of the God Emporer take a –2 penalty on all attributes.");
                bp.m_Icon = Icon_SiphoningAura;
                bp.IsClassFeature = true;
                bp.m_Flags = BlueprintBuff.Flags.HiddenInUi;
                bp.AddComponent<AddAreaEffect>(c => {
                    c.m_AreaEffect = SiphoningAuraArea.ToReference<BlueprintAbilityAreaEffectReference>();
                });
                bp.FxOnStart = new PrefabLink();
                bp.FxOnRemove = new PrefabLink();
            });
            var SiphoningAuraAbility = Helpers.CreateBlueprint<BlueprintActivatableAbility>("SiphoningAuraAbility", bp => {
                bp.SetName("Siphoning Aura");
                bp.SetDescription("Enemies within 40 feet of the God Emporer take a –2 penalty on all attributes.");
                bp.m_Icon = Icon_SiphoningAura;
                bp.m_Buff = SiphoningAuraAreaBuff.ToReference<BlueprintBuffReference>();
                bp.Group = ActivatableAbilityGroup.None;
                bp.WeightInGroup = 1;
                bp.IsOnByDefault = true;
                bp.DoNotTurnOffOnRest = true;
                bp.DeactivateImmediately = true;
                bp.ActivationType = AbilityActivationType.Immediately;
            });
            var SiphoningAuraFeature = Helpers.CreateBlueprint<BlueprintFeature>("SiphoningAuraFeature", bp => {
                bp.SetName("Siphoning Aura");
                bp.SetDescription("At 12th level, enemies within 40 feet of the God Emporer take a –2 penalty on all attributes.");
                bp.m_Icon = Icon_SiphoningAura;
                bp.Ranks = 1;
                bp.IsClassFeature = true;
                bp.AddComponent<AddFacts>(c => {
                    c.m_Facts = new BlueprintUnitFactReference[] { SiphoningAuraAbility.ToReference<BlueprintUnitFactReference>() };
                });
            });
        }
    }
}
