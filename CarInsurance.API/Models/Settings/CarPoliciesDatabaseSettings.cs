namespace CarInsurance.API.Models.Settings;

public class CarPoliciesDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string CarPolicyCollectionName { get; set; } = null!;
}
