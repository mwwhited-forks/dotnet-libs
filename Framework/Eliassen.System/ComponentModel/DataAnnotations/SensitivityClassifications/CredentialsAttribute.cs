namespace Eliassen.System.ComponentModel.DataAnnotations.SensitivityClassifications
{
    public class CredentialsAttribute : ConfidentialBaseAttribute
    {
        public CredentialsAttribute() : base(
            informationType: "Credentials",
            informationTypeId: "c64aba7b-3a3e-95b6-535d-3bc535da5a59"
                )
        {
        }
    }
}
