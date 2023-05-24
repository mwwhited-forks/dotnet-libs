namespace Eliassen.System.ComponentModel.DataAnnotations.SensitivityClassifications
{
    public class ConfidentialBaseAttribute : SensitivityClassificationAttribute
    {
        public ConfidentialBaseAttribute(
            string informationType,
            string informationTypeId,
            SensitivityClassificationRanks rank = SensitivityClassificationRanks.Medium
            )
        {
            Label = "Confidential";
            LabelId = "4232c6db-16cc-4416-8954-1044917bb632";
            InformationType = informationType;
            InformationTypeId = informationTypeId;
            Rank = rank;
        }
    }
}
