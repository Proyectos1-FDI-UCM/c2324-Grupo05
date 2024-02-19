# Game design document

## Género

Action-adventure, Puzzle.

**Referencias:** Undertale, OneShot, Deltarune.

## Sinopsis: 

>[!NOTE] 
>Este parte de GDD proporciona una visión general concisa del entorno, permitiendo a cualquier lector comprender qué imaginar mientras se mencionan términos específicos en el texto. Por ejemplo, si especificamos que el entorno del juego es un mundo de fantasía medieval, el lector entenderá que cuando se mencione "armas", se refiere a espadas o ballestas, y no a armas láser futuristas.

El escenario del juego EG6 es un mundo sombrío de un vertedero en una isla ártica, lleno de contaminación y restos de tecnología. El jugador y su compañero robótico pingüino exploran este paisaje devastado, recolectando piezas y resolviendo acertijos para encontrar una ruta hacia la salvación. El tiempo parece detenido aquí, y la naturaleza ha casi desaparecido debido al terrible impacto de la contaminación.


## Controles

>[!NOTE] 
>En secciones posteriores del documento, para asociar una acción específica con un botón, debe especificar el nombre de ese botón entre corchetes triangulares.
> Ejemplo: *Para adjuntar una nueva pieza al pingüino, el jugador debe hacer clic en `<Interactuar>` en su habitación, al lado del huevo*.
> 
> Si necesitamos cambiar un botón que será responsable de alguna acción, bastará con cambiarlo en la tabla y no tocar todos los demás lugares en los que se menciona.

| Botón  | Nombre  |
|---|---|
|W |arriba|
|A |izquierda|
|S |abajo|
|D |derecha|
|E/Space |interactuar|
|LMB |disparar|
|i|inventario|
|Esc |guardar/ ajustes|
## Estilo

>[!NOTE] 
>El estilo se entiende en el sentido más amplio. Aquí podemos agregar cualquier arte conceptual y referencias. Escriba los detalles de cómo debería sentirse el juego, qué emociones debería evocar en el jugador.
>Desde el punto de vista del juego, en esta sección debes describir cómo funciona el juego sin tocar detalles. Por ejemplo, cómo está estructurado el mundo del juego, si está dividido en niveles o es un "mundo abierto", como se produce el movimiento entre ubicaciones. ¿El personaje sólo puede caminar? ¿O volar? ¿O conducir un vehículo? ¿Podrá recoger algo en su inventario? ¿Mover cosas? ¿Luchar? ¿Usar magia?, etc...
>Esta sección es como un avance (trailer) del juego en forma de texto, donde describimos las capacidades del jugador. Después de leer toda la sección, el lector deberá entender de qué se tratará el juego, pero sin entrar en detalles.

El juego está realizado en pixel art 2D, con una posición de la cámara Top-Down.
El mundo del juego está dividido en niveles, cada nivel tiene un conjunto específico de pantallas, cada pantalla está hecha de tiles.
Hay un "hub" en forma de habitación de un personaje, al que llega después de completar un nivel para prepararse para el siguiente.
El personaje puede recolectar elementos y ponerlos en el inventario. Así, además de piezas para el robot pingüino, puede poner consumibles en su inventario y utilizarlos a medida que avanza de nivel.

El juego debe sentirse principalmente como un puzzle, el entorno debe motivar al jugador a abandonar la isla y debe causar rechazo por la apariencia de un entorno lleno de basura. Al mismo tiempo, la apariencia de la habitación del personaje debería motivarlo a regresar allí, crear una sensación de seguridad (como bonefire en la serie de juegos Dark Souls o el ascensor al final del nivel en la serie Portal).

Durante el paso de niveles, el personaje principal puede interactuar con los objetos, pero tendrá desventajas en forma de restricciones de movimiento. El puede romper algunos tiles que le impide pasar, pero esto no se aplicable a todos los obstáculos.
El pingüino, por el contrario, tiene menos opciones para interactuar con el entorno, pero más opciones de movimiento (puede nadar donde el jugador no puede, iluminar el camino en un lugar oscuro, etc.)

