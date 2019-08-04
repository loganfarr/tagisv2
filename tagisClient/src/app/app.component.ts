import { Component } from '@angular/core';

@Component({
  selector: 'tagis',
  template: `
    <navigation></navigation>
    <div class="container">
      <router-outlet></router-outlet>
    </div>
    <simple-notifications [options]="notificationOptions"></simple-notifications>
  `,
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  notificationOptions = {
    timeOut: 4000,
    pauseOnHover: true
  };
}
