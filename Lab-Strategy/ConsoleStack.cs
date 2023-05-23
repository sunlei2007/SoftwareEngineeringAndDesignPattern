
User user = new User("User1", "user1@aaa.com", 15, false, 10);
user.HandleAccess();

Manager manager = new Manager("User2", "user2@aaa.com", 30, false);
manager.HandleAccess();

Admin admin = new Admin("User3", "user3@aaa.com", null, false);
admin.HandleAccess();

Console.ReadLine();
public abstract class Client
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int? Age { get; set; }
    public bool AccessDisabled { get; set; }
    public AccessHandler AccessHandler { get; set; }

    public abstract void HandleAccess();

    protected Client(string name, string email, int? age, bool accessDisabled)
    {
        Name = name;
        Email = email;
        Age = age;
        AccessDisabled = accessDisabled;
    }
}

public class User : Client
{
    public int Reputation { get; set; }

    public User(string name, string email, int? age, bool accessDisabled, int reputation)
        : base(name, email, age, accessDisabled)
    {
        Reputation = reputation;
        AccessHandler = new HasReputation();
    }

    public override void HandleAccess()
    {
        bool isAccess = AccessHandler.GetAccess(Reputation, AccessDisabled);
        Console.WriteLine($"User: {Name}, Access: {isAccess}");
    }
}

public class Manager : Client
{
    public Manager(string name, string email, int? age, bool accessDisabled)
        : base(name, email, age, accessDisabled)
    {
        AccessHandler = new HasAccessAutomatic();
    }

    public override void HandleAccess()
    {
        bool isAccess = AccessHandler.GetAccess();
        Console.WriteLine($"Manager: {Name}, Access: {isAccess}");
    }
}

public class Admin : Client
{
    public Admin(string name, string email, int? age, bool accessDisabled)
        : base(name, email, age, accessDisabled)
    {
        AccessHandler = new HasAccessAutomatic();
    }

    public override void HandleAccess()
    {
        bool hasAccess = AccessHandler.GetAccess();
        Console.WriteLine($"Admin: {Name}, Access: {hasAccess}");
    }
}

public interface AccessHandler
{
    bool GetAccess(int? reputation = 0, bool access = false);
}

public class HasReputation : AccessHandler
{
    public bool GetAccess(int? reputation = 0, bool access = false)
    {
        bool isAccess=false;
        if(reputation > 20 && !access)
            isAccess = true;
        return isAccess;
    }
}

public class HasAccessAutomatic : AccessHandler
{
    public bool GetAccess(int? reputation = 0, bool access = false)
    {
        return !access;
    }
}

