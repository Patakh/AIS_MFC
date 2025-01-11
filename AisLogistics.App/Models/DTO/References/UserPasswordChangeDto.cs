namespace AisLogistics.App.Models.DTO.References
{
    public class UserPasswordChangeDto<TKey>
    {
        public TKey UserId { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
