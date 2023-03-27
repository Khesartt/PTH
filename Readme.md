<h1 align="center"><b>Documentacion rapida para la Api</b></h1>
<p align="center"> Esta es un api pensada para poder gestionar el ingreso de usuarios y gestion y radicacion de hoteles y reservas de los mismo, de igual forma es una version estandar y basica de lo que un sistema robusto deberia de realizar.</p>
<p align="center">Su implementacion esta pensada para ser escalable y ser de facil modificacion ya que esta diseñada bajo el estandar de la arquitectura hexagonal, cuyo principal objetivo es ser un patron de diseño orientado al dominio y a la facil adaptacion.</p>



## Tabla de contenido:
---
1. [Prerrequisitos](#prerrequisitos)
1. [Visualizacion Preliminar](#Visualizacion-Preliminar)
1. [Guia de despliegue](#guia-de-despliegue)
    1. [Funcionamiento servico Parametric](#Funcionamente-servicio-Parametric)    
    1. [Insercion de nuevos Hoteles,Reservas,etc](#Insercion-de-nuevos-Hoteles,Reservas,etc)
1. [Autor/es](#autores)

## Prerrequisitos
---

- Clonar el repositorio desde github con el siguiente comando:
~~~<git>
git clone https://github.com/Khesartt/PTH.git"
~~~
- instalar los paquetes y dependencias necesarias para correr el paquete, existen problemas al
trabajar con version muy reciente de entityFrameWork por lo que es recomendable trabajar bajo la version 5.0.6:

## Visualizacion Preliminar
---
El api esta pensado para su ejecucion con swagger que permitira su consumo directamente y una mejor visaulizacion de cada proceso, las url de consumo dependeran del ambiente en el que se ejecute el api, en este caso existe una url desplegada en azure a la cual pueden acceder y la cual consume una base de datos en azure igual

- https://pthsmarttalent.azurewebsites.net/swagger/index.html

de igual forma si se ejecuta el proyecto de manera local la url deberia ser algo parecido a esto (puede variar dependiendo del ambiete)

- https://localhost:44307/swagger/index.html


## Guía de despliegue
---
dentro de la solucion se encuentran 4 proyecto cada proyecto representa una capa del mismo, dentro de la capa <b>PTH.infraestructure.EF</b> se deberan ajustar las librerias de entityFrameWork correspondientes en caso de ser necesario siendo las utilizadas:

- Microsoft.EntityFrameWorkCore (V5.0.6)
- Microsoft.EntityFrameWorkCore.Desing (V5.0.6)
- Microsoft.EntityFrameWorkCore.SqlServer (V5.0.6)
- Microsoft.EntityFrameWorkCore.Tools (V5.0.6)
- Microsoft.Extensions.Configuration (V7.0.0)
- Microsoft.Extensions.Configuration.Json (V7.0.0)

para la conexion a la base de datos existen dos archivos de nombre <b>appsettings.json</b> que deben ser modificados, actualmente se encuentran aputando a una base de datos alojada por azure devops, pero si se desea trabajar con una base de datos local solo deberan cambiar la cadena de conexion por la linea comentada dentro del mismo archivo, esto se debe hacer en los dos archivos, sus ubicaciones son:

- PTH.infraestructure.EF/appsettings.json
- PTH.infraestructure.api/appsettings.json

para crear las tablas, relaciones y parametrizar los datos iniciales (ciudades, roles, servicios, etc) el proyecto ya cuenta con la estructura para esto y al trabajar con entityFrameWork es posible realizar este proceso sin mucho problema, no es necesario tener la base de datos creada tampoco.

- ajustar la cadena de conexion correspondiente a la situacion
- abrir la consola de 'administrador de paquetes'
- ejecutar el comando <b>update-database</b>

con esto el proyecto mapeara y creara la base de datos en base al archivo de migracion inicial alojado dentro del mismo proyecto <b>PTH.infraestructure.EF</b>, y de igual forma si es necesario cambiar alguna configuracion o parametria, es aconsejable revisar dicho archivo.


Como se trata de un proyecto base dentro de los servicios de usuario y reservar existen los metodos que realizan la notificacion por correo y que actualmente contienen las credenciales quemadas, al tratarse de un correo generico y sin riesgo de perdida de informacion no existe ningun incoveniente en tratar las credenciales de esta forma, sin embargo si se desea ajustar en la base de datos existe la tabla <b>Parametric</b> a la cual se le pueden insertar dichos datos cifrados para luego ser obtenidos y consumidos por los servicios respectivos.

## Funcionamente servicio Parametric
---
este servicio busca parametrizar cualquier informacion que pueda ser usado por un futuro aplicativo front o de cara al cliente, el cual puede consumir para obtener por ejemplo:

- ciudades
- tipos de documento
- tipos de habitacion
- servicios
- generos
- roles

## Insercion de nuevos Hoteles,Reservas,etc
---
Cuando se crea un hotel o una habitacion esta debera tener una definicion por ejemplo para el tipo de habitacion o el tipo de servicios que tiene un hotel, para estos casos por ejemplo se recomienda echar un vistado a los datos ya parametrizados dentro de la base de datos y asignar el que mejor convenga a la situacion correspondiente.

Ejemplo:

quiero agregar un Hotel swagger te pedira un modelo parecido a esto en formato json
~~~<json>
{
  "name": "hotelCesar",
  "idUser": 1,
  "description": "hotel de prueba",
  "image": "una imagen en base64",
  "idCity": 1,
  "address": "direccion",
  "services": "1,2,3",
  "checkIn": "12:30:00",
  "checkOut": "16:30:00"
}
~~~
como notaras este te pedira un tipo de usuario y un tipo de ciudad, estos son faciles de conocer al consultar cualquier endpoint del servicio de parametric o en el caso del usuario al obtener todos los usuario que existen actualmente en la base de datos.


tenemos un caso especial para el campo de servicios que puede llegar a tener un hotel, en este caso colocamos los id's de varios servicios separados por coma para poder registrarlos al hotel en este ejemplo si consultaramos los servicios:


- https://pthsmarttalent.azurewebsites.net/api/Parametric/getServices

~~~<json>
{
      "id": 1,
      "name": "Servicio de habitaciones",
      "description": "Servicio para solicitar comida y bebidas en la habitación",
      "icon": "<svg>...</svg>"
    },
    {
      "id": 2,
      "name": "Spa",
      "description": "Servicio de masajes y tratamientos de belleza",
      "icon": "<svg>...</svg>"
    },
    {
      "id": 3,
      "name": "Gimnasio",
      "description": "Área para hacer ejercicio",
      "icon": "<svg>...</svg>"
    }

}
~~~
observamos entonces que el hotel en mencion cuenta con servicio a la habitacion, Spa y Gimnasio.


## Autor/es
---
- **Cesar Luis Reyes Lopez** - *Desarrollador* - cesarlu-12@hotmail.com

