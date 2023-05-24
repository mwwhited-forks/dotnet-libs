namespace Eliassen.System.ComponentModel.DataAnnotations.SensitivityClassifications
{
    public interface ISensitivityClassification
    {
        string InformationType { get; }
        string InformationTypeId { get; }
        string Label { get; }
        string LabelId { get; }
        SensitivityClassificationRanks Rank { get; }
    }
}