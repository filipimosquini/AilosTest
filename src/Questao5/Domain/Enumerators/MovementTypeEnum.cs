using System.ComponentModel;

namespace Questao5.Domain.Enumerators;

public enum MovementTypeEnum
{
    [Description("Credit")]
    C = 'C',
    [Description("Debit")]
    D = 'D'
}