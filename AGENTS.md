# Girotronica Game Jam 2026

Este repositorio trabaja en modo **game jam**: primero una experiencia jugable pequena, luego claridad y pulido. La velocidad, el alcance controlado y la simplicidad tienen prioridad sobre una arquitectura preparada para escenarios hipoteticos.

## Estado actual

- Aun no existe un proyecto Unity.
- Todavia no se eligio 2D o 3D.
- No crear `Assets/`, `Packages/`, `ProjectSettings/` ni una estructura de motor hasta que el usuario confirme la direccion.
- Blender, PaintBridge/Krita, Aseprite AI Artist, Unity Relay y Soundbox/Mirli estan declarados en `.codex/config.toml`.

## Reglas de trabajo

1. Leer la solicitud, este archivo y `git status --short` antes de editar.
2. Usar `.agents/skills/game-jam-delivery/SKILL.md` como router principal.
3. Implementar el menor corte vertical que permita jugar, observar o decidir algo.
4. Preferir codigo directo, configuracion local y pocos archivos. Abstraer solo cuando ya hay dos usos reales o un limite que lo exige.
5. No crear OpenSpec, ADR, matrices de arquitectura ni suites de tests por defecto.
6. Solo hacer pruebas cuando el usuario las pida expresamente y dentro del alcance que indique. Esto incluye pruebas manuales o automatizadas, entrar en Play Mode, hacer smoke playtests, lanzar compilaciones o builds de comprobacion y revisar la consola para validar cambios. No agregar tests automatizados sin pedido expreso. Esta regla tambien se aplica a las pruebas sugeridas por skills o delegadas a otros agentes.
7. No decidir 2D/3D, pipeline visual, plataforma, resolucion ni controles que el usuario no haya confirmado.
8. No instalar herramientas, cambiar configuracion global, hacer commit, push, PR o publicacion sin pedido expreso.
9. Preservar cambios del usuario y no tocar archivos ajenos al corte solicitado.
10. Si una decision ausente cambia materialmente el resultado, avanzar con lo independiente y presentar una sola pregunta concreta.

## Agentes locales

Los perfiles viven en `.codex/agents/` y no dependen de agentes remotos:

- `designer`: concepto, loop, alcance y criterios de diversion.
- `dev`: implementacion directa e integracion Unity cuando exista el proyecto.
- `playtester`: smoke playtest y regresion observable, sin editar producto.
- `artist2d`: sprites, pixel art, tiles, animacion y exportacion mediante Aseprite o Krita.
- `modeler`: modelos, retopologia, rigs y animacion mediante Blender.

El agente principal conserva el alcance y combina entregas. Los perfiles especializados no delegan, no publican y no amplian el trabajo por iniciativa propia.

## Enrutamiento de herramientas

- Unity Relay: solo cuando exista un proyecto Unity y una tarea de motor.
- Aseprite AI Artist: pixel art, sprites, tilesets y animaciones por frames.
- PaintBridge/Krita: ilustracion raster, paintovers, concept art y texturas pintadas.
- Blender: modelado, UV, materiales, retopologia, rigging y animacion 3D.
- Soundbox/Mirli: SFX o musica cuando el encargo los pida; la integracion en el juego pertenece a `dev`.

Una herramienta no autoriza a crear assets o cambiar escenas fuera del pedido. Si no esta disponible, informar el bloqueo y continuar con preparacion local que siga siendo util.

## Definicion de terminado para la jam

- El resultado solicitado existe y se puede observar.
- Si el usuario pidio pruebas, informar cuales se realizaron y su resultado. Se puede cerrar una implementacion sin ejecutar pruebas.
- Los assets tienen formato, escala, nombres y destino claros.
- Se informan limitaciones reales; no se agregan tareas preventivas.

