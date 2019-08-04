import { FormControl } from '@angular/forms';

export class SharedValidators {
  static validEmail(control: FormControl) {
    //Regex expression for validating the email
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if(!re.test(control.value))
      return { validEmail: true};

    return null;
  }
}