A continuación se detalla la forma de compilar la solución

1.- Descargue la solución <br/>
2.- Dentro de la carpeta "\DISC_PruebaTecnica\DISC_PruebaTecnica\Documentacion" encontrará el archivo "BD.sql", el cual contiene el esquema de la BD y algunos datos de prueba para comenzar las pruebas<br/>
3.- Abra SQL Server, copie y pegue el archivo al que se hace referencia previamente y ejecute<br/>
4.- Una vez creada la BD, ya procedemos a ejecutar el Archivo "DISC_PruebaTecnica.sln" para que sea abierto directamente en su visual Studio (Se sugiere tener la versión .Net 7 y Visual Studio 2022)<br/>
5.- Al abrirse el archivo sólo es ejecutar la solución con F5 o en el botón de compilación.<br/>
6.- Para poder realizar las pruebas Directamente en Postman se agregaron 2 archivos más en "\DISC_PruebaTecnica\DISC_PruebaTecnica\Documentacion", los cuáles son "PruebaTecnica.postman_environment.json" y "DISC_PruebaTecnica.postman_collection.json", los cuales contienen las pruebas y de consumo desde Postman<br/>
7.- Las credenciales para el consumo del EP "Login" se encuentran encriptadas en AES para que pueda realizarse su posterior Desencriptación<br/>
8.- Abra su Postman, Importe los archivos comentados del punto 6 y para poder usar el "Enviroment" debe seleccionarlo en la parte superior derecha de su "Collection"<br/>
9.- Una vez abierto y enlazado, cada que haga un inicio de sesión, en Postman se guardará automáticamente en la llave "Token" el último token generado (Ya sea de administrador o usuario)<br/>
10.- Puede cambiar de token cada vez que sea requerido para poder realizar las pruebas de los mensajes de validaciones<br/>
10.1.- Como evidencia de los mensajes de validaciones se agregaron los archivos "Evidencias_Postman.docx" y "Evidencias_BD.docx" en la carpeta "\DISC_PruebaTecnica\DISC_PruebaTecnica\Documentacion", los cuales tienen evidencias de las validaciones<br/>
10.2.- Algunas de las respuestas que se dan al cliente son 200, 401, 402, 409 con sus respectivos mensajes de error según sea el caso<br/>
11.- Parte de las tecnologías usadas son .Net 7, Entity Framework, AutoMapper, FluentValidator<br/>
