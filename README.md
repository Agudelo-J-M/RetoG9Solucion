# 🧩 Reto Técnico – Extensión de Checkout (Arquitectura con DIP)

## 📌 Contexto

El proyecto base implementa un sistema de **Checkout de E-commerce en consola** desarrollado en **.NET 9**, siguiendo principios de arquitectura como:

* **Dependency Inversion Principle (DIP)**
* **Low Coupling (GRASP)**
* **Separación por capas (Domain / Application / Infrastructure)**

Actualmente el sistema realiza el siguiente flujo:

1. Validar stock
2. Procesar pago
3. Generar factura
4. Enviar confirmación
5. Guardar la orden

La lógica principal se encuentra en `CheckoutService`, el cual depende **únicamente de interfaces**, permitiendo desacoplar la lógica de negocio de las implementaciones concretas.

---

# 🎯 Objetivo del Reto

Extender el sistema de Checkout agregando **nuevas capacidades sin modificar la lógica principal de negocio (`CheckoutService`)**, respetando el principio de **Inversión de Dependencias (DIP)**.

El objetivo es demostrar que el diseño actual permite **extensibilidad sin acoplamiento**.

---

# 📋 Requerimientos del Reto

Implementar **dos nuevas funcionalidades** en el sistema:

---

## 1️⃣ Nuevo método de pago

Agregar un nuevo método de pago llamado:

```
PayPal
```

Debe cumplir con la interfaz existente:

```
IPaymentService
```

La lógica puede ser simple, por ejemplo:

* Simular autenticación con PayPal
* Aprobar pagos menores a cierto valor
* Rechazar pagos mayores a cierto monto

**Importante**

No se debe modificar:

```
CheckoutService
```

---

## 2️⃣ Nuevo servicio de notificación

Agregar un nuevo servicio de notificación:

```
SMSNotificationService
```

Debe implementar la interfaz:

```
IEmailService
```

Simular el envío de un mensaje SMS al cliente indicando que la orden fue confirmada.

Ejemplo de salida esperada:

```
Enviando SMS al cliente...
SMS enviado al número registrado.
```

---

# ⚠️ Restricciones

Para cumplir correctamente el reto:

* ❌ No modificar `CheckoutService`
* ❌ No eliminar interfaces existentes
* ❌ No acoplar el código a clases concretas

Debe mantenerse el diseño basado en **abstracciones**.


---

# 📝 Implementación de las Nuevas Clases Concretas

## PayPalPaymentService

La clase `PayPalPaymentService` implementa la interfaz `IPaymentService` y simula el procesamiento de pagos a través de PayPal. Se encuentra en el directorio `Infrastructure`.

### Funcionalidad
- Simula la autenticación con PayPal con una demora de 1 segundo.
- Aprueba pagos menores o iguales a $10000.
- Rechaza pagos mayores a $10000 para simular límites de transacción.

### Código Principal
```csharp
public class PayPalPaymentService : IPaymentService
{
    private const decimal MaxApprovedAmount = 10000;

    public bool ProcessPayment(Order order)
    {
        Console.WriteLine("Simulando Autenticación de PayPal...");
        Thread.Sleep(1000);
        Console.WriteLine("Autenticación de PayPal exitosa.");

        if (order.TotalOrden <= MaxApprovedAmount)
        {
            Console.WriteLine($"Pago de {order.TotalOrden:c} aprobado via PayPal.");
            return true;
        }
        else
        {
            Console.WriteLine($"Pago de {order.TotalOrden:c} rechazado via PayPal (excede el límite).");
            return false;
        }
    }
}
```

## SMSNotificationService

La clase `SMSNotificationService` implementa la interfaz `IEmailService` y simula el envío de notificaciones por SMS. Se encuentra en el directorio `Infrastructure`.

### Funcionalidad
- Envía un mensaje SMS al cliente confirmando la orden con una demora de 0.5 segundos.
- Utiliza el campo `EmailCliente` de la orden como número de teléfono.

