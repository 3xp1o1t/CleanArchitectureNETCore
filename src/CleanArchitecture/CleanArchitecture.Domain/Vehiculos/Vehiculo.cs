using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Vehiculos
{
    public sealed class Vehiculo : Entity
    {
        // base - Take parent(Entity) constructor
        public Vehiculo(Guid Id, Modelo modelo, Vin vin, Moneda precio, Moneda mantenimiento, DateTime? fechaUltimoAlquiler, List<Accesorio> accesorios, Direccion? direccion) : base(Id)
        {
            Modelo = modelo;
            Vin = vin;
            Precio = precio;
            Mantenimiento = mantenimiento;
            FechaUltimoAlquiler = fechaUltimoAlquiler;
            Accesorios = accesorios;
            Direccion = direccion;
        }
        public Modelo? Modelo { get; private set; }
        public Vin? Vin { get; private set; }
        public Direccion? Direccion { get; private set; }
        public Moneda? Precio { get; private set; }
        public Moneda? Mantenimiento { get; private set; }
        public DateTime? FechaUltimoAlquiler { get; private set; }
        public List<Accesorio> Accesorios { get; private set; }

    }
}