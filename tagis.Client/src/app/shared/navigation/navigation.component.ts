import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../../user/auth.service';

@Component({
  selector: 'navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent {
  authService;

  constructor(private _authService: AuthService) {
    this.authService = _authService;
  }
}
