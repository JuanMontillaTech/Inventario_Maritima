# Inventario Maritima
Este proyecto de manejo de inventario pequeño.
esta creado en .net core MVC, c#.net , implementa API y utiliza base de datos MSSQL
 

*es importante tener internet ya que utiliza Liberia que están el repositorio CDN 

# Utiliza Librería 

1. vuejs : para hacer la web reactiva (interactiva) 

2. axiosjs: para comunicar con las apis 

3. jquery: solo para base de otras librerías 

4. jquery datatable: para hacer tablas más dinámicas y elegantes 

5. sweetalert 2: para mostrar mensajes más interactivos 

6. toastr: para manejar notificaciones  

# Carpetas: 

*Source:  

Es el código fuente del proyecto 

*publicacion:  

Proyecto listo para colocarlo en un servidor 

*Continuous_Deploy: 

  En esta carpeta se encuentra preparada con un script de nombre PushHeroku para hacer CI/CD a un servidor, es requerido tener instalado git, docker y una cuenta en el servidor de https://www.heroku.com/ es una plataforma cloud como Amazon, Azure o google, pero modo SAAS   

*script PushHeroku :  

Este script crea un documento docker y luego hace un conteniner y lo lleva a servidor de heroku, más detalles en la guía de heroku conteniner, utiliza git para subir el conteniner, el script es automatico pero pedirá información para configurar al deploy automático al servidor 

 *DB 

Contiene el script para crear la base de datos del proyecto 

 