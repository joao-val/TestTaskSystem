using System.ComponentModel;

namespace SistemaDeTarefas_api_basica_.Enums
{
    public enum TasksStatus
    {
        [Description("To do")]
        ToDo = 1,

        [Description("In progress")]
        InProgress = 2,

        [Description("Concluded")]
        Concluded = 3
    }
}