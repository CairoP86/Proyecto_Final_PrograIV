# 📌 Sistema de Tickets de Soporte TI


Sistema de tickets de soporte técnico desarrollado como una aplicación de escritorio en **C# (Windows Forms)** con **SQL Server**, orientado a la gestión de incidencias de TI dentro de una organización.

Este proyecto fue desarrollado inicialmente como trabajo académico y posteriormente mejorado para que pueda ser utilizado como un sistema funcional y demostrativo.

---

## 🎯 Funcionalidades principales

- 🔐 **Inicio de sesión con roles**
  - Administrador
  - Técnico
  - Usuario (Empleado)

- 📝 **Gestión de tickets**
  - Crear tickets de soporte
  - Asignar tickets a técnicos
  - Cambiar estado del ticket (Pendiente, En proceso, Resuelto)
  - Agregar observaciones y seguimiento

- 👥 **Gestión de usuarios**
  - Registro de empleados y técnicos
  - Asociación de usuarios a departamentos

- 📊 **Reportes básicos**
  - Tickets por estado
  - Tickets por técnico
  - Historial de atención
  - El sistema registra auditoría de acciones críticas como el reseteo de contraseñas, permitidas únicamente a usuarios con rol TI.

- 🖥 **Interfaz gráfica amigable**
  - Aplicación Windows Forms
  - Flujo de uso simple y claro

---

## 🧠 Flujo básico del sistema

1. El **usuario** inicia sesión y crea un ticket de soporte.
2. El ticket queda en estado **Pendiente**.
3. El **técnico** inicia sesión y toma el ticket → estado **En proceso**.
4. El técnico registra la solución.
5. El ticket se marca como **Resuelto**.
6. El **administrador** puede consultar reportes y supervisar el estado general.

---

## 🛠 Tecnologías utilizadas

- Lenguaje: **C#**
- Plataforma: **.NET Framework**
- Interfaz gráfica: **Windows Forms**
- Base de datos: **SQL Server**
- IDE: **Visual Studio**

---

## 📋 Requisitos

Antes de ejecutar el sistema, asegúrese de tener instalado:

- Windows 10 o superior
- Visual Studio 2019 o superior
- .NET Framework
- SQL Server (Express o LocalDB)
- SQL Server Management Studio (SSMS)

---

## ⚙️ Instalación y configuración

### 1️⃣ Clonar el repositorio
```bash
git clone https://github.com/CairoP86/Proyecto_Final_PrograIV.git


## 👨‍💻 Autores

- **Cairo Pérez** – Ingeniería en Sistemas  
- **Kevin Quirós Hidalgo** – Ingeniería en Sistemas  
- **Kevin Morera Mairena** – Ingeniería en Sistemas  


