namespace AisLogistics.App.Models
{
    public class UserRoleItem
    {
        public UserRoleItem(Guid roleId, string rolename, bool isUserInClientRole) =>
                (Id, RoleName, IsUserInRole) = (roleId, rolename, isUserInClientRole);

        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public bool IsUserInRole { get; set; }
    }
}
