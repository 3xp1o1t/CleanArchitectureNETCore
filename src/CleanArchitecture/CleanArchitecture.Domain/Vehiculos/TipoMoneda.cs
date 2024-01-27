namespace CleanArchitecture.Domain.Vehiculos;

public record TipoMoneda
{
  public static readonly TipoMoneda None = new("");
  public static readonly TipoMoneda USD = new("USD");
  public static readonly TipoMoneda MXN = new("MXN");
  public static readonly TipoMoneda EUR = new("EUR");

  private TipoMoneda(string codigo) => Codigo = codigo;

  public string? Codigo { get; init; }

  public static readonly IReadOnlyCollection<TipoMoneda> All = new[]
  {
    USD, MXN, EUR
  };

  public static TipoMoneda FromCodigo(string codigo)
  {
    return All.FirstOrDefault(c => c.Codigo == codigo) ??
      throw new ApplicationException("El tipo de moneda es invalido!");
  }

}