namespace Eliassen.System.ComponentModel.DataAnnotations.SensitivityClassifications
{
    public class ContactInfoAttribute : ConfidentialBaseAttribute
    {
        public ContactInfoAttribute(): base(
            informationType: "Contact Info",
            informationTypeId: "5c503e21-22c6-81fa-620b-f369b8ec38d1"
                )
        {
        }
    }
}
