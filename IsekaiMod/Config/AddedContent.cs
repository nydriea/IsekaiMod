using TabletopTweaks.Core.Config;

namespace IsekaiMod.Config {

    public class AddedContent : IUpdatableSettings {
        public bool NewSettingsOffByDefault = false;
        public bool ExcludeCompanionsFromIsekaiClass = false;
        public bool RestrictExceptionalFeats = false;
        public bool RestrictMythicOPAbility = false;
        public bool RestrictMythicSpecialPower = false;
        public bool MultipleMythicOPAbility = false;
        public bool MultipleMythicSpecialPower = false;
        public bool MergeIsekaiSpellList = false;
        public int IsekaiDefaultClothes = 20;
        public SettingGroup Isekai = new();
        public SettingGroup Other = new();

        public void Init() {
        }

        public void OverrideSettings(IUpdatableSettings userSettings) {
            var loadedSettings = userSettings as AddedContent;
            NewSettingsOffByDefault = loadedSettings.NewSettingsOffByDefault;
            ExcludeCompanionsFromIsekaiClass = loadedSettings.ExcludeCompanionsFromIsekaiClass;

            // Restrict Features
            RestrictExceptionalFeats = loadedSettings.RestrictExceptionalFeats;
            RestrictMythicOPAbility = loadedSettings.RestrictMythicOPAbility;
            RestrictMythicSpecialPower = loadedSettings.RestrictMythicSpecialPower;

            // Allow Multiple Selections
            MultipleMythicOPAbility = loadedSettings.MultipleMythicOPAbility;
            MultipleMythicSpecialPower = loadedSettings.MultipleMythicSpecialPower;

            // Change Isekai Protagonist Default Clothes
            IsekaiDefaultClothes = loadedSettings.IsekaiDefaultClothes;

            MergeIsekaiSpellList = loadedSettings.MergeIsekaiSpellList;
            Isekai.LoadSettingGroup(loadedSettings.Isekai, NewSettingsOffByDefault);
            Other.LoadSettingGroup(loadedSettings.Other, NewSettingsOffByDefault);
        }
    }
}