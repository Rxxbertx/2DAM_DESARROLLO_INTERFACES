**Asunto:** Pasos necesarios para la configuración de la aplicación

Hola,

Espero que te encuentres bien. Para garantizar el correcto funcionamiento de nuestra aplicación, es crucial seguir algunos pasos de configuración inicial. A continuación, te detallo el proceso:

1. **Ejecución del archivo SQL:**
   - Asegúrate de tener MySQL instalado en tu sistema.
   - Ejecuta el archivo `dbroberto.sql` en tu servidor MySQL para crear la base de datos necesaria.

2. **Instalación del conector MySQL ODBC:**
   - Descarga e instala el conector MySQL ODBC compatible con tu sistema operativo desde el [sitio oficial de MySQL](https://dev.mysql.com/downloads/connector/odbc/).
   -O bien ejecutar el archivo presente en la carpeta mysql-connector-odbc-8.3.0-winx64.msi

3. **Configuración de la conexión ODBC en Windows (64 bits):**
   - Accede a la herramienta "ODBC Data Source Administrator" en tu sistema (puedes buscarlo en el menú de inicio o ejecutar `odbcad64.exe`).
   - En la pestaña "System DSN", haz clic en "Agregar" y selecciona el controlador "MySQL ODBC ANSI" de la lista.
   - Completa los campos de la ventana de configuración con la siguiente información proveniente del archivo `robertodb.dsn` abrelo con un editor de texto:
      - **Nombre de la conexión:** [DB]
      - **Servidor:** [usa localhost]
      - **Base de datos:** [DATABASE]
      - **Usuario:** [USER]
      - **Contraseña:** [PASSWORD]

4. **Verificación de la configuración:**
   - Después de configurar la conexión ODBC, haz clic en "Aceptar" para guardar los cambios.
   - Puedes verificar la conexión haciendo clic en "Probar conexión" o simplemente cerrando la ventana.

Con estos pasos, deberías tener la configuración necesaria para que la aplicación se ejecute correctamente. Si encuentras algún problema o necesitas ayuda adicional, no dudes en contactarme.

¡Gracias por elegir nuestra aplicación!

Saludos
