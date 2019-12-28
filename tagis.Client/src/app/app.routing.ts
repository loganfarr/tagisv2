import { Router, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthGuard } from './user/auth-guards/auth-guard.service';

export const routing = RouterModule.forRoot([
  { path: '', component: DashboardComponent, canActivate: [AuthGuard]},
  { path: '**', redirectTo: '/' }
]);
