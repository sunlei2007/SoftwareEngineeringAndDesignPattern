
User user1 = UserFactory.CreateUser(true, true);
user1.PasswordHash();

User user2 = UserFactory.CreateUser(true, false);
user2.PasswordHash();
 
User user3 = UserFactory.CreateUser(false, false);

user3.PasswordHash();
public abstract class User
{
    public string Password { get; set; }

    public abstract void PasswordHash();
}
 
public class NormalUser : User
{
    public override void PasswordHash()
    {
        Console.WriteLine("Password for Normal User");
       
    }
}

 
public class Administrator : User
{
    public override void PasswordHash()
    {
        Console.WriteLine("Password for Administrator");
        
    }
}

public static class UserFactory
{
    public static User CreateUser(bool twoFactorAuthentication, bool isAdmin)
    {
        if (twoFactorAuthentication)
        {
            if (isAdmin)
            {
                return new Administrator();
            }
            else
            {
                return new NormalUser();
            }
        }
        else
        {
            throw new Exception("authentication is required.");
        }
    }
}