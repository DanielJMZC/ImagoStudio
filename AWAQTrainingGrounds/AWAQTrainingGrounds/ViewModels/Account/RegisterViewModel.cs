public class RegisterViewModel
{
    public int birth_day { get; set; }
    public int birth_month { get; set; }
    public int birth_year { get; set; }

    public DateTime? fecha_de_nacimiento {get; set;}

    public int? country_id { get; set; }
    public string telefono { get; set; } = "";
    public string telefono_prefix {get; set;} = "";

    public int? cosmetic_id {get; set;} 
    public int? user_id { get; set; }
}