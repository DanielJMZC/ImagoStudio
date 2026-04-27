public class Users
{
    public int? user_id {get; set;}
    public int? country_id {get; set;} 
    public int? city_id {get; set;}
    public int? career_id {get; set;}
    public string nombre {get; set;} = "";
    public string apellido {get; set;} = "";
    public string telefono {get; set;} = "";
    public string encrypted_password {get; set;} = "";
    public string correo {get; set;} = "";

    //CountryName
    public string name {get; set;} = "";

     public DateTime? fecha_de_nacimiento {get; set;}
}