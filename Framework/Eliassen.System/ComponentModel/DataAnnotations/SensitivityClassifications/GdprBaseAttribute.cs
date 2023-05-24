namespace Eliassen.System.ComponentModel.DataAnnotations.SensitivityClassifications
{
    public class GdprBaseAttribute : SensitivityClassificationAttribute
    {
        public GdprBaseAttribute(
            string informationType,
            string informationTypeId,
            SensitivityClassificationRanks rank = SensitivityClassificationRanks.Medium
            )
        {
            Label = "Confidential - GDPR";
            LabelId = "eb048505-431d-4709-83d7-8f0e4074c035";
            InformationType = informationType;
            InformationTypeId = informationTypeId;
            Rank = rank;
        }
    }
}
