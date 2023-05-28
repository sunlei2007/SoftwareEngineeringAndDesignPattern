
User user = new User();
user.GetPrivileges();

Console.WriteLine("User Reputation: " + user.GetReputation());

Client communityBadgeUser = new CommunityBadge(user);
communityBadgeUser.GetPrivileges();

Console.WriteLine("Community Badge: " + communityBadgeUser.GetReputation());

Client bannedBadgeUser = new BannedBadge(user);
bannedBadgeUser.GetPrivileges();

Console.WriteLine("Banned Badge: " + bannedBadgeUser.GetReputation());

Client hundredPostsBadgeUser = new HundredPostsBadge(user);
hundredPostsBadgeUser.GetPrivileges();

Console.WriteLine("Hundred Posts Badge: " + hundredPostsBadgeUser.GetReputation());


public abstract class Client
{
    public abstract int GetReputation();
    public abstract void GetPrivileges();
}

public class User : Client
{
    private int _reputation;

    public User()
    {
        _reputation = 0;
    }

    public override int GetReputation()
    {
        return _reputation;
    }

    public override void GetPrivileges()
    {
        GrantBasicAccess();
    }

    private void GrantBasicAccess()
    {
        Console.WriteLine("basic access.");
    }
}

public abstract class Badges : Client
{
    protected Client _client;

    public Badges(Client client)
    {
        _client = client;
    }

    public override int GetReputation()
    {
        return _client.GetReputation();
    }

    public override void GetPrivileges()
    {
        _client.GetPrivileges();
    }
}

public class CommunityBadge : Badges
{
    public CommunityBadge(Client client) : base(client)
    {
    }

    public override int GetReputation()
    {
        return _client.GetReputation() + 5;
    }

    public override void GetPrivileges()
    {
        GrantGroupAccess();
    }

    private void GrantGroupAccess()
    {
        Console.WriteLine("group access.");
    }
}

public class BannedBadge : Badges
{
    public BannedBadge(Client client) : base(client)
    {
    }

    public override int GetReputation()
    {
        return 0;
    }

    public override void GetPrivileges()
    {
        BlockAccess();
    }

    private void BlockAccess()
    {
        Console.WriteLine("blocked.");
    }
}

public class HundredPostsBadge : Badges
{
    public HundredPostsBadge(Client client) : base(client)
    {
    }

    public override int GetReputation()
    {
        return _client.GetReputation() + 100;
    }

    public override void GetPrivileges()
    {
        _client.GetPrivileges();
    }
}