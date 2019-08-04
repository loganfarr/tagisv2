import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NavigationComponent } from './navigation/navigation.component';
import { SharedValidators } from './shared.validators';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
  ],
  declarations: [NavigationComponent],
  exports: [NavigationComponent]
})
export class SharedModule { }
