import { AbstractControl, ValidatorFn } from "@angular/forms";

export function notEmpty(): ValidatorFn {
    return (control: AbstractControl) => {
        const value = <string>control.value;

        if (!value) return;
        if ((value || '').trim().length === 0) {
            return {
                notEmpty :{
                    message: 'Nu se accepta campul gol !'
                }
            }
        }
        return;
    }
}