- [[#Género|Género]]
- [[#Sinopsis:|Sinopsis:]]
- [[#Controles|Controles]]
- [[#Estilo|Estilo]]
- [[#Dinámicas:|Dinámicas:]]
- [[#Sistemas y Mecánicas:|Sistemas y Mecánicas:]]
	- [[#Sistemas y Mecánicas:#Sistemas|Sistemas]]
		- [[#Sistemas#Sistema de acompañante|Sistema de acompañante]]
		- [[#Sistemas#Sistema de movimiento|Sistema de movimiento]]
		- [[#Sistemas#Sistema de la cámara|Sistema de la cámara]]
		- [[#Sistemas#Sistema de interacciones|Sistema de interacciones]]
		- [[#Sistemas#Sistema de niveles|Sistema de niveles]]
	- [[#Sistemas y Mecánicas:#Mecánicas|Mecánicas]]
		- [[#Mecánicas#Mecánica de muerte|Mecánica de muerte]]
- [[#Parámetros:|Parámetros:]]
- [[#Diseño:|Diseño:]]
	- [[#Diseño:#Historia:|Historia:]]
	- [[#Diseño:#Art:|Art:]]
	- [[#Diseño:#Animaciones:|Animaciones:]]
	- [[#Diseño:#Sonido:|Sonido:]]
	- [[#Diseño:#Música:|Música:]]
	- [[#Diseño:#VFX:|VFX:]]
	- [[#Diseño:#Niveles:|Niveles:]]
	- [[#Diseño:#NPCs:|NPCs:]]
- [[#Progresión:|Progresión:]]
- [[#Interfaz:|Interfaz:]]

## Género

Action-adventure, Puzzle
**Referencias:** Undertale, OneShot, Deltarune.

## Sinopsis: 

>[!info]- ¿Qué es?
>Este parte de GDD proporciona una visión general concisa del entorno, permitiendo a cualquier lector comprender qué imaginar mientras se mencionan términos específicos en el texto. Por ejemplo, si especificamos que el entorno del juego es un mundo de fantasía medieval, el lector entenderá que cuando se mencione "armas", se refiere a espadas o ballestas, y no a armas láser futuristas.

El escenario del juego EG6 es un mundo sombrío de un vertedero en una isla ártica, lleno de contaminación y restos de tecnología. El jugador y su compañero, un pingüino robótico, exploran este paisaje devastado, recolectando piezas y resolviendo puzzles para encontrar una ruta hacia la salvación. El tiempo en esta isla parece detenido, y la naturaleza ha desaparecido casi por completo debido al terrible impacto de la contaminación.


## Controles

>[!info]- ¿Para qué?
>En secciones posteriores del documento, para asociar una acción específica con un botón, debe especificar el nombre de ese botón entre corchetes triangulares.
> Ejemplo: *Para adjuntar una nueva pieza al pingüino, el jugador debe hacer clic en `<Interactuar>` en su habitación, al lado del huevo*.
> 
> Si necesitamos cambiar un botón que será responsable de alguna acción, bastará con cambiarlo en la tabla y no tocar todos los demás lugares en los que se menciona.

### Teclado
| Botón   | Nombre                                |
| ------- | ------------------------------------- |
| W       | arriba                                |
| A       | izquierda                             |
| S       | abajo                                 |
| D       | derecha                               |
| E/Space | interactuar                           |
| i       | inventario                            |
| Esc     | ajustes                               |
| Q       | cambiar control de jugador a pingüino |

### Gamepad
| Botón                       | Nombre                                |
| --------------------------- | ------------------------------------- |
| D-pad Up / L-stick Up       | arriba                                |
| D-pad Left / L-stick Left   | izquierda                             |
| D-pad Down / L-stick Down   | abajo                                 |
| D-pad Right / L-stick Right | derecha                               |
| Button South                | interactuar                           |
| Select                      | inventario                            |
| Start                       | ajustes                               |
| Button North                | cambiar control de jugador a pingüino |

## Estilo

>[!info]- ¿Qué es?
>El estilo se entiende en el sentido más amplio. Aquí podemos agregar cualquier arte conceptual y referencias. Escriba los detalles de cómo debería sentirse el juego, qué emociones debería evocar en el jugador.
>
   Desde el punto de vista del juego, en esta sección debes describir cómo funciona el juego sin tocar detalles. Por ejemplo, cómo está estructurado el mundo del juego, si está dividido en niveles o es un "mundo abierto", como se produce el movimiento entre ubicaciones. ¿El personaje sólo puede caminar? ¿O volar? ¿O conducir un vehículo? ¿Podrá recoger algo en su inventario? ¿Mover cosas? ¿Luchar? ¿Usar magia?, etc...
   Esta sección es como un avance (trailer) del juego en forma de texto, donde describimos las capacidades del jugador. Después de leer toda la sección, el lector deberá entender de qué se tratará el juego, pero sin entrar en detalles.

El juego está realizado en pixel art 2D, con una posición de la cámara Top-Down.
El mundo del juego está dividido en niveles, cada nivel tiene un conjunto específico de pantallas, cada pantalla está hecha de tiles.
Hay un "hub" en forma de habitación de un personaje, al que llega después de completar un nivel para prepararse para el siguiente.
El personaje puede recolectar elementos y ponerlos en el inventario. Así, además de piezas para el robot pingüino, puede poner consumibles en su inventario y utilizarlos a medida que avanza de nivel.

El juego debe sentirse principalmente como un puzzle, el entorno debe motivar al jugador a abandonar la isla y debe causar rechazo por la apariencia de un entorno lleno de basura. Al mismo tiempo, la apariencia de la habitación del personaje debería motivarlo a regresar allí, crear una sensación de seguridad (como bonefire en la serie de juegos Dark Souls o el ascensor al final del nivel en la serie Portal).

Durante el paso de niveles, el personaje principal puede interactuar con los objetos, pero tendrá desventajas en forma de restricciones de movimiento. El puede romper algunos tiles que le impide pasar, pero esto no se aplicable a todos los obstáculos.
El pingüino, por el contrario, tiene menos opciones para interactuar con el entorno, pero más opciones de movimiento (puede nadar donde el jugador no puede, iluminar el camino en un lugar oscuro, etc.)

La tarea del jugador es resolver tareas cambiando entre personajes y usando su conjunto único de habilidades (casi como los niveles de [It Takes Two](https://www.youtube.com/watch?v=GAWHzGNcTEw&ab_channel=ElectronicArts), pero bajo el control de un jugador).

## Dinámicas

>[!info]- ¿Qué es?
> Dentro del **MDA framework**, "dinámica" se refiere a la forma en que los jugadores interactúan con las mecánicas del juego mientras juegan. La dinámica se define como cómo las mecánicas del juego conducen a cambios y evolución de la experiencia del juego a lo largo del tiempo. En otras palabras, la dinámica es el resultado de la interacción del jugador con las mecánicas y los cambios posteriores en el juego.
> 
> En el contexto del **MDA framework**, podemos decir que la dinámica es un nivel más alto de abstracción en comparación con la mecánica. La mecánica determina qué acciones están disponibles para el jugador y la dinámica describe cómo estas acciones afectan el curso del juego, qué consecuencias tienen, cómo se desarrolla la experiencia del juego y qué reacciones emocionales se evocan en el jugador.
> 
> Así, podemos decir que la dinámica no es simplemente un sistema de mecánicas, sino el resultado de su interacción durante el transcurso del juego.

El jugador sale de la habitación del personaje en busca de una pieza para mejorar el robot pingüino, pasa por niveles cada vez más difíciles utilizando nuevas mecánicas, regresa a la habitación para mejorar a su compañero para poder superar obstáculos más difíciles y escapar de la isla.

Si el jugador completa la actividad opcional de recolectar y reciclar basura, que no impide su progreso, recibirá un final más positivo o un secreto escondido al final.

## Sistemas y Mecánicas

>[!info]- ¿Qué es?
> En esta sección debemos escribir todo lo relacionado con la lógica del juego. No hace falta profundizar en los parámetros de cuánto dura en segundos o cuánto daño causa. Aquí debemos describir el principio de funcionamiento de TODO lo que sucede dentro del juego.
> 
> En términos de construir la estructura del documento, vale la pena comenzar con los sistemas y luego pasar a las mecánicas.

>[!note]- Consejo
>
>Estoy seguro de que en España, como en muchos otros países, en el colegio/escuela te enseñan a escribir composiciones o ensayos, intentando cometer un mínimo de errores léxicos y estilísticos (por ejemplo, tautologías).
>
>Pero la documentación no es una obra de arte, aquí se fomenta romper las reglas de redacción de composiciones para evitar la grafomanía
>
>**Ejemplo:** 
>*`Cuando un personaje activa la habilidad de "Curación", el personaje recibe el buff de "Curación", que cura al personaje y restaura N unidades de salud.`*
>
>Esto puede sonar terrible desde un punto de vista estilístico, pero para fines de documentación, este es un párrafo muy bueno que se puede traducir fácilmente a [codigo](code_example.png).




### Sistemas

>[!info]- ¿Qué es?
>
>**El sistema** es una regla global que siempre funciona. Por ejemplo, un sistema de movimiento, un sistema para interactuar con objetos (el personaje SIEMPRE debe acercarse al objeto y hacer clic en el botón de interacción), un sistema de selección de nivel (el jugador hace clic en el ícono de nivel, se resalta en color, después de lo cual el botón "Confirmar" vuelve a estar disponible y el jugador se transfiere a una escena con el nivel apropiado), etc.

#### Sistema de acompañante
Incluye la lógica de funciones que están asociadas a la interacción (personaje - acompañante). Habilita la mecánica de movimiento del pingüino cuando no está bajo el control del jugador (y está controlado por IA). Incluye mecánicas para cambiar entre el personaje principal y el pingüino, etc...
Todas estas mecánicas forman un sistema.

#### Sistema de movimiento
El sistema de movimiento se implementa con Rigidbodies cinemáticos.
Para evitar que los personajes atraviesen las paredes, utilizamos RayCast. El componente *`CollisionHandler.cs`* se encarga de detectar obstáculos en el camino de movimiento de los objetos, lo que transmite información a otros métodos del sistema si hay un objeto de la capa “Walls” en nuestro camino.
Todos los objetos que se pueden mover (personajes y bloques) heredan de la clase común en *`MovableObject.cs`* , que implementa la interfaz *`IMovable`*.

Para controlar el personaje usamos la clase heredera en *`PlayerMovement.cs`*, que puede recibir información de "New Input System".

Cuando el personaje recoge toda la basura en un nivel, aumenta la velocidad de movimiento.

**Incluye:**
- [[#Mecánica de caminar]]
- [[#Mecánica de nadar]]


| Class            | ¿Qué hace?                                                                                                                                                                       |
| ---------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| MovableObject    | Contiene lógica de movimiento básica para rigidbodies cinemáticos.                                                                                                               |
| PlayerMovement   | Heredero de MovableObject. Determina la dirección del movimiento usando un Input del jugador.                                                                                    |
| PlayerNewInput   | Una clase que le permite llamar a métodos de otros componentes y pasarles información utilizando "Unity New Input System".                                                       |
| CollisionHandler | Verifica si hay otro objeto en la capa "Paredes" en la ruta del movimiento del MovementObject usando Raycast. Devuelve booleano para utilizarlo en los métodos de MovableObject. |

#### Sistema de la cámara
La lógica de la cámara incluye pantallas divididas, así como posibles funciones de la cámara, como hacer zoom en los personajes para mostrar una escena escrita, funciones para representar lugares oscuros, etc.

#### Sistema de interacciones
Contiene logica que permite al jugador interactuar con tiles. 
Cada mecánica de interación depende del personaje que se esté controlando el jugador.

**Incluye:**
- [[#Mecánica de romper tiles]]
- [[#Mecánica de recoger cosas]]
#### Sistema de niveles


### Mecánicas

>[!info]- ¿Qué es?
> 
> **La mecánica** es una acción separada, una pieza a partir de la cual se forman los sistemas. Por ejemplo, el sistema de movimiento tiene una mecánica "correr" y una mecánica "nadar". Nuestra tarea es describir la mecánica para que podamos imaginar su código.

#### Mecánica de caminar
Cuando el jugador envia Input, el personaje se mueve en 2 ejes, tiene aceleración instantánea sin movimiento diagonal. 

#### Mecánica de nadar
<Descripción de mecánica>

#### Mecánica de romper tiles
El niño puede romper solo tiles de basura
El pingüino puede romper solo tiles de hielo
Ambos tipos de tiles tienen la misma animación al romperse. 
Cuando el tile se rompe, este desaparece.
Para romper un tile, el personaje necesita acercarse a este tile y mirar en su dirección y pulsar botón de `<Interactuar>`. 
Cuando el personaje puede romper un tile, el contorno del bloque aparece marcado con una línea más gruesa.
#### Mecánica de recoger cosas
Solo el niño puede recoger cosas.
Para recoger cosas el necesita entrar en su collider. 
Un objeto desaparece cuando el personaje la recoge.

Para realizar lógica de objetos recogibles, implementamos la interfaz IPickable 
Basura Recogible funciona junto con el contador.

| PickableObject   | Lógica                                                                                                                                                                                          |
| ---------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Pieza            | La ponemos al inventario. Dice a otros componentes, que el jugador puede pasar al siguiente nivel si recogió una pieza en nivel actual. La utilizamos en la habitación para mejorar el pinüino. |
| Basura Recogible | Incrementa el contador de basura en (el sistema de niveles). Necesitamos recoger toda basura en todos los niveles para desbloquear un final alternativo.                                        |


#### Mecánica de pulsar botónes

#### Mecánica de muerte
La palabra muerte se refiere a todos los casos en los que un personaje pisa lava o se ahoga en agua. La mecánica debe describir el comportamiento del juego, ¿cómo exactamente se reinicia el personaje después de la muerte? ¿Aparece al principio del nivel? ¿Muere inmediatamente al tocar un tile o tiene algo de tiempo antes de morir? etc...

## Parámetros

>[!info]- ¿Qué es?
>
>Todos estos son (a menudo) indicadores numéricos, a veces colores y otros atributos de los objetos o su comportamiento, que cambiaremos cientos de veces durante el desarrollo. Esto incluye todos los datos dinámicos, desde la velocidad de movimiento del personaje hasta la suavidad de la transición de la cámara de una pantalla a otra y el tiempo necesario para romper un tile de hielo.
>
>Deben separarse de la sección de mecánicas, porque esto facilitará el diseño de scripts (sabiendo de antemano qué parámetros deben resaltarse en SerializeField). Esto también nos permitirá crear conjuntos de parámetros ya preparados para la prueba (presets) y cambiar rápidamente entre ellos.
>
>El valor de los parámetros no debe escribirse antes del prototipo, ya que es mejor probarlos en la práctica y apuntar aquí.

**DESPUÉS DEL PROTOTIPO!!!**
## Diseño

>[!info]- ¿Qué es?
>
>Diseño es una sección que describe los detalles de lo que se debe hacer para cada rama del diseño del juego (desde el diseño de niveles hasta la animación y el sonido).
>
>**¿Qué deberíamos escribir exactamente aquí?**
>
>**Antes del prototipo**, vale la pena agregar ideas, conceptos, una descripción básica de qué sonidos, animaciones y efectos queremos tener en la forma final. Esquemas y bocetos de niveles, una propuesta de mapa mundial. Primeros borradores del guión del juego, referencias de animación (de recursos ya preparados, otros juegos, etc.).
>
>**Después del prototipo,** debemos agregar aquí información relevante sobre el diseño. 
>Los mapas finales de cada nivel en formato digital, para sonidos y animaciones hacer una breve descripción de los archivos en el proyecto Unity (lo más conveniente es en forma de una[ tabla](table_example.png)), donde frente al nombre del fichero se describirá en qué lugar lo utilizamos cual sonido o animación, de modo que en caso de circunstancias imprevistas, si el repositorio del proyecto se dañara de alguna manera o se produjera un error crítico que mezclara o eliminara los archivos que necesitábamos, pudiéramos restaurar todo rápida y fácilmente usando el GDD.

### Historia:


### Art:


### Animaciones:


### Sonido:
  
  

### Música:

  

### VFX:
  
  

### Niveles:

  

### NPCs:

  

## Progresión

>[!info]- Qué es?
>Una sección muy pequeña que indica la secuencia de apertura de niveles, desbloqueo de nuevas mecánicas y eventos de la historia.
  
## Interfaz

>[!info]- Qué es?
>
>Hacemos al final. Una buena interfaz está hecha para el juego, no el juego para la interfaz.
>En la última etapa de desarrollo, ya tendremos una idea y realización clara de qué mecánicas y sistemas usamos y qué debería ver el jugador.
>Rehacer una interfaz es difícil y doloroso, por lo que durante casi todo el proceso de desarrollo intentamos limitarnos y usar `(if debug)` o a una interfaz temporal esquemática, cuya creación no requiere mucho tiempo.



  
  