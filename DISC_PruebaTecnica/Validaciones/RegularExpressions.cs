﻿namespace DISC_PruebaTecnica.Validaciones
{
    public class RegularExpressions
    {
        public const string nombreUsuarioValidation = "^[\\w\\-_ ]{2,50}$";
        public const string contraseniaValidation = "^[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}((([a-zñ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[A-ZÑ]+)|([A-ZÑ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[a-zñ]+))[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}\\d+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[@#$%^\\&\\+=]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,})|((([a-zñ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[A-ZÑ]+)|([A-ZÑ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[a-zñ]+))[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[@#$%^\\&\\+=]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}\\d+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,})|((([a-zñ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[@#$%^\\&\\+=]+)|([@#$%^\\&\\+=]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[a-zñ]+))[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[A-ZÑ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}\\d+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,})|((([a-zñ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}\\d+)|(\\d+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[a-zñ]+))[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[A-ZÑ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[@#$%^\\&\\+=]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,})|((([@#$%^\\&\\+=]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[a-zñ]+)|([a-zñ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[@#$%^\\&\\+=]+))[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}\\d+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[A-ZÑ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,})|((([A-ZÑ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[@#$%^\\&\\+=]+)|([@#$%^\\&\\+=]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[A-ZÑ]+))[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}\\d+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[a-zñ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,})|(((\\d+[a-zñ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[@#$%^\\&\\+=])|([a-zñ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}\\d+))[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[@#$%^\\&\\+=]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[A-ZÑ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,})|((([A-ZÑ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}\\d+)|(\\d+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[A-ZÑ]+))[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[@#$%^\\&\\+=]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[a-zñ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,})|((([A-ZÑ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}\\d+)|(\\d+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[A-ZÑ]+))[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[a-zñ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[@#$%^\\&\\+=]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,})|((([A-ZÑ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[@#$%^\\&\\+=]+)|([@#$%^\\&\\+=]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[A-ZÑ]+))[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[a-zñ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}\\d+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,})|((([@#$%^\\&\\+=]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}\\d+)|(\\d+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[@#$%^\\&\\+=]+))[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[a-zñ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[A-ZÑ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,})|((([@#$%^\\&\\+=]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}\\d+)|(\\d+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[@#$%^\\&\\+=]+))[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[A-ZÑ]+[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}[a-zñ]+)[@#$%^\\&\\+=\\dA-ZÑa-zñ]{0,}$";
        public const string longitudContraseniaValidation = "^.{8,250}$";
        public const string mailValidation = "^[\\w_\\.\\-]{1,150}@[\\w_\\-]{1,100}(\\.[\\w_\\-]{1,100}){1,10}$";
    }
}