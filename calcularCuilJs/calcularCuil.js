
function get_cuil_cuit(document_number, gender) {
    /**
     * Cuil-Cuit format has 11 digits: AB - document_number - C
     * Author: Mario Antonio Ramb
     *
     * @param {str} document_number -> string has only numbers
     * @param {str} gender -> char has 3 options: M (masculino) F (femenino) S (sociedad)
     *
     * @return {str}
     **/

    var AB, C;

    // Checks document_number has only numbers and length must be 8 digits.
    if(!isNaN(document_number)){
        switch (document_number.length) {
            case 8:
                //8 digits is OK
                break;
            case 7:
                document_number = '0'.concat(document_number);
                break;
            case 6:
                document_number = '00'.concat(document_number);
                break;  
            default:
                console.log("El número de DNI debe contener como mínimo 6 dígitos");
                break;        
        }        
    } else {
        console.log("El número de DNI debe contener solo dígitos");
        return null;
    }


     // Converts gender char to upper case and calculates AB.
    gender = gender.toUpperCase();

    if (gender == "M") {
        AB = '20';
    } else if(gender == "F") {
        AB = '27';
    } else {
        AB = '30';
    }

    // Fills an array with multipliers digits.
    var multiplicadores = [3, 2, 7, 6, 5, 4, 3, 2];

    // Does calculations for 2 first digits (AB).
    var calculo = ((parseInt(AB.charAt(0)) * 5) + (parseInt(AB.charAt(1)) * 4));

    // Loops through the array and do the calculations.
    for (var i = 0; i < 8; i++) {
        calculo += (parseInt(document_number.charAt(i)) * multiplicadores[i]);
    }

    // Gets MOD and evaluates to get C value.
    var resto = (parseInt(calculo)) % 11;

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

    // Shows example
    console.log([AB, document_number, C].join('-'));

    // Generates Cuil - Cuit
    var cuil_cuit = [AB, document_number, C].join('');

    return cuil_cuit;
}