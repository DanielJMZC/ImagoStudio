using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class NPCAdminService : INPCAdminService
{
    private readonly HttpClient _httpClient;

    //private readonly string baseUrl = "http://127.0.0.1:5530/npc/";
    private readonly string baseUrl = "https://10.14.255.43:5530/npc/";

    public NPCAdminService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<DialogoViewModel>> GetDialogosPorNpc(int npcId)
    {
        var response = await _httpClient.GetFromJsonAsync<List<DialogoViewModel>>(
            $"{baseUrl}{npcId}/dialogos"
        );

        return response ?? new List<DialogoViewModel>();
    }

    public async Task<List<PreguntaViewModel>> GetPreguntasPorNpc(int npcId)
    {
        var response = await _httpClient.GetFromJsonAsync<List<PreguntaViewModel>>(
            $"{baseUrl}{npcId}/preguntas"
        );

        return response ?? new List<PreguntaViewModel>();
    }

    public async Task<bool> ReplaceDialogosPorNpc(int npcId, List<DialogoViewModel> dialogos)
    {
        dialogos ??= new List<DialogoViewModel>();

        var payload = dialogos.Select(d => new
        {
            texto = d.Texto
        });

        var content = new StringContent(
            JsonSerializer.Serialize(payload),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PutAsync(
            $"{baseUrl}{npcId}/dialogos",
            content
        );

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> ReplacePreguntasPorNpc(int npcId, List<PreguntaViewModel> preguntas)
    {
        preguntas ??= new List<PreguntaViewModel>();

        var payload = preguntas.Select(p => new
        {
            enunciado = p.Enunciado,
            respuestas = (p.Respuestas ?? new List<RespuestaViewModel>())
                .Select(r => new
                {
                    texto = r.Texto,
                    esCorrecta = r.EsCorrecta
                }).ToList()
        });

        var content = new StringContent(
            JsonSerializer.Serialize(payload),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PutAsync(
            $"{baseUrl}{npcId}/preguntas",
            content
        );

        return response.IsSuccessStatusCode;
    }

    public async Task<NPCAdminViewModel> GetNPCData(int npcId)
    {
        var dialogos = await GetDialogosPorNpc(npcId);

        var preguntas = await GetPreguntasPorNpc(npcId);

        return new NPCAdminViewModel
        {
            NpcId = npcId,
            Dialogos = dialogos,
            Preguntas = preguntas
        };
    }
}