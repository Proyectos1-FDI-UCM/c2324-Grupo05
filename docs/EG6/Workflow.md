
# Esquema de trabajo

- [[#SCRUM|SCRUM]]
	- [[#SCRUM#Herramientas:|Herramientas:]]
	- [[#SCRUM#Artefactos|Artefactos]]
	- [[#SCRUM#Proceso de trabajo|Proceso de trabajo]]
	- [[#SCRUM#Bucle|Bucle]]
- [[#Unity scripting|Unity scripting]]
	- [[#Unity scripting#Consejos para Unity Scripting.|Consejos para Unity Scripting.]]
- [[#Git|Git]]
	- [[#Git#Consejos para hacer commits|Consejos para hacer commits]]

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
5. El miércoles y viernes en clase nos reunimos para discutir nuevas ideas y propuestas, que anotamos en [[Draft]]
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