La tarea del jugador es resolver tareas cambiando entre personajes y usando su conjunto único de habilidades (casi como los niveles de [It Takes Two](https://www.youtube.com/watch?v=GAWHzGNcTEw&ab_channel=ElectronicArts), pero bajo el control de un jugador).

## Dinámicas

>[!NOTE] 
> Dentro del **MDA framework**, "dinámica" se refiere a la forma en que los jugadores interactúan con las mecánicas del juego mientras juegan. La dinámica se define como cómo las mecánicas del juego conducen a cambios y evolución de la experiencia del juego a lo largo del tiempo. En otras palabras, la dinámica es el resultado de la interacción del jugador con las mecánicas y los cambios posteriores en el juego.
> 
> En el contexto del **MDA framework**, podemos decir que la dinámica es un nivel más alto de abstracción en comparación con la mecánica. La mecánica determina qué acciones están disponibles para el jugador y la dinámica describe cómo estas acciones afectan el curso del juego, qué consecuencias tienen, cómo se desarrolla la experiencia del juego y qué reacciones emocionales se evocan en el jugador.
> 
> Así, podemos decir que la dinámica no es simplemente un sistema de mecánicas, sino el resultado de su interacción durante el transcurso del juego.

El jugador sale de la habitación del personaje en busca de una pieza para mejorar el robot pingüino, pasa por niveles cada vez más difíciles utilizando nuevas mecánicas, regresa a la habitación para mejorar a su compañero para poder superar obstáculos más difíciles y escapar de la isla.

Si el jugador completa la actividad opcional de recolectar y reciclar basura, que no impide su progreso, recibirá un final más positivo o un huevo de Pascua escondido al final.

## Sistemas y Mecánicas

>[!NOTE] 
> En esta sección debemos escribir todo lo relacionado con la lógica del juego. No hace falta profundizar en los parámetros de cuánto dura en segundos o cuánto daño causa. Aquí debemos describir el principio de funcionamiento de TODO lo que sucede dentro del juego.
> 
> En términos de construir la estructura del documento, vale la pena comenzar con los sistemas y luego pasar a las mecánicas.


>[!TIP] 
>
>Estoy seguro de que en España, como en muchos otros países, en el colegio/escuela te enseñan a escribir composiciones o ensayos, intentando cometer un mínimo de errores léxicos y estilísticos (por ejemplo, tautologías).
>
>Pero la documentación no es una obra de arte, aquí se fomenta romper las reglas de redacción de composiciones para evitar la grafomanía
>
>**Ejemplo:** 
>*`Cuando un personaje activa la habilidad de "Curación", el personaje recibe el buff de "Curación", que cura al personaje y restaura N unidades de salud.`*
>
>Esto puede sonar terrible desde un punto de vista estilístico, pero para fines de documentación, este es un párrafo muy bueno que se puede traducir fácilmente a [codigo](https://raw.githubusercontent.com/Proyectos1-FDI-UCM/c2324-Grupo05/main/docs/Media/code_example.png).


### Sistemas

>[!NOTE] 
>
>**El sistema** es una regla global que siempre funciona. Por ejemplo, un sistema de movimiento, un sistema para interactuar con objetos (el personaje SIEMPRE debe acercarse al objeto y hacer clic en el botón de interacción), un sistema de selección de nivel (el jugador hace clic en el ícono de nivel, se resalta en color, después de lo cual el botón "Confirmar" vuelve a estar disponible y el jugador se transfiere a una escena con el nivel apropiado), etc.

#### Sistema de acompañante
Incluye la lógica de funciones que están asociadas a la interacción (personaje - acompañante). Habilita la mecánica de movimiento del pingüino cuando no está bajo el control del jugador (y está controlado por IA). Incluye mecánicas para cambiar entre el personaje principal y el pingüino, etc...
Todas estas mecánicas forman un sistema.

#### Sistema de movimiento
Incluye dos secciones: el movimiento del personaje principal y el movimiento del pingüino.
Se diferencian en la naturaleza y la velocidad del movimiento, así como en los "modos". Por ejemplo, el pingüino tiene un modo separado que le permite nadar. 

>[!TIP] 
> Durante un modo separado, la naturaleza del movimiento cambia, pero la lógica básica permanece sin cambios (lo que significa que no comienza a moverse como en un juego de plataformas o de ritmo, por lo que podemos usar la [herencia](https://www.w3schools.com/cs/cs_inheritance.php) de manera segura para implementar este sistema).

#### Sistema de la cámara
La lógica de la cámara incluye pantallas divididas, así como posibles funciones de la cámara, como hacer zoom en los personajes para mostrar una escena escrita, funciones para representar lugares oscuros, etc.

#### Sistema de interacciones
Incluye la lógica por la cual ocurren todas las interacciones en el juego (independientemente del tipo de interacción, como recolectar un objeto, hablar con un NPC, mejorar un pingüino, romper una ficha). 

>[!TIP] 
>Cuando un jugador entra al área de efecto de un objeto, tiene la oportunidad de interactuar con él presionando el botón `<interactuar>`. Pero para evitar conflictos, cuando el jugador está parado al lado de dos objetos y entra en la zona de interacción de ambos, el objeto del jugador dispara rayos (RayCast) en la dirección en la que mira, y si entran en contacto con el objeto, el objeto se resalta y te permite realizar una determinada acción.
>
>U otro ejemplo
>
>El jugador puede usar el cursor para seleccionar un objeto que se encuentre dentro de la zona de interacción del jugador (como en [Terraria](https://static.wikia.nocookie.net/terraria_gamepedia/images/b/b9/Pylon_Demonstration_spoiler.gif/revision/latest/scale-to-width-down/277?cb=20200501192936))

#### Sistema de niveles
Incluye la lógica por la cual se debe reiniciar y cargar el nivel.
Por ejemplo, ¿se guardan los coleccionables repartidos por el nivel si ya los hemos recogido?
¿Qué bloques se restauran al reiniciar y cuáles no?
¿Cómo se produce la transición de un nivel a otro? ¿Qué datos del nivel anterior se restablecen y cuáles se conservan?

### Mecánicas

>[!NOTE] 
> 
> **La mecánica** es una acción separada, una pieza a partir de la cual se forman los sistemas. Por ejemplo, el sistema de movimiento tiene una mecánica "correr" y una mecánica "nadar". Nuestra tarea es describir la mecánica para que podamos imaginar su código.


#### Mecánica de muerte
La palabra muerte se refiere a todos los casos en los que un personaje pisa lava o se ahoga en agua. La mecánica debe describir el comportamiento del juego, ¿cómo exactamente se reinicia el personaje después de la muerte? ¿Aparece al principio del nivel? ¿Muere inmediatamente al tocar un tile o tiene algo de tiempo antes de morir? etc...

## Parámetros

>[!NOTE] 
>
>Todos estos son (a menudo) indicadores numéricos, a veces colores y otros atributos de los objetos o su comportamiento, que cambiaremos cientos de veces durante el desarrollo. Esto incluye todos los datos dinámicos, desde la velocidad de movimiento del personaje hasta la suavidad de la transición de la cámara de una pantalla a otra y el tiempo necesario para romper un tile de hielo.
>
>Deben separarse de la sección de mecánicas, porque esto facilitará el diseño de scripts (sabiendo de antemano qué parámetros deben resaltarse en SerializeField). Esto también nos permitirá crear conjuntos de parámetros ya preparados para la prueba (presets) y cambiar rápidamente entre ellos.
>
>El valor de los parámetros no debe escribirse antes del prototipo, ya que es mejor probarlos en la práctica y apuntar aquí.

**DESPUÉS DEL PROTOTIPO!!!**
## Diseño

>[!NOTE] 
>
>Diseño es una sección que describe los detalles de lo que se debe hacer para cada rama del diseño del juego (desde el diseño de niveles hasta la animación y el sonido).
>
>**¿Qué deberíamos escribir exactamente aquí?**
>
>**Antes del prototipo**, vale la pena agregar ideas, conceptos, una descripción básica de qué sonidos, animaciones y efectos queremos tener en la forma final. Esquemas y bocetos de niveles, una propuesta de mapa mundial. Primeros borradores del guión del juego, referencias de animación (de recursos ya preparados, otros juegos, etc.).
>
>**Después del prototipo,** debemos agregar aquí información relevante sobre el diseño. 
>Los mapas finales de cada nivel en formato digital, para sonidos y animaciones hacer una breve descripción de los archivos en el proyecto Unity (lo más conveniente es en forma de una[ tabla](https://raw.githubusercontent.com/Proyectos1-FDI-UCM/c2324-Grupo05/main/docs/Media/table_example.png)), donde frente al nombre del fichero se describirá en qué lugar lo utilizamos cual sonido o animación, de modo que en caso de circunstancias imprevistas, si el repositorio del proyecto se dañara de alguna manera o se produjera un error crítico que mezclara o eliminara los archivos que necesitábamos, pudiéramos restaurar todo rápida y fácilmente usando el GDD.

### Historia:


### Art:


### Animaciones:


### Sonido:
  
  

### Música:

  

### VFX:
  
  

### Niveles:

  

### NPCs:

  

## Progresión

>[!NOTE] 
>Una sección muy pequeña que indica la secuencia de apertura de niveles, desbloqueo de nuevas mecánicas y eventos de la historia.
  
## Interfaz

>[!NOTE] 
>
>Hacemos al final. Una buena interfaz está hecha para el juego, no el juego para la interfaz.
>En la última etapa de desarrollo, ya tendremos una idea y realización clara de qué mecánicas y sistemas usamos y qué debería ver el jugador.
>Rehacer una interfaz es difícil y doloroso, por lo que durante casi todo el proceso de desarrollo intentamos limitarnos y usar `(if debug)` o a una interfaz temporal esquemática, cuya creación no requiere mucho tiempo.



# Workflow

## SCRUM 

Para organizar el proceso de trabajo utilizamos técnicas básicas de la metodología Scrum.
Intentamos minimizar el número de herramientas para no perder mucho tiempo en cosas cotidianas.

### Herramientas:

- Para desarrollar el proyecto utilizamos [Unity 2022.3.5f1](https://unity.com/)
- Para el control de versiones utilizamos [Git](https://git-scm.com/) y [Github](https://github.com/).
- Para mantener la documentación utilizamos [Obsidian](https://obsidian.md/)
- Para la comunicación utilizamos [Whataspp](https://www.whatsapp.com/?l=es) y [Discord](https://discord.com/)

### Artefactos

- [Product Backlog](https://github.com/orgs/Proyectos1-FDI-UCM/projects/35/views/1?layout=table)
- [Task Board](https://github.com/orgs/Proyectos1-FDI-UCM/projects/35/views/3)

### Proceso de trabajo

Los fines de semana hacemos una reunión general, con la planificación para el próximo sprint y una retrospectiva del sprint anterior. Primero, analizamos [Product Backlog](https://github.com/orgs/Proyectos1-FDI-UCM/projects/35/views/1?layout=table) y lo ajustamos según si debemos eliminar algunas funciones, cambiar la prioridad de su implementación o agregar algo nuevo a partir de ideas que nacieron durante la semana pasada.
Después de editar [Product Backlog](https://github.com/orgs/Proyectos1-FDI-UCM/projects/35/views/1?layout=table), creamos un trabajo pendiente de sprint para la próxima semana. Para ello, tomamos historias de usuarios y las distribuimos entre tres equipos.

Durante la semana tenemos 2 días en los que podemos discutir libremente el proceso de desarrollo, proponer nuevas ideas y utilizar programación extrema.
Los miércoles y viernes.
 
### Bucle 

1. Hacemos una reunión general, editamos [Product Backlog](https://github.com/orgs/Proyectos1-FDI-UCM/projects/29/views/1). (fin de semana)
2. Tomamos historias de usuarios del [Product Backlog](https://github.com/orgs/Proyectos1-FDI-UCM/projects/29/views/1)  y las distribuimos entre los equipos.
3. Cada equipo divide la historia del usuario en pequeñas tareas, según se sienta cómodo presentándolas. Estas pequeñas tareas se colocan en [Task Board](https://github.com/orgs/Proyectos1-FDI-UCM/projects/29/views/2)
4. Cada equipo trabaja por separado en su propia tarea durante toda la semana.
5. El miércoles y viernes en clase nos reunimos para discutir nuevas ideas y propuestas, que anotamos en Draft
6. También consideramos aquellos casos que requieren la interacción de componentes escritos por diferentes equipos. Juntos probamos las funciones que ya se han implementado
7. Repetimos

## Unity scripting

### Consejos para Unity Scripting.

- Al nombrar componentes, evitad las palabras Manager, Controller, System. Desdibujan enormemente la idea de las responsabilidades y tareas que debe realizar un componente. Intentad darle al componente un nombre de antemano que declare claramente su territorio en el desempeño de sus funciones.

- Utilizar los principios básicos de [SOLID](https://medium.com/@alejandrodiazjllo/s-o-l-i-d-principles-for-unity-a1556ee99e7c) y [Programación Orientada a Objetos](https://medium.com/@ssmore101/object-oriented-programming-oop-in-unity-game-development-452486d1e4c5#:~:text=Importance%20of%20OOP%20in%20Unity,create%20complex%20systems%20with%20ease.). Si os encontráis utilizando las mismas soluciones una y otra vez para implementar cosas, considerad utilizar la [herencia](https://www.w3schools.com/cs/cs_inheritance.php). Al diseñar componentes, pensad con anticipación qué parte de su lógica se puede reutilizar en el futuro y tratad de mantenerla separada.

- Observar la denominación de variables según [convención.](https://unity.com/how-to/naming-and-code-style-tips-c-scripting-unity)

- Escribir comentarios en inglés. Si dejas un comentario sobre una línea, hazlo en la misma línea de código. Si desea comentar un bloque, separe el código con una línea vacía y escriba el comentario en una línea separada encima (sin espacio).

- Tratad de no usar regiones (si es necesario usarlas, entonces el script es grande y vale la pena refactorizarlo, dividiendo sus responsabilidades  en varios componentes más legibles).

- Si su función pública toma una gran cantidad de parámetros y tiene una lógica compleja, vale la pena escribir [summaries](https://stackoverflow.com/questions/6522889/how-to-create-summary).

## Git

### Consejos para hacer commits

- Al crear un commit nuevo, intentad escribir un nombre corto usando las palabras: `Add, Fix, Remove, Change, Update` etc...
- Si cambia algo en la documentación, al comienzo del commit escribid `[Docs]`
- Usar doble parámetro `git commit -m "<Descripción corto> -m "<Descripción completo>"` para escribir detalles de cambios (si es necesario).
- Aseguraos siempre de que la versión con la que está trabajando esté actualizada. Especialmente si la rama principal se ha revertido recientemente y se han deshecho algunas commits en el repositorio remoto.
