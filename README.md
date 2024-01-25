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
