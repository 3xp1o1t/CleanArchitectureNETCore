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

dotnet new sln --name CANetCore

Agregar el proyecto de dominio

dotnet new classlib -o src/CleanArchitecture/CleanArchitecture.Domain

Vincular el dominio a la solución

dotnet sln add src/CleanArchitecture/CleanArchitecture.Domain/CleanArchitecture.Domain.csproj
