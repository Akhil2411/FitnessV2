import { NgModule } from "@angular/core";
import { SharedModule } from "src/app/shared/shared.module";
import { HomeComponent } from "./home/home.component";
import { LoginComponent } from './auth/components/login/login.component';
import { CommonRoutingModule } from "./common-routing.module";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

@NgModule({
  declarations:[
    HomeComponent,
    LoginComponent
  ],
  imports:[
    SharedModule,
    CommonModule,
    FormsModule,
    CommonRoutingModule,
    ReactiveFormsModule
  ],
  exports:[
    HomeComponent
  ]
})
export class CommonComponentsModule{}