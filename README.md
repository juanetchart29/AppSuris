# Aplicación de Pedidos - .NET Core 8 + React

Este proyecto es una aplicación sencilla desarrollada con .NET Core 8 en el backend y React en el frontend. La aplicación permite gestionar pedidos según vendedores y artículos, los cuales se almacenan en archivos JSON en el proyecto.

## Requisitos

Para levantar la aplicación, es necesario tener instalados los siguientes componentes:

- **Node.js** (última versión recomendada)
- **.NET Core 8 SDK**
- **Visual Studio Community 2019 o 2022** (recomendado para abrir y ejecutar la solución)

## Clonación del Repositorio

Clona este repositorio en tu máquina local:

```bash
git clone <URL_DEL_REPOSITORIO>
```

## Configuración y Ejecución

1. Abre el proyecto clonado con **Visual Studio Community** (versiones 2019 o 2022).
2. Una vez abierto, selecciona la opción **Play** en Visual Studio para compilar el proyecto.
3. Al iniciar la compilación, Visual Studio se encargará de instalar automáticamente las dependencias de Node necesarias para el frontend de React.

## Estructura del Proyecto

### Entidades Principales

La aplicación cuenta con dos entidades principales que se almacenan en archivos JSON en el proyecto: `Producto` y `Vendedor`.

#### Formato de los Datos en JSON

Los datos de productos y vendedores se guardan en archivos JSON dentro del proyecto, con el siguiente formato:

##### Ejemplo de JSON para `Producto`

```json
[
    {
        "codigo": "P001",
        "descripcion": "Producto 1",
        "precio": 100.0,
        "deposito": 10
    },
    {
        "codigo": "P002",
        "descripcion": "Producto 2",
        "precio": 150.0,
        "deposito": 15
    }
]
```

##### Ejemplo de JSON para `Vendedor`

```json
[
    {
        "id": 1,
        "descripcion": "Vendedor 1"
    },
    {
        "id": 2,
        "descripcion": "Vendedor 2"
    }
]
```

### Propiedades de las Entidades

#### Producto

Cada producto cuenta con las siguientes propiedades:

```csharp
public class Producto
{
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; }

    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; }

    [JsonPropertyName("precio")]
    public decimal Precio { get; set; }

    [JsonPropertyName("deposito")]
    public int Deposito { get; set; }
}
```
- **Código**: Código identificador del producto.
- **Descripción**: Descripción detallada del producto.
- **Precio**: Precio del producto.
- **Depósito**: Ubicación o número de depósito del producto.

#### Vendedor

Cada vendedor cuenta con las siguientes propiedades:

```csharp
public class Vendedor
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; }
}
```

- **ID**: Identificador único del vendedor.
- **Descripción**: Descripción detallada del vendedor.

## Uso

La aplicación permite crear, actualizar y gestionar pedidos mediante el frontend en React y el backend en .NET Core. Cada pedido se realiza seleccionando un vendedor y uno o más artículos disponibles.
