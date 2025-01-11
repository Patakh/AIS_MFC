namespace AisLogistics.App.Utils
{
    public static class NameSplitter
    {
        public static string GetInitials(string name)
        {
            if (string.IsNullOrEmpty(name)) return string.Empty;
            var splittedName = name.Trim().Replace("  ", " ").Split();
            return splittedName.Length > 2 ? $"{splittedName[0]} {splittedName[1][0]}. {splittedName[2][0]}." :
                splittedName.Length > 1 ? $"{splittedName[0]} {splittedName[1][0]}." : name;
        }
        public static char GetBadge(string name)
        {
            if (string.IsNullOrEmpty(name)) return char.MinValue;
            var splittedName = name.Trim().Replace("  ", " ").Split();
            return splittedName.Length > 1 ? splittedName[1][0] : name[0];
        }
    }
}
