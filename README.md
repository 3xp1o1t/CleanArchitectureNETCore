# Clean Architecture .NET Core y ASP.Net

Proyecto de ejemplo usando Clean Arch.

## Setup

Definir una version global de .NET para la creación de proyectos y bibliotecas internamente en la solución.

Dentro del directorio de la solución, crear un archivo global.json para bloquear la version de .NET.

```bash
dotnet new globaljson --sdk-version 8.0.101 --force
```

Generar la solución y proyectos

Solución:

```bash
dotnet new sln --name CANetCore
```

Agregar el proyecto de dominio

```bash
dotnet new classlib -o src/CleanArchitecture/CleanArchitecture.Domain
```

Vincular el dominio a la solución

```bash
dotnet sln add src/CleanArchitecture/CleanArchitecture.Domain/CleanArchitecture.Domain.csproj
```

Compilar para verificar si hay errores

```bash
dotnet build
```

## Dominio Vehiculo

Los dominios/negocio deben aplicar el principio solid S
Principio de responsabilidad única, la palabra reservada **Sealed**
en la definición de la clase garantiza que no pueda ser heredado
respetan este principio.

```c#
public sealed class Vehiculo {}
```

## Refactorizar la entidad Vehículo usando DDD

Para que una clase sea considerara una **entidad** en DDD debe cumplir dos reglas.

1. Debe tener una propiedad que la diferencie, por ejemplo un ID.
   1. El ID solo debe de especificarse durante la creación del objeto, después no debe ser modificado
   2. En C# marcar una propiedad como **init** en lugar de **set** realiza dicha función previene de cambios ID.
2. Debe ser continua. (La existencia de este objeto debe estar presente durante toda la vida util de la aplicación)

Algunas propiedades no transmiten significado alguno, por ejemplo en la clase Vehículo
las propiedades que hacen referencia a la dirección (Calle, Departamento) se pueden componer
en una clase o mejor dicho en un Value Object, los values objects se pueden representar
con una clase (Método antiguo) o con un registro Record

La clase **Direccion**.cs demuestra el concepto de un Object Value.

En pocas palabras un Object Value, son valores únicos, véase la clase Modelo.cs

`Cuando un modelo/entidad/dominio utiliza solo propiedades con valores primitivos
se dice que es de tipo **Anemico**, cuando usa Object Values entonces es un modelo **Enriquezido**`

## Instalar un paquete de Nuget desde la terminal

Es posible utilizar también una extension de VSCode llamada Nuget Packages

MediaTR es una librería que proporciona el patron **Mediador** lo que permite la comunicación
entre diferentes componentes sin que estén acoplados directamente entre si, este patron mediador
normalmente se utiliza en arquitecturas **CQRS** (Command Query Responsibility Segregation) y aplicaciones
basadas en eventos

```bash
# Ingresamos al directorio de los dominios donde se usara MediatR
cd /src/CleanArchitecture/CleanArchitecture.Domain
# Instalar el paquete
dotnet add package MediatR.Contracts --version 2.0.1
```
