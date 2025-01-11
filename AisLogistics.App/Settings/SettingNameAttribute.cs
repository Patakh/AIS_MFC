using System;

namespace AisLogistics.App.Settings;

[AttributeUsage(AttributeTargets.All)]
public class SettingNameAttribute : Attribute
{
    public string SettingName { get; }

    public SettingNameAttribute(string settingName) => SettingName = settingName;
}