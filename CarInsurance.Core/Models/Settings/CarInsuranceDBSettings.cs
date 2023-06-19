namespace CarInsurance.Core.Models.Settings;

public class CarInsuranceDBSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string CarPolicyCollectionName { get; set; } = null!;
}
