public interface IUsuariosService
{
    Task<UsuariosResponseViewModel> GetUsuarios(int page, int pageSize, string search);
    Task<EstadisticasViewModel> GetEstadisticas();
}