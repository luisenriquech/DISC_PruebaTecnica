namespace DISC_PruebaTecnica.Validaciones.Mensajes
{
    public class Utils
    {

        public static string MensajesValidacion(string campo, int opcion)
        {
            return opcion switch
            {
                1 => ("El campo " + campo + " no puede ser nulo. "),
                2 => ("El campo " + campo + " no puede ser vacío. "),
                3 => ("El campo " + campo + " está mal formado. "),
                4 => ("El campo " + campo + " no puede ser menor a 0. "),
                5 => ("El campo " + campo + " no puede ser menor a 1. "),
                6 => ("El campo " + campo + " no puede ser menor a "),
                7 => ("El campo " + campo + " no puede ser mayor a "),
                8 => ("El campo " + campo + " debe ser mayor a 0. "),
                9 => ("El campo " + campo + " debe ser 0. "),
                _ => "Error en el campo " + campo
            };
        }

        public static string Sugerencia(int opcion)
        {
            return opcion switch
            {
                0 => ("Debe ser un número positivo entero mayor a o igual 0. "),
                1 => ("Debe ser un número positivo decimal o entero mayor a 0. "),
                2 => ("Debe ser una fecha válida. "),
                3 => ("Debe ser un número entero positivo mayor a 0. "),
                4 => ("Debe ser un correo electrónico válido. "),
                7 => ("Debe ser un texto con por lo menos una mayúscula, una minúscula, un número y un caracter especial ( @#$%^&+= ) con una longitud mínima de 8 y máxima de 250 caracteres. "),
                _ => "",
            };
        }

        public static string MensajesGenerales(int opcion)
        {
            return opcion switch
            {
                1 => ("Excepción no controlada. "),
                2 => ("Error en validaciones de campos. "),
                3 => ("No se pudo iniciar sesión, verifique sus credenciales. "),
                4 => ("Registro no insertado, el mail o el usuario es duplicado. "),
                5 => ("Registro insertado correctamente. "),
                6 => ("Debe ser un texto con letras mayúsculas, minúsculas, números y _-, de 2 a 50 caracteres de longitud. "),
                7 => ("Debe ser un texto con por lo menos una mayúscula, una minúscula, un número y un caracter especial ( @#$%^&+= ) con una longitud mínima de 8 y máxima de 250 caracteres. "),
                8 => ("El Id Rol no está dentro del catálogo. "),
                9 => ("El Id Puesto no está dentro del catálogo. "),
                10 => ("Sin registros para mostrar. "),
                11 => ("Registro eliminado con éxito. "),
                12 => ("El registro ya había sido eliminado previamente. "),
                13 => ("Registro actualizado correctamente. "),
                14 => ("El usuario a editar no exite. "),
                15 => ("Registro no actualizado, el mail o el usuario es duplicado. "),
                _ => "",
            };

        }
    }
}