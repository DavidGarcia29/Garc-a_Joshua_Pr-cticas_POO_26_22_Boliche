🎥 Cómo aplicar el script de seguimiento a la cámara

Selecciona la cámara principal

En el Hierarchy busca el objeto Main Camera.

Si no existe, crea una nueva:
GameObject → Camera y renómbrala como Main Camera.

Agrega el script CameraFollow

En el Inspector haz clic en Add Component.

Busca CameraFollow (el que guardaste en Assets/Tarea_camara_bola/Scripts/).

Haz clic para agregarlo.

Asigna el objetivo (Target)

Arrastra el objeto Bola desde la jerarquía al campo Target del script.

Así la cámara sabrá a qué seguir.

Configura los valores recomendados

offset → (0, 5, -8)

smoothTime → 0.2

lookAheadFactor → 0.5

maxLookAhead → 3

collisionRadius → 0.3

collisionBuffer → 0.6

collisionLayers → Everything (o la capa donde estén tus muros/pista)

Guarda la escena y prueba el juego

Asegúrate de que la bola tenga el script ControlBola.cs y un Rigidbody.

Usa las teclas ← y → para moverla antes del lanzamiento.

Presiona Espacio para lanzarla y ver cómo la cámara la sigue suavemente.


README 

# 🎳 Proyecto Unity - Tareas_POO_26_1

Este proyecto contiene una práctica de Programación Orientada a Objetos en Unity 3D: **control y cámara de seguimiento para un juego de boliche**.

## 📂 Estructura principal
- `Assets/Tarea_camara_bola/Scripts/` → Scripts C# (`ControlBola.cs`, `CameraFollow.cs`)
- `Assets/Tarea_camara_bola/Scenes/` → Instrucciones para montar la escena
- `Assets/Tarea_camara_bola/Prefabs/` → Instrucciones para crear el prefab de la bola
- `Assets/Tarea_camara_bola/Documentation/` → Guía paso a paso

## ⚙️ Cómo usar
1. Clona o abre el repositorio `Tareas_POO_26_1` en Unity 2021.3 LTS o superior.
2. Sigue las instrucciones del archivo `Assets/Tarea_camara_bola/Documentation/IMPLEMENTATION_GUIDE.md`.
3. Ejecuta la escena `BowlingScene` creada manualmente según `BowlingScene_instructions.txt`.

## 🎮 Scripts incluidos
- **ControlBola.cs**: controla el movimiento lateral y lanzamiento de la bola.
- **CameraFollow.cs**: sigue la bola con suavidad y detección de colisión para evitar atravesar objetos.

Autor: *TJoshua David García Munguía]*  
Versión: 1.0  
Lenguaje: C#  
Motor: Unity 3D  
