using System.Collections.Generic;
using System.Threading.Tasks;

public interface INPCAdminService
{
    Task<List<DialogoViewModel>> GetDialogosPorNpc(int npcId);

    Task<List<PreguntaViewModel>> GetPreguntasPorNpc(int npcId);

    Task<bool> ReplaceDialogosPorNpc(int npcId, List<DialogoViewModel> dialogos);

    Task<bool> ReplacePreguntasPorNpc(int npcId, List<PreguntaViewModel> preguntas);

    Task<NPCAdminViewModel> GetNPCData(int npcId);
}