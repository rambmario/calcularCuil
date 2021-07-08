
function get_cuil_cuit(document_number, gender) {
    /**
     * Cuil format is: AB - document_number - C
     * Author: Mario Ramb
     *
     * @param {str} document_number -> string solo digitos
     * @param {str} gender -> debe contener M (masculino) F (femenino) S (sociedad)
     *
     * @return {str}
     **/

    var AB, C;

    /**
     * Verifico que el document_number tenga exactamente ocho numeros y que
     * la cadena no contenga letras, tengo en cuenta document_number con 6 y 7 digitos.
     */
    if(!isNaN(document_number)){
        switch (document_number.length) {
            case 7:
                document_number = '0'.concat(document_number);
                break;
            case 6:
                document_number = '00'.concat(document_number);
                break;  
            default:
                break;        
        }        
    }

    /**
     * De esta manera permitimos que el gender venga en minusculas y 
     * mayusculas.
     */
    gender = gender.toUpperCase();

    // Defino el valor del prefijo.
    if (gender == "M") {
        AB = '20';
    } else if(gender == "F") {
        AB = '27';
    } else {
        AB = '30';
    }

    /*
     * Los numeros (excepto los dos primeros) que le tengo que
     * multiplicar a la cadena formada por el prefijo y por el
     * numero de document_number los tengo almacenados en un array.
     */
    var multiplicadores = [3, 2, 7, 6, 5, 4, 3, 2];

    // Realizo las dos primeras multiplicaciones por separado.
    var calculo = ((parseInt(AB.charAt(0)) * 5) + (parseInt(AB.charAt(1)) * 4));

    /*
     * Recorro el arreglo y el numero de document_number para
     * realizar las multiplicaciones.
     */
    for (var i = 0; i < 8; i++) {
        calculo += (parseInt(document_number.charAt(i)) * multiplicadores[i]);
    }

    // Calculo el resto.
    var resto = (parseInt(calculo)) % 11;

    /*
     * Llevo a cabo la evaluacion de las tres condiciones para
     * determinar el valor de C y conocer el valor definitivo de
     * AB.
     */

    if(resto == 1) {
        if(gender == "M") {
            C = '9';
        } else {
            C = '4';
        }
        AB = '23';
    } else if (resto ===0) {
        C = '0';
    } else {
        C = 11 - resto;
    }

    // Show example
    console.log([AB, document_number, C].join('-'));

    // Generate cuit
    var cuil_cuit = [AB, document_number, C].join('');

    return cuil_cuit;
}