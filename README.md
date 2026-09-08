# 🎮 Seller Game

![Godot Engine](https://img.shields.io/badge/GODOT_4-%23478CBF.svg?style=for-the-badge&logo=godot-engine&logoColor=white)
![C#](https://img.shields.io/badge/C%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)

Este repositorio contiene el taller práctico desarrollado para la asignatura de **Paradigmas de Programación**. El proyecto es un videojuego 2D diseñado para aplicar de forma práctica los conceptos de programación orientada a objetos, utilizando Godot Engine y C#.

---

## ✨ Características Principales

*   **Arquitectura de Nodos:** Jerarquía estructurada siguiendo las mejores prácticas del motor.
*   **Lógica en C#:** Implementación de scripts robustos y tipados para el control de entidades y físicas.
*   **Mecánicas 2D:** [Ejemplo: Movimiento en 8 direcciones, sistema de colisiones y animaciones dinámicas con Sprites].
*   **Gestión Visual:** [Ejemplo: Ordenamiento de profundidad (Z-Index/Y-Sort) para una correcta visualización].

## 🛠️ Requisitos Previos

Para clonar y ejecutar este proyecto en tu máquina local, necesitas tener instalado:

*   [Godot Engine](https://godotengine.org/download/) (Versión 4.x con soporte para .NET/C#).
*   [.NET SDK](https://dotnet.microsoft.com/download) (Requerido para compilar y ejecutar los scripts en C#).

## 🚀 Instalación y Ejecución

1. **Clonar el repositorio:**
   ```bash
   git clone [https://github.com/tu-usuario/nombre-del-repo.git](https://github.com/tu-usuario/nombre-del-repo.git)

## 🚀 Arquitectura y Características Implementadas

### 1. Jerarquía de NPCs y Eliminación de Duplicación
- Se creó una clase base abstracta/general denominada `NPC` que hereda de `StaticBody2D`. Esta clase unifica la lógica común de los personajes (como la gestión del componente visual `AnimatedSprite2D`).
- Las clases concretas (`Lancer`, `Monk`, `Goblin`) heredan de `NPC`, eliminando la duplicación de código.

   ```bash
    public partial class NPC : StaticBody2D
   {
       private AnimatedSprite2D _animator;
       public string NameNpc { get; set; }
       public override void _Ready()
       {
           _animator = GetNode<AnimatedSprite2D>("Animator");
           _animator.Play("default");
       }
   }

### 2. Interfaces (`IBuyer` y `IThief`)
- Se implementaron las interfaces `IBuyer` (para personajes que compran madera y entregan monedas) y `IThief` (para personajes que hurtan recursos).
- Esto permite aplicar polimorfismo puro en el personaje principal (`Seller`), evitando el uso de condicionales rígidos o chequeos de tipos concretos al momento de interactuar en el mundo del juego.
  
   ```bash
   public interface IThief
   {
       public int StealAmount { get; set; }
       public void Steal(Seller seller)
       {
           if (seller.WoodCounts <= 0) return;
           seller.DiscountWood(StealAmount);
       }
   }
   
   public interface IBuyer
   {
       public int Price { get; set; }
   
       public void Buy(Seller seller)
       {
           if (seller.WoodCounts <= 0) return;
   
           seller.DiscountWood();
           seller.IncreaseCoin(Price);
       }

}
### 3. Lógica de Transacciones e Historial
- Se estructuró un modelo orientado a objetos para el historial financiero y de inventario mediante una clase base `Transaction`, de la cual extienden `Sale` (Ventas) y `Theft` (Robos).

   ```bash
  public class Transaction //historial
   {
    public string NameNpc { get; set; }
    public int TotalCounts { get; set; }

    public Transaction(string nameNpc, int totalCounts)
    { 
      NameNpc = nameNpc;
      TotalCounts = totalCounts;
    }
   }
   
   public class Sale : Transaction
   {
       public Sale(string nameNpc, int totalCounts) : base(nameNpc,totalCounts)
       {
       }
   }
   
   public class Theft : Transaction
   {
       public Theft(string nameNpc, int totalCounts) : base(nameNpc, totalCounts)
       {
       }
   }
  
- El jugador puede presionar la tecla asignada (`Z` / `show_resume`) para desplegar en la consola el resumen consolidado de las interacciones acumuladas con cada NPC.
  
    ```bash
   Npc: Goblin -> Maderas robadas: 1
   Npc: Lancer -> Dinero obtenido: 5
   Npc: Monk -> Dinero obtenido: 2

### 4. Actualización Dinámica de Animaciones
- El sistema evalúa el estado actual del inventario de recursos (`WoodCounts`) del vendedor para alternar de forma automática entre los sets de animaciones correspondientes (por ejemplo, transportar madera vs. inventario vacío).
<p align="center">
   <img width="250" height="225" alt="image" src="https://github.com/user-attachments/assets/9026405a-7653-4417-9bc9-7cf1295488f0" />
   <img width="250" height="225" alt="image" src="https://github.com/user-attachments/assets/b57c5756-c55c-4f01-9276-2fd7aafcb08c" />
</p>

## Implementación de un mapa
<p align="center">
      <img width="983" height="554" alt="image" src="https://github.com/user-attachments/assets/2989226d-c92d-46d1-9bd8-5c04b5197ff9" />
</p>

## Diagrama de clases
<p align="center">
  <a href="https://drive.google.com/file/d/1KUpO1qq8OZ3jrjsQtRzGhx5KqHjVpNFN/view">
    <img width="1146" height="551" alt="image" src="https://github.com/user-attachments/assets/737dcd4f-3f4c-4e85-b297-46876a56f32d" />
  </a>
</p>

