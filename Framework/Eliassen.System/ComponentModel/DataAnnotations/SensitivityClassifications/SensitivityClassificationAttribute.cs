using System;
using System.Diagnostics;

namespace Eliassen.System.ComponentModel.DataAnnotations.SensitivityClassifications
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/sql/t-sql/statements/add-sensitivity-classification-transact-sql?view=sql-server-ver15
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    [DebuggerDisplay("{Label}::{InformationType} (Rank)")]
    public class SensitivityClassificationAttribute : Attribute, ISensitivityClassification
    {
        /// <summary>
        /// Is the human readable name of the sensitivity label. Sensitivity labels represent the sensitivity of the data stored in the database column.
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// Is an identifier associated with the sensitivity label. This is often used by centralized information protection platforms to uniquely identify labels in the system.
        /// </summary>
        public string LabelId { get; set; }
        /// <summary>
        /// Is an identifier associated with the sensitivity label. This is often used by centralized information protection platforms to uniquely identify labels in the system.
        /// </summary>
        public string InformationType { get; set; }
        /// <summary>
        /// Is an identifier associated with the information type. This is often used by centralized information protection platforms to uniquely identify information types in the system.
        /// </summary>
        public string InformationTypeId { get; set; }
        /// <summary>
        /// Is an identifier based on a predefined set of values which define sensitivity rank. Used by other services like Advanced Threat Protection to detect anomalies based on their rank.
        /// </summary>
        public SensitivityClassificationRanks Rank { get; set; }
    }
}
