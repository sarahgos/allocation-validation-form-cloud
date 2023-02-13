using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationsForm
{
    /// <summary>
    /// A class to hold all the constants used in the program.
    /// </summary>
    public static class Constants
    {
        public static string EqualSign => "=";
        public static string Comma => ",";
        public static int FirstValue => 0;
        public static int SecondValue => 1;
        public static int ThirdValue => 2;
        public static string DefaultLogfile => "DEFAULT-LOGFILE=";
        public static string LimitsTasks => "LIMITS-TASKS=";
        public static string LimitsProcessors => "LIMITS-PROCESSORS=";
        public static string LimitsProcessorFrequencies => "LIMITS-PROCESSOR-FREQUENCIES=";
        public static string LimitsRam => "LIMITS-RAM=";
        public static string ProgramData => "PROGRAM-DATA=";
        public static string ReferenceFrequency => "REFERENCE-FREQUENCY=";
        public static string TaskRuntimeRam => "TASK-RUNTIME-RAM=";
        public static string ProcessorsFrequencyRam => "PROCESSORS-FREQUENCIES-RAM=";
        public static string ProcessorsCoefficients => "PROCESSORS-COEFFICIENTS=";
        public static string LocalCommunication => "LOCAL-COMMUNICATION";
        public static string RemoteCommunication => "REMOTE-COMMUNICATION";
        public static string SemiColon => ";";
        public static string ZeroString => "0";
        public static string ValidityTrue => "valid";
        public static string ValidityFalse => "invalid";
        public static string InvalidProcessorTypeError => "In PROCESSORS-FREQUENCIES-RAM processor type is not unique.";
        public static string InvalidProcessorCoefficientTypeError => "In PROCESSORS-COEFFICIENTS processor types do not match PROCESSORS-FREQUENCIES-RAM processor types.";
        public static string TwoBackwardSlash => "\\";
        public static string EndOfRamLine => " GB\n";
        public static string CarriageReturnUnicode => "\r\n";
        public static string NewLineUnicode => "\n";
        public static string InvalidKeyword => " : Invalid keyword";
        public static string FullStop => ".";
        public static string OneString => "1";
        public static string AllocationId => "ALLOCATION-ID=";
        public static string AllocationData => "ALLOCATIONS-DATA=";
        public static char EqualsChar => '=';
        public static char QuotationChar => '"';
        public static string ConfigFile => "CONFIG-FILE";
        public static string IsInvalidString => "is invalid";
        public static string IsValidString => "is valid";
        public static string AllocationsError => "ALLOCATION ERRORS";
        public static string NoAllocationErrors => "There are no errors in Allocations.";
        public static string ClosingBracket => ")";
        public static string ForwardSlash => "/";
        public static string FileErrorsString => "FILE ERRORS";
        public static string TaffString => "TAFF ";
        public static string CffString => "CFF ";
    }
}
