# Transferencia.API 

Este proyecto se construyo para la prueba tecnica de PayPhone

---

##  Tecnologia utilizada

- **Framework**: .NET 8
- **Arquitectura**: Clean Architecture (Dominios, Aplicación, Infraestructura, API)
- **Persistencia**: Entity Framework Core
- **Base de datos**: SQL Server
- **Pruebas**: Pruebas unitarias
- **Buenas prácticas**: Principios SOLID y manejo estructurado de errores

---

##  Estructura del Proyecto

- **Transferencia.API**: Capa de presentación (endpoints HTTP).
- **Transferencia.Aplicacion**: Casos de uso y lógica de negocio.
- **Transferencia.Dominio**: Entidades y contratos.
- **Transferencia.Infraestructura**: Acceso a datos y servicios externos.

---

##  Modelo de Datos

###  Billetera
| Campo       | Descripción                              |
|-------------|------------------------------------------|
| `id`        | Identificador único                      |
| `documentId`| Documento de identidad del propietario   |
| `name`      | Nombre del propietario                   |
| `balance`   | Saldo actual                             |
| `createdAt` | Fecha de creación                        |
| `updatedAt` | Fecha de última actualización            |

###  Movimiento
| Campo       | Descripción                              |
|-------------|------------------------------------------|
| `id`        | Identificador único                      |
| `walletId`  | ID de la billetera                       |
| `amount`    | Monto de la transferencia                |
| `type`      | Débito / Crédito                         |
| `createdAt` | Fecha del movimiento                     |

---

##  Validaciones Implementadas

- Monto debe ser mayor que cero.
- Nombre no puede estar vacío.
- No se puede transferir más de lo que hay disponible.
- No se puede transferir a una billetera que no existe.

---

##  Manejo de Errores

- Se implemento con Serilog
---

## Autenticación y Autorización 

- Se implemento un login basico utilizar las siguiente credenciales
usuario: payphone
pass:pyphone2025*

---

##  Pruebas

- Pruebas  Preguntas Clave

### 1. ¿Cómo tu implementación puede ser escalable a miles de transacciones?
Utilizando una arquitectura en capas, desacoplando lógica de negocio y acceso a datos.

### 2. ¿Cómo tu implementación asegura el principio de idempotencia?
Cada transferencia valida la creacion de un documentid  único que es validado antes de realizar la operación de movimiento. Esto evita duplicaciones si se reintenta una misma solicitud.

### 3. ¿Cómo protegerías tus servicios para evitar ataques como DoS, SQL Injection, CSRF?
- **DoS**: Rate Limiting, Timeouts y circuit breakers.
- **SQL Injection**: Uso de parámetros en EF Core
- **CSRF**: Uso de tokens antifalsificación si se expone frontend; en APIs, es menos relevante si solo se permite CORS controlado.

### 4. ¿Cuál sería tu estrategia para migrar un monolito a microservicios?
1. Identificar módulos 
2. Extraerlos como servicios con APIs bien definidas implementado y asegurando monitoreo, trazabilidad y resiliencia desde el principio.

### 5. ¿Qué alternativas a la solución requerida propondrías para una solución escalable?
- Bases de datos como Redis
- Uso de contenedores como Docker + Kubernetes

## Cómo correr el proyecto

1. Clona el repositorio:
```bash
git clone [https://github.com/tuusuario/Transferencia.API.git](https://github.com/manuelchoez/APITransferencia.git)
```

2. Configura tu base de datos en `appsettings.json`.
3. Ejecutar los siguientes scripts en la base de datos :
SQL/1.CrearBDD.sql
SQL/2.CrearTablas.sql 
4. Ejecuta el proyecto:
```bash
dotnet run --project Transferencia.API
```
