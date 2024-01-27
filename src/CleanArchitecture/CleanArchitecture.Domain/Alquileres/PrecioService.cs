using System.Security.Cryptography;
using CleanArchitecture.Domain.Vehiculos;

namespace CleanArchitecture.Domain.Alquileres;

public class PrecioService
{
  public PrecioDetalle CalcularPrecio(Vehiculo vehiculo, DateRange periodo)
  {
    var tipoMoneda = vehiculo.Precio!.TipoMoneda;

    var precioPorPeriodo = new Moneda(periodo.CantidadDias * vehiculo.Precio.Monto, tipoMoneda);

    decimal porcentageChange = 0;

    foreach (var accesorio in vehiculo.Accesorios)
    {
      porcentageChange += accesorio switch
      {
        Accesorio.AppleCar or Accesorio.AndroidCar => 0.05m,
        Accesorio.AireAcondicionado => 0.01m,
        Accesorio.Mapas => 0.01m,
        _ => 0
      };
    }

    var accesoriosCharges = Moneda.Zero(tipoMoneda);

    if (porcentageChange > 0)
    {
      accesoriosCharges = new Moneda(precioPorPeriodo.Monto * porcentageChange, tipoMoneda);
    }

    var precioTotal = Moneda.Zero();
    precioTotal += precioPorPeriodo;

    if (!vehiculo!.Mantenimiento!.IsZero())
    {
      precioTotal += vehiculo.Mantenimiento;
    }

    precioTotal += accesoriosCharges;

    return new PrecioDetalle(precioPorPeriodo, vehiculo.Mantenimiento, accesoriosCharges, precioTotal);
  }
}