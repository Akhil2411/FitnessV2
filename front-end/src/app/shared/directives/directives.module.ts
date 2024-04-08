import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToggleSideBarDirective } from './toggle-sidebar.directive';



@NgModule({
  declarations: [
    ToggleSideBarDirective
  ],
  imports: [
    CommonModule
  ],
  exports:[
    ToggleSideBarDirective
  ]
})
export class DirectivesModule { }
