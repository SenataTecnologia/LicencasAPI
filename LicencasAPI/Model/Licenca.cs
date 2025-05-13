namespace LicensasApi.Models;

public class Licenca
{
    public int Id { get; set; }
    public string CNPJ { get; set; }
    public string Empresa { get; set; }
    public bool Ativa { get; set; }
    public DateTime DataExpiracao { get; set; }
}