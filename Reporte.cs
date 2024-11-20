using SQLite;

public class Report
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string UserEmail { get; set; } = string.Empty;
    public string ProblemType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Municipio { get; set; } = string.Empty;
    public string Colonia { get; set; } = string.Empty;
    public string Calle { get; set; } = string.Empty;
    public string Status { get; set; } = "Pendiente";
}