### Código Principal
```csharp
public class SMSNotificationService : IEmailService
{
    public void SendConfirmation(Order order)
    {
        Console.WriteLine("Enviando SMS al cliente...");
        Thread.Sleep(500);
        Console.WriteLine($"SMS enviado al número {order.EmailCliente} con éxito.");
    }
}
```

---

# 🔄 Lógica de Llamado en Program.cs

Toda la lógica de selección de servicios se implementa en `Program.cs` sin modificar otras clases, respetando el principio de Inversión de Dependencias.

## Selección del Servicio de Pago

```csharp
// Determine which payment service to use
IPaymentService selectedPaymentService = medioPago.ToLower() == "paypal" ? payPalPaymentService : paymentService;
```

- Si `medioPago` es igual a "paypal" (ignorando mayúsculas/minúsculas), se utiliza `PayPalPaymentService`.
- De lo contrario, se utiliza el servicio de pago por defecto (`PaymentService`).

## Selección del Servicio de Notificación

```csharp
// Determine which notification service to use
IEmailService selectedEmailService = email.Contains("@") ? emailService : smsNotificationService;
```

- Si el campo `email` contiene el carácter "@", se asume que es una dirección de correo electrónico y se utiliza `EmailService`.
- Si no contiene "@", se asume que es un número de teléfono y se utiliza `SMSNotificationService`.

## Inyección de Dependencias

Los servicios seleccionados se pasan al constructor de `CheckoutService`:

```csharp
var checkout = new CheckoutService(
    stockService,
    selectedPaymentService,
    invoiceService,
    selectedEmailService,
    orderRepository);
```

Esto permite que `CheckoutService` siga dependiendo únicamente de interfaces, manteniendo el desacoplamiento y la extensibilidad del sistema.

---

# 🏗 Estructura Esperada del Proyecto

```
Ecommerce.Checkout
│
├── Domain
│     └── Order.cs
│
├── Application
│     ├── Interfaces
│     │     ├── IStockService.cs
│     │     ├── IPaymentService.cs
│     │     ├── IInvoiceService.cs
│     │     ├── IEmailService.cs
│     │     └── IOrderRepository.cs
│     │
│     └── CheckoutService.cs
│
├── Infrastructure
│     ├── StockService.cs
│     ├── PaymentService.cs
│     ├── InvoiceService.cs
│     ├── EmailService.cs
│     ├── OrderRepository.cs
│     ├── PayPalPaymentService.cs
│     └── SMSNotificationService.cs
│
└── Program.cs
```

---

# ▶️ Cómo Ejecutar el Proyecto

## 1️⃣ Requisitos

Instalar:

* **.NET SDK 9.0**

Verificar instalación:

```bash
dotnet --version
```

Debe mostrar una versión compatible con **9.0**.

---

## 2️⃣ Clonar el repositorio

```bash
git clone https://github.com/usuario/repositorio.git
```

Entrar al proyecto:

```bash
cd repositorio
```

---

## 3️⃣ Restaurar dependencias

```bash
dotnet restore
```

---

## 4️⃣ Compilar el proyecto

```bash
dotnet build
```

---

# 🧾 Archivo de Proyecto (.csproj)

El proyecto está configurado con:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    
  </PropertyGroup>

</Project>
```

---

# 📚 Conceptos Arquitectónicos Evaluados

Este reto evalúa la correcta aplicación de:

* Dependency Inversion Principle (DIP)
* Bajo acoplamiento (Low Coupling)
* Diseño orientado a interfaces
* Extensibilidad del sistema
* Separación de responsabilidades

---

# 🏁 Resultado Esperado

El sistema debe permitir agregar nuevas implementaciones de servicios sin modificar la lógica central de Checkout.

Esto demuestra que la arquitectura diseñada es **flexible, mantenible y extensible**.
