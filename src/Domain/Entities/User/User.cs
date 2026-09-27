namespace Project.Analytics.Dashboard.Domain.Entities.User
{
    public class User
    {
        public Guid Id { get; private set; }

        public string GoogleId { get; private set; } = string.Empty;

        public string Name { get; private set; } = string.Empty;

        public string Email { get; private set; } = string.Empty;

        public string? ProfileImage { get; private set; }

        public DateTime CreatedAt { get; private set; }

        private User()
        {
        }

        public User(
            string googleId,
            string name,
            string email,
            string? profileImage)
        {
            Id = Guid.NewGuid();
            GoogleId = googleId;
            Name = name;
            Email = email;
            ProfileImage = profileImage;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